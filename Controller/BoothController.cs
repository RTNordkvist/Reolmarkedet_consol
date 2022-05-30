using Reolmarkedet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Controller
{
    public class BoothController
    {
        private DbContext _dbContext;

        public List<string> BoothTypes { get; set; } = new List<string>()
        {
            "Reol",
            "Tøjreol",
            "Glasmontre",
            "Hylde i glasmontre",
            "Gulvplads"
        };

        public BoothController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booth CreateBooth(string name, string type, decimal price)
        {
            var booth = new Booth();
            booth.Name = name;
            booth.Type = type;
            booth.Price = price;

            _dbContext.BoothDb.AddItem(booth);

            return booth;
        }
    }
}
