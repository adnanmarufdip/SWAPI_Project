using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Models.People;
using Business.Services.Services;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Security.Policy;

namespace SWAPI_Project.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        public async Task<ActionResult> Index(int? page)
        {
            int pageNumber = page.HasValue ? page.Value : 1;
            int pageSize = 10;

            var peopleList = await _peopleService.GetPeopleAsync(pageNumber, pageSize);
            ViewBag.CurrentPageNumber = pageNumber;

            return View(peopleList);
        }

        public async Task<ActionResult> Details(string url, int pageNumber)
        {
            var person = await _peopleService.GetPersonDetailsAsync(url);
            ViewBag.CurrentPageNumber = pageNumber;
            return View(person);
        }
    }
}