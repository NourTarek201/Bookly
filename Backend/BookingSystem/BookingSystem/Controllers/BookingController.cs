using BookingSystem.DTOs;
using BookingSystem.services.EventServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.Controllers
{
    public class BookingController: ControllerBase
    {
        private readonly BookingService bookingService;
        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Customer")]
        [HttpPost("BookEvent")]
        public async Task<IActionResult> BookEvent(Guid EventId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("Please sign in as an Customer first.");
            }

            if (!Guid.TryParse(userIdString, out Guid userGuid))
            {
                return BadRequest("Invalid Customer ID");
            }
            var Event = await bookingService.BookEvent(EventId,userGuid);
            if(Event == null)
            {
                return BadRequest("No events found");
            }
            return Ok("Event Booked");
        }
    }
}
