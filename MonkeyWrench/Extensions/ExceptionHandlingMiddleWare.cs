namespace MonkeyWrench.Extensions
{
    public class ExceptionHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleWare> _logger;

        public ExceptionHandlingMiddleWare(RequestDelegate next,
            ILogger<ExceptionHandlingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                context.Response.Redirect("/Error");
            }
        }
    }
}
