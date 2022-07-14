using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext; //Burada private readonly olarak _dbContext'i set ediyoruz, böylece sadece private içerisinden erişim sağlayacağız. Burada _dbContext bir database instance'ı.
        public int BookId { get; set; } //Id için gerekli kod.
        public GetBookDetailQuery(BookStoreDbContext dbContext) //Constructor oluşturuyoruz.
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault(); //Where şartı ile BookId'li database'deki veriyi book nesnesine eşliyoruz.         
            BookDetailViewModel vm = new BookDetailViewModel(); //BookDetailViewModel türünde vm nesnesi üretiyoruz.
            if (book is null) //Eğer kitap boşsa hata atacak.
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yy");
            vm.Genre = book.GenreId.ToString();

            return vm;
        }
        public class BookDetailViewModel //Veri tipinin ui'a dönmesi için ViewModel kullanıyoruz.
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}
