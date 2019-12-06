using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SNobleCSharpProject
{
    public class Product
    {
        public string prodName { get; set; }
        public string prodCategory { get; set; }
        public string prodSubcategory { get; set; }
        public int prodSKU { get; set; }
        public string prodBarcode { get; set; }
        public int prodQuantityMon { get; set; }
        public int prodTotalMon { get; set; }
        public int prodQuantityTue { get; set; }
        public int prodTotalTue { get; set; }
        public int prodQuantityWed { get; set; }
        public int prodTotalWed { get; set; }
        public int prodQuantityThu { get; set; }
        public int prodTotalThu { get; set; }
        public int prodQuantityFri { get; set; }
        public int prodTotalFri { get; set; }
        public int prodQuantitySat { get; set; }
        public int prodTotalSat { get; set; }
        public int prodQuantitySun { get; set; }
        public int prodTotalSun { get; set; }

    }
}
