using System;
using System.Collections.Generic;
using System.Text;

namespace Proje2ToDo
{
    enum Line
    {
        Todo = 1,
        InProgress = 2,
        Done = 3
    }
    class Kart
    {
        string baslik;
        string icerik;
        EnumBuyukluk buyukluk;
        Line line;
        Kisi Kisi;
        public Kart()
        {
           

        }
        public Kart(string baslik, string icerik, EnumBuyukluk buyukluk, Line line, Kisi kisi)
        {
            this.baslik = baslik;
            this.icerik = icerik;
            this.buyukluk = buyukluk;
            this.Line = line;
            Kisi = kisi;
        }

        public string Baslik { get => baslik; set => baslik = value; }
        public string Icerik { get => icerik; set => icerik = value; }
        internal EnumBuyukluk Buyukluk { get => buyukluk; set => buyukluk = value; }
        internal Line Line { get => line; set => line = value; }
        internal Kisi Kisi1 { get => Kisi; set => Kisi = value; }
    }
}
