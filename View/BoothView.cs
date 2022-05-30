using Reolmarkedet.Controller;
using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.View
{
    public class BoothView
    {
        private BoothController _boothController;

        public BoothView(BoothController boothController)
        {
            _boothController = boothController;
        }

        public Booth CreateBoothView()
        {
            Console.Clear();
            Console.WriteLine("Opret ny reol");
            Console.WriteLine();

            Console.WriteLine("Vælg reoltype");

            var type = Console.ReadLine();

            Console.WriteLine("Indtast nummer på reolen");
            var name = Console.ReadLine();

            Console.WriteLine("Indtast beløb for ugentlig leje");
            decimal price;

            while(!decimal.TryParse(Console.ReadLine(), out price) && price < 0)
                Console.WriteLine("Ugyldigt beløb");

            var booth = _boothController.CreateBooth(name, type, price);

            Console.WriteLine();
            Console.WriteLine("Reol oprettet!");
            Console.WriteLine($"{booth.Name} ({booth.Type}): {booth.Price} kr.");
            Console.ReadKey();

            return booth;
        }
    }
}
