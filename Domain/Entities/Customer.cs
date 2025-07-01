using Mechanic.Domain.Common;
using Mechanic.Domain.Enums;

namespace Mechanic.Domain.Entities
{
    public class Customer : BaseClass
    {
        public long ApplicatonUserId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public Gender Gender { get; set; }
    }



}
