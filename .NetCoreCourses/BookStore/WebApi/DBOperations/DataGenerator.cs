using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace WebApi.DBOperations
{   public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider) // Uygulama ilk çalıştığında ayağa kalkacak ve hep çalışacak bir uygulama yapacağız, bu da service provider sayesinde oluyor.
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())) // Bir context instance ediyoruz, dbcontext ten, birazdan oluşturacağımız bilgileri context aracılığıyla databaase e kaydediyoruz.
            {
                if(context.Books.Any()) //Bu database de books nesnesi içinde herhangi bir context var mı demek. Eğer varsa hiçbir şey yapmadan direkt return ediyor.
                {
                    return;
                }
                context.Books.AddRange( // Buradan Book nesnelerini database e eklyoruz.
                    new Book{
                        //Id = 1, //Book class'ında benzersiz kimlik oluşturduğumuz için buradan siliyoruz.
                        Title = "Lean Startup",
                        GenreId = 1, // Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12)
                    },
                    new Book{
                        //Id = 2, //Book class'ında benzersiz kimlik oluşturduğumuz için buradan siliyoruz.
                        Title = "Herland",
                        GenreId = 2, // Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23)
                    },   
                    new Book{
                        //Id = 3, //Book class'ında benzersiz kimlik oluşturduğumuz için buradan siliyoruz.
                        Title = "Dune",
                        GenreId = 2, // Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2001,12,21)
                    }   
                );
                context.SaveChanges(); // sonra da değişiklikleri kaydediyoruz.
            }
        }
    }
}