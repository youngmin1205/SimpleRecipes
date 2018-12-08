using Microsoft.EntityFrameworkCore;
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
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;
        public EFRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        // public IQueryable<AddedReviews> Reviews => context.Reviews;
        // public void AddReview(AddedReviews review) { }

        public IQueryable<SavedRecipes> Recipes => context.Recipes;

        public IQueryable<Review> Reviews => context.Reviews;
        //.Include(r => r.Reviews);

        //  public void InsertPage(SavedRecipes recipe) { }


        public void SaveRecipe(SavedRecipes recipe)
        {
            if (recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                SavedRecipes dbEntry = context.Recipes
                    .FirstOrDefault(r => r.RecipeID == recipe.RecipeID);
                if (dbEntry != null)
                {
                    dbEntry.Name = recipe.Name;
                    dbEntry.Ingredients = recipe.Ingredients;
                    dbEntry.Number = recipe.Number;
                    dbEntry.Description = recipe.Description;
                    dbEntry.Instruction = recipe.Instruction;
                    dbEntry.LastUpdate = recipe.LastUpdate;
                    dbEntry.LastUser = recipe.LastUser;

                    dbEntry.Reviews = recipe.Reviews;
                }
            }
            context.SaveChanges();
        }

        public SavedRecipes DeleteRecipe(int recipeID)
        {
            SavedRecipes dbEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeID == recipeID);
            if (dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews
                    .FirstOrDefault(r => r.RecipeID == review.RecipeID);
                if (dbEntry != null)
                {
                    dbEntry.Body = review.Body;
                    dbEntry.Reviewer = review.Reviewer;
                    dbEntry.ReviewDate = review.ReviewDate;
                }
            }
            context.SaveChanges();

        }


        }
}
