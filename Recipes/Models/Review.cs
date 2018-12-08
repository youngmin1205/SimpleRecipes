using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int RecipeID { get; set; }
        public string Body { get; set; }
        public string Reviewer { get; set; }
        [Display(Name = "Review Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

    }
}
