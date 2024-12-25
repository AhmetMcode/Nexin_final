using Nexin.Entity;

namespace Nexin.Models
{
    public class AddMessageViewModel
    {
        public string Isim { get; set; }
        public string Mail { get; set; }
        public string TelNo { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public LayoutAyar LayoutAyar { get; set; }
    }
}
