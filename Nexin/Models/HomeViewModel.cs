using Nexin.Entity;
using System.Collections.Generic;

namespace Nexin.Models
{
    public class HomeViewModel
    {
        public List<AnaSayfaHakkindaResimler> AnaSayfaHakkindaResimler { get; set; }
        public List<Hizmet> Hizmets { get; set; }
        public HakkimizdaAnaSayfa HakkimizdaAnaSayfa { get; set; }
        public AnaSayfaTamamlanmis AnaSayfaTamamlanmis { get; set; }
        public AnaSayfaSeciton3 AnaSayfaSeciton3 { get; set; }
        public List<Blog> Bloglar{ get; set; }
        public List<Referanslar> Referanslar { get; set; }
        public List<Ortaklar> Ortaklar { get; set; }
        public List<Servisler> Servisler { get; set; }
    }
}
