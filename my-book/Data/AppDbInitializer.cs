using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_book.Data.Models;
using my_books.Data;
using System;
using System.Linq;

namespace my_book.Data
{
    //Seeding Data to Database!
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var  context =serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                       Title = "1st Book Title",
                       Description = "1st Book Description",
                       IsRead = true,
                       DateRead = DateTime.Now.AddDays(-10),
                       Rate = 4,
                       Genre = "Biology",
                       CoverUrl = "Https.....",
                       DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biology",
                        CoverUrl = "Https.....",
                        DateAdded = DateTime.Now
                    });
                    //Must--Save!
                    context.SaveChanges();
                }

            }

        }
    }
}
