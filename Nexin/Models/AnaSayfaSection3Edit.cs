using Microsoft.AspNetCore.Http;

namespace Nexin.Models
{
    public class AnaSayfaSection3Edit
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string AltYazi { get; set; }
        public string Icerik1 { get; set; }
        public string Icerik2 { get; set; }
        public string Icerik3 { get; set; }
        public string Icerik4 { get; set; }
        public string Icerik5 { get; set; }
        public string Icerik6 { get; set; }
        public IFormFile ResimSol { get; set; }
        public IFormFile ResimOynar { get; set; }
    }
}
