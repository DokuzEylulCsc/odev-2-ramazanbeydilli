using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Fakulte
    {
        private string ad;
        Universite uni;
        public Fakulte(string ad, Universite uni)
        {
            this.ad = ad;
            this.uni = uni;
        }
        public string isim
        {
            get { return ad; }

        }
        public Universite u
        {
            get { return uni; }
        }
        public List<Bolum> bolums = new List<Bolum>();
        public List<Ogrenci> ogrencis = new List<Ogrenci>();
        public List<OgretimElemanlari> ogretimElemanlaris = new List<OgretimElemanlari>();

    }
}
