using BookingSystem.DTOs;
using BookingSystem.Models.EventManagement;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Repositories;
using BookingSystem.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
namespace BookingSystem.services.EventServices
{
    public class EventService 
    {
        EventRepository eventRepository;
        TagRepository tagRepository;
        CategoryRepository categoryRepository;
        VenueRepository venueRepository;
        AddressRepository addressRepository;
        IBaseRepository<EventTag> eventTagRepository;

        public EventService(EventRepository eventRepository, VenueRepository venueRepository, CategoryRepository categoryRepository,
            TagRepository tagRepository, AddressRepository addressRepository)
        {
            this.eventRepository = eventRepository;
            this.venueRepository = venueRepository;
            this.categoryRepository = categoryRepository;
            this.tagRepository = tagRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<Event> CreateEvent(EventDTO newEvent, TagDTO tag, Guid adminId)
        {
            var address = new Address
            {
                buildingNo = newEvent.Address.buildingNo,
                Street = newEvent.Address.Street,
                City = newEvent.Address.City,
                Country = newEvent.Address.Country
            };
            Guid addressId;
            var existAddress = await addressRepository.getExistAddress(address);
            if (existAddress==null)
            {
                existAddress = await addressRepository.add(address);
            }
            addressId = existAddress.Id;

            Category category = new Category
            {
                Name = newEvent.CategoryName
            };
            Guid categoryId;
            var existCategory = await categoryRepository.getByName(category.Name);
            if (existCategory == null)
            {
                existCategory = await categoryRepository.add(category);
                
            }
            categoryId = existCategory.Id;


            Venue Venue = new Venue
            {
                Name = newEvent.VenueName,
                PhoneNumber = newEvent.VenuePhone,
                AddressId = addressId
            };
            Venue existVenue = await venueRepository.getExistVenue(Venue, existAddress);
            Guid venueId;
            if (existVenue == null)
            {
                existVenue = await venueRepository.add(Venue);
            }
            venueId = existVenue.Id;

            List<Tag>Tags= await getTags(tag);

            var createdEvent = new Event
            {
                Name = newEvent.Name,
                Description = newEvent.Description,
                Date = newEvent.Date,
                Price = newEvent.Price,
                ImageUrl = newEvent.ImageUrl,
                VenueId = venueId,
                CategoryId = categoryId,
                AdminId=adminId
            };

            if (!Tags.IsNullOrEmpty())
            {
                foreach (var i in Tags)
                {
                    createdEvent.EventTags.Add(new EventTag
                    {
                        TagId = i.Id
                    });

                }

            }
            return await eventRepository.add(createdEvent);
        }


        public async Task<List<Tag>> getTags(TagDTO tag)
        {
            var tagList = new List<Tag>();
            foreach (var t in tag.Tags)
            {
                Tag existTag = await tagRepository.getByName(t);

                if (existTag==null){
                    var newTag = new Tag
                    {
                        Name = t,
                    };
                    existTag=await tagRepository.add(newTag);
                }
                tagList.Add(existTag);
            }
            return tagList;
        }

        public async Task<List<EventDTO>> getAllEvents()
        {
            var events = await eventRepository.getAll();
            var eventsDTOs = events.Select(e => new EventDTO
            {
                Name = e.Name,
                Description = e.Description,
                Date = e.Date,
                Price = e.Price,
                ImageUrl = e.ImageUrl,
                CategoryName = e.Category.Name,
                VenueName = e.Venue.Name,
                VenuePhone=e.Venue.PhoneNumber,
                Address = new AddressDTO
                {
                    City = e.Venue.Address.City,
                    Street = e.Venue.Address.Street,
                    Country = e.Venue.Address.Country
                },
                Tags = new TagDTO
                {
                    Tags = e.EventTags?.Select(et => et.Tag.Name).ToList()
                }

            }).ToList();

            return eventsDTOs;
        }

    }
}
