using LinqPractices.Entities;
using Microsoft.EntityFrameworkCore;


namespace LinqPractices.DBOperations
{
    public class LinqDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } //Student entity'mizi DbSet ile context içine ekliyoruz. Student türünde olacak ve çoðul Students eklenecek.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Burada database'e in memory çalýþacaðýmýzý söylüyoruz.
        {
            optionsBuilder.UseInMemoryDatabase(databaseName : "LinqDatabase");
        }
    }
}

