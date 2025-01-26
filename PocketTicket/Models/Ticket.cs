using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketTicket.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(10)")]
    [Display(Name = "Seat Number")]
    public string SeatNumber { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "nvarchar(10)")]
    [Display(Name = "Ticket class")]
    public string TicketClass { get; set; } = string.Empty;

    // RELATIONSHIPS
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }

}
