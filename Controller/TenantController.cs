using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Controller
{
    public class TenantController
    {
        private DbContext _dbContext;

        public TenantController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tenant CreateTenant(string name, string telephoneNo, string mail)
        {
            var tenant = new Tenant();
            tenant.Name = name;
            tenant.TelephoneNo = telephoneNo;
            tenant.Mail = mail;

            var id = _dbContext.TenantDb.AddItem(tenant);

            _dbContext.TenantDb.Items.FirstOrDefault(x => x.Id == id).CustomerNo = id + 1000000;

            _dbContext.TenantDb.UpdateDatabase();

            return tenant;
        }
    }
}
