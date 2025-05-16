using BookingSystem.Models.EventManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingSystem.Configurations
{
    public class BookedEventConfiguration: IEntityTypeConfiguration<BookedEvent>
    {
        public void Configure(EntityTypeBuilder<BookedEvent> builder)
        {
            //composite prim key for BookedEvent
            builder.HasKey(be => new { be.EventId, be.CustomerId });

            //M-M

            //1- M
            builder.HasOne(be => be.Event)
                .WithMany(e => e.BookedEvents)
                .HasForeignKey(be => be.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            //1-M
            builder.HasOne(be => be.Customer)
                .WithMany(c => c.BookedEvents)
                .HasForeignKey(be => be.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("BookedEvent");
        }
    }
}
