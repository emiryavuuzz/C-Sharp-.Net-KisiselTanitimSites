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
    public class EgitimMap : IEntityTypeConfiguration<Egitim>
    {
        public void Configure(EntityTypeBuilder<Egitim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.OkulAdi).HasMaxLength(250);
            builder.Property(x => x.BolumAdi).HasMaxLength(250);
            builder.Property(x => x.BaslamaYili).HasColumnType("datetime");
            builder.Property(x => x.MezuniyetYili).HasColumnType("datetime");

            builder.HasOne(x => x.users).WithMany(x => x.egitim).HasForeignKey(x => x.UsersId);

            builder.ToTable("Egitim" +
                "");
        }
    }
}
