using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new SavedRecipes
                    {
                        // RecipeID = 1,
                        Name = "Pasta",
                        Ingredients = "Mushroom",
                        Number = 3,
                        Description = "Good",
                        Instruction = "Boil"
                    },
                new SavedRecipes
                {
                    // RecipeID = 2,
                    Name = "Rice",
                    Ingredients = "Mushroom",
                    Number = 3,
                    Description = "Boil",
                    Instruction = "Boil"
                }

                    );
                context.SaveChanges();
            }

        }
    }
}
