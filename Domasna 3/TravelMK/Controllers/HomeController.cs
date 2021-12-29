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
            /*if (db.Hotels.Count() < 107) // temporary, should be removed when deployed
            {
                string data = System.IO.File.ReadAllText("Data/hotelslist.txt");

                foreach (string row in data.Split("\n"))
                {
                    string Id = row.Split(",")[0]; // there might be a better way to check for duplicates
                    int countedHotels = db.Hotels.Where(h => h.Id == Id).Count();
                    
                    if (countedHotels == 0)
                    {
                        db.Hotels.Add(new Hotel
                        {
                            Id = row.Split(",")[0],
                            Lat = row.Split(",")[1],
                            Lon = row.Split(",")[2],
                            Name_EN = row.Split(",")[3],
                            Name_MK = row.Split(",")[4],
                            Municipality_EN = row.Split(",")[5],
                            Municipality_MK = row.Split(",")[6]
                        });

                        db.SaveChanges();
                    }
                }
            }*/
            
            return View(db.Hotels.ToList());
        }

        public IActionResult DetailsHotel(string id)
        {
            var model = db.Hotels.Find(id);
            return View(model);
        }

        public IActionResult AddFavorite(string id)
        {
            foreach (var item in favoritesList)
            {
                if (item.Id == id)
                    return View("Favorites", favoritesList);
            }
            var model = db.Hotels.Find(id);
            favoritesList.Add(model);
            return View("Favorites", favoritesList); // redirects user to Favorites site after adding hotel to favorites
            //return RedirectToAction("Index"); // redirects user to Index site after adding hotel to favorites
        }
        public IActionResult RemoveFavorite(string id)
        {
            var model = db.Hotels.Find(id);
            foreach (var item in favoritesList)
            {
                if (item.Id == id)
                {
                    favoritesList.Remove(item);
                    return View("Favorites", favoritesList);
                }
            }
            return View("Favorites", favoritesList);
        }
            

        public IActionResult Favorites()
        {
            return View(favoritesList);
        }

        public IActionResult Map()
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
