using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View("Index");
        }
    

        public ViewResult UserPage()
        {
            return View("UserPage");
        }

        public ViewResult DataPage() => View(repository.Recipes);

        public ViewResult DisplayPage(int id)
        {
            SavedRecipes recipe = repository.Recipes.First(r => r.RecipeID == id);

            recipe.Reviews = repository.Reviews.Where(r => r.RecipeID == id).ToList();
            return View(recipe);
        }
        [Authorize]
        public ViewResult AddReview(int id)
        {
            ReviewViewModel reviewViewModel = new ReviewViewModel { RecipeID = id };
            return View(reviewViewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddReview(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                SavedRecipes recipe = repository.Recipes.First(r => r.RecipeID == reviewViewModel.RecipeID);
                if (recipe.Reviews == null)
                {
                    recipe.Reviews = new List<Review>();
                }
                reviewViewModel.Review.RecipeID = reviewViewModel.RecipeID;
                repository.SaveReview(reviewViewModel.Review);

                recipe.Reviews = repository.Reviews.Where(r => r.RecipeID == reviewViewModel.RecipeID).ToList();

                return View("DisplayPage", recipe);
            }
            else
            {
                //there is something wrong in data
                return View(reviewViewModel);
            }

        }


    }
}
