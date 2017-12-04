using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class EducatorsController : Controller
    {
        kindergartenContext context = new kindergartenContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(context.Educators.ToList());
        }
        public IActionResult Details(int? id)
        {
            var educators = context.Educators.Where(m => m.EducatorsId == id).First();
            return View(educators);
        }
        public IActionResult Edit(int? id)
        {
            var educators = context.Educators.Where(m => m.EducatorsId == id).First();
            return View(educators);
        }

    }
}
