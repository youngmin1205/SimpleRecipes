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
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;
        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Review> Reviews => context.Reviews;
       


    }

}