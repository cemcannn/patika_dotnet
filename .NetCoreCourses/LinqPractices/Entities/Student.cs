using System.ComponentModel.DataAnnotations.Schema;

namespace LinqPractices.Entities
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Benzersiz kodu auto increment olarak ayarl�yoruz.
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassId { get; set; }
    }
}