using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Bu benzersiz kimlik getirmesini sağlıyor.
        public int Id { get; set; } // "prop" anahtar kelimesiyle hızlıca property oluşturabiliriz.
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}