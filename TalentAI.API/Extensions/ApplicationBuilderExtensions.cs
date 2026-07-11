using TalentAI.API.Middlewares;

namespace TalentAI.API.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder
        UseCustomMiddlewares(
            this IApplicationBuilder app)
    {
        app.UseMiddleware<
            ExceptionHandlingMiddleware>();

        return app;
    }
}
