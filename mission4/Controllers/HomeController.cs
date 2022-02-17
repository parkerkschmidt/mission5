using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission4.Models;
using Microsoft.EntityFrameworkCore;

namespace mission4.Controllers
{
    public class HomeController : Controller
    {

        private MovieResponseContext BlahContext { get; set; }

        public HomeController(MovieResponseContext someName)
        {
            BlahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmForm()
        {
            ViewBag.Categories = BlahContext.Categories.ToList();
            return View(new MovieResponse());
        }

        [HttpPost]
        public IActionResult FilmForm(MovieResponse response)
        {
            if (ModelState.IsValid)
            {
                BlahContext.Add(response);
                BlahContext.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = BlahContext.Categories.ToList();
                return View(response);

            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            ViewBag.Categories = BlahContext.Categories.ToList();
            var movies = BlahContext.Responses
            .OrderBy(x => x.Title)
            .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = BlahContext.Categories.ToList();

            var movie = BlahContext.Responses.Single(x => x.MovieID == id);

            return View("FilmForm", movie);
        }

        [HttpPost]
        public IActionResult Edit (MovieResponse blah)
        {
            BlahContext.Update(blah);
            BlahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = BlahContext.Responses.Single(x => x.MovieID == id);

            return View("Delete", movie);
        }

        
        [HttpPost]
        public IActionResult Delete (MovieResponse blah)
        {
            BlahContext.Responses.Remove(blah);
            BlahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
