using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;

namespace CheckInAppMobile {
    public static class Query {
        private static string connectionString = @"data source=.\SQLEXPRESS;initial catalog=PhoneCheckIn;Trusted_Connection=True;";
        private static Dictionary<string, Models.EventType> eventTypes = Globals.EventTypes;
        #region Methods

        public static object Event(SqlCommand command, Models.EventType eventType) {
            int deviceID = Globals.DeviceID;
            Models.Student student = Globals.Student;
            command.Parameters.AddWithValue("@DeviceID", SqlDbType.Int).Value = deviceID;
            command.Parameters.AddWithValue("@EventType", SqlDbType.NVarChar).Value = eventTypes[eventType.EventTypeName].EventTypeName;
            command.Parameters.AddWithValue("@EventTypeID", SqlDbType.Int).Value = eventTypes[eventType.EventTypeName].EventTypeID;
            command.Parameters.AddWithValue("@Username", SqlDbType.NVarChar).Value = student.Username;
            command.Parameters.AddWithValue("@Firstname", SqlDbType.NVarChar).Value = student.Firstname;
            command.Parameters.AddWithValue("@Lastname", SqlDbType.NVarChar).Value = student.Lastname;
            //command.Parameters.AddWithValue("@Time", DateTime.Now);
            return 1;
        }

        public static object FindAll(SqlCommand command, Models.EventType eventType = null) {
            var returnParameter = command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            return returnParameter.Value;
        }


        #endregion

        private static SqlConnection Connection { get; set; } = new SqlConnection(connectionString);

        public delegate object StoredProcedureCommand(SqlCommand command, Models.EventType eventType = null);

        public static void Insert(string storedProcedure, StoredProcedureCommand spFunction, Models.EventType eventType) {
            Connection.Open();
            SqlCommand command = new SqlCommand(storedProcedure, Connection);
            command.CommandType = CommandType.StoredProcedure;
            spFunction(command, eventType);
            Connection.Close();
        }

        public static object Read(string storedProcedure, StoredProcedureCommand spFunction, Models.EventType eventType) {
            Connection.Open();
            SqlCommand command = new SqlCommand(storedProcedure, Connection);
            command.CommandType = CommandType.StoredProcedure;
            object data = spFunction(command);
            Connection.Close();
            return data;
        }
    }
}
