using Microsoft.AspNetCore.Http;

namespace Nexin.Models
{
    public class ProjeEkleViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string AltAd { get; set; }
        public IFormFile KapakResimi { get; set; }
        public IFormFile AnaResim { get; set; }
        public IFormFile AnaResim1 { get; set; }
        public IFormFile AnaResim2 { get; set; }
        public string Video { get; set; }
        public string Icerik { get; set; }
        public string MetaTaglar { get; set; }
        public string Url { get; set; }
    }
}
