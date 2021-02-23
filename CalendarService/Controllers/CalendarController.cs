using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CalendarService
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CalendarController : ControllerBase
    {
        private readonly ILogger<CalendarController> _logger;
        public CalendarController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Calendar>> GetCalendar()
        {
            return await Logic.GetCalendar();
        }

        [HttpGet("events")]
        [Authorize]
        public async Task<IEnumerable<Event>> GetMyEvents()
        {
            return await Logic.GetMyEvents();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Event>> CreateEvent(EventDto eventDto)
        {
            var ret = await Logic.CreateEvent(eventDto);
            if (ret == null)
            {
                return BadRequest("Event not created");
            }
            return ret;
        }

        [HttpPut("events/{id}")]
        [Authorize]
        public async Task<ActionResult<Event>> EditEvent(EventDto eventDto, string id)
        {
            return await Logic.EditEvent(eventDto, id);
        }

        [HttpDelete("events/{id}")]
        [Authorize]
        public async Task<ActionResult<string>> DeleteEvent(string id)
        {
            return await Logic.DeleteEvent(id);
        }
    }
}
