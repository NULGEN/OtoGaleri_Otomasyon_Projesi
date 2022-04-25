using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_G023
{
    class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralamaSureleri.Count;
            }
        }
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int item in KiralamaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }
        public ARAC_TIPI AracTipi { get; set; }
        public DURUM Durum { get; set; }

        public List<int> KiralamaSureleri = new List<int>();

        

        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }



    }

   
    public enum DURUM
    {
        Empty,
        Kirada,
        Galeride
    }

    public enum ARAC_TIPI
    {
        Empty,
        SUV,
        Hatchback,
        Sedan
    }


}
