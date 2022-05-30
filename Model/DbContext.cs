using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Model
{
    public class DbContext
    {
        public Database<Tenant> TenantDb { get; set; }
        public Database<Booth> BoothDb { get; set; }
        public Database<Booking> BookingDb { get; set; }

        public DbContext()
        {
            TenantDb = new Database<Tenant>();
            BoothDb = new Database<Booth>();
            BookingDb = new Database<Booking>();
        }
    }
}
