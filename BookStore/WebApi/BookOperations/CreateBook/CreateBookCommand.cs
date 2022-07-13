using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; } //Bu modeli CreateBookModel'a set ediyoruz.
        private readonly BookStoreDbContext _dbContext; 
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title); //Book nesnesini oluşturuyoruz. Eğer birden fazla gelirse hata verir.

            if (book is not null) //Eğer book nesnesi null değilse,
            {
                throw new InvalidOperationException("Kitap zaten mevcut"); //Hata fırlatıyoruz.
            }
            book = new Book(); //Book nesnesini oluşturuyoruz.
            book.Title = Model.Title; //Book nesnesinin Title'i Model'daki Title'i set ediyoruz.
            book.GenreId = Model.GenreId; //Book nesnesinin GenreId'i Model'daki Genre'i set ediyoruz.
            book.PageCount = Model.PageCount; //Book nesnesinin PageCount'i Model'daki PageCount'i set ediyoruz.
            book.PublishDate = Model.PublishDate; //Book nesnesinin PublishDate'i Model'daki PublishDate'i set ediyoruz.
            _dbContext.Books.Add(book); //Book nesnesini database'e ekliyoruz.
            _dbContext.SaveChanges(); //Database'e değişiklikleri kaydediyoruz.
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
