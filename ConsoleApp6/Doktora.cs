using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Doktora : Ogrenci
    {
        public Doktora(int numara, string adsoyad, Bolum bolum) : base(numara, adsoyad, bolum)
        {
            this.numara = numara;
            this.adsoyad = adsoyad;
            this.bolum = bolum;
        }
        public int telno
        {
            get
            {
                return telefon;
            }
            set
            {
                this.telefon = value;
            }
        }
    }
}
