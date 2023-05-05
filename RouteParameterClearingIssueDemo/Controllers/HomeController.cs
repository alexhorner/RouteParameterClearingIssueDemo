using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RouteParameterClearingIssueDemo.Models;

namespace RouteParameterClearingIssueDemo.Controllers;

public class HomeController : Controller
{
    private readonly List<Person> _people;

    public HomeController(List<Person> people)
    {
        _people = people;
    }

    public IActionResult Index() => View(_people);

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
