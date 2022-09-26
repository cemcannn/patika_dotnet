using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task invoke(HttpContext context) //Asenkron çalışacak fonksiyon
        {
            var watch = Stopwatch.StartNew(); //Bu fonksiyon bir izleme açar. Neyin ne kadar sürede çalıştığını takip eder.
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path; // Hangi Requestin talep edildiğini ve onun yolunu bize mesaj olarak verir
                _loggerService.Write(message);
                await _next(context); //Request bittikten sonra aşağıda bir işlem varsa onu çalıştırır.

                message = "[Request]   HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed.TotalMilliseconds + "ms";
                _loggerService.Write(message); //Request edilen metod, onun yolu, status code'u ve totalde kaç saniyede bu request gerçekleşti onu verir. 
            }
            catch (Exception ex)
            {
                watch.Stop(); //İzlemeyi durdurur.
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error]    HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.Elapsed.TotalMilliseconds + " ms."; //Hata durumunda yazılacak ve geriye dnecek mesaj
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new {error = ex.Message}, Formatting.None); //burada json objesini serialize edyoruz, onun için Newtonsoft.Json implement ediyoruz. 
            return context.Response.WriteAsync(result); //result objesini Response olarak döndürecek.
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();  
        }
    }
}
