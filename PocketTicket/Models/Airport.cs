using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;
public class Airport
{
    [Key]
    public int AirportId { get; set; }

    [Required]
    [Display(Name = "Havaalanı Adı")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Konum")]
    public string Location { get; set; } = string.Empty;

    // RELATIONSHIP
    public List<Flight> DepartureFlights { get; set; } = new List<Flight>();
    public List<Flight> ArrivalFlights { get; set; } = new List<Flight>();

}

