using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model;
        private readonly BookStoreDbContext _dbContext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); //SingleOrDefault ile title'e göre bookList'e atıyoruz.
            if (book == null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
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
