using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Universite
    {
        string ad;
        public Universite(string ad)
        {
            this.ad = ad;

        }
        public string isim
        {
            get { return ad; }
        }
    }
}
