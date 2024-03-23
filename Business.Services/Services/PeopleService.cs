using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Models.People;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Business.Services.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.swapi.tech/api/people";

        public PeopleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PeopleList> GetPeopleAsync(int pageNumber, int pageSize)
        {
            var url = $"{BaseUrl}?page={pageNumber}&limit={pageSize}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RootObject>(content);

            var peopleList = new PeopleList
            {
                TotalRecords = result.total_records,
                TotalPages = result.total_pages,
                Previous = result.previous,
                Next = result.next,
                Results = result.results.Select(r => new Person
                {
                    Name = r.name,
                    Url = r.url
                })
            };

            return peopleList;
        }

        public async Task<Person> GetPersonDetailsAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PersonDetailsRootObject>(content);

            var person = new Person
            {
                Name = result.result.properties.name,
                Url = url,
                Properties = new Person.PersonProperties
                {
                    Height = result.result.properties.height,
                    Mass = result.result.properties.mass,
                    HairColor = result.result.properties.hair_color,
                    SkinColor = result.result.properties.skin_color,
                    EyeColor = result.result.properties.eye_color,
                    BirthYear = result.result.properties.birth_year,
                    Gender = result.result.properties.gender,
                    HomeWorld = result.result.properties.homeworld
                }
            };

            return person;
        }

        private class RootObject
        {
            public string message { get; set; }
            public int total_records { get; set; }
            public int total_pages { get; set; }
            public string previous { get; set; }
            public string next { get; set; }
            public List<ResultObject> results { get; set; }
        }

        private class ResultObject
        {
            public string uid { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        private class PersonDetailsRootObject
        {
            public string message { get; set; }
            public PersonDetailsResultObject result { get; set; }
        }

        private class PersonDetailsResultObject
        {
            public PropertiesObject properties { get; set; }
            public string description { get; set; }
            public string _id { get; set; }
            public string uid { get; set; }
            public int __v { get; set; }
            public string url { get; set; }
        }

        private class PropertiesObject
        {
            public string height { get; set; }
            public string mass { get; set; }
            public string hair_color { get; set; }
            public string skin_color { get; set; }
            public string eye_color { get; set; }
            public string birth_year { get; set; }
            public string gender { get; set; }
            public string created { get; set; }
            public string edited { get; set; }
            public string name { get; set; }
            public string homeworld { get; set; }
        }
    }
}
