using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace L_DINER.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [RegularExpression(".+\\@.+\\..+")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression("\\(\\d\\d\\d-\\d\\d\\d-\\d\\d\\d\\d\\)")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Pass", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPass { get; set; }


    }
}
