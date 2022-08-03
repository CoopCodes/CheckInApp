using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInAppMobile.Models {
    public class EventType {
        public int EventTypeID { get; set; }
        public string EventTypeName { get; set; }

        public EventType(int eventTypeID, string eventTypeName) {
            EventTypeID = eventTypeID;
            EventTypeName = eventTypeName;
        }
    }
}
