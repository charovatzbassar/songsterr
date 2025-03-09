using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Project_Task.DTO;
using Project_Task.Interfaces;
using Project_Task.Models;
using Project_Task.Services;

namespace Project_Task.Controllers;

public class SongsController : Controller
{
    private readonly ISongsService _songsService;

    public SongsController(ISongsService songsService)
    {
        _songsService = songsService;
    }


    public async Task<IActionResult> Index()
    {
        return View("Index", await _songsService.GetSongs("linkinpark"));
    }

    [HttpPost]
    public async Task<JsonResult> SearchSongs([FromBody] SearchDTO search)
    {
        // Process the data
        return Json(await _songsService.GetSongs(search.Search));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
