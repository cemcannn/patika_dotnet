using LinqPractices.Entities;
using Microsoft.EntityFrameworkCore;


namespace LinqPractices.DBOperations
{
    public class LinqDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } //Student entity'mizi DbSet ile context i�ine ekliyoruz. Student t�r�nde olacak ve �o�ul Students eklenecek. Yani Student s�n�f� Database k�sm�nda Students s�n�f�na kar��l�k gelecek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Burada database'e in memory �al��aca��m�z� s�yl�yoruz.
        {
            optionsBuilder.UseInMemoryDatabase(databaseName : "LinqDatabase");
        }
    }
}

