﻿namespace ETicaretAPI.api.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
        private readonly string path = "";

        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[An unhandled exception occurred.]");

                using var fileStream = new FileStream($@"C:\Users\Casper\Desktop\GitHub Projects\ETicaretAPI\ETicaretAPI.api\Logs\logError.txt", FileMode.Append);

                using var streamWriter = new StreamWriter(fileStream);

                await streamWriter.WriteLineAsync($"{DateTime.UtcNow} - {ex.Message}");
                await streamWriter.FlushAsync();

                throw;
            }
        }
    }
}
