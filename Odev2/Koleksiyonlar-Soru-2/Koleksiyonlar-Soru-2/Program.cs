using System;

namespace Koleksiyonlar_Soru_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dizi = new int[20];

            for (int i = 0; i < 20; i++)
            {
                System.Console.WriteLine("Lütfen" + (i + 1) + ". sayıyı giriniz: ");
                int sayi = Convert.ToInt32(Console.ReadLine());
                dizi[i]=sayi;
            }
            Array.Sort(dizi);
            int enBuyukToplam = dizi[17] + dizi[18] + dizi[19];
            int enKucukToplam = dizi[0] + dizi[1] + dizi[2];
            double ortalamaKucuk= (double)enKucukToplam / 3;
            double ortalamaBuyuk = (double)enBuyukToplam / 3;
            Console.WriteLine("En küçük sayilar" + dizi[0] +" " + dizi[1] + " " + dizi[2]);
            Console.WriteLine("En büyük sayilar" + dizi[17] + " " + dizi[18] + " " + dizi[19]);
            Console.WriteLine("En küçük sayilar ortalmasi:" + ortalamaKucuk);
            Console.WriteLine("En büyük sayilar ortalmasi:" + ortalamaBuyuk);
            Console.WriteLine("Ortalama toplamları:" + (ortalamaBuyuk + ortalamaKucuk));
        }
    }
}
