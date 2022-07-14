## Kurulum:
- [install](https://dotnet.microsoft.com/download) adresinden .net core son versiyonunu indirip kuruyoruz.

## Extensions:
- .Net Core Tools
- C#
- MsBuild Project Tools

---

- [Nuget](nuget.org) sitesinden "Entity Framework" son versiyonunun install kodunu alıp terminalden Api dosyasının bulunduğu dizin içine yükleme işlemini yapıyoruz.
- Ardından in memory de işlem yapabilmek için yine aynı siteden "Entity Framework Core In Memory" install kodunu alıp yine api dosyasının bulunduğu dizine yükleme işlemini yapıyoruz.
- Ardından DBoperations diye bir dosya oluşturuyoruz ve için bir Context dosyası oluşturuyoruz. İsmi "BookStoreDbContext.cs" olacak.
```c#
public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {}
    public DbSet<Book> Books { get; set; }
  
}
```
- Sonrasında ise initial data için yani hepten boş bir data dönmemesi için DBOperations klasörü içine "DataGenerator.cs" dosyası oluşturuyoruz.
- Ardından uygulama ayağa kalktığından initial datanın in memory DB'ye yazılması için Program.cs içerisinde configurasyon yapılması gerekiyor.
```c#
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); //Host u build ediyoruz.

            using(var scope = host.Services.CreateScope()) //servis katmanını buluyoruz.
            {
                var services = scope.ServiceProvider; // servis katmanı için instance alıyoruz.
                DataGenerator.Initialize(services); // Data generatoru initialize ediyoruz.
            }
            host.Run(); // Ardından host u başlatıyoruz.
        }
```
ilgili kısım yukarıdaki kod şeklinde güncelleniyor.
- Sonrasında Startup.cs içerisinde ConfigureServices() içerisinde DbContext'in servis olarak eklenmesi gerekiyor. 
```c#
            services.AddDbContext<BookStoreDbContext>(options=> options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
```
- Ardından BookController içindeki statik listemizi siliyoruz, zaten bu listeyi database üzerinden çalıştırdığımız için, yani DataGenerator üzerinde bu işlemleri yaptığımız için siliyoruz.
- Sonrasında BookController içinde sildiğimiz statik veriyi DBOperations ile ilişkilendirmeliyiz. Bunun için statik kodların silindiği yere:
```c#
        private readonly BookStoreDbContext _context;

        public BookController (BookStoreDbContext context)
        {
            _context = context;
        }
```
kodlarını ekliyoruz. Bu sayede private bir *_context* instance yaratmış oluyoruz, bu instance'ı da *readonly* keywordü ile uygulama içinden erişimini engelledik, sadece okuma yapılabiliyor. Ardından BookController constructor ataması yaptık bu sayede *_context* instance'ına erişim sağlayabileceğiz. 
-Ardından endpointlerimizi dönüştürüyoruz çünkü artık statik bir liste üzerinden değil database üzerinden işlem yapıyoruz. 
- Öncelikle GetBooks metodumuzu dönüştüreceğiz: 
```cs
var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>(); 
```
Burada BookList'ten verileri çekmeyi bırakıyoruz, oluşturduğumuz *_context* instance ının *Books* nesnesinden sorgu yapıyoruz.
- Ardından bütün BookList içeren kodları _context.Books olarak güncelliyoruz. Fakat *AddBook* metodunda bir değişiklik daha yapmamız gerekiyor. Çünkü eskiden statik bir listeye ekleme yaptığımız için basit bir ekleme işlemi yeterliydi fakat şu an database üzerinde işlem yaptığımız için bir kayıt işlemi yapmalıyız.
```cs
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook) 
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title); 
            if(book is not null) 
                return BadRequest(); 
            _context.Books.Add(newBook); 
            _context.SaveChanges(); 
            return Ok(); 
        }
```
şeklinde değişiklik yapıyoruz. 
-Aynı değişikliği ve kayıt işlemini *Put* ve *Delete* metodlarında da yapıyoruz.
- Sonrasında projemiz build oluyor mu kontrol etmek için terminal ekranında:
```
dotnet build
```
komutu ile *build* olup olmadığını kontrol edebiliriz. Eğer Solution dizininin altında birden fazla proje varsa hepsini çalıştırır. 
- Build işleminde hiç *warning* ve *error* yok ise uygulamamızı ayağa kaldırabiliriz. Terminal ekranında:
```
dotnet watch run
```
koduyla uygulamamız ayağa kalkar ve *swagger ui*'mız ekrana gelir.
- Sonrasında id alanını database üzerinden girmemek için autoincrement özelliği ekliyoruz. *Book* class'ı altında 
```cs
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
```
kodu ile benzersiz kimliğimiz oluşuyor.
- Sonrasında *DataGenerator* dosyasında oluşturduğumuz 3 tane hazır nesnelerin *id* kısımlarını siliyoruz çünkü *Book* class'ında otomatik oluşacak artık.
- Şimdi BookController sınıfındaki metodlarımızda dışarıdan entity almamamız gerekir. Öncelikle *GetBooks* metodumuzu düzenleyeceğiz. İlk olarak *BookOperations* klasörü oluşturuyoruz, onun altına *GetBooks* klasörü oluşturuyoruz. Bu klasör içine *GetBooksQuery* class'ı oluşturuyoruz.
- Bu class içerisine öncelikle *_dbContext* adında bir *BookStoreDbContext* nesnesi oluştururuz. Bunu da öncelikle private yapıp ardından constructor metod üzerinden erişim sağlıyoruz.
```cs
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext; 
        public GetBooksQuery(BookStoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
    }
```
- Bu arada unutmadan bir tane Genre dosyası için bir enum oluşturacağız, bunun için ana dizinde bir *Common* klasörü oluşturup bu klasör içine *GenreEnum* dosyası oluşturuyoruz ve aşağıdaki kodları yazıyoruz:
```cs
    public enum GenreEnum
    {
        PersonalGrowth=1,
        ScienceFiction,
        Noval            
    }
```
bu genre'ler daha sonra genişletilebilir.
- Ardından kullanıcıya dönecek verinin ViewModel türünde olması gerektiğini söylemiştik, dönecek veriler için *GetBooksQuery* class'ının en altına:
```cs
    public class BookViewModel 
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
```

- Sonrasında kullanıcıya database'deki dosyaları döndürecek kodu yazıyoruz, yani asıl işi yapacak *Handle* metodu yine *GetBooksQuery* sınıfı içerisinde :
```cs
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
                    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
                    PageCount = book.PageCount
                });
            }
            return vm;
        }
```
- Ardından biz bu işlemi dışarıdan entity almamak için yaptık, şimdi *BookController* sınıfında *GetBooks* metodunu aşadğıdaki gibi değiştiriyoruz:
```cs
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context); 
            var result = query.Handle();
            return Ok(result); 
        }
```
- Sonrasında *AddBook* metodunu düzenleyeceğiz. *BookOperations* klasörü altına *CreateBook* klasörü oluşturup içine *CreateBookCommand* sınıfını oluşturuyoruz. Sınıfın içerisine yine *_dbContext* adında bir *BookStoreDbContext* nesnesi oluştururuz. Bunu da öncelikle private yapıp ardından constructor metod üzerinden erişim sağlıyoruz:
```cs
        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
```
- Ardından kullanıcıya dönecek verinin ViewModel türünde olması gerektiğini söylemiştik, dönecek veriler için *CreateNookModel* class'ının en altına:
```cs
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
```
- Ardından *Model* dosyasını oluşturduğumuz *CreateModelBook* a setlemek için *CreateBookCommand* sınıfının içinde en üste:
```cs
public CreateBookModel Model { get; set; }
```
kodunu yazıyoruz.
- Sonrasında asıl işi yapacak *Handle* metodunu oluşturuyoruz:
```cs
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x=>x.Title==Model.Title); 

            if (book is not null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut"); 
            }
            book = new Book(); 
            book.Title = Model.Title; 
            book.GenreId = Model.GenreId; 
            book.PageCount = Model.PageCount; 
            book.PublishDate = Model.PublishDate; 
            _dbContext.Books.Add(book); 
            _dbContext.SaveChanges(); 
        }
```
- *BookController* kısmında *AddBook* metodunu değiştirmeye geldi sıra:
```cs
            CreateBookCommand command = new CreateBookCommand(_context); 
            try 
            {
                command.Model = newBook; 
                command.Handle();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message); 
            }            
            return Ok();
```
Ardından *GetById* metodunu refactor ediyoruz. Bu metodda *BookOperations* klasörü içerisinde *GetBookDetail* klasörü oluşturup içine *GetBookDetailQuery* sınıfını oluşturuyoruz. Class içine:
```cs
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; } 
        public GetBookDetailQuery(BookStoreDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.OrderBy(x => x.Id == BookId).SingleOrDefault();
            BookDetailViewModel vm = new BookDetailViewModel(); 
            if (book is null) 
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/mm/yy");
            vm.Genre = book.GenreId.ToString();

            return vm;
        }
        public class BookDetailViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
```
- Ardından *BookController* sınıfı içerisinde kodumuzu düzenliyoruz.
```cs
        public IActionResult GetById(int id) 
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
```
- Sonrasında *Update* metodunu refactor etmemiz lazım. *BookOperations* içerisinde *UpdateBook* klasörü oluşturup içerisinde *UpdateBookCommand* sınıfı oluşturup aşağıdaki kodları ekliyoruz.
```cs
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
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId); 
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            book.Title = Model.Title != default ? Model.Title : book.Title; 
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId; 
            book.PageCount = Model.PageCount != default ? Model.GenreId : book.PageCount; 
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate; 
            _dbContext.SaveChanges(); 
                       
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
```
- Ardından *BookController* sınıfı içerisinde kodumuzu düzenliyoruz.
```cs
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
            return Ok();
        }
```
- Sonrasında *Delete* metodunu refactor etmemiz lazım. *BookOperations* içerisinde *DeleteBook* klasörü oluşturup içerisinde *DeleteBookCommand* sınıfı oluşturup aşağıdaki kodları ekliyoruz.
```cs
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
    public class DeleteBookModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
    }
```
- Ardından *BookController* sınıfı içerisinde kodumuzu düzenliyoruz.
```cs
