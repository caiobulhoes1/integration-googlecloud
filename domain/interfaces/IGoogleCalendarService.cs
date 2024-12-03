using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.interfaces
{
    public interface IGoogleCalendarService
    {
        IList<Event> GetEvents(string calendarId = "primary");
    }
}
