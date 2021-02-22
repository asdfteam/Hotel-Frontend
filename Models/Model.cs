using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelLibrary;

namespace Hotel_Frontend.Models
{
    internal class Model : Customer
    {
        [Required]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Username")]
        public new string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        public new string Password { get; set; }

        [Required]
        [Display(Name = "Repeat password")]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
