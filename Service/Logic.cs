using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Models.DataTransfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Service                                           //Need to add json credential file, change jsonFile string, change ApplicationName, change CalendarId
{
    public class Logic
    {
        /// <summary>
        /// Initialize Calendar service with credentials
        /// </summary>
        /// <returns>Calendar service</returns>
        public static async Task<CalendarService> InitializeCalendar()
        {
            string jsonFile = "p2nullreturners-997092916366.json";
            string[] Scopes = { CalendarService.Scope.Calendar };
            ServiceAccountCredential credential;
            await using (var stream =
                new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var config = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(config.ClientEmail)
                   {
                       Scopes = Scopes
                   }.FromPrivateKey(config.PrivateKey));
            }
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "P2NullReturners",
            });
            return service;
        }
        /// <summary>
        /// Get a Calendar by ID
        /// </summary>
        /// <param name="service">Calendar service</param>
        /// <returns>Calendar</returns>
        public static async Task<Calendar> GetCalendar()
        {
            CalendarService service = await InitializeCalendar();
            string calendarId = @"a6jdhdbp5mpv8au8mbps8qfelk@group.calendar.google.com";
            var calendar = await service.Calendars.Get(calendarId).ExecuteAsync();
            return calendar;
        }
        /// <summary>
        /// Get list of Events from Calendar
        /// </summary>
        /// <param name="service">Calendar service</param>
        /// <returns>list of Events</returns>
        public static async Task<IEnumerable<Event>> GetMyEvents()
        {
            CalendarService service = await InitializeCalendar();
            string calendarId = @"a6jdhdbp5mpv8au8mbps8qfelk@group.calendar.google.com";
            EventsResource.ListRequest listRequest = service.Events.List(calendarId);
            listRequest.TimeMin = DateTime.Now;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 10;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = await listRequest.ExecuteAsync();
            List<Event> eventList = new List<Event>();
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    eventList.Add(eventItem);
                }
            }
            return eventList;
        }
        /// <summary>
        /// Create a new Event on Calendar
        /// </summary>
        /// <param name="service">Calendar service</param>
        /// <param name="eventDto">Event info from input</param>
        /// <returns>Calendar Event</returns>
        public static async Task<Event> CreateEvent(EventDto eventDto)
        {
            CalendarService service = await InitializeCalendar();
            string calendarId = @"a6jdhdbp5mpv8au8mbps8qfelk@group.calendar.google.com";
            EventDateTime start = new EventDateTime()
            {
                DateTime = eventDto.StartTime
            };
            EventDateTime end = new EventDateTime()
            {
                DateTime = eventDto.EndTime
            };
            var myevent = new Event()
            {
                Start = start,
                End = end,
                Location = eventDto.Location,
                Summary = eventDto.Description,
                Description = eventDto.Message
            };
            var insertRequest = service.Events.Insert(myevent, calendarId);
            try
            {
                await insertRequest.ExecuteAsync();
            }
            catch (Exception)
            {
                try
                {
                    await service.Events.Update(myevent, calendarId, myevent.Id).ExecuteAsync();
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return myevent;
        }
        public static async Task<Event> EditEvent(EventDto eventDto, string Id)
        {
            CalendarService service = await InitializeCalendar();
            string calendarId = @"a6jdhdbp5mpv8au8mbps8qfelk@group.calendar.google.com";
            EventDateTime start = new EventDateTime()
            {
                DateTime = eventDto.StartTime
            };
            EventDateTime end = new EventDateTime()
            {
                DateTime = eventDto.EndTime
            };
            var myevent = new Event()
            {
                Start = start,
                End = end,
                Location = eventDto.Location,
                Summary = eventDto.Description,
                Description = eventDto.Message,
                Id = Id
            };
            var updateRequest = service.Events.Update(myevent, calendarId, myevent.Id);
            try
            {
                await updateRequest.ExecuteAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return myevent;
        }
        public static async Task<string> DeleteEvent(string eventId)
        {
            CalendarService service = await InitializeCalendar();
            string calendarId = @"a6jdhdbp5mpv8au8mbps8qfelk@group.calendar.google.com";
            var status = await service.Events.Delete(calendarId, eventId).ExecuteAsync();
            return status;
        }
    }
}
