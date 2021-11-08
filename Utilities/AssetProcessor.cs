using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using GroupDocs.Metadata;
using PhotoManager.Core.Common;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace PhotoManager.Core.Utilities
{
    public class AssetProcessor
    {
        private IReadOnlyList<MetadataExtractor.Directory> _metadata;
        private AssetType _type;

        #region Constructors
        public AssetProcessor(Stream stream, AssetType type)
        {
            _metadata = ImageMetadataReader.ReadMetadata(stream);
            _type = type;
        }

        public AssetProcessor(FileStream stream)
        {
            _metadata = ImageMetadataReader.ReadMetadata(stream);
            _type = GetAssetType(stream.Name);
        }

        public AssetProcessor(string filePath) : this(new FileStream(filePath, FileMode.Open))
        {
        }
        #endregion

        public AssetMetadata Process()
        {
            var info = new AssetMetadata();

            foreach (var directory in _metadata)
            {               
                foreach (var tag in directory.Tags)
                {
                    info.Properties.Add(tag.DirectoryName + ":"+ tag.Name, tag.Description);
                }
            }

            return info;
        }

        public static AssetType GetAssetType(string fileName)
        {
            string extension = GetExtension(fileName).ToLower();
            
            AssetType type = AssetType.Other;
            if (Constants.ImageTypes.Contains(extension))
            {
                type = AssetType.Image;
            }
            else if(Constants.VideoTypes.Contains(extension))
            {
                type = AssetType.Video;
            }
            else if (Constants.AudioTypes.Contains(extension))
            {
                type = AssetType.Audio;
            }

            return type;
        }

        private static string GetExtension(string filePath)
        {
            int index = filePath.LastIndexOf('.');
            return index >= 0 ? filePath.Substring(index + 1) : filePath;          
        }

        private static string GetExtension(FileStream stream)
        {
            return Path.GetExtension(stream.Name);
        }
    }
}
