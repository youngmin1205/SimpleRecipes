using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Models.ViewModels
{
    public class LoginModel
    {
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";


    }
}
