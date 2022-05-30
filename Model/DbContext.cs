using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Model
{
    /// <summary>
    /// Created as a SingleTon
    /// Use: DbContext.Instance to access the databases
    /// </summary>
    public sealed class DbContext 
    {
        public Database<Tenant> TenantDb { get; set; }
        public Database<Booth> BoothDb { get; set; }
        public Database<Booking> BookingDb { get; set; }

        private static readonly DbContext _instance = new DbContext();
        static DbContext()
        {
        }

        private DbContext()
        {
            TenantDb = new Database<Tenant>();
            BoothDb = new Database<Booth>();
            BookingDb = new Database<Booking>();
        }

        public static DbContext Instance
        {
            get { return _instance; }
        }
    }

}
