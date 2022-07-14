using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId); //SingleOrDefault metodu ile title'e göre bookList'e atıyoruz.
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            book.Title = Model.Title != default ? Model.Title : book.Title; //book.Title'ı dışarıdan aldığımız Model.Title değerine eşitliyoruz, eğer bu değer default ise book.Title'ı kullanıyoruz.
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId; //book.GenreId'i dışarıdan aldığımız Model.GenreId değerine eşitliyoruz, eğer bu değer default ise book.GenreId'i kullanıyoruz.
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount; //book.PageCount'ı dışarıdan aldığımız Model.PageCount değerine eşitliyoruz, eğer bu değer default ise book.PageCount'ı kullanıyoruz.
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate; //book.PublishDate'ı dışarıdan aldığımız Model.PublishDate değerine eşitliyoruz, eğer bu değer default ise book.PublishDate'ı kullanıyoruz.
            _dbContext.SaveChanges(); //Database'e değişiklikleri kaydet.
                       
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        
    
    }
}
