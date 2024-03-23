using Business.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Services
{
    public interface IPeopleService
    {
        Task<PeopleList> GetPeopleAsync(int pageNumber, int pageSize);
        Task<Person> GetPersonDetailsAsync(string url);
    }
}
