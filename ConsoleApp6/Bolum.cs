using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Bolum
    {
        private string ad;
        Fakulte fa;
        public Bolum(string ad, Fakulte fa)
        {
            this.ad = ad;
            this.fa = fa;
        }
        public string isim
        {
            get { return ad; }

        }
        public Fakulte f 
        {
            get { return fa; }
        }
        public List<Ders> derses = new List<Ders>(); 
        public List<Ogrenci> ogrencis = new List<Ogrenci>(); 
        public List<OgretimElemanlari> ogretimElemanlaris = new List<OgretimElemanlari>(); 
    }
}
