using System;

namespace OtoGaleri_G023
{
    class Program
    {

        static Galeri OtoGaleri = new Galeri();

       
        static void Main(string[] args)
        {
            SahteVeriGir();
            Uygulama();
        }

        static void Uygulama()
        {
            Menu();
            Console.WriteLine();

            while (true)
            {
                string secim = SecimAl();

                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalarinListesi();
                        break;
                    case "4":
                    case "M":
                        MüsaitArabalarinListesi();
                        break;
                    case "5":
                    case "A":
                        TümArabalarinListesi();
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        YeniArabaEkle();
                        break;
                    case "8":
                    case "S":
                        ArabaSil();
                        break;
                    case "9":
                    case "G":
                        BilgileriGöster();
                        break;
                }
            }


        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon");
            Console.WriteLine("1 - Araba Kirala(K)");
            Console.WriteLine("2 - Araba Teslim Al(T)");
            Console.WriteLine("3 - Kiradaki arabaları listele(R)");
            Console.WriteLine("4 - Müsait arabaları listele(M)");
            Console.WriteLine("5 - Tüm arabaları listele(A)");
            Console.WriteLine("6 - Kiralama Iptali(I)");
            Console.WriteLine("7 - Yeni araba Ekle(Y)");
            Console.WriteLine("8 - Araba sil(S)");
            Console.WriteLine("9 - Bilgileri göster(G)");
        }

        static string SecimAl()
        {
            Console.WriteLine();
            Console.Write("Seciminiz: ");
            string giris = Console.ReadLine().ToUpper();

            return giris;
        }

        static int SayiAl(string text)   
            
        {
            int sayi;
            while (true)
            {

                Console.Write(text);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi) == true)
                {
                    return sayi;
                }
                Console.WriteLine("Hatalı giris yapıldı, tekrar deneyin.");
            }
        }


        static void ArabaKirala()   //  1
        {
            Console.WriteLine("-Araç Kirala-");
            if (OtoGaleri.BekleyenAracSayisi == 0)
            {
                Console.WriteLine("Galeride arac yok.");
                return;
            }

            
            string plaka;
            do
            {

                Console.Write("Kiralanacak aracın plakası: ");
                plaka = Console.ReadLine();
            } while (OtoGaleri.PlakaKiralamaKontrol(plaka) == true);

            int sure = SayiAl("Kiralama süresi: ");

            OtoGaleri.ArabaKirala(plaka, sure);
            Console.WriteLine(plaka + " plakali arac " + sure + " saatligine kiralandi.");
        }





        static void ArabaTeslimAl()  //   2
        {
            Console.WriteLine("-Araç Teslim-");
            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada arac yok.");
                return;
            }

            
            string plaka;
            do
            {
                Console.Write("Teslim edilecek aracın plakası: ");
                plaka = Console.ReadLine();
            } while (OtoGaleri.PlakaTeslimKontrol(plaka) == true);

            OtoGaleri.ArabaTeslimAl(plaka);
            Console.WriteLine("Arac galeride beklemeye alindi.");
        }



        static void KiradakiArabalarinListesi()   
        {
            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Listelenecek arac yok.");
                return;
            }
            Console.WriteLine("-Kiradaki Araçlar-");
            Console.WriteLine("Plaka".PadRight(15, ' ') + "Marka".PadRight(14, ' ') + "K. Bedeli".PadRight(15, ' ') + "Arac Tipi".PadRight(16, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            OtoGaleri.KiradakiAraclarinListesi();
        }

        static void MüsaitArabalarinListesi()   
        {
            if (OtoGaleri.BekleyenAracSayisi == 0)
            {
                Console.WriteLine("Listelenecek arac yok.");
                return;
            }
            Console.WriteLine("-Müsait Araçlar-");
            Console.WriteLine("Plaka".PadRight(15, ' ') + "Marka".PadRight(14, ' ') + "K. Bedeli".PadRight(15, ' ') + "Arac Tipi".PadRight(16, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            OtoGaleri.MüsaitAraclarinListesi();
        }

        static void TümArabalarinListesi()  
        {
            Console.WriteLine("-Tüm Araçlar-");
            Console.WriteLine("Plaka".PadRight(15, ' ') + "Marka".PadRight(14, ' ') + "K. Bedeli".PadRight(15, ' ') + "Arac Tipi".PadRight(16, ' ') + "K. Sayisi".PadRight(15, ' ') + "Durum");
            Console.WriteLine("-------------------------------------------------------------------------------------");

            OtoGaleri.TümAraclarinListesi();
        }


        static void KiralamaIptali()  
        {
            Console.WriteLine("-Kiralama Iptali-");

            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Kirada arac yok.");
                return;
            }

           
            string plaka;
            do
            {
                Console.Write("Kiralaması iptal edilecek aracın plakası: ");
                plaka = Console.ReadLine();
            } while (OtoGaleri.KiralamaIptalKontrol(plaka) == true);

            OtoGaleri.KiralamaIptali(plaka);
            Console.WriteLine("Iptal gerçeklestirildi.");
        }


        static void YeniArabaEkle()    //    7
        {
            Console.WriteLine("-Yeni Araç Ekle-");

            string yeniPlaka;
            do
            {
                Console.Write("Plaka: ");
                yeniPlaka = Console.ReadLine();
            } while (OtoGaleri.PlakaYazimKontrol(yeniPlaka) == true);

            Console.Write("Marka: ");
            string yeniMarka = Console.ReadLine();
            Console.Write("Kiralama bedeli: ");
            int yeniKB = int.Parse(Console.ReadLine());
            Console.WriteLine(" Araç Tipleri:");
            Console.WriteLine("- SUV için 1");
            Console.WriteLine("- Hatchback için 2");
            Console.WriteLine("- Sedan için 3");

            string secim = Console.ReadLine();
            OtoGaleri.YeniArabaEkle(yeniPlaka, yeniMarka, yeniKB, secim);

            Console.WriteLine("Araç basarılı bir sekilde eklendi.");

        }


        static void ArabaSil()    
        {
            Console.WriteLine("-Araba Sil-");

            string silinecekPlaka;
            do
            {
                Console.Write("Silinmek istenen arac plakasini girin: ");
                silinecekPlaka = Console.ReadLine();
            } while (OtoGaleri.SilinecekPlakaKontrol(silinecekPlaka) == true);

            OtoGaleri.AracSil(silinecekPlaka);

        }


        static void BilgileriGöster()    
        {
            Console.WriteLine("-Galeri Bilgileri -");
            Console.WriteLine("Toplam Araç Sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen Araç Sayısı: " + OtoGaleri.BekleyenAracSayisi);
            Console.WriteLine("Toplam araç kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
            Console.WriteLine("Toplam araç kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
        }


        static void SahteVeriGir()
        {
            OtoGaleri.ArabaEkle("11aaa111", "Opel", 150, ARAC_TIPI.SUV);
            OtoGaleri.ArabaEkle("22aaa111", "Opel", 150, ARAC_TIPI.SUV);
            OtoGaleri.ArabaEkle("33aaa111", "Opel", 150, ARAC_TIPI.SUV);

        }

    }
}
