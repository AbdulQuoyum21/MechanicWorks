using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class Staff:BaseClass
    {
        public long ApplicationUserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public StaffExperienceLevel ExperienceLevel { get; set; }
        public StaffType StaffType { get; set; }
        public Gender Gender { get; set; }
    }
    
}
