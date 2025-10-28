﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        /*
         
        Repository nedir
        ?
        Repository pattern, veri erişim katmanını soyutlamak ve yönetmek için kullanılan bir tasarım desenidir. 
        Bu desen, veri kaynaklarına (örneğin, veritabanları, web servisleri, dosyalar) 
        erişimi merkezi bir şekilde yönetmeyi amaçlar. Repository pattern'in temel amacı, 
        veri erişim kodunu iş mantığından ayırmak ve böylece kodun daha temiz, 
        test edilebilir ve sürdürülebilir olmasını sağlamaktır.
        
         
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=desktop-af2jbbh;database=CorePortfolioDB;integrated security=true;");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
