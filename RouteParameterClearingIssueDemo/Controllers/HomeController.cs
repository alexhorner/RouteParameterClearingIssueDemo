using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RouteParameterClearingIssueDemo.Models;

namespace RouteParameterClearingIssueDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Person> _people;

        public HomeController(List<Person> people)
        {
            _people = people;
        }

        public IActionResult Index() => RedirectToAction("DataViewer");
        
        public IActionResult DataViewer([FromRoute] int page = 0, [FromQuery] string? search = null)
        {
            const int pageSize = 100;
            int offset = page * pageSize;

            List<Person> finalPeopleList = _people;

            if (!string.IsNullOrEmpty(search))
            {
                finalPeopleList = finalPeopleList
                    .Where(p => p.FirstName.ToLower().Contains(search.ToLower()) || p.LastName.ToLower().Contains(search.ToLower()))
                    .ToList();
            }

            int totalResultCount = finalPeopleList.Count;

            finalPeopleList = finalPeopleList.Skip(offset).Take(pageSize).ToList();
            
            return View(new DataViewerViewModel
            {
                People = finalPeopleList,
                Pages = totalResultCount / pageSize,
                CurrentPage = page,
                Search = search
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
