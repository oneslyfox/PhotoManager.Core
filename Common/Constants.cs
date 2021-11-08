using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.Core.Common
{
    public class Constants
    {
        public static List<string> ImageTypes = new List<string>() { "jpg", "jpeg", "png", "gif", "tiff", "jpe", "jp2", "webp", "bmp", "djvu", "djv", "dicom", "psd" };
        public static List<string> VideoTypes = new List<string>() { "avi", "mov", "qt", "flv" };
        public static List<string> AudioTypes = new List<string>() { "mp3", "wav" };
    }
}
