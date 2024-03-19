public class TimeMiddleware
{
    readonly RequestDelegate next;  //invoca al middleware que sigue en el ciclo

    public TimeMiddleware(RequestDelegate nextRequest) //constructor
    {
        next = nextRequest;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context); //invoca al middleware que sigue

        if(context.Request.Query.Any(p => p.Key == "time")) //al que tiene time le escribimos la fecha actual
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }    
}

public static class TimeMiddlewareExtension //ayuda a que en program se haga el uso del middleware TimeMiddleware
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}