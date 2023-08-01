using Microsoft.AspNetCore.Mvc;
using Smsark.Models;

namespace Smsark.Controllers
{
    public class ApartmentController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly SmsarkDb smsarkDbContext;

        public ApartmentController1(SmsarkDb _smsarkDbContext)
        {
            smsarkDbContext = _smsarkDbContext;
        }
    }
}
