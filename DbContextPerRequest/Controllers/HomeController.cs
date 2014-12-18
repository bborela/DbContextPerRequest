using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataContext.Implementations;

namespace DbContextPerRequest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyEntitiesDataContext _dataContext;

        public HomeController(IMyEntitiesDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ActionResult Index()
        {
            return View();
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