using Nexin.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nexin.Entity
{
    public class Hizmet
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string AltAd { get; set; }
        public string KapakResimi { get; set; }
        public string AnaResim { get; set; }
        public string AnaResim1 { get; set; }
        public string AnaResim2 { get; set; }
        public string Video { get; set; }
        public string Icerik { get; set; }
        public string MetaTaglar { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public AddMessageViewModel Iletisim { get; set; }
    }


}
