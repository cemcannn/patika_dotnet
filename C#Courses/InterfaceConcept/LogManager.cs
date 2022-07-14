using System;

namespace interface_concept
{
    public interface LogManager : ILogger //ILogger'dan kalıtım alıyor.
    {
        public ILogger _logger; //Burada interface'in referansını yaratıyoruz.

        public LogManager(ILogger logger) //Interface'in bir referansını (Instance değil çünkü interfacelerin instance'ı olamaz) parametre olarak alıyor.
        {
            _logger = logger; //_logger referansını, aldığı logger parametresine eşitliyoruz.
        }

        public void WriteLog()
        {
            _logger.WriteLog(); //ILogger'dan türeyen _logger'ın WriteLog() metodunu çalıştırıyor.
        }
    }
}