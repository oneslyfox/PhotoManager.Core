using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.Core.Utilities
{
    public class AssetMetadata
    {
        public AssetType AssetType { get; set; }
        public DateTime CreatedOn { get; set; }
        public byte[] Thumbnail { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Description { get; set; }
        
        public Dictionary<string,object> Properties { get; set; }

        public AssetMetadata() 
        {
            Properties = new Dictionary<string, object>();
        }
    }
}
