using System;
using System.Collections.Generic;
using System.Text;

namespace CheckInApp.Models {
    public class Student {
        public int StudentID { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Grade { get; set; }

        public Student(int studentID, string username, string firstname, string lastname, int grade) {
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
            StudentID = studentID;
            Grade = grade;
        }
    }
}
