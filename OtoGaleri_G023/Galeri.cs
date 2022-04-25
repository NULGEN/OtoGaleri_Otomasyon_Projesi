using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_G023
{
    class Galeri
    {

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi 
        { 
            get
            {
                return KiradakiAracSayisi + BekleyenAracSayisi;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach(Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }
        public int BekleyenAracSayisi      
        {
            get
            {
                int adet = 0;
                foreach(Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        adet++;
                    }
                }
                return adet;

            }
        }
        public int ToplamAracKiralamaSuresi   
        { 
            get
            {
                int toplamSüre=0;
                foreach (Araba item in this.Arabalar)
                {
                    toplamSüre += item.ToplamKiralanmaSuresi;
                }                  
                return toplamSüre;
            }
        }
        public int ToplamAracKiralamaAdedi
        { 
            get
            {
                int toplamAdet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    toplamAdet += item.KiralanmaSayisi;
                }
                return toplamAdet;
            }
        }
        public float Ciro 
        {
            get
            {

                float toplamCiro = 0;
                foreach (Araba item in this.Arabalar)
                {

                    for (int i = 0; i < item.KiralamaSureleri.Count; i++)
                    {
                        toplamCiro += item.KiralamaBedeli * item.KiralamaSureleri[i];
                        break;
                    }

               }
                return toplamCiro;
            }
        }


       


        public bool PlakaKiralamaKontrol(string plaka)  
        {
            foreach (Araba item in this.Arabalar)
            {

                if(item.Plaka == plaka.ToUpper())
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        return false;
                    }
                    else if(item.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine("Arac zaten kirada.");
                        return true;
                    }
                }
                
            }

            Kontrol(plaka);
            return true;
                               
        }


        public bool PlakaTeslimKontrol(string plaka) 
        {
            foreach (Araba item in this.Arabalar)
            {

                if (item.Plaka == plaka.ToUpper())
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        return false;
                    }
                    else if (item.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine("Arac zaten galeride.");
                        return true;
                    }
                }

            }

            Kontrol(plaka);
            return true;

        }


        public bool KiralamaIptalKontrol(string plaka)  
        {
            foreach (Araba item in this.Arabalar)
            {

                if (item.Plaka == plaka.ToUpper())
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        return false;
                    }
                    else if (item.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine("Hatali giris yapildi. Arac zaten galeride.");
                        return true;
                    }
                }

            }

            Kontrol(plaka);
            return true;

        }


        public void Kontrol(string plaka)    
        {

            if (plaka.Length == 8)
            {
                int sayi;
                if (int.TryParse(plaka.Substring(0, 2), out sayi) == true && int.TryParse(plaka.Substring(2, 3), out sayi) == false && int.TryParse(plaka.Substring(5, 3), out sayi) == true)
                {
                    Console.WriteLine("Galeriye ait böyle bir araç yok.");
                }
                else
                {
                    Console.WriteLine("Giris tanimlanamadi. Tekrar deneyin.");
                }
            }
            else
            {
                Console.WriteLine("Giris tanimlanamadi. Tekrar deneyin.");
            }

        }


        public bool PlakaYazimKontrol(string plaka)   
        {
            if (plaka.Length == 8)
            {
                int sayi;
                if( int.TryParse(plaka.Substring(0, 2), out sayi) == true && int.TryParse(plaka.Substring(2,3), out sayi) == false && int.TryParse(plaka.Substring(5, 3), out sayi) == true)
                {
                    return false;
                }
            }

                Console.WriteLine("Bu sekilde plaka girisi yapamazsınız. Tekrar deneyin.");
                return true;
        }


        public bool SilinecekPlakaKontrol(string plaka)
        {
            foreach(Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    return false;
                }              
            }
            Console.WriteLine("Silinecek araç bulunamadı.");
            return true;            
        }




     

        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = null;
            
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = DURUM.Kirada;
                a.KiralamaSureleri.Add(sure);

            }
        }

        public void ArabaTeslimAl(string plaka)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                }
            }

            if (a != null)
            {
                a.Durum = DURUM.Galeride;
            }
        }

          
      

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);
            this.Arabalar.Add(a);
        }

        
        
        public void YeniArabaEkle(string plaka, string marka, float kb, string secim)
        {
            Araba yeniAraba = new Araba(plaka, marka, kb, ARAC_TIPI.Empty);

            switch (secim)
            {
                case "1":
                    yeniAraba.AracTipi = ARAC_TIPI.SUV;
                    break;
                case "2":
                    yeniAraba.AracTipi = ARAC_TIPI.Hatchback;
                    break;
                case "3":
                    yeniAraba.AracTipi = ARAC_TIPI.Sedan;
                    break;
            }

            this.Arabalar.Add(yeniAraba);
        }
        

        public void AracSil(string plaka)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    a = item;
                }
            }

            if (a != null)
            {
                Arabalar.Remove(a);
                Console.WriteLine("Arac silindi.");
            }
        }

       
        public void KiradakiAraclarinListesi()   
        {
            foreach(Araba item in this.Arabalar)
            {
                if(item.Durum == DURUM.Kirada)
                {
                    Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(14, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(16, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum);
                }
            }
        }

        public void MüsaitAraclarinListesi()      
        {
            foreach (Araba item in this.Arabalar)
            {
                if (item.Durum == DURUM.Galeride)
                {
                    Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(14, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(16, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum);
                }
            }
        }

        public void TümAraclarinListesi()     
        {
            foreach(Araba item in this.Arabalar)
            {
                Console.WriteLine(item.Plaka.PadRight(15, ' ') + item.Marka.PadRight(14, ' ') + item.KiralamaBedeli.ToString().PadRight(15, ' ') + item.AracTipi.ToString().PadRight(16, ' ') + item.KiralanmaSayisi.ToString().PadRight(15, ' ') + item.Durum);

            }
        }



        public void KiralamaIptali(string plaka)    
        {

            foreach(Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka.ToUpper())
                {
                    item.Durum = DURUM.Galeride;

                    int sayi = item.KiralanmaSayisi;
                    sayi--;

                    item.KiralamaSureleri.RemoveAt(item.KiralamaSureleri.Count-1);

                }
            }

          
        }


        

    }
}
