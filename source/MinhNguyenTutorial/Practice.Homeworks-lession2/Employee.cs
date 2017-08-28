﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Homeworks_lession2
{
    class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FristName { get; set; }
        public string Title{ get; set; }
        public string TitleOfCourtesy { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string PhotoPath { get; set; }

        public string GetDetail()
        {
            return  $"{TitleOfCourtesy} { FristName} {LastName} {Title} {BirthDate} {Address},{City},{Region},{Country} {HomePhone}" ;
        }


    }
}
