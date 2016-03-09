using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace icemaoCN.Controllers
{
    public class HomeController : BaseController
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Article()
        {
            var article = DB.Articles.OrderByDescending(x => x.Time).ToList();
            return PagedView(article, 10);
        }
    }
}
