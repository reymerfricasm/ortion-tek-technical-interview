using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion_tek_technical_interview.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name {get; set;}
        public string Nickname {get;set;}
        public string LastName {get; set;}
        public string IdNumber {get; set;}
        public DateTime Birthdate {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}
        public bool Inactive {get;set;}

        public IEnumerable<Address> Adresses {get; set;}
    }
}