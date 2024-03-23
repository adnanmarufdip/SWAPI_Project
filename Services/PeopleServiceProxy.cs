using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Services.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Business.Models.People;


namespace SWAPI_Project.Services
{
    public class PeopleServiceProxy : IPeopleService
    {
        private readonly IPeopleService _peopleService;

        public PeopleServiceProxy(HttpClient httpClient)
        {
            _peopleService = new PeopleService(httpClient);
        }

        public Task<PeopleList> GetPeopleAsync(int pageNumber, int pageSize)
        {
            return _peopleService.GetPeopleAsync(pageNumber, pageSize);
        }

        public Task<Person> GetPersonDetailsAsync(string url)
        {
            return _peopleService.GetPersonDetailsAsync(url);
        }
    }
}