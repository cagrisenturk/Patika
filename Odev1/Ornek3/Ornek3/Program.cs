using System;

namespace Ornek3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pozitif tam sayi giriniz");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(n + " adet kelime giriniz");
            string[] kelimeler = new string[n];
            for (int i = 0; i < n; i++)
            {
                kelimeler[i] = Console.ReadLine();
            }
            for (int i = n-1; i >= 0; i--)
            {
                Console.WriteLine(kelimeler[i]);
            }
        }
    }
}
