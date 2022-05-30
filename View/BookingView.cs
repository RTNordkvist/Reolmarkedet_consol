using Reolmarkedet.Controller;
using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.View
{
    public class BookingView
    {
        private BookingController _bookingController;

        public BookingView()
        {
            _bookingController = new BookingController();
        }

        public void CreateBookingView(int tenantId)
        {
            Console.WriteLine("Opret ny booking");
            Console.WriteLine();
            Console.WriteLine("Indtast startdato for ønsket periode (DD-MM-YYYY)");

            DateTime startDate;
            while (DateTime.TryParse(Console.ReadLine(), out startDate))
                Console.WriteLine("Indtast dato i formatet DDMMYYYY");

            DateTime endDate;
            Console.WriteLine("Indtast slutdato for ønsket periode (DD-MM-YYYY)");
            while (DateTime.TryParse(Console.ReadLine(), out endDate))
                Console.WriteLine("Indtast dato i formatet DDMMYYYY");

            var availableBooths =_bookingController.GetAvailableBooths(startDate, endDate);

            if (availableBooths != null)
            {
                Console.WriteLine();
                Console.WriteLine("Ledige reoler i den valgte periode:");

                foreach (var booth in availableBooths)
                {
                    Console.WriteLine($"{booth.Name} ({booth.Type}): {booth.Price} kr.");
                }
                Console.WriteLine();
                Console.WriteLine("Angiv nummeret på den ønskede reol");

                bool isBoothValid = false;
                while (!isBoothValid)
                {
                    var userInput = Console.ReadLine();
                    var chosenBooth = availableBooths.FirstOrDefault(x => x.Name == userInput);

                    if (chosenBooth != null)
                    {
                        isBoothValid = true;
                        _bookingController.CreateBooking(startDate, endDate, tenantId, chosenBooth.Id);
                        Console.WriteLine("Booking oprettet!");
                        Console.WriteLine($"{startDate.ToString("dd-MM-yyyy")}-{endDate.ToString("dd-MM-yyyy")}: {chosenBooth.Price}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt reolnummer. Angiv nummeret på den ønskede reol.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Der er desværre ingen ledige reoler i det valgte tidsrum.");
            }
        }
    }
}
