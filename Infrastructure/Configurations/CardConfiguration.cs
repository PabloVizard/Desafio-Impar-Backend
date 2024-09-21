using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Reflection.Emit;

namespace Infrastructure.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Card");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property<int?>("PhotoId");

            builder.Property(c => c.Status)
            .HasConversion<string>(); 

            builder.HasOne<Photo>()
                   .WithMany()
                   .HasForeignKey("PhotoId")
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
