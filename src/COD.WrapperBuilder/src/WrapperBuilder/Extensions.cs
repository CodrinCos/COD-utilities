using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WrapperBuilder.Models;

namespace WrapperBuilder;

public static class Extensions
{
    private const string SectionName = "AppOptions";
    public static WebApplicationBuilder AddCOD(this WebApplicationBuilder builder, string sectionName = SectionName)
    {
        if (string.IsNullOrWhiteSpace(sectionName))
        {
            sectionName = SectionName;
        }

        var options = builder.GetOptions<AppOptions>(sectionName);
        builder.Services.AddSingleton(options);

        return builder;
    }

    public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
    where TModel : new()
    {
        var model = new TModel();
        configuration.GetSection(sectionName).Bind(model);

        return model;
    }

    public static TModel GetOptions<TModel>(this WebApplicationBuilder builder, string settingsSectionName)
        where TModel : new()
    {
        if (builder.Configuration is not null)
        {
            return builder.Configuration.GetOptions<TModel>(settingsSectionName);
        }

        using var serviceProvider = builder.Services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        return configuration.GetOptions<TModel>(settingsSectionName);
    }
}
