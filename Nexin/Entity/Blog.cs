using System;

namespace Nexin.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public string KisaAciklama { get; set; }
        public string Url { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;


    }
}
