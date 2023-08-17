using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Web_market.Models;
using Web_market.ModelViews;

namespace Web_market.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbMarketsContext _context;
        private readonly IToastNotification _toastNotification;

        public ShoppingCartController(DbMarketsContext context, IToastNotification toastNotification)
        {        
            _context = context;
            _toastNotification = toastNotification;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == null)
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
