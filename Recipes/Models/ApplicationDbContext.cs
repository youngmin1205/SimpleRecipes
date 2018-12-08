using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<SavedRecipes> Recipes { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

    public class ApplicationDbContextFactory
           : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services
                .GetRequiredService<ApplicationDbContext>();

    }
}
