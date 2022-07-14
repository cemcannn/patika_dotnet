using LinqPractices.DBOperations;
using LinqPractices.Entities;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize(); //Initialize metodu ile data oluşturuyoruz.
            LinqDbContext _context = new LinqDbContext(); //LinqDbContext türünden _context nesnesi oluşturuyoruz.
            var students = _context.Students.ToList<Student>; //Student'ları listeye ekliyor.

            //Find()
            Console.WriteLine("**** Find ****");
            var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault(); //Find metodu kullanmadan 1 id'li student bulma işlemi.
            var student1 = _context.Students.Find(1); //Find() metodu ile 1 idli student buluyoruz.
            Console.WriteLine(student.Name);

            //FirstOrDefault()
            Console.WriteLine("**** First or Default ****");
            var student2 = _context.Students.Where(student => student.Surname == "Kılıç").FirstOrDefault(); //Soyadı Kılıç olan student nesnesini varsa getirir yoksa null döndürür. Where kullanımı ile.
            var student3 = _context.Students.FirstOrDefault(student => student.Surname == "Kılıç"); //Where şartını kullanmadan.
            Console.WriteLine(student3.Name);

            //SingleOrDefault()
            Console.WriteLine("**** Single or Default ****");
            var student4 = _context.Students.SingleOrDefault(student => student.Name == "Veli"); //Veli ismindeki nesneyi getirir.
            /*var student5 = _context.Students.SingleOrDefault(student => student.Surname == "Kılıç"); *///Birden fazla Kılıç soyadı olduğu için hata atar.

            //ToList()
            Console.WriteLine("**** To List ****");
            var studentList = _context.Students.Where(student => student.Surname == "Kılıç").ToList(); //Soyadı Kılıç olanları listeler.
            Console.WriteLine(studentList.Count);//studentList içerisindeki nesne sayısını yazdırır.

            //OrderBy()
            Console.WriteLine("**** Order By ****");
            var studentList2 = _context.Students.OrderBy(student => student.Name).ToList(); //Name alanına göre sıralar.
            foreach (var st in studentList2)
            {
                Console.WriteLine(student.Name);
            }

            //OrderByDescending()
            Console.WriteLine("**** Order By Descending ****");
            var studentList3 = _context.Students.OrderByDescending(student => student.Name).ToList(); //Name alanına göre tersten sıralar.
            foreach (var st in studentList3)
            {
                Console.WriteLine(student.Name);
            }

            //AnonymousObjectResult()
            Console.WriteLine("**** Anonymous Object Result ****");
            var anonymousObject = _context.Students.Where(x => x.ClassId == 2).Select(x => new { Id = x.StudentId, Fullname = x.Name + " " + x.Surname }); //Burada önce filtreleme yapıp ardından anonymous object ile yeni bir obje yaratıyoruz.
            foreach (var st in anonymousObject)
            {
                Console.WriteLine(st.Id + " " + st.Fullname);
            }
        }
    }
}