namespace Mechanic.Domain.Common
{
    public class BaseClass
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long? ModifiedBy { get; set; }
    }



}
