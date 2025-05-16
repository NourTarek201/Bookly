using BookingSystem.Models.EventManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.Configurations
{
    public class EventTagConfigurations: IEntityTypeConfiguration<EventTag>
    {
        public void Configure(EntityTypeBuilder<EventTag> builder)
        {
            //composite prim key for EventTag
            builder.HasKey(be => new { be.EventId, be.TagId });

            //M-M

            //1-M
            builder.HasOne(be => be.Event)
                .WithMany(e => e.EventTags)
                .HasForeignKey(be => be.EventId);

            //1-M
            builder.HasOne(be => be.Tag)
                .WithMany(c => c.EventTags)
                .HasForeignKey(be => be.TagId);
        }
    
    }
}
