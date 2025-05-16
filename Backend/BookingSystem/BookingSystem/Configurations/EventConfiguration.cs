using BookingSystem.Models.EventManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.Configurations
{
    public class EventConfigurations : IEntityTypeConfiguration<Event>
    {

        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(p => p.Price).HasColumnType("money");

            // venue 1 -M events
            builder.HasOne(p => p.Venue)
                .WithMany(p => p.Events)
                .HasForeignKey(p => p.VenueId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
