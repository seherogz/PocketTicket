using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;

public class Reservation
{
    [Key]
    public int ReservationId { get; set; }

    [Required]
    [Display(Name = "Reservation date")]
    public DateTime ReservationDate { get; set; }

    [Required]
    [Display(Name = "Total Price")]
    public decimal TotalPrice { get; set; }

    // RELATIONSHIPS
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }

    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();

}
