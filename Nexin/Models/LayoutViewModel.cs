using Microsoft.AspNetCore.Http;

namespace Nexin.Models
{
    public class LayoutViewModel
    {
        public string Renk { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile BeyazLogo { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string FaceLink { get; set; }
        public string InstagramLink { get; set; }
        public string LinkedLink { get; set; }
        public string Slogan { get; set; }
        public string Adres { get; set; }
    }
}
