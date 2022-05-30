using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reolmarkedet.Model
{
    public class Tenant : BaseIdentifiableItem
    {
        public string Name { get; set; }
        public string TelephoneNo { get; set; }
        public string Mail { get; set; }
        public decimal Balance { get; set; }
        public int CustomerNo { get; set; }
    }
}
