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
    public class Repository
    {
        private static Repository sharedRepository = new Repository();
        private Dictionary<string, SavedRecipes> recipes = new Dictionary<string, SavedRecipes>();

        public static Repository SharedRepository => sharedRepository;

        public IEnumerable<SavedRecipes> Recipes => recipes.Values;
        public void InsertPage(SavedRecipes r) => recipes.Add(r.Name, r);

    }
}
