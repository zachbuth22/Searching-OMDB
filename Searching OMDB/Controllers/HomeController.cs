using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Searching_OMDB.Models;

namespace Searching_OMDB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieSearchForm()
    {
        return View("MovieSearch");
    }

    [HttpPost]
    public IActionResult MovieSearchResults(string Title)
    {
        MovieModel result = MovieModelDAL.GetMovie(Title);
        return View("MovieSearch", result);
    }

    [HttpGet]
    public IActionResult MovieNight()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieNight(string Title1, string Title2, string Title3)
    {
        List<MovieModel> result = new List<MovieModel>();

        result.Add(MovieModelDAL.GetMovie(Title1));
        result.Add(MovieModelDAL.GetMovie(Title2));
        result.Add(MovieModelDAL.GetMovie(Title3));

        return View(result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

