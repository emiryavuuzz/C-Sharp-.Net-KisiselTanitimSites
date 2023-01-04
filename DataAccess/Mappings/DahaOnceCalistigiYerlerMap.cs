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
    public class DahaOnceCalistigiYerlerMap : IEntityTypeConfiguration<DahaOnceCalistigiYerler>
    {
        public void Configure(EntityTypeBuilder<DahaOnceCalistigiYerler> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.kurumAdi).HasMaxLength(250);
            builder.Property(x => x.CalistigiRutbe).HasMaxLength(250);
            builder.Property(x => x.CalistigiAlan).HasMaxLength(250);
            builder.Property(x => x.IseGirisTarihi).HasColumnType("datetime");
            builder.Property(x => x.IstenCikisTarihi).HasColumnType("datetime");
            builder.Property(x => x.IsYeriKonumu).HasMaxLength(250);

            builder.HasOne(x => x.users).WithMany(x => x.DahaOnceCalistigiYerlers).HasForeignKey(x => x.UsersId);

            builder.ToTable("DahaOnceCalistigiYerler");

        }
    }
}
