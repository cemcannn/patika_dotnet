using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksById
    {
        public BookViewModelById Model;
        private readonly BookStoreDbContext _dbContext;
        public GetBooksById(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Book Handle()
        {
            var book = _dbContext.Books.OrderBy(x => x.Id == Model.Id).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            book.GenreId = Model.GenreId;

            return book;
        }
        public class BookViewModelById
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int GenreId { get; set; }
        }
    }
}
