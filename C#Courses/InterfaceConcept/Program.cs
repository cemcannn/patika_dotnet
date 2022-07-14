using System;

namespace interface_concept
{
    class Program
    {
        static void Main(string[] args)
        { 
            FileLogger fileLogger = new FileLogger(); //Bir instance ürettik.
            fileLogger.WriteLog(); //Metodu çalıştırdık.

            DatabaseLogger databaseLogger = new DatabaseLogger(); 
            databaseLogger.WriteLog();

            SmsLogger smsLogger = new(); //Bu şekilde de instance üretebiliyoruz.
            smsLogger.WriteLog();

            LogManager logManager = new LogManager(new FileLogger());
            logManager.WriteLog();
        }
    }
}