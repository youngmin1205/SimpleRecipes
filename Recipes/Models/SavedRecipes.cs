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

namespace Recipes.Models
{
    public class SavedRecipes
    {

        [Key]
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        [Display(Name = "Last Update")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdate { get; set; }
        public string LastUser { get; set; }      
        public string ImagePath { get; set; }

        public List<Review> Reviews { get; set; }
        
    }
}