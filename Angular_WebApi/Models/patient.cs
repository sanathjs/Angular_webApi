using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular_WebApi.Models
{
    public class patient
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public string DateOfRegistration { get; set; }
    }
}