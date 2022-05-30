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
            //foreach (boothType in _boothController.BoothTypes)

            Console.WriteLine("Indtast nummeret på reolen");
            var name = Console.ReadLine();

            Console.WriteLine("Indtast dit telefonnummer");
            var telephoneNo = Console.ReadLine();

            //var tenant = _boothController.CreateBooth();

            return new Booth();
        }
    }
}
