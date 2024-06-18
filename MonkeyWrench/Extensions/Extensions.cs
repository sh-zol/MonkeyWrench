namespace MonkeyWrench.Extensions
{
    public static class Extensions
    {
        public static IApplicationBuilder CustomExceptionHandlingMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleWare>();
        }
    }
}
