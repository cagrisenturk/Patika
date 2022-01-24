using System;

namespace Ornek1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pozitif bir sayi giriniz");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 0)
            {
                int[] sayilar = new int[n];
                for (int i = 0; i < n; i++)
                {
                    sayilar[i] = Convert.ToInt32(Console.ReadLine());
                }
                for (int i = 0; i < n; i++)
                {
                    if (sayilar[i] % 2 == 0)
                        Console.WriteLine(sayilar[i]);

                }
            }
            else
                Console.WriteLine("Pozitif bir sayi girmediniz");
        }
    }
}
