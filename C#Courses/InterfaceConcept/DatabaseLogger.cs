using System;

namespace interface_concept
{
    public interface DatabaseLogger : ILogger // ILogger interface'inden kalıtım aldı
    {
        void WriteLog()
        {
            System.Console.WriteLine("Database'e yazar.");
        }
    }
}