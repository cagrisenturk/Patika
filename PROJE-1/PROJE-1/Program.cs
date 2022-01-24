using System;
using System.Collections.Generic;

namespace PROJE_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Kisi> kisiler = new List<Kisi>();
            kisiler.Add(new Kisi("Çağrı", "Şentürk", 100));
            kisiler.Add(new Kisi("MehmeT", "Şentürk", 101));
            kisiler.Add(new Kisi("Ozi", "Şentürk", 102));
            Rehber rehber = new Rehber(kisiler);
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapma﻿k");
                Console.WriteLine("(-1) Çıkış");
                Console.WriteLine("*******************************************");
                int islem = Convert.ToInt32(Console.ReadLine());
                if (islem==-1)
                {
                    break;
                }
                else if (islem<1||islem>5)
                {
                    Console.WriteLine("Hatalı Tercih Yaptınız Tekrar Deneyiniz");
                    continue;
                }
                Console.Clear();
                switch (islem)
                {
                    
                    case 1:
                        Console.WriteLine("Lütfen isim giriniz:");
                        string isim = Console.ReadLine();
                        Console.WriteLine("Lütfen soyisim giriniz:");
                        string soyisim = Console.ReadLine();
                        Console.WriteLine("Lütfen telefon numarası giriniz:");
                        int telNo = Convert.ToInt32(Console.ReadLine());
                        Kisi kisis = new Kisi(isim, soyisim, telNo);
                        rehber.KisiEkle(kisis);
                        Console.WriteLine("Kaydedilmiştir :)");
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
                            string girdi = Console.ReadLine();
                            int index = rehber.IndexBul(girdi);
                            if (index == -1)
                            {
                                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                                Console.WriteLine("* Yeniden denemek için      : (2)");
                                int yeniIslem = Convert.ToInt32(Console.ReadLine());
                                if (yeniIslem == 1)
                                    break;

                            }
                            else
                            {
                                Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", girdi);
                                girdi = Console.ReadLine();
                                if (girdi == "y")
                                {
                                    rehber.NumaraSil(index);
                                    Console.WriteLine("Silme işlemi başarıyla gerçekleşmiştir.");
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (true)
                        {
                            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                            string girdi = Console.ReadLine();
                            int index = rehber.IndexBul(girdi);
                            if (index == -1)
                            {
                                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                Console.WriteLine("* Güncellemeyi sonlandırmak için : (1)");
                                Console.WriteLine("* Yeniden denemek için           : (2)");
                                int yeniIslem = Convert.ToInt32(Console.ReadLine());
                                if (yeniIslem == 1)
                                    break;

                            }
                            else
                            {
                                Console.WriteLine("{0} isimli kişinin güncel numarasını giriniz: ", girdi);
                                int yeniNo = Convert.ToInt32(Console.ReadLine());
                                rehber.NumaraGuncelleme(index, yeniNo);
                                Console.WriteLine("Güncelleme işlemi başarıyla gerçekleşmiştir.");
                                break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Hangi düzende sıralamak istediğinizi seçiniz.");
                        Console.WriteLine(" *A-Z için: (1)");
                        Console.WriteLine(" *Z-A için: (2)");
                        int siralamaSecim = Convert.ToInt32(Console.ReadLine());
                        rehber.RehberListele(siralamaSecim);
                        break;
                    case 5:
                        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                        Console.WriteLine("*İsim veya soyisime göre arama yapmak için: (1)");
                        Console.WriteLine("*Telefon numarasına göre arama yapmak için: (2)");
                        int yeniSecim = Convert.ToInt32(Console.ReadLine());
                        if (yeniSecim == 1)
                        {
                            Console.Write("İsim veya soyisim giriniz:");
                            string girdi = Console.ReadLine();
                            rehber.KisiGetir(rehber.IndexBul(girdi));
                        }
                        if (yeniSecim == 2)
                        {
                            Console.Write("Telefon numarası giriniz:");
                            int aranaTelNo = Convert.ToInt32(Console.ReadLine());
                            rehber.KisiGetir(rehber.IndexBul(aranaTelNo));
                        }
                        break;

                }
            }
            


        }
    }
    class Kisi
    {
        private string isim;
        private string soyisim;
        private int telNo;

        public Kisi(string isim, string soyisim, int telNo)
        {
            this.isim = isim;
            this.soyisim = soyisim;
            this.telNo = telNo;
        }

        public string Isim { get => isim; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public int TelNo { get => telNo; set => telNo = value; }
    }
    class Rehber
    {
        private List<Kisi> kisiler = new List<Kisi>();

        public Rehber(List<Kisi> kisiler)
        {
            this.Kisiler = kisiler;
        }
        public void KisiEkle(Kisi yeniKisi){
            kisiler.Add(yeniKisi);
        }
        public void NumaraSil(int index)
        {
            kisiler.RemoveAt(index);
        }
        public void RehberListele(int tercih)
        {
            kisiler.Sort((u1, u2) => u1.Isim.CompareTo(u2.Isim));
            if (tercih==2)
            {
                kisiler.Reverse();
            }
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*********************************");
            Console.WriteLine("");
            for (int i = 0; i < kisiler.Count; i++)
            {
                KisiGetir(i);
                Console.WriteLine("-----------------------------------");
            }

        }
        public void KisiGetir(int index)
        {
            Console.WriteLine("İsim: {0}", kisiler[index].Isim);
            Console.WriteLine("Soyisim: {0}", kisiler[index].Soyisim);
            Console.WriteLine("Telefon Numarası: {0}", kisiler[index].TelNo);
        }
        public int IndexBul(string girdi)
        {
            int index = -1;
            for (int i = 0; i < kisiler.Count; i++)
            {
                if (kisiler[i].Isim== girdi || kisiler[i].Soyisim== girdi)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int IndexBul(int girdi)
        {
            int index = -1;
            for (int i = 0; i < kisiler.Count; i++)
            {
                if (kisiler[i].TelNo==girdi)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void NumaraGuncelleme(int index,int yeniNo)
        {
            kisiler[index].TelNo = yeniNo;
        }

        internal List<Kisi> Kisiler { get => kisiler; set => kisiler = value; }
    }
}
