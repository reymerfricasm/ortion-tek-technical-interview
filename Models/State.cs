using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orion_tek_technical_interview.Models
{
    public class State
    {
        public int StateId {get; set;}
        public string Name {get; set;}
        public int CityId {get; set;}
        public City City {get;set;}

        public IEnumerable<Address> Adresses {get; set;}
    }
}