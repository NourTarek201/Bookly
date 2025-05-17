using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BookingSystem.DTOs;
using BookingSystem.Models;
using BookingSystem.services;
using BookingSystem.Models.PlaceManagement;
using BookingSystem.Models.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using BookingSystem.services.Authentication;
using BookingSystem.Models.EventManagement;
using BookingSystem.services.EventServices;
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

        [Authorize(AuthenticationSchemes = "Bearer",Roles = "Admin")]
        [HttpPost("Add")]
        public async Task<IActionResult> AddEvent([FromBody] EventDTO newEvent)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userIdString))
            {
                return Unauthorized("Please sign in as an Admin first.");
            }

            if (!Guid.TryParse(userIdString, out Guid userGuid))
            {
                return BadRequest("Invalid Admin ID.");
            }
            if (ValidationService.isEmptyDTO(newEvent)){
                return BadRequest("fill required fields to proceed");
            }
            var createdEvent = await eventService.CreateEvent(newEvent, newEvent.Tags, userGuid);

            return Ok(newEvent);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Customer")]
        [HttpGet("All")]
        public async Task<IActionResult> getAllEvents()
        {
            var Events = await eventService.getAllEvents();
            return Ok(Events);
        }
    }
}
