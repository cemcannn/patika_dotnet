using System;

namespace interface_concept
{
    public interface SmsLogger : ILogger // ILogger interface'inden kalıtım aldı
    {
        public void WriteLog()
        {
            Console.WriteLine("Sms olarak log yazar.");
        }
    }
}