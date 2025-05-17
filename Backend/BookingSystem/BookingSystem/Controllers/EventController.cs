using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookingSystem.DTOs;
using BookingSystem.Models;
using BookingSystem.Services;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using BookingSystem.Services.Authentication;
using BookingSystem.Models.EventManagement;
using BookingSystem.Services.EventServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventService eventService;

        public EventController(EventService eventService)
        {
            this.eventService = eventService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddEvent([FromBody] EventDTO newEvent)
        {
            //var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userIdString = "5E6B9465-51AC-435C-C52D-08DD954374A3";
            //if (string.IsNullOrEmpty(userIdString))
            //{
            //    return Unauthorized("Please sign in as an Admin first.");
            //}

            if (!Guid.TryParse(userIdString, out Guid userGuid))
            {
                return BadRequest("Invalid Admin ID.");
            }
            //Console.WriteLine("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWww",userGuid);
            if (ValidationService.isEmptyDTO(newEvent)){
                return BadRequest("fill required fields to proceed");
            }
            var createdEvent = await eventService.CreateEvent(newEvent, newEvent.Tags, userGuid);

            return Ok(newEvent);
        }

        [HttpGet("All")]
        public async Task<IActionResult> getAllEvents()
        {
            var Events = await eventService.getAllEvents();
            return Ok(Events);
        }
    }
}
