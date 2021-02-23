using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelLibrary;

namespace Hotel_Frontend.Models
{
    public class ReservationModel : CreateReservationRequest
    {
        [Required]
        [Display(Name = "Put in your starting date")]
        public new DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Put in your end date")]
        public new DateTime EndDate { get; set; }
        
        [Required]
        [Display(Name = "Type in preferred number of single beds")]
        public new int SingleBeds { get; set; }
        [Required]
        [Display(Name = "Type in preferred number of double beds")]
        public new int DoubleBeds { get; set; }
    }
}
