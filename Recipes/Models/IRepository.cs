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
    public interface IRepository
    {
        IQueryable<SavedRecipes> Recipes { get; }
        IQueryable<Review> Reviews { get; }
        //void InsertPage(SavedRecipes recipe);


        void SaveRecipe(SavedRecipes recipe);
        void SaveReview(Review review);

        SavedRecipes DeleteRecipe(int recipeID);

    
    }
}
