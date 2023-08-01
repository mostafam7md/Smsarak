using System.ComponentModel.DataAnnotations.Schema;

namespace Smsark.Models
{
    public class Reservation
    {
        [key]
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Customer>? Customers { get; set; }
      
        public int ItemsId { get; set;}
        public Room? apartmentItem { get; set; }
    }
}
