using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnicaFox.Core.Models
{
    public class PriceModel
    {
        public int Id { get; set; }
        public float SinglePrice { get; set; }
        public float DoublePrice { get; set; }
        public float SuitePrice { get; set; }
        public float DeluxePrice { get; set; }
        

        public PriceModel()
        {
            SinglePrice= 10;
            DoublePrice= 15;
            SuitePrice= 25;
            DeluxePrice= 40;
        }
    }
}
