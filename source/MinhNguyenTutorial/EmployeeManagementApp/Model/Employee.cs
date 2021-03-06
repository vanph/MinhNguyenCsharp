﻿using System;

namespace EmployeeManagementApp.Model
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName{ get; set; }
        public string FristName{ get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string PhotoPath { get; set; }
        public string FullName => $"{TitleOfCourtesy} {FristName} {LastName}";
        public string FullAddress => $"{Address},{City},{ Region} ,{ Country}";
    }
}
