using System;

namespace Ornek4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir cümle giriniz");
            string cumle=Console.ReadLine();
            string[] kelimeler = cumle.Split(" ");
            Console.WriteLine("Kelime Sayisi=" + kelimeler.Length);
            Console.WriteLine("Harf Sayisi=" + (cumle.Length-(kelimeler.Length-1)));
        }
    }
}
