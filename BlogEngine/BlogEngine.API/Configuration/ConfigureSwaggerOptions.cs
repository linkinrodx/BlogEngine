using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BlogEngine.API.Configuration
{
    //public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    //{
    //    private readonly IApiVersionDescriptionProvider _provider;

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
    //    /// </summary>
    //    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    //    {
    //        _provider = provider;
    //    }

    //    public void Configure(SwaggerGenOptions options)
    //    {
    //        foreach (var description in _provider.ApiVersionDescriptions)
    //        {
    //            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
    //            options.CustomSchemaIds(x => x.FullName);
    //        }
    //    }

    //    private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
    //    {
    //        var info = new OpenApiInfo()
    //        {
    //            Title = "DirectvGo Content API",
    //            Version = description.ApiVersion.ToString(),
    //            Description = "This API provides a set of endpoint to manage all actions related to the Content service",
    //        };

    //        if (description.IsDeprecated)
    //        {
    //            info.Description += " This API version has been deprecated.";
    //        }

    //        return info;
    //    }
    //}
}
