using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.Property(p => p.DateFrom).IsRequired();
            builder.Property(p => p.DateTo).IsRequired();
            builder.HasOne(r => r.Resource).WithMany()
                .HasForeignKey(r => r.ResourceId);
        }
    }
}
