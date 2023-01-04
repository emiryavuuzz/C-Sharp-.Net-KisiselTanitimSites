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
    public class ServislerMap : IEntityTypeConfiguration<Servisler>
    {
        public void Configure(EntityTypeBuilder<Servisler> builder)
        {
           builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ServisAdi).HasMaxLength(200);
            builder.Property(x => x.ServisAciklama).HasMaxLength(400);

            builder.HasOne(x => x.users).WithMany(x => x.servisler).HasForeignKey(x => x.UsersId);

            builder.ToTable("Servisler");

        }
    }
}
