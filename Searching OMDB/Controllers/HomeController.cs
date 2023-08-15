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
    public IActionResult MovieNightForm()
    {
        return View("MovieNight");
    }

    [HttpPost]
    public IActionResult MovieNightResults(string Title1, string Title2, string Title3)
    {
        List<MovieModel> result = new List<MovieModel>();

        MovieModel result1 = MovieModelDAL.GetMovie(Title1);
        MovieModel result2 = MovieModelDAL.GetMovie(Title2);
        MovieModel result3 = MovieModelDAL.GetMovie(Title3);

        result.Add(result1);
        result.Add(result2);
        result.Add(result3);

        return View("MovieNight", result);
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

