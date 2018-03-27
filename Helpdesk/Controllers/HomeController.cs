using Helpdesk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpdesk.Controllers
{
    public class HomeController : Controller
    {
        HelpdeskDbContext context;
        public HomeController(HelpdeskDbContext _context)
        {
            context = _context;
        }

        [Authorize]
        public ActionResult Index()
        {
            //User s = (User.Identity as Helpdesk.Infrastructure.MyIdentity).User; 
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}