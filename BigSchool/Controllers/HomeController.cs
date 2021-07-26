using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using BigSchool.ViewModel;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourse = _dbContext.Courses
                .Include(a => a.Lecture)
                .Include(a => a.Category)
                .Where(a => a.dateTime > DateTime.Now);

            //var userid = _dbContext.Users.Find(User.Identity.GetUserId());
            //bool isGoing = _dbContext.Attendances.Any(a => a.CourseId == )
            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourse,
                ShowAction = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}