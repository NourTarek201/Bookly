using BookingSystem.Models.EventManagement;
using BookingSystem.Models.Users;
using BookingSystem.Repositories;
using BookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.services.EventServices
{
    public class BookingService
    {
        UserManager<BaseUser> userManager;
        EventRepository eventRepository;
        BookedEventRepository bookedEventRepository;
        public BookingService(UserManager<BaseUser> userManager, EventRepository eventRepository, BookedEventRepository bookedEventRepository)
        {
            this.userManager = userManager;
            this.eventRepository = eventRepository;
            this.bookedEventRepository = bookedEventRepository;
        }
        public async Task<Event> BookEvent(Guid EventId, Guid userId)
        {
            BaseUser customer = await userManager.FindByIdAsync(userId.ToString());
            if(customer == null)
            {
                throw new Exception("User not found");
            }
            Event bookedEvent = await eventRepository.getById(EventId);
            if(bookedEvent==null)
            {
                throw new Exception("Event not found");
            }
            var isEventBooked = await bookedEventRepository.isBooked(EventId, userId);
            if(isEventBooked)
            {
                throw new Exception("Event already booked by user");
            }
            bookedEvent.BookedEvents.Add(
                new BookedEvent
                {
                    CustomerId=userId,
                }
            );
            return await eventRepository.update(bookedEvent);
        }
    }
}
