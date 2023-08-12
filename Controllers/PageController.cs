using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_market.Models;

namespace Web_market.Controllers
{
    public class PageController : Controller
    {
       
            private readonly DbMarketsContext _context;
            public PageController(DbMarketsContext context)
            {
                _context = context;
            }
            // GET: /<controller>/

            [Route("/page/{Alias}", Name = "PageDetails")]
            public IActionResult Details(string Alias)
            {
                if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");

                var page = _context.Pages
                .AsNoTracking()
                .SingleOrDefault(x => x.Alias == Alias);
                if (page == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(page);
            }
        
    }
}
