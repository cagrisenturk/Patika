using System;
using System.Collections.Generic;

namespace Proje2ToDo
{
    class Program
    {
        static List<Kart> kartlar;
        static List<Kart> ToDo;
        static List<Kart> IPL;
        static List<Kart> DL;
        static void Main(string[] args)
        {
            kartlar = new List<Kart>();
            ToDo = new List<Kart>();
            IPL = new List<Kart>();
            DL = new List<Kart>();
            kartlar.Add(new Kart("baslik0", "icerik0", EnumBuyukluk.XS, Line.Todo, new Kisi(0, "ad0", "soyad0")));
            kartlar.Add(new Kart("baslik1", "icerik1", EnumBuyukluk.S, Line.InProgress, new Kisi(1, "ad1", "soyad1")));
            while (true)
            {
                ToDo.Clear();
                IPL.Clear();
                DL.Clear();
                KartListe();
                Console.WriteLine("******************************************");
                Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz:");
                Console.WriteLine("1-)Board Listelemek\n2-)Board'a Kart Eklemek\n3-)Board'dan kart Silmek\n4-)Kart Taşımak\n 5-)Cikis Yap");
                string secim = Console.ReadLine();
                switch (secim)
                {

                    case "1":
                        BoardGetir();
                        break;

                    case "2":
                        KartEkle();
                        break;

                    case "3":
                        KartSil();
                        break;

                    case "4":
                        KartTasi();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static int KartAra(string baslik,out string line)
        {
            int index;
            
            for (int i = 0; i < kartlar.Count; i++)
            {
                if (kartlar[i].Baslik.Equals(baslik))
                {
                    index = i;
                    line = kartlar[i].Line.ToString();
                    return index;
                }
            }
            line = null;
            return -1;
        }
        static void KartTasi()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen Başlık Giriniz: ");
            string baslik = Console.ReadLine();
            string line;
            int index = KartAra(baslik, out line);
            if (index == -1)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Taşımayı sonlandirmak icin (1)");
                Console.WriteLine("* Yeniden denemek icin (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartTasi();
                else
                    Console.WriteLine("Kart taşıma islemi sonlandi.");
            }
            else
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("*******************************************");
                Console.WriteLine("Baslik       :   {0}", kartlar[index].Baslik);
                Console.WriteLine("Icerik       :   {0}", kartlar[index].Icerik);
                Console.WriteLine("Atanan Kisi  :   {0}", kartlar[index].Kisi1.Ad);
                Console.WriteLine("Buyukluk     :   {0}", kartlar[index].Buyukluk);
                Console.WriteLine("Line         :   {0}", kartlar[index].Line);
                Console.WriteLine();
                Console.WriteLine("Lutfen tasimak istediginiz Line'i secin:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        kartlar[index].Line = Line.Todo;
                        ToDo.Clear();
                        IPL.Clear();
                        DL.Clear();
                        KartListe();
                        BoardGetir();
                        break;
                    case 2:
                        kartlar[index].Line = Line.InProgress;
                        ToDo.Clear();
                        IPL.Clear();
                        DL.Clear();
                        KartListe();
                        BoardGetir();
                        break;
                    case 3:
                        kartlar[index].Line = Line.Done;
                        ToDo.Clear();
                        IPL.Clear();
                        DL.Clear();
                        KartListe();
                        BoardGetir();
                        break;
                    default:
                        Console.WriteLine("Hatali bir secim yaptiniz!");
                        break;
                }
            }
        }
        static void KartSil()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen Başlık Giriniz: ");
            string baslik = Console.ReadLine();
            string line;
            int index=KartAra(baslik,out line);
            if (index==-1)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Silmeyi sonlandirmak icin (1)");
                Console.WriteLine("* Yeniden denemek icin (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartSil();
                else
                    Console.WriteLine("Kart silme islemi sonlandi.");
            }
            else
            {
                Console.WriteLine("Kart bulundu ve silindi");
                kartlar.RemoveAt(index);
            }
        }
        static void KartEkle()
        {
            Kart kart = new Kart();
            Kisi kisi = new Kisi();
            Console.WriteLine("ID Giriniz:");
            kisi.Id =Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("İsim Giriniz:");
            kisi.Ad = Console.ReadLine();

            Console.WriteLine("Soy Isim Giriniz:");
            kisi.Soyad = Console.ReadLine();
            kart.Kisi1 = kisi;

            Console.WriteLine("Başlık Giriniz:");
            kart.Baslik = Console.ReadLine();

            Console.WriteLine("İçerik Giriniz:");
            kart.Icerik = Console.ReadLine();

            Console.WriteLine("Lütfen Büyüklük Giriniz XS(1),S(2),M(3),L(4),XL(5):");
            kart.Buyukluk = (EnumBuyukluk)Convert.ToInt16(Console.ReadLine());

            kart.Line = Line.Todo;

            kartlar.Add(kart);
        }
        static void KartListe()
        {
            for (int i = 0; i < kartlar.Count; i++)
            {
                if (kartlar[i].Line.Equals(Line.Todo))
                {
                    ToDo.Add(kartlar[i]);
                }
                else if (kartlar[i].Line.Equals(Line.InProgress))
                {
                    IPL.Add(kartlar[i]);
                }
                else
                {
                    DL.Add(kartlar[i]);
                }

            }
        }
        static void BoardGetir()
        {
            


                Console.WriteLine();
                Console.WriteLine("TODO Line");
                Console.WriteLine("*****************************");
            for (int i = 0; i < ToDo.Count; i++) 
                {
                    Console.WriteLine("Baslik       : {0}", ToDo[i].Baslik);
                    Console.WriteLine("Icerik       : {0}", ToDo[i].Icerik);
                    Console.WriteLine("Atanan Kisi  : {0}", ToDo[i].Kisi1.Ad);
                    Console.WriteLine("Buyukluk     : {0}", ToDo[i].Buyukluk);
                    Console.WriteLine("-");

                }

                Console.WriteLine();
                Console.WriteLine("IN PROGRESS Line");
                Console.WriteLine("*****************************");

            for (int i = 0; i < IPL.Count; i++)
                    { 
                    Console.WriteLine("Baslik       : {0}", IPL[i].Baslik);
                    Console.WriteLine("Icerik       : {0}", IPL[i].Icerik);
                    Console.WriteLine("Atanan Kisi  : {0}", IPL[i].Kisi1.Ad);
                    Console.WriteLine("Buyukluk     : {0}", IPL[i].Buyukluk);
                    Console.WriteLine("-");
                }

                Console.WriteLine();
                Console.WriteLine("DONE Line");
                Console.WriteLine("*****************************");

            for (int i = 0; i < DL.Count; i++)
            {

            
                    Console.WriteLine("Baslik       : {0}", DL[i].Baslik);
                    Console.WriteLine("Icerik       : {0}", DL[i].Icerik);
                    Console.WriteLine("Atanan Kisi  : {0}", DL[i].Kisi1.Ad);
                    Console.WriteLine("Buyukluk     : {0}", DL[i].Buyukluk);
                    Console.WriteLine("-");
                }
            

        }

    }
}
