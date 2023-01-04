using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappings
{
    public class ProjelerMap : IEntityTypeConfiguration<Projeler>
    {
        public void Configure(EntityTypeBuilder<Projeler> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ProjeAdi).HasMaxLength(200);
            builder.Property(x => x.ProjeAmaci).HasMaxLength(400);
            builder.Property(x => x.ProjeCategory).HasMaxLength(100);
            builder.Property(x => x.ProjeninYapildigiKurum).HasMaxLength(200);
            builder.Property(x => x.ProjeAlanAdi).HasMaxLength(200);
            builder.Property(x => x.YapilisTarihi).HasColumnType("datetime");

            builder.HasOne(x => x.users).WithMany(x => x.projeler).HasForeignKey(x => x.UsersId);

            builder.ToTable("Projeler");

        }
    }
}
