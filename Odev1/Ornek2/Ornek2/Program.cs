using System;

namespace Ornek2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İki adet pozitif tam sayi giriniz");

            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            
                Console.WriteLine(n+" adet pozitif tam sayi giriniz");
                int[] sayilar = new int[n];
                for (int i = 0; i < n; i++)
                {
                    sayilar[i] = Convert.ToInt32(Console.ReadLine());
                }
                for (int i = 0; i < n; i++)
                {
                    if (sayilar[i]%m==0)
                        Console.WriteLine(sayilar[i]);

            }
        }
    }
}
