using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {

        public static void Initiallize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbCondex(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbCondex>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }


                context.Books.AddRange(

                        new Book
                        {
                            //Id = 1,
                            Title = "sava  barıis",
                            GenerateId = 1,
                            PageCount = 260,
                            BublishDate = DateTime.Now.AddDays(1),


                        },

                     new Book
                     {
                        // Id = 2,
                         Title = "sava  barıis",
                         GenerateId = 2,
                         PageCount = 210,
                         BublishDate = DateTime.Now.AddDays(1),
                     
                     
                     },
                     
                      new Book
                      {
                       //   Id = 3,
                          Title = "Kumarbaz",
                          GenerateId = 3,
                          PageCount = 270,
                          BublishDate = DateTime.Now.AddDays(1),
                     
                     
                      },
                       new Book
                       {
                          // Id = 4,
                           Title = "gümn olur asra bdele",
                           GenerateId = 4,
                           PageCount = 200,
                           BublishDate = DateTime.Now.AddDays(1)
                       }
                     
                       );

                context.SaveChanges();
                        };
                     
                     
                     
        }            
    }

}

