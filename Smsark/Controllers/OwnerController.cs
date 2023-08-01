using Microsoft.AspNetCore.Mvc;
using Smsark.Models;

namespace Smsark.Controllers
{
    public class OwnerController : Controller
    {

		private readonly SmsarkDb _smsarkDbContext;
		private readonly IWebHostEnvironment _environment;

		public OwnerController(SmsarkDb _smsarkDbContext, IWebHostEnvironment _environment)
		{
			this._smsarkDbContext = _smsarkDbContext;
			this._environment = _environment;
		}
		public IActionResult Index()
        {
			if (HttpContext.Session.GetString("SignedInOwner") == "1")
			{
				TempData["SigninOwnerFlag"] = "1";
			}
			TempData["flag"] = 0;
            TempData["EditFlag"] = 0;
            return View();
           
        }
		public IActionResult ownerProfile()
		{
			return View();
		}

		public IActionResult signin()
		{

			return View();

		}
		[HttpPost("Owner/signin")]
		public IActionResult signin(Owner O)
		{

			var owner = _smsarkDbContext.owners.Where(s => s.Email ==
			  O.Email && s.Password == O.Password).FirstOrDefault();
			if (owner == null)
			{
				return Redirect("Owner/signin");
			}
			HttpContext.Session.SetString("Email", owner.Email);
			HttpContext.Session.SetString("SignedInOwner", "1");
			return Redirect("/Owner/UserProfile");
		}
	
		public IActionResult Signn(IFormCollection req)
		{
			TempData["SignInEmail"] = req["email"];
			TempData["SignInPassword"] = req["password"];


			if (TempData["SignInEmail"].ToString() == "Radwa@gmail.com" && TempData["SignInPassword"].ToString() == "1234")
			{
				HttpContext.Session.SetString("SignedInOwner", "1");
				TempData["SigninOwnerFlag"] = "1";
				
				return View("Index", "Owner");
			}

			else
			{
				TempData["Wrong"] = 1;
				return RedirectToAction("signin");
			}
		}

		//Edit Owner
		public IActionResult UserProfile()
		{
			if (HttpContext.Session.GetString("SignedIn") == "1")
			{
				TempData["SigninFlag"] = "1";
			}
			return View();
		}
		
		[HttpPost]
		public IActionResult UserProfile(Owner owner)
		{

			String ownerEmail = HttpContext.Session.GetString("Email");
			if (HttpContext.Session.GetString("SignedIn") == "1")
			{
				TempData["SigninFlag"] = "1";
			}

			var tempOwner = _smsarkDbContext.owners.Where(owner => owner.Email == ownerEmail).FirstOrDefault();
			if (tempOwner == null)
			{
				return BadRequest("there's no owner with the same owner email");
			}

			tempOwner.Email = owner.Email ?? tempOwner.Email;
			tempOwner.Password = owner.Password ?? tempOwner.Password;
			tempOwner.Name = owner.Name ?? tempOwner.Name;
			tempOwner.PhoneNo = owner.PhoneNo ?? tempOwner.PhoneNo;
			tempOwner.Gender = owner.Gender;

			_smsarkDbContext.owners.Update(tempOwner);
			_smsarkDbContext.SaveChanges();
			TempData["upd"] = "1";
			return View();
		}


		public IActionResult Contact()
		{
			if (HttpContext.Session.GetString("SignedInOwner") == "1")
			{
				TempData["SigninOwnerFlag"] = "1";
			}
			return View();
		}


		public IActionResult DeleteAccount()
		{
			var owner = _smsarkDbContext.owners.Where(o => o.Email ==
			  HttpContext.Session.GetString("Email")).FirstOrDefault();

			if (owner == null)
			{
				return BadRequest("there's no customer with this CustomerEmail");
			}

			_smsarkDbContext.owners.Remove(owner);
			_smsarkDbContext.SaveChanges();

			LogOut();
			return Redirect("/Home/Index");
		}


		public IActionResult LogOut()
		{

			HttpContext.Session.SetString("SignedInOwner", "0");
			HttpContext.Session.Clear();
			return View("Index", "Owner");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();

		}


		[HttpPost("/Register")]
		[ValidateAntiForgeryToken]  // to more security
		public IActionResult Register(Owner owner, IFormFile img_file)
		{

			
			string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string unique = DateTime.Now.Ticks.ToString();
			if (img_file != null && img_file.Length > 0)
			{
				path = Path.Combine(path,unique + img_file.FileName); // for example : /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					img_file.CopyTo(stream);
					ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
				}
				owner.NationalIdPhoto = unique+ img_file.FileName;
			}
			else
			{
				owner.NationalIdPhoto = "default.jpeg"; // to save the default image path in database.
			}


			_smsarkDbContext.Add(owner);
			_smsarkDbContext.SaveChanges();
			TempData["Successful"] = "1";
			return Redirect("/Owner/signin");

		}


		public IActionResult signupp()
		{
			TempData["Successful"] = 1;
			return RedirectToAction("signin");

		}
	

		public IActionResult DisplayRooms()
        {
			if (HttpContext.Session.GetString("SignedInOwner") == "1")
			{
				TempData["SigninOwnerFlag"] = "1";
				return View();
			}
			else
			{
				TempData["SignedInException"] = "1";
                return RedirectToAction("Index");
               

            } 
           
        }


        public IActionResult EditRooms()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
                return View();
            }
            else
            {
                TempData["SignedInException"] = "1";
                return RedirectToAction("Index");


            }
        }


        public IActionResult AddRooms()
        {
            if (HttpContext.Session.GetString("SignedInOwner") == "1")
            {
                TempData["SigninOwnerFlag"] = "1";
                return View();
            }
            else
            {
                TempData["SignedInException"] = "1";
                return RedirectToAction("Index");


            }
        }


        public RedirectToActionResult AddRoom() {
            TempData["flag"] = 1;
            return RedirectToAction("DisplayRooms");
           
        }


        public RedirectToActionResult EditRoom() {
            TempData["EditFlag"] = 1;
            return RedirectToAction("DisplayRooms");

        }
    }
}
