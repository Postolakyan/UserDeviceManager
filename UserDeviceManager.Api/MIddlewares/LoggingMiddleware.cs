namespace UserDeviceManager.Api.MIddlewares;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string logDirectory;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
        logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var logFilePath = Path.Combine(logDirectory, $"{DateTime.UtcNow:yyyy-MM-dd_HH-mm-ss}.log");

        var originalBodyStream = context.Response.Body;

        try
        {
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                var responseType = context.Response.ContentType;
                var responseMessage = await FormatResponse(context.Response);

                var logMessage = $"Timestamp: {DateTime.UtcNow}\nReturn Type: {responseType}\nMessage: {responseMessage}";

                await File.WriteAllTextAsync(logFilePath, logMessage);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception ex)
        {
            var errorLogMessage = $"Error: {ex.Message}\nStack Trace: {ex.StackTrace}";
            await File.AppendAllTextAsync(logFilePath, errorLogMessage + Environment.NewLine);

            throw;
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return text;
    }
}

