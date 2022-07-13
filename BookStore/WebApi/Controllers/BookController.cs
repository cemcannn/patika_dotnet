using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.DBOperations;
using System;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using WebApi.BookOperations.UpdateBook;

namespace WebApi.AddControllers //Namespace proje adının oluştuğu ismi alır "WebApi" ardından neyin altında "Controller" yazıyoruz.
{
    [ApiController] // Api bir HTTP Response döneceğini bu attribute ile sağlıyoruz.
    [Route("[controller]s")] // Gelen Request i hangi Resource'un karşılayacağını söyler.
    public class BookController : ControllerBase // Bookcontroller bir class olduğu için yazıyoruz, sonra "ControllerBase" sınıfından kalıtım aldığı için onu yazıyoruz.
    {
        private readonly BookStoreDbContext _context; // BookStoreDbContext'e constructor aracılığıyla erişiyoruz, sadece burada kullanılacak context'in private instance'ını oluşturuyoruz. Buranın readonly yapılmasının sebebi uygulama içinden değiştirilmemesini istedik. 
        //*** Readonly değişkenler uygulama içinden değiştirilemezler, sadece constructor içinde set edilebilirler.

        public BookController (BookStoreDbContext context) //Constructor atadık.
        {
            _context = context; // Bizim private _context'imizi inject edilen context'e atadık.
        }
        // private static List<Book> BookList = new List<Book>() {
        //     new Book{
        //         Id = 1,
        //         Title = "Lean Startup",
        //         GenreId = 1, // Personal Growth
        //         PageCount = 200,
        //         PublishDate = new DateTime(2001,06,12)
        //     },
        //     new Book{
        //         Id = 2,
        //         Title = "Herland",
        //         GenreId = 2, // Science Fiction
        //         PageCount = 250,
        //         PublishDate = new DateTime(2010,05,23)
        //     },   
        //     new Book{
        //         Id = 3,
        //         Title = "Dune",
        //         GenreId = 2, // Science Fiction
        //         PageCount = 540,
        //         PublishDate = new DateTime(2001,12,21)
        //     }         
        //}; // Private olmalı, çünkü uygulama çalıştıkça yaşamalı ve uygulama sona erdiğinde sona ermeli. Static yaşam döngüsü bu şekilde.
        
        [HttpGet]
        public IActionResult GetBooks() // Tüm bookları geri döndüren bir endpoint yaptık, bu eylem çağırıldığında tüm kitap bilgileri geriye dönecek.
        {
            //var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>(); //Önceki BookList statik listini iptal edip _context instance ını oluşturduğumuz bir database yarattığımız için context'in Books nesnesine göre sorgu yapıyoruz.
            //return bookList;
            GetBooksQuery query = new GetBooksQuery(_context); // GetBooksQuery sınıfının bir instance'ı oluşturuyoruz. Database olarak _context'i alıyoruz.
            var result = query.Handle(); 
            return Ok(result); // Geriye 200 kodu ve result döndürüyoruz.
        }

        [HttpGet("{id}")] // id ile Route'dan almamıza yarıyor.
        public IActionResult GetById(int id) // Id bazında sadece bir id nin tüm özelliklerini geri döndürecek bir endpoint.
        {
            GetBooksById command = new GetBooksById(_context);
            try
            {
                command.Model = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            //var book = _context.Books.Where(book => book.Id == id).SingleOrDefault(); //Önceki BookList statik listini iptal edip _context instance ını oluşturduğumuz bir database yarattığımız için context'in Books nesnesine göre sorgu yapıyoruz.
            //return book;
        }

        // [HttpGet] 
        // public Book Get([FromQuery] string id) // id ile Route'dan değilde "fromquery" yöntemi ile // Id bazında sadece bir id nin tüm özelliklerini geri döndürecek bir endpoint. Fakat "Route"dan almak daha doğru bir yaklaşım.
        // {
        //     var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //     return book;
        // }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) // "frombody" den "Book" gelicek adı da "newBook" olacak.
        {
            CreateBookCommand command = new CreateBookCommand(_context); //CreateBookCommand türünden command nesnesi oluşturuyoruz.
            try //Hata alırsak diye try catch metodu kullanıyoruz.
            {
                command.Model = newBook; //command.Model'i newBook'a set ediyoruz.
                command.Handle(); //command nesnesinin Handle metodunu çalıştırıyoruz.
            }
            catch (Exception ex) //Burada eğer hata patlatırsa ex bizim hatamız oluyor.
            {
                return BadRequest(ex.Message); //Hata olursa hata mesajımız ile birlikte BadRequest döndürecek.
            }            
            //var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title); // Gelen book bizim database mizde var mı onu kontrol etmek için yapılan validasyon. Bunu da gelen x.Title bizim newBook.Title kısmında var mı? 
            //if(book is not null) // Eğer varsa:
            //    return BadRequest(); // BadRequest döndürüyoruz, bunu döndürmek için ise metoda "IActionResult" eklememiz gerek.
            //_context.Books.Add(newBook); // Eğer boş ise Ok döndürüyoruz.
            //_context.SaveChanges(); // Veritabanına ekleme yapıyoruz. Artık statik bir listeye ekleme yapmadığımız için _context database'ini kaydetmemiz gerekiyor.
            return Ok(); //Ok dönüyoruz.
        }

        [HttpPut("{id}")] // Önce hangi id üzerinde güncelleme yapılacağı yazılıyor, 
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.Model = updatedBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }            //var book = _context.Books.SingleOrDefault(x => x.Id == id);
            //if(book is null)
            //    return BadRequest();

            //book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            //book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
            //book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate; // Swagger ın o anki datetime ını aldığı için default olarak vermeyebilir, o sebeple sürekli güncellemek gerekir.
            //book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;

            //_context.SaveChanges();// Veritabanına ekleme yapıyoruz. Artık statik bir listeye ekleme yapmadığımız için _context database'ini kaydetmemiz gerekiyor.

            return Ok();
        }
        
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();// Veritabanına ekleme yapıyoruz. Artık statik bir listeye ekleme yapmadığımız için _context database'ini kaydetmemiz gerekiyor.
            return Ok();
        }
    }
}