using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Smsark.Models;
using System.ComponentModel.DataAnnotations;
using System.IO;

//Shaabannnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn

namespace Smsark.Controllers
{
	public class CustomerController : Controller
	{
		
        private readonly SmsarkDb  _smsarkDbContext;

        private readonly IWebHostEnvironment _environment;


        public CustomerController(SmsarkDb context, IWebHostEnvironment environment)
		{
            _smsarkDbContext = context;		
			_environment = environment;	 
		}

        [HttpGet]
        public IActionResult CustomerRegister()
        {
            return View();
        }

       [HttpPost]
		[ValidateAntiForgeryToken]  // to more security
		public IActionResult CustomerRegister(Customer customer, IFormFile img_file)
		{

			string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string unique = DateTime.Now.Ticks.ToString();
			if (img_file != null && img_file.Length > 0)
			{
				path = Path.Combine(path, unique + img_file.FileName); // for example : /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					img_file.CopyTo(stream);
					ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
				}
				customer.Photo = unique + img_file.FileName;
			}
			else
			{
				customer.Photo = "default.jpeg"; // to save the default image path in database.
			}

			try
			{
				_smsarkDbContext.Add(customer);
				_smsarkDbContext.SaveChanges();
				TempData["Successful"] = "1";
				return Redirect("/Customer/CustomerLogin");
			}
			catch (Exception ex)
			{
				ViewBag.exc = ex.Message;
			}

			return Redirect("/Home/Index");
		}

		[HttpGet]
		public IActionResult CustomerLogin()
		{
			return View();
		}
		[HttpPost("CustomerLogin")]
		public RedirectResult CustomerLogin(CustomerLogin c)
		{

			var customer = _smsarkDbContext.customers.Where(s => s.CustomerEmail ==
			  c.CustomerEmail && s.Password == c.Password).FirstOrDefault();
			if (customer == null)
			{
				HttpContext.Session.SetString("SignedIn", "0");
				TempData["Wrong"] = "1";
				return Redirect("Customer/CustomerLogin");
			}

			HttpContext.Session.SetString("CustomerEmail", customer.CustomerEmail);
			HttpContext.Session.SetString("SignedIn", "1");
			TempData["SigninFlag"] = 1;
			return Redirect("Customer/CustomerProfile");

		}
		public IActionResult EditCustomer() {
			if (HttpContext.Session.GetString("SignedIn") == "1")
			{
				TempData["SigninFlag"] = "1";
			}
			return View();
		}
		// [HttpPut("/Customer/EditCustomer")]
		[HttpPost]
		public IActionResult EditCustomer( Customer c, IFormFile img_file)
		{
			
			String email = HttpContext.Session.GetString("CustomerEmail");
			if (HttpContext.Session.GetString("SignedIn") == "1")
			{
				TempData["SigninFlag"] = "1";
			}
			var customer = _smsarkDbContext.customers.Where(c => c.CustomerEmail == email).FirstOrDefault();
			if (customer == null)
			{
				return BadRequest("there's no customer with the same CustomerEmail");
			}
			string path = Path.Combine(_environment.WebRootPath, "Img"); // wwwroot/Img/
			string unique = DateTime.Now.Ticks.ToString();
			if (img_file != null && img_file.Length > 0)
			{
				path = Path.Combine(path, unique + img_file.FileName); // for example : /Img/Photoname.png
				using (var stream = new FileStream(path, FileMode.Create))
				{
					img_file.CopyTo(stream);
					ViewBag.Message = string.Format("<b>{0}</b> uploaded.</br>", img_file.FileName.ToString());
				}
				c.Photo = unique + img_file.FileName;
			}
			customer.CustomerEmail = c.CustomerEmail ?? customer.CustomerEmail;
				customer.Password = c.Password ?? customer.Password;
				customer.FName = c.FName ?? customer.FName;
				customer.LName = c.LName ?? customer.LName;
				customer.Phone = c.Phone ?? customer.Phone;
				customer.Photo = c.Photo ?? customer.Photo;
				customer.Pin = c.Pin;
	
			_smsarkDbContext.customers.Update(customer);
			_smsarkDbContext.SaveChanges();
			TempData["upd"] = "1";
			return View();
		}

		[HttpGet("PinLogin")]
		public IActionResult LoginPin(int pin, String CustomerEmail)
		{
			var res = _smsarkDbContext.customers.Find(CustomerEmail);
			if (pin == res.Pin)
			{
				return View();
			}
			return BadRequest("Wrong Pin");
		}
		//	[HttpDelete("DeleteAccount")]
	//	[HttpPost]
		public IActionResult DeleteAccount()
		{
			var customer = _smsarkDbContext.customers.Where(s => s.CustomerEmail ==
			  HttpContext.Session.GetString("CustomerEmail")).FirstOrDefault();

			if (customer == null)
			{
				return BadRequest("there's no customer with this CustomerEmail");
			}

			_smsarkDbContext.customers.Remove(customer);
			_smsarkDbContext.SaveChanges();

			LogOut();
			return Redirect("Home/Index");

		
		}
	
		public IActionResult CustomerProfile()

		{
			   if (HttpContext.Session.GetString("SignedIn") == "1")
            {
                TempData["SigninFlag"] = "1";
            }
			var customerEmail = HttpContext.Session.GetString("CustomerEmail");
			var customer = _smsarkDbContext.customers.Where(s => s.CustomerEmail == customerEmail).FirstOrDefault();
			if (customer == null)
			{
				return Redirect("Customer/CustomerLogin");
			}
			return View(customer);

		}

		public IActionResult LogOut()
		{

			HttpContext.Session.SetString("SignedIn", "0");
			HttpContext.Session.Clear();
			return View("Index", "Home");
		}

		public RedirectToActionResult zz() {
			return RedirectToAction("Index", "Home");
		}

		
	}
}
