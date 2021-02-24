using CalendarService;
using System;
using Xunit;
using Service;
using System.Threading.Tasks;
using Models.DataTransfer;
using System.Collections.Generic;
using Google.Apis.Calendar.v3.Data;

namespace Service.Tests
{
    public class ServiceTest
    {
        [Fact]
        public async void TestInitializeCalendar()
        {
            Logic logic = new Logic();

            var getLogic = await Logic.InitializeCalendar();

            Assert.NotNull(getLogic);


        }

        [Fact]
        public async void TestGetCalendar()
        {
            Logic logic = new Logic();

            var getCalendar = await Logic.GetCalendar();

            Assert.NotNull(getCalendar);
        }


        [Fact]
        public async void TestGetMyEvents()
        {
            Logic logic = new Logic();

            var getEvents = await Logic.GetMyEvents();

            Assert.NotNull(getEvents);

        }

        [Fact]
        public async void TestCreateAndDeleteEvent()
        {
            Logic logic = new Logic();

            var events = new EventDto
            {
                Description = "Basketball game",
                Location = "Los Angeles",
                Message = "February 26",
                StartTime = DateTime.Now,
                EndTime = DateTime.UtcNow
            };

            var createEvent = await Logic.CreateEvent(events);

            Assert.NotNull(createEvent);
            var deleteEvent = Logic.DeleteEvent(createEvent.Id);


        }

    }
}
