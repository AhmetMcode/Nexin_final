using Nexin.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexin.Entity
{
    public class Servisler
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string KucukYazi { get; set; }
        public string UzunYazi { get; set; }
        public string Resim { get; set; }
        public string Icon { get; set; }
        public string MetaTaglar { get; set; }

        [NotMapped]
        public AddMessageViewModel Iletisim { get; set; }
    }
}
