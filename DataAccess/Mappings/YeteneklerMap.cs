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
    public class YeteneklerMap : IEntityTypeConfiguration<Yetenekler>
    {
        public void Configure(EntityTypeBuilder<Yetenekler> builder)
        {
           builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.YetenekAdi).HasMaxLength(200);
          
        

            builder.HasOne(x => x.users).WithMany(x => x.yetenekler).HasForeignKey(x => x.UsersId);

            builder.ToTable("Yetenekler");

        }
    }
}
