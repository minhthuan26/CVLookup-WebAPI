namespace CVLookup_WebAPI.Middleware
{
    public class AuthMiddlewareBuilder
    {

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<AuthMiddleware>();
        }
    }
}
