using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion_tek_technical_interview.Models
{
    public class Address
    {
        public int AddressId {get; set;}
        public int CustomerId {get; set;}
        public int CountryId {get; set;}
        public int CityId {get; set;}
        public int StateId {get; set;}
        public string AddressDetail {get; set;}
        public string Specification {get; set;}
        public string ZipCode {get; set;}

        public Customer Customer {get; set;}
        public Country Country {get; set;}
        public City City {get; set;}
        public State State {get; set;}
    }
}