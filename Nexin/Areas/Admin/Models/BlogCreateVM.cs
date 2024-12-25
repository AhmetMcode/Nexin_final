using Microsoft.AspNetCore.Http;

namespace Nexin.Areas.Admin.Models
{
    public class BlogCreateVM
    {
        public string Baslik { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public string KisaAciklama { get; set; }
        public string Url { get; set; }
        public IFormFile ResimYolu { get; set; }

    }
}
