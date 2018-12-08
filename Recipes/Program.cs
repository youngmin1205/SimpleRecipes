using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

/*
 * Course: COMP229-001-Project-v1
 * Group#: 9
 * Members: Asha Saha, Janelle Baetiong, Youngshin Min
 */

namespace Recipes
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
         
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
        .UseDefaultServiceProvider(options =>
options.ValidateScopes = false)
            .Build();
    }
}
