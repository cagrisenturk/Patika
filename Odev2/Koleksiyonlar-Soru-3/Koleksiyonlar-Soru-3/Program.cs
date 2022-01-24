using System;
using System.Collections;

namespace Koleksiyonlar_Soru_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir cümle giriniz:");
            string cumle = Console.ReadLine();
            string sesliHarf = "aeıioöuüAEIİOÖUÜ";
            ArrayList liste = new ArrayList();
            int adet = 0;
            for (int i = 0; i < cumle.Length; i++)
            {
                if (sesliHarf.Contains(cumle[i]))
                {
                    adet++;
                    liste.Add(cumle[i]);
                }
            }
            foreach (var i in liste)
            {
                Console.WriteLine(i);
            }
        }
    }
}
