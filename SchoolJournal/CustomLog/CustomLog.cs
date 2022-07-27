using Microsoft.AspNetCore.Http;

namespace CustomLog
{
    public class CustomLog : ICustomLog
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public CustomLog(RequestDelegate next)
        {
            _next = next;
        }        

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            string logFilePath = Path.Combine($"C:\\Logs", "RequestLog.txt");

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, 
                                          $"\n{DateTime.Now}" +
                                          $"\t{context.User.Identity.Name}" +
                                          $"\t{context.Request.Method}" +
                                          $"\t{context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
