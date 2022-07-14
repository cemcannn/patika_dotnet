using System;

namespace interface_concept
{
    public interface FileLogger : ILogger // ILogger interface'inden kalıtım aldı
    {
        void WriteLog()
        {
            System.Console.WriteLine("Dosyaya log yazar.");
        }       
    }
}