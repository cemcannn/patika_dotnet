using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext; //Burada private readonly olarak _dbContext'i set ediyoruz, böylece sadece private içerisinden erişim sağlayacağız. Burada _dbContext bir database instance'ı.
        public GetBooksQuery(BookStoreDbContext dbContext) //GetBookQuery constructor'ı oluşturuyoruz.
        {
            _dbContext = dbContext;
        }
        public List<BookViewModel> Handle() //Asıl işi yapacak Handle metodu.
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList(); //bookList tanımlayıp, database içerisindeki Books'ları id'ye göre sıralayıp bookList içerisine liste olarak atıyoruz.
            List<BookViewModel> vm = new List<BookViewModel>(); //Sonrasında vm isminde bir liste oluşturup bu bookList içindeki property'leri kullanıcıya viewmodel ile göndermek üzere BookViewModel listesine eşitliyoruz. 
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
            }
            return vm;
        }
    }
    public class BookViewModel //Veri tipinin ui'a dönmesi için ViewModel kullanıyoruz.
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}
