using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibararySoftware
{
    public class Book : Document
    {
        public string ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
    }
}
