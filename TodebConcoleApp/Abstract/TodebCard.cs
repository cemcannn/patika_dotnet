using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TodebConsoleApp.Abstract
{
    public abstract class TodebCard
    {
        protected string _userName { get; set; } //Burada encapsulation işlemi yapıyoruz.
        public TodebCard(string username) //Burada contructor oluşturuyoruz.
        {
            _userName = username; //Constructor içinde access modifiersı protected olan _username değerine dışarıdan adlığımız username değerini eşitliyoruz.
        }
        public string CardNumber { get; set; } //
        public DateTime ExpireDate { get; set; }
        public string BankName { get; set; }
        public virtual void WriteCardUserName()
        {
            Console.WriteLine(_userName);
        }
    }
}
