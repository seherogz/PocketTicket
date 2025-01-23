using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PocketTicket.Models;

public class Passenger
{
    [Key]
    public int PassengerId { get; set; }

    [Display(Name = "Name-Surname")]
    [Required(ErrorMessage = "Name and surname are required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Surname must be between 3 and 50 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "E-mail")]
    [Required(ErrorMessage = "E-mail addresses are required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Phone number")]
    [Required(ErrorMessage = "Phone number are required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    // RELATIONSHIP
    [ValidateNever]
    public List<Flight_Passenger> Flights_Passengers { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();

}
