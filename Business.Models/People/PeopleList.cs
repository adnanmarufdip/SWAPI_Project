using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.People
{
    public class PeopleList
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
        public IEnumerable<Person> Results { get; set; }
    }
}
