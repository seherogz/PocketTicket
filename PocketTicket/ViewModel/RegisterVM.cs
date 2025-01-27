using System.ComponentModel.DataAnnotations;

namespace PocketTicket.ViewModels;

public class RegisterVM
{
    [Required(ErrorMessage = "Full name is required.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email address is required.")]
    [Display(Name = "Email Address")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Password confirmation is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmePassword { get; set; }
}
