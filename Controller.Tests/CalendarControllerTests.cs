using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using Xunit;


namespace Controller.Tests
{
    public class CalendarControllerTests
    {
        [Fact]
        public async void TestGetCalendar()
        {
               
                Logic logic = new Logic();
                CalendarController calendarController = new CalendarController(logic);
               

                var getCalendar = await calendarController.GetCalendar();

                Assert.NotNull(getCalendar);

            
        }

        [Fact]
        public async void TestGetMyEvents()
        {
          
                Logic logic = new Logic();
                CalendarController calendarController = new CalendarController(logic);

                var events = new EventDto
                {
                    Description = "Basketball game",
                    Location = "Los Angeles",
                    Message = "February 26",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.UtcNow
                };

              

                var getCalendar = await calendarController.GetMyEvents();

                Assert.NotNull(getCalendar.GetMyEvents());


            }
        }


        [Fact]
        public async void TestEditEvent()
        {
          
            Logic logic = new Logic();
            CalendarController calendarController = new CalendarController(logic);

        var events = new EventDto
        {
            Description = "Basketball game",
            Location = "San Francisco",
            Message = "February 27",
            StartTime = DateTime.Now,
            EndTime = DateTime.UtcNow
        };

  

        var getCalendar = await calendarController.EditEvent(events);

        Assert.NotNull(getCalendar);

    
}

         [Fact]
        public async void TestDeleteEvent()
        {
           
            Logic logic = new Logic();
            CalendarController calendarController = new CalendarController(logic);
                
        var events = new EventDto
        {
            Description = "Basketball game",
            Location = "Los Angeles",
            Message = "February 26",
            StartTime = DateTime.Now,
            EndTime = DateTime.UtcNow
        };

       

        var getCalendar = await calendarController.GetCalendar();

        Assert.NotNull(getCalendar);

    
}



        [Fact]
        public async void TestEditEvent()
        {
            
            Logic logic = new Logic();
            CalendarController calendarController = new CalendarController(logic);

            var events = new EventDto
        {
            Description = "Basketball game",
            Location = "Los Angeles",
            Message = "February 26",
            StartTime = DateTime.Now,
            EndTime = DateTime.UtcNow
        };

           

            var getCalendar = await calendarController.EditEvent("12345");

        Assert.NotNull(getCalendar);

            
    
}

        [Fact]
        public async void TestDeleteEvent()
    {
        Logic logic = new Logic();
        CalendarController calendarController = new CalendarController(logic);

        var events = new EventDto
        {
            Description = "Basketball game",
            Location = "Los Angeles",
            Message = "February 26",
            StartTime = DateTime.Now,
            EndTime = DateTime.UtcNow
        };


        var getCalendar = await calendarController.DeleteEvent("12345");

        Assert.NotNull(getCalendar);

    }
}
