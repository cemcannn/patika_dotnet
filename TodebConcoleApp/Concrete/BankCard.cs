using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodebConsoleApp.Abstract;

namespace TodebConsoleApp.Concrete
{
    public class BankCard : TodebCard //Burada TodebCard abstract sınıfından kalıtım alıyoruz.
    {
        public BankCard(string username) : base(username) //Burada TodebCard abstract sınıfının constructorını kalıtım alıyoruz.
        {
        }
        public override void WriteCardUserName() //Burada TodebCard abstract sınıfının WriteCardUserName metodunu override ediyoruz..
        {
            Console.WriteLine($"{BankName} {_userName}"); //Normalde TodebCard sınıfında kodumuz Console.WriteLine(_userName); bu şekilde.
        }
    }
}
