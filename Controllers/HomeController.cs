using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestaurantContext _context;
    
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult ShowReviews()
        {   
            List<Restaurant> AllReviewss = _context.restaurants.OrderByDescending(rev => rev.VisitDate).ToList();
            ViewBag.allReviews = AllReviewss;
            return View("reviews");
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddReviewToDb(RestaurantViewModel model)
        {   
            if(ModelState.IsValid)
            {
                Restaurant reviews = new Restaurant
                {
                    ReviewerName = model.ReviewerName,
                    RestaurantName = model.RestaurantName,
                    Review = model.Review,
                    Stars = model.Stars,
                    VisitDate = model.VisitDate
                };  

                _context.restaurants.Add(reviews);
                _context.SaveChanges();
                return RedirectToAction("ShowReviews");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("Remove")]
        public IActionResult RemoveReviewFromDb()
        {   
            Restaurant RetrievedReview = _context.restaurants.SingleOrDefault(rev => rev.RestaurantId == 0);
            _context.restaurants.Remove(RetrievedReview);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
