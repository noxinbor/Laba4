using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class PupilsController : Controller
    {
        kindergartenContext context = new kindergartenContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Pupils.ToList());
        }
        public IActionResult Details(int? id)
        {
            var pupils = context.Pupils.Where(m => m.PupilsId == id).First();
            return View(pupils);
        }
        public IActionResult Edit(int? id)
        {
            var pupils = context.Pupils.Where(m => m.PupilsId == id).First();
            return View(pupils);
        }
    }
}
