using PocketTicket.Data;
using PocketTicket.Models;
using System.ComponentModel.DataAnnotations;

public class Flight
{
    [Key]
    public int FlightId { get; set; }

    [Required]
    [Display(Name = "Airline")]
    public string Airline { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Flight number")]
    public string FlightNumber { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Departure time")]
    public DateTime DepartureTime { get; set; }

    [Required]
    [Display(Name = "Arrival time")]
    public DateTime ArrivalTime { get; set; }

    [Required]
    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [Display(Name = "Flight status")]
    public FlightStatus Status { get; set; } = FlightStatus.OnTime;

    // RELATIONSHIPS
    [Required]
    [Display(Name = "Departure airport")]
    public int DepartureAirportId { get; set; }
    public Airport DepartureAirport { get; set; }

    [Required]
    [Display(Name = "Arrival airport")]
    public int ArrivalAirportId { get; set; }
    public Airport ArrivalAirport { get; set; }

    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}
