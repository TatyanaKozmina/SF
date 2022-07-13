using MVCStartApp.Models;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IHistoryRepository histRepo)
        {
            // Для логирования данных о запросе используем свойста объекта HttpContext
            await histRepo.RecordHistory($"{context.Request.Host.Value + context.Request.Path}");
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
