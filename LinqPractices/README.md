# Linq Practices

- Öncelikle LinqPractices diye bir klasör oluşturup içinde bir console app oluşturuyoruz.
```
dotnet new console
```
- Ardından *entityframework*'ü kullanmak için *entity framework* ve *entityframework in memory* cx kullanmak için gerekli kodları [nuget](https://www.nuget.org/) sitesinden alarak terminalde çalıştırıp indiriyoruz.
```
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```
- Sonra *DBOperations* klasörü oluşturup içinde *LinqDbContext.cs* dosyasını oluşturuyoruz ve içeride namespace'i yazıp *LinqDbContext class*'ını oluşturuyoruz ve *DbContext* sınıfından kalıtım alıyoruz.
- Ardından ana dizinde bir *Entities* klasörü oluşturup içine Student dosyası oluşturuyoruz ve içine Student'a ait özellikleri yazıyoruz.
```cs
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Surname { get; set; }    
        public int Class { get; set; }
    }
``` 
- Sonasında oluşturduğumuz entity'i context içine ekliyoruz:
```cs
public DbSet<Student> Students { get; set; }
```
- Ardından *inmemory* çalışacağımızı database'e context içinde söylüyoruz:
```cs
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseInMemoryDatabase(databaseName : "LinqDatabase");
        } 
```
- Şu an hali hazırda bir datamız yok, bir data generator oluşturuyoruz, program başladığında hazır datalar elde etmek için. *DBOperations* içerisinde *DataGenerator.cs* class'ı oluşturuyoruz. Class içine:
```cs
public static void Initialize()
```
*initialize* metodu oluşturuyoruz.
- Initialize metodu içerisinde:
```cs
using (var context = new LinqDbContext())
```
constructor metodundan nesne üretiyoruz.
- Bu nesne içerisinde data var mı yok mu kontrol ediyoruz, eğer varsa:
```cs
                if (context.Students.Any()) //context içinde içinde data var mı diye kontrol ediyoruz.
                {
                    return; //Data zaten var ise işlem yapma.
                }
```
boş return ediyoruz. Eğer yoksa:
```cs
                context.Students.AddRange( //İçinde veri yoksa AddRange fonksiyonu ile birden fazla veri ekliyoruz.
                    new Student()
                    {
                        StudentId = 1,
                        Name = "Ali",
                        Surname = "Kılıç",
                        ClassId = 1
                    },
                );
```
AddRange metodu ile student nesneleri oluşturuyoruz.
- Sonrasında *Program.cs* dosyasında programı initialize ediyoruz ve detaları database'e ekliyoruz.
```cs
            DataGenerator.Initialize(); //Initialize metodu ile data oluşturuyoruz.
            LinqDbContext _context = new LinqDbContext(); //LinqDbContext türünden _context nesnesi oluşturuyoruz.
            var students = _context.Students.ToList<Student>; //Student'ları listeye ekliyor.
```
- Sırada primary key id'leri auto increment olarak ayarlayacağız. Student class'ı içerisinde:
```cs
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
```
- Ardından *DataGenerator* içerisindeki dataların id kısımlarını siliyoruz çünkü artık otomatik olarak oluşacak.

## Metodlar
### Find()
- Benzersiz kimlik üzerinden ilgili nesneyi bulmaya yarar. Birden fazla nesne varsa ilk nesneyi getirir.
### FirstOrDefault()
- Eğer nesne varsa getirir yoksa null döndürür. Birden fazla nesne varsa ilk nesneyi getirir.
### First()
- Eğer nesne varsa getirir yoksa hata atar. Birden fazla nesne varsa ilk nesneyi getirir.
### SingleOrDefault()
- Eğer nesne varsa getirir yoksa null döndürür. Birden fazla nesne varsa hata atar.
### ToList()
- Listeleme yapar.
### Count
- Liste sayısını verir.
### OrderBy
- Filtreleme yaparak sıralama yapar.
### OrderByDescending
- Filtreleme yaparak tersten sıralama yapar.
### Anonymous Objcet Result
- Anonymous bir obje yaratmaya yarar.

--- 

# LINQ (Language Integrated Query)

LINQ .Net Framework 3.5 ve Visual Studio 2008 ile hayatımıza giren farklı data source yani veri kaynaklarını sorgulamamıza yarayan bir dildir. LINQ Visual Basic ve C# ile birlikte kullanılabilir.


Linq IQuerayable sınıflar ve IQuerayable'dan türeyen sınıflarla birlikte kullanılabilir. EF Core ile yarattığımız context'in elemanları yani tabloların koddaki karşıklıkları DBSet tipindedir. DBSet de IQuerayable sınıfından türeyen bir sınıftır. Dolayısıyla LINQ kullanılarak DBSet'ler üzerinde sorgulama yapılabilir.

Günlük hayatımızda Entity Framework Core ile birlikte LINQ'yu çok kullanıyoruz. Ve her gün nerdeyse kullandığımız bazı temel Linq metotları vardır.

Başlıca önemli LINQ metotları şu şekilde:

- First()
- Find()
- FirstOrDefault()
- Single()
- SingleOrDefault()
- ToList()
- Count()
- Min()
- Max()
- Last()
- LastOrDefault()
- Average()

Şimdi LINQ metotlarının bazılarının kullanımlarına tek tek örnekler ile birlikte bakalım.

- Find()
DBSet sınıfı ile kullanılabilen bir metottur. İlgili DbSet üzerinden Primary Key olarak tanımlanan alana göre arama yapmak için kullanılır.

```cs
using (var ctx = new BookStoreDbContext())
{
    var book = ctx.Books.Find(id);
}
```

- First/FirstOrDefault()

First ve FirstOrDefault birden fazla verinin olabileceği sorgulamaların sonunda listedeki ilk elemanı seçmek için kullanılır.

```cs
using (var ctx = new BookStoreDbContext())
{
    var books = ctx.Books
                    .Where(s => s.Title == "Herland")
                    .FirstOrDefault<Book>();
}
```
**Önemli:** First() ve FirstOrDefault() arasındaki temel fark; eğer listede veri bulunamazsa First() hata fırlatırken, FirstOrDefault() geriye null döndürür. Bu nedenle FirstOrDefault() ile veriyi çekip daha sonradan verinin null olup olmadığını kontrol etmek daha doğru bir yaklaşım olur.

- SingleOrDefault()

Sorgulama sonunda kalan tek veriyi geri döndürür. Eğer listede birden fazla eleman varsa hata döndürür. Listede hiç eleman yoksa geriye null döndürür.

```cs
using (var ctx = new BookStoreDbContext())
{
    var books = ctx.Books
                    .Where(s => s.Title == "Herland")
                    .SingleOrDefault<Book>();
}
```

- ToList()

Sorgulama sonucunu geriye koleksiyon olarak döndürmek için kullanılır.

```cs
using (var ctx = new BookStoreDbContext())
{
    var bookList = ctx.Books.Where(s => s.GenreId == 2).ToList();
}
```

- OrderBy/OrderByDescending()

OrderBy() bir listeyi sıralamak için kullanılır. OrderBy() varsayılan olarak Ascending sıralama sunar. Tersi sıralamak için OrderByDescending() kullanılmalıdır.

```cs
using (var ctx = new BookStoreDbContext())
{
    var books = ctx.Books.OrderBy(s => s.Title).ToList();

    // or descending order
    var  descBooks = ctx.Books.OrderByDescending(s => s.Title).ToList();
}
```

- GroupBy()

Belirli bir alana göre verileri gruplamak için kullanılır.

```cs
using (var ctx = new BookStoreDbContext())
{
    var books = ctx.Books.GroupBy(s => s.GenreId);

    foreach (var groupItem in books)
    {
        Console.WriteLine(groupItem.Key);

        foreach (var book in groupItem)
        {
            Console.WriteLine(book.GenreId);
        }

    }
}
```

- Parameterized Query

LINQ içerisinde parametreleri kullanabiliriz.

```cs
using (var ctx = new BookStoreDbContext())
{
    string title = "Herland";
    var book = ctx.Books
                .Where(s => s.Title == name)
                .FirstOrDefault<Book>();
}
```

- Anonymous Object Result

LINQ her zaman geriye entity objesi dönmek zorunda değildir. Query sonucunu kendi yarattığınız bir obje formatında döndürebilirsiniz.

```cs
using (var ctx = new BookStoreDbContext())
{
    var anonymousObjResult = ctx.Books
                                .Where(b => b.GenreId == 2)
                                .Select(b => new {
                                            Id = b.Id,
                                            BookName = b.Title });

    foreach (var obj in anonymousObjResult)
    {
        Console.Write(obj.Name);
    }
}
```
