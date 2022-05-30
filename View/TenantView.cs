using Reolmarkedet.Controller;
using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.View
{
    public class TenantView
    {
        private TenantController _tenantController;

        public TenantView(TenantController tenantController)
        {
            _tenantController = tenantController;
        }

        public Tenant CreateTenantView()
        {
            Tenant tenant = null;
            Console.Clear();
            Console.WriteLine("Opret ny bruger");
            Console.WriteLine();

            Console.WriteLine("Indtast dit fulde navn");
            var name = Console.ReadLine();

            Console.WriteLine("Indtast dit telefonnummer");
            var telephoneNo = Console.ReadLine();

            while (tenant == null)
            {
                Console.WriteLine("Indtast din emailadresse");
                var mail = Console.ReadLine();

                Console.WriteLine("Genindtast din emailadresse");
                var mailConfirmation = Console.ReadLine();

                if (mailConfirmation == mail)
                {
                    tenant = _tenantController.CreateTenant(name, telephoneNo, mail);
                }
                else
                {
                    Console.WriteLine("De indtastede mailadresser er ikke ens.");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Bruger oprettet!");

            return tenant;
        }
    }
}
