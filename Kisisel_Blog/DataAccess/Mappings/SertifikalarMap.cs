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
    public class SertifikalarMap : IEntityTypeConfiguration<Sertifikalar>
    {
        public void Configure(EntityTypeBuilder<Sertifikalar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.SertifikaAdi).HasMaxLength(150);
            builder.Property(x => x.VerenKurum).HasMaxLength(200);
            builder.Property(x => x.AlinanTarih).HasColumnType("datetime");

            builder.HasOne(x => x.users).WithMany(x => x.sertifikalar).HasForeignKey(x => x.UsersId);

            builder.ToTable("Sertifikalar");


        }
    }
}
