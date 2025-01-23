using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }

    [Required]
    [Display(Name = "Seat Number")]
    public string SeatNumber { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Ticket class")]
    public string TicketClass { get; set; } = string.Empty;

    // RELATIONSHIPS
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }

}
