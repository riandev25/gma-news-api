namespace gma_news_api.Presentation.Extensions;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using gma_news_api.Presentation.Endpoints;
using Microsoft.AspNetCore.Builder;
using Serilog;

[ExcludeFromCodeCoverage]
public static class WebApplicationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        #region Logging

        _ = app.UseSerilogRequestLogging();

        #endregion Logging

        #region Security

        _ = app.UseHsts();

        #endregion Security

        #region API Configuration

        _ = app.UseHttpsRedirection();

        #endregion API Configuration

        #region Swagger

        var ti = CultureInfo.CurrentCulture.TextInfo;

        _ = app.UseSwagger();
        _ = app.UseSwaggerUI(c =>
            c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                $"gma_news_api - {ti.ToTitleCase(app.Environment.EnvironmentName)} - V1"));

        #endregion Swagger

        #region MinimalApi
        _ = app.MapNewsEndpoints();
        _ = app.MapVersionEndpoints();
        //_ = app.MapAuthorEndpoints();
        //_ = app.MapMovieEndpoints();
        //_ = app.MapReviewEndpoints();

        #endregion MinimalApi

        return app;
    }
}
