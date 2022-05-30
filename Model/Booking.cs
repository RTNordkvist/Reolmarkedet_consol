using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Model
{
    public class Booking: BaseIdentifiableItem
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int BookingNo { get; set; }
        public int TenantId { get; set; }
        public int BoothId { get; set; }
    }
}
