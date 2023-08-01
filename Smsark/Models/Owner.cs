using System.ComponentModel.DataAnnotations;

namespace Smsark.Models
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NationalId { get; set; }
        [Required]
        public string NationalIdPhoto { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Apartment>? apartments { get; set; }
    }
}
