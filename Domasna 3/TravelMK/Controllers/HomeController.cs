﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelMK.Data;
using TravelMK.Models;

namespace TravelMK.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext db;
        public HomeController(HotelContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            if (db.Hotels.Count() < 107) // temporary, should be removed when deployed
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
            }

            return View();
        }

        public IActionResult Favorites()
        {
            return View();
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