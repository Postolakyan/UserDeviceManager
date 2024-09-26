namespace UserDeviceManager.Api.MIddlewares;

public class LoggingMiddleware
{
    public readonly RequestDelegate _next;
    private readonly string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
    private readonly string logFilePath;
    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
        logFilePath = Path.Combine(logDirectory, "logs.txt");

        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
    }


    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        try
        {
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);

                var responseType = context.Response.ContentType;
                var responseMessage = await FormatResponse(context.Response);

                var logMessage = $"Return Type: {responseType}, Message: {responseMessage}";

                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
        catch (Exception ex)
        {
            File.AppendAllText("logs.txt", "Error: " + ex.Message + Environment.NewLine);
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
