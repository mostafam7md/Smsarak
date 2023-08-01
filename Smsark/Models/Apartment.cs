using System.ComponentModel.DataAnnotations;

namespace Smsark.Models
{
    public class Apartment
    {
        [Key]
        public int ApartmentId { get; set; }
        [Required]
        public string Region { get; set; }
        [Required (ErrorMessage = "Department description is required")]
        public string Description { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Rooms number is out of range")]
        public int NoOfRooms { get; set; }
        [Required]
        public bool LandLine { get; set; }
        [Required]
        public string Photos { get; set; }
        [Required]
        public string Videos { get; set; }
        [Required]
        public bool WiFi { get; set; }
        [Required]
        public int NoOfBeds { get; set; }
        [Required]
        public int NoOfBathrooms { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<Room>? Items { get; set; }
        public Owner? Owner { get; set; }
        public int OwnerId { get; set; }

    }
}
