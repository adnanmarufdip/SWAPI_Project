using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.People
{
    public class Person
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public PersonProperties Properties { get; set; }

        public class PersonProperties
        {
            public string Height { get; set; }
            public string Mass { get; set; }
            public string HairColor { get; set; }
            public string SkinColor { get; set; }
            public string EyeColor { get; set; }
            public string BirthYear { get; set; }
            public string Gender { get; set; }
            public string HomeWorld { get; set; }
        }
    }
}
