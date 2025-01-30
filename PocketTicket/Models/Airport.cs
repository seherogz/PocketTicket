using PocketTicket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;
public class Airport : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Airport name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Description")]
    public string Desc { get; set; } = string.Empty; 
    public string Logo { get; set; } = string.Empty;

    // RELATIONSHIPS
    public List<Flight> DepartureFlights { get; set; } = new List<Flight>();
    public List<Flight> ArrivalFlights { get; set; } = new List<Flight>();
}

