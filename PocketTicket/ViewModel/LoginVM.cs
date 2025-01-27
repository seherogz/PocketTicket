using System.ComponentModel.DataAnnotations;

namespace PocketTicket.ViewModels;

public class LoginVM
{

    [Required(ErrorMessage = "E-mail adresses is required.")]
    [Display(Name = "E-mail addresses")]
    public string EmailAdress { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [Display(Name = "Pasword")]
    public string Password { get; set; }
}
