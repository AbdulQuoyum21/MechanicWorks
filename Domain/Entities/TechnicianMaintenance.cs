using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mechanic.Domain.Common;

namespace Mechanic.Domain.Entities
{
    public class TechnicianMaintenance:BaseClass
    {
        public long StaffId { get; set; }
        public long MaintenanceRecordId { get; set; }
        public virtual MaintenanceRecord { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
