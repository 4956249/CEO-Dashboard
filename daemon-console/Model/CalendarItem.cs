using System;
using System.Collections.Generic;
using System.Text;

namespace daemon_console.Model
{
    class CalendarItem
    {
        public string body { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Location { get; set; }
        public string Attendees { get; set; }
        public string Subject { get; set; }
    }
}
