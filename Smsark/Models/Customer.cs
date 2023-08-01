using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smsark.Models
{
    public class CustomerRegister
    {
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
		public int NationalId { get; set; }
		public string Gender { get; set; }    
        public DateTime BirthDate { get; set; }
   		public string Photo { get; set; }
		public int Pin { get; set; }
	}
    public class CustomerLogin
    {
        public string CustomerEmail { get; set; }
        public string Password { get; set; }
    }
    public class Customer
    {   [Key]
        [RegularExpression (@"[A-Za-z0-9_.+-]+@[A-Za-z0-9]+\.[A-Za-z0-9.]+$", ErrorMessage = "Not a valid Email")]
        public string CustomerEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public int NationalId { get; set; }
        [Required]
        public string Gender { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public int Pin { get; set; }
        public int ResId { get; set; }
        public Reservation? reservation { get; set; }

    }
}
