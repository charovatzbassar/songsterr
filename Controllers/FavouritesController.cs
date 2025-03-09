using Microsoft.AspNetCore.Mvc;
using Project_Task.Data;
using Project_Task.DTO;
using Project_Task.Models;

namespace Project_Task.Controllers
{
    public class FavouritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavouritesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.Songs.ToList());
        }

        [HttpPost]
        public IActionResult AddToFavourites([FromBody] FavouriteDTO song)
        {
            var results = _context.Songs
                .Where(s => s.Title.Contains(song.Title))
                .ToList();

            if (results.Count > 0)
            {
                return Json(new { success = false });
            }
            _context.Songs.Add(new Song
            {
                Title = song.Title,
                Artist = song.Artist,
                Lyrics = song.Lyrics
            });
            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpDelete]
        public IActionResult RemoveFromFavourites([FromBody] FavouriteDTO song)
        {
            var songToRemove = _context.Songs.Find(song.Id);
            _context.Songs.Remove(songToRemove);
            _context.SaveChanges();
            return Json(new { success = true });
        }
    }
}
