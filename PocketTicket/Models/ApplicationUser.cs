﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PocketTicket.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "User Name")]
    public string FullName { get; set; } = string.Empty;

}