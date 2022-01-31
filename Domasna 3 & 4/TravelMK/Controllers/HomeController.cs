using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelMK.Data;
using TravelMK.Models;

namespace TravelMK.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext db;

        static List<Hotel> favoritesList = new List<Hotel>() { };

        public HomeController(HotelContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Hotels.ToList());
        }

        public IActionResult DetailsHotel(string id)
        {
            var hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                throw new ArgumentNullException("The selected hotel could not be found in the database.");
            }

            return View(hotel);
        }

        public IActionResult AddFavorite(string id)
        {
            if (!favoritesList.Exists(hotel => hotel.Id == id))
            {
                var hotel = db.Hotels.Find(id);
                if (hotel == null)
                {
                    throw new ArgumentNullException("The selected hotel could not be found in the database.");
                }

                favoritesList.Add(hotel);
            }

            return View("Favorites", favoritesList);
        }

        public IActionResult RemoveFavorite(string id)
        {
            favoritesList.RemoveAll(hotel => hotel.Id == id);

            return View("Favorites", favoritesList);
        }
            
        public IActionResult Favorites()
        {
            return View(favoritesList);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
