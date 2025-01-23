using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;

public class Flight_Passenger
{
    [Key]
    public int Id { get; set; }

    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public int PassengerId { get; set; }
    public Passenger Passenger { get; set; }

    [Display(Name = "Ticket class")]
    [Required(ErrorMessage = "Ticket class are required")]
    public string TicketClass { get; set; } = string.Empty;

    [Display(Name = "Seat number")]
    public string SeatNumber { get; set; } = string.Empty;
}
