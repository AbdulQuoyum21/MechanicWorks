using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class FileUpload : BaseClass
    {
        public string FileName { get; set; }
        public string RelativeUrl { get; set; }
        public string Extension { get; set; }
        public FileType FileType { get; set; }
        public long Size { get; set; }
        public long AppUserId { get; set; }
    }
}