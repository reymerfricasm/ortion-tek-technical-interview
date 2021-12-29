using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion_tek_technical_interview.Models
{
    public class Country
    {
        public int CountryId {get; set;}
        public string Name {get; set;}
        public IEnumerable<City> Cities {get; set;}
        public IEnumerable<Address> Adresses {get; set;}
    }
}