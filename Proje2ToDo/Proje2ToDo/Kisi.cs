using System;
using System.Collections.Generic;
using System.Text;

namespace Proje2ToDo
{
   
    class Kisi
    {
        int id;
        string ad;
        string soyad;

        public Kisi()
        {

        }
        public Kisi(int id, string ad, string soyad)
        {
            this.id = id;
            this.ad = ad;
            this.soyad = soyad;
        }

        public int Id { get => id; set => id = value; }
        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
    }
}
