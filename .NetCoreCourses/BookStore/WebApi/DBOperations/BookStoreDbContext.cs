using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext //Bunun bir database context olduğunu göstermek için kalıtım alıyoruz.
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) // Burada Default Constructor yaratıyoruz ve base sınıfından options'ı kalıtım alıyoruz.
        { } // Süslü parantez aç kapa yapıyoruz, çünkü varsıylan bir kurucu fonksiyon.
        public DbSet<Book> Books { get; set; } // Database'e Book entity (nesne) sini ekledik şu an, Book entity'sini eklerken Books olarak yazmalıyız.
        // Bu entity database ile koddaki nesneler arasında bir köprü vazifesi görüyor. Burada "Book" ise  database deki "Books" objenin replikası konumunda. Yani burada Book entity'sinin database kısmında karşılığı Books sınıfı olacak. DbSet ile bunu ayarlamış oluyoruz.
    }
    
}