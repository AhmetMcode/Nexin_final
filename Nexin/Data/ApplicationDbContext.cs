using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nexin.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<UstBar> ustBars { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<HizmetlerAlt> HizmetlerAlts { get; set; }
        public DbSet<LayoutAyar> LayoutAyars { get; set; }
        public DbSet<YararliLinkler> YararliLinklers { get; set; }
        public DbSet<AnaSayfa> AnaSayfalar { get; set; }
        public DbSet<Sayfa> Sayfa { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AnaSayfaHakkindaResimler> AnaSayfaHakkindaResimlers { get; set; }
        public DbSet<HakkimizdaAnaSayfa> HakkimizdaAnaSayfa { get; set; }
        public DbSet<Referanslar> Referanslars { get; set; }
        public DbSet<AnaSayfaSeciton3> AnaSayfaSeciton3 { get; set; }
        public DbSet<SSS> SSS { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<AnaSayfaTamamlanmis> AnaSayfaTamamlanmis { get; set; }
        public DbSet<AnaSayfaResim> AnaSayfaResimler { get; set; }
        public DbSet<Servisler> Servisler { get; set; }
        public DbSet<Ortaklar> Ortaklar { get; set; }
    }
}
