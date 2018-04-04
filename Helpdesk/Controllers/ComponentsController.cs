using Helpdesk.Models;
using Helpdesk.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helpdesk.Controllers
{
    public class ComponentsController : Controller
    {
        HelpdeskDbContext context;
        public ComponentsController(HelpdeskDbContext _context)
        {
            context = _context;
        }

        // GET: Components
        public ActionResult Index()
        {
            var vm = new ComponentViewModel();
            vm.components = context.Components.OrderBy(x => x.Name).ToList();
            return View(vm);
        }
    }
}