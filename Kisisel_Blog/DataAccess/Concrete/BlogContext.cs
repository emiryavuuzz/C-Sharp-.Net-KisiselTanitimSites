using DataAccess.Mappings;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BlogContext:DbContext
    {
       
        public DbSet<Users> Users { get; set; }
        public DbSet<DahaOnceCalistigiYerler> DahaOnceCalistigiYerlers { get; set; }
        public DbSet<Egitim> egitim { get; set; }
        public DbSet<Projeler> projeler { get; set; }
        public DbSet<Servisler> servisler { get; set; }
        public DbSet<Sertifikalar> sertifikalar { get; set; }
        public DbSet<Yetenekler> yetenekler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-Q6LCBONF\SQLEXPRESS;Initial Catalog=KisiselBlogDatas;Integrated Security=True;TrustServerCertificate=True");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new EgitimMap());
            modelBuilder.ApplyConfiguration(new DahaOnceCalistigiYerlerMap());
            modelBuilder.ApplyConfiguration(new ProjelerMap());
            modelBuilder.ApplyConfiguration(new SertifikalarMap());
            modelBuilder.ApplyConfiguration(new ServislerMap());
            modelBuilder.ApplyConfiguration(new YeteneklerMap());
        }
    }
}
