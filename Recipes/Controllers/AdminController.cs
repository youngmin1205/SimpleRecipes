using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRepository repository;

        private readonly IHostingEnvironment he;

        public AdminController(IHostingEnvironment hi, IRepository repo)
        {
            he = hi;
            repository = repo;
        }

  

        public ViewResult Index() => View(repository.Recipes);

       
        public ViewResult Update(int recipeId) =>
            View(repository.Recipes
                .FirstOrDefault(r => r.RecipeID == recipeId));

        [HttpPost]
     
        public IActionResult Update(SavedRecipes recipe)
        {
            if (ModelState.IsValid)
            {


                var file = this.Request.Form.Files[0];

                var filepath = Path.Combine(he.WebRootPath, recipe.Name+".jpg");

                var stream = new FileStream(filepath, FileMode.Create);

                file.CopyToAsync(stream);

                recipe.ImagePath = filepath;
                recipe.LastUpdate = DateTime.Now;
                recipe.LastUser = User.Identity.Name;
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved at " +
                    $"{recipe.LastUpdate}";
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(recipe);
            }
        }
        // public ViewResult Create() => View("Update", new SavedRecipes());
     
        public ViewResult Create() => View("Update", new SavedRecipes());

        [HttpPost]
     
        public IActionResult Delete(int recipeId)
        {
            SavedRecipes deletedRecipe = repository.DeleteRecipe(recipeId);
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted at" +
                    $"{deletedRecipe.LastUpdate}";
            }
            return RedirectToAction("Index");
        }

      
        public ViewResult InsertPage()
        {
            return View("InsertPage");
        }

        [HttpGet]
        public ViewResult PartialRecipe()
        {

            return View(new SavedRecipes());
        }
        [HttpPost]
        public IActionResult PartialRecipe(SavedRecipes r)
        {



            //repository.InsertPage(r);
            repository.SaveRecipe(r);
            return View("RecipeView", r);
        }



        public ViewResult DataPage() => View(repository.Recipes);

        public ViewResult DisplayPage(int id)
        {
            SavedRecipes recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == id);

            recipe.Reviews = repository.Reviews.Where(r => r.RecipeID == id).ToList();
            return View(recipe);
        }

        public ViewResult AddReview(int id)
        {
            ReviewViewModel reviewViewModel = new ReviewViewModel { RecipeID = id };
            return View(reviewViewModel);
        }

        [HttpPost]
        public IActionResult AddReview(ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                reviewViewModel.Review.ReviewDate = DateTime.Now;
                reviewViewModel.Review.Reviewer = User.Identity.Name;
                SavedRecipes recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == reviewViewModel.RecipeID);
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

