using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;
public class Airport
{
    [Key]
    public int AirportId { get; set; }

    [Required]
    [Display(Name = "Airport name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Description")]
    public string desc { get; set; } = string.Empty;
    public string logo { get; set; } = string.Empty;

    // RELATIONSHIP
    public List<Flight> DepartureFlights { get; set; } = new List<Flight>();
    public List<Flight> ArrivalFlights { get; set; } = new List<Flight>();

}

