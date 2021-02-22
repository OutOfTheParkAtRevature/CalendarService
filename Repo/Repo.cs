using Microsoft.Extensions.Logging;
using System;

namespace Repository
{
    public class Repo
    {
        private readonly CalendarContext _calendarContext;
        private readonly ILogger _logger;

        public Repo(CalendarContext messageContext, ILogger<Repo> logger)
        {
            _calendarContext = messageContext;
            _logger = logger;
        }
    }
}
