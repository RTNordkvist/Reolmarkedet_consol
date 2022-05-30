using Reolmarkedet.Controller;
using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.View
{
    public class FlowView
    {
        private DbContext _dbContext;
        private TenantController _tenantController;
        private BookingController _bookingController;
        private BoothController _boothController;
        private string _userinput;
        private Tenant _currentTenant;
        private TenantView _tenantView;
        private BookingView _bookingView;
        private BoothView _boothView;

        public FlowView()
        {
            _dbContext = new DbContext();

            _tenantController = new TenantController(_dbContext);
            _bookingController = new BookingController(_dbContext);
            _boothController = new BoothController(_dbContext);

            _tenantView = new TenantView(_tenantController);
            _bookingView = new BookingView(_bookingController);
            _boothView = new BoothView(_boothController);
        }

        public void RunProgram()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Reolmarkedet");
                Console.WriteLine();
                Console.WriteLine("1. Opret ny bruger");
                Console.WriteLine("2. Tilgå systemet som admin");
                Console.WriteLine("3. Afslut program");

                while (_currentTenant == null)
                {
                    _userinput = Console.ReadLine();

                    switch (_userinput)
                    {
                        case "1":
                            _currentTenant = _tenantView.CreateTenantView();
                            break;

                        case "2":
                            if (Console.ReadLine() == "admin123")
                            {

                            }
                            else
                            {
                                Console.WriteLine("Forkert password");
                            }

                            break;

                        case "3":
                            return;

                        default:
                            Console.WriteLine();
                            Console.WriteLine("Vælg et menupunkt");
                            break;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Velkommen {_currentTenant.Name}");
                Console.WriteLine();
                Console.WriteLine($"Saldo: {_currentTenant.Balance} kr");
                Console.WriteLine();
                Console.WriteLine($"1. Opret ny booking");
                Console.WriteLine($"2. Log ud");
                while (_currentTenant != null)
                {
                    _userinput = Console.ReadLine();

                    switch (_userinput)
                    {
                        case "1":
                            _bookingView.CreateBookingView(_currentTenant.Id);
                            break;

                        case "2":
                            _currentTenant = null;
                            break;

                        default:
                            Console.WriteLine("Vælg et menupunkt");
                            break;
                    }
                }
            }
        }
    }
}
