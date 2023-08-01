using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Smsark.Models;
using System.Diagnostics;


namespace Smsark.Controllers
{
    
    public class HomeController : Controller
    {
       public string SignInFlag = "0";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            var name = HttpContext.Session.GetString("Name");
            if ( string.IsNullOrEmpty(name)) {
                //    return RedirectToAction("index", "Home");
                return View();
            }
            return View();
        }

		public IActionResult Profile()
		{
             if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

            return View();
			
		}
		public IActionResult DisplayRooms()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            
            return View();
        }

        public IActionResult Booking()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }

            return Redirect("/Home/Index/#booking");
        }

        public IActionResult abt()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                
                TempData["SigninFlag"] = "1";
            }

            return Redirect("/Home/Index/#aboutus");
        }
        public IActionResult Rooms()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        public RedirectResult signup()
        {
            return Redirect("/Customer/CustomerRegister");
        }

        public RedirectResult signin()
        {
            TempData["SignInEmail"] ="";
            TempData["SignInPassword"] = "";
            return Redirect("/Customer/CustomerLogin");
        }

		public IActionResult Signn(IFormCollection req)
		{
			TempData["SignInEmail"] = req["email"];
			TempData["SignInPassword"] = req["password"];


			if (TempData["SignInEmail"].ToString() == "Radwa@gmail.com" && TempData["SignInPassword"].ToString() == "1234")
			{
				HttpContext.Session.SetString("SignedIn", "1");
				TempData["SigninFlag"] = "1";
				return View("Index", "Home");
			}

			else
			{
				TempData["Wrong"] = 1;
				return RedirectToAction("signin");
			}
		}

        public IActionResult LogOut() {

			HttpContext.Session.SetString("SignedIn", "0");
			return View("Index", "Home");
		}
		public IActionResult UserProfile()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }
        public IActionResult payment()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
                return View();
            }
            else {
                TempData["ReservExcept"] = "1";
                return RedirectToAction("Room");

            }
            
        }

        public IActionResult Aboutus()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View("Aboutus");
        }

        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        public IActionResult Room()
        {
            if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}