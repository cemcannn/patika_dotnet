using System.Linq;

namespace PhoneBookProject
{
    class Contact
    {
        private string firstName;
        private string lastName;
        private string phoneNumber;

        public string FirstName { get => firstName; set => firstName = value; } 
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}