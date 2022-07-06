using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodebConsoleApp.Abstract;

namespace TodebConsoleApp.Concrete
{
    public class CreditCard : TodebCard   
    {
        public string Iban { get; set; }
        public CreditCard(string username) : base(username)
        {
        }
        public override void WriteCardUserName()
        {
            Console.WriteLine($"{BankName} {_userName}");
        }
    }
}
