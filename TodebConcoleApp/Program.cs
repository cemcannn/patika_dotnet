using System;
using TodebConsoleApp.Abstract;
using TodebConsoleApp.Concrete;

namespace TodebConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditcard = new CreditCard("Cem Can"); //CreditCard türünden ismi creditCard olan bir CreditCard nesnesi oluşturuyoruz.
            creditcard.BankName = "Akbank";
            creditcard.CardNumber = Guid.NewGuid().ToString(); //Guid bir değer üretir.
            creditcard.Iban = "123456789";
            creditcard.WriteCardUserName(); //WriteCardUserName metodu çalıştırır.

            TodebCard creditCard2 = new CreditCard("Cem Can"); //TodebCard türünden ismi creditCard2 olan bir CreditCard nesnesi oluşturuyoruz.
            creditCard2.BankName = "VakıfBank";
            creditCard2.CardNumber = Guid.NewGuid().ToString();
            //creditCard2.Iban Iban'ı direkt CreditCard sınıfında oluşturduğumuz için burada compile hatası verir.
            creditCard2.WriteCardUserName(); //WriteCardUserName metodu çalıştırır.
        }
    }
}
