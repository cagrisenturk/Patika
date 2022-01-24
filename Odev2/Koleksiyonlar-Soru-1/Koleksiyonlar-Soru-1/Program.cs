using System;
using System.Collections;

namespace Koleksiyonlar_Soru_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("20 adet pozitif tam sayı giriniz");

            int i = 0;
            int sayi;
            ArrayList asalListe = new ArrayList();
            ArrayList asalOlmayanListe = new ArrayList();

            while (i<20)
            {
                Console.Write((i+1)+". sayi:");
                sayi = Convert.ToInt32(Console.ReadLine());
                if (sayi>0)
                {
                    if (asalMi(sayi))
                    {
                        asalListe.Add(sayi);
                    }
                    else
                    {
                        asalOlmayanListe.Add(sayi);
                    }
                    i++;
                }
                else
                {
                    Console.WriteLine("Yanlış değer girdiniz sadeece poztif tam sayılar");
                }

            }
            asalListe.Sort();
            asalListe.Reverse();
            asalOlmayanListe.Sort();
            asalOlmayanListe.Reverse();
            Console.WriteLine("Asal Sayılar");
            int toplam = 0;
            foreach (int sayii  in asalListe)
            {
                Console.WriteLine(sayii);
                toplam += sayii;
            }
            Console.WriteLine("Eleman sayısı:"+asalListe.Count+" Ortalaması:"+(double)toplam/asalListe.Count);
            toplam = 0;
            foreach (int sayii  in asalOlmayanListe)
            {
                Console.WriteLine(sayii);
                toplam += sayii;
            }
            Console.WriteLine("Eleman sayısı:" + asalOlmayanListe.Count + " Ortalaması:" + (double)toplam / asalOlmayanListe.Count);
        }

        private static bool asalMi(int sayi)
        {
            bool asal=true;
            if (sayi == 1)
                return false;
            if (sayi == 2)
                return asal;
            for (int i = 2; i < sayi; i++)
            {
                if (sayi%i==0)
                {
                    asal = false;
                    break;
                }
            }
            return asal;
        }
    }
}
