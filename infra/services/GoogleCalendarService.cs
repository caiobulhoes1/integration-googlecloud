using domain.interfaces;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace domain.services
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private readonly CalendarService _calendarService;

        public GoogleCalendarService(IGoogleCredentialProvider credentialProvider)
        {
            var credential = credentialProvider.GetUserCredential();
            _calendarService = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Web Application - Google Calendar"
            });
        }
        public IList<Event> GetEvents(string calendarId = "primary")
        {
            var request = _calendarService.Events.List(calendarId);
            request.TimeMinDateTimeOffset = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute().Items;
        }
    }
}
