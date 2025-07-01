namespace Mechanic.Domain.Common
{
    public class BaseClass
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public long CreatedBy { get; set; }
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public long ModifiedBy { get; set; }
    }
}