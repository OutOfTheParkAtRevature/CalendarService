using Microsoft.Extensions.Logging;
using Models.DataTransfer;
using Service;
using System;
using Xunit;

namespace CalendarService.Tests
{
    public class CalendarControllerTests
    {
        [Fact]
        public async void TestGetCalendar()
        {

            Logic logic = new Logic();
            CalendarController calendarController = new CalendarController(null);


            var getCalendar = await calendarController.GetCalendar();

            Assert.NotNull(getCalendar);


        }

        [Fact]
        public async void TestGetMyEvents()
        {

            Logic logic = new Logic();
            CalendarController calendarController = new CalendarController(null);

            var events = new EventDto
            {
                Description = "Basketball game",
                Location = "Los Angeles",
                Message = "February 26",
                StartTime = DateTime.Now,
                EndTime = DateTime.UtcNow
            };



            var getCalendar = await calendarController.GetMyEvents();

            Assert.NotNull(getCalendar);

        }

            [Fact]
            public async void TestCreateEvent()
            {

                Logic logic = new Logic();
                CalendarController calendarController = new CalendarController(null);

                var events = new EventDto
                {
                    Description = "Basketball game",
                    Location = "San Francisco",
                    Message = "February 27",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.UtcNow
                };



                var getCalendar = await calendarController.CreateEvent(events);

                Assert.NotNull(getCalendar);


            }
    }
}
