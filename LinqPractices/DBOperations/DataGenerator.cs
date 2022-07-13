using LinqPractices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractices.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize() //Initialize metodu oluşturuyoruz, static olacak çünkü class ismiyle direkt erişmeliyiz.
        {
            using (var context = new LinqDbContext()) //LinqDbContext sınıfının Default constructor'ını çalıştırarak bir tane nesne oluşturuyoruz.
            {
                if (context.Students.Any()) //context içinde içinde data var mı diye kontrol ediyoruz.
                {
                    return; //Data zaten var ise işlem yapma.
                }
                context.Students.AddRange( //İçinde veri yoksa AddRange fonksiyonu ile birden fazla veri ekliyoruz.
                    new Student()
                    {
                        //StudentId = 1, //Student içerisinde Auto Increment olarak ayarladığımız için id otomatik gelecek.
                        Name = "Ali",
                        Surname = "Kılıç",
                        ClassId = 1
                    },
                    new Student()
                    {
                        //StudentId = 2,
                        Name = "Veli",
                        Surname = "Kılıç",
                        ClassId = 2
                    },
                    new Student()
                    {
                        //StudentId = 3,
                        Name = "Ayşe",
                        Surname = "Kılıç",
                        ClassId = 2
                    },
                    new Student()
                    {
                        StudentId = 4,
                        Name = "Fatma",
                        Surname = "Kılıç",
                        ClassId = 2
                    }
                );
                context.SaveChanges();//Değişiklikleri kaydediyoruz.
            }
        }
    }
}
