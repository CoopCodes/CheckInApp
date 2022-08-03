using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections;

namespace CheckInAppMobile {
    static class Globals {
        public static Dictionary<string, Models.EventType> EventTypes { get; set; }

        public static Models.Student Student { get; set; }
        public static int DeviceID { get; set; }
        public static ArrayList Students { get; set; }
        public static ArrayList Devices { get; set; }
        public static ArrayList DeviceIDs { get; set; }

        static Globals() {
            try {
                Student = new Models.Student(0, "", "", "", 0);
                Students = (ArrayList)Query.Read("spStudents_Read", Query.FindAll, null);
                Devices = (ArrayList)Query.Read("spDevices_Read", Query.FindAll, null);
                EventTypes = (Dictionary<string, Models.EventType>)Query.Read("spEventTypes_Read", Query.FindAll, null);
            }
            catch {
                throw new NotImplementedException();
            }
        }
    }
}
