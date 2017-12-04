using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class GroupsController : Controller
    {
        kindergartenContext context = new kindergartenContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Groups.ToList());
        }
        public IActionResult Details(int? id)
        {
            var groups = context.Groups.Where(m => m.GroupsId == id).First();
            return View(groups);
        }
        public IActionResult Edit(int? id)
        {
            var groups = context.Groups.Where(m => m.GroupsId == id).First();
            return View(groups);
        }

    }
}
