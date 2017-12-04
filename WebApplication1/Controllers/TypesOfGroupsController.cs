using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class TypesOfGroupsController : Controller
    {
        kindergartenContext context = new kindergartenContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.TypesOfGroups.ToList());
        }
        public IActionResult Details(int? id)
        {
            var typesOfGroups = context.TypesOfGroups.Where(m => m.TypesOfGroupsId == id).First();
            return View(typesOfGroups);
        }
        public IActionResult Edit(int? id)
        {
            var typesOfGroups = context.TypesOfGroups.Where(m => m.TypesOfGroupsId == id).First();
            return View(typesOfGroups);
        }
    }
}
