using Aquiestan.Data.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.AspNetCore;

public static class Aquiestan.Data.ModuleExtensions
{
    /// <summary>
    /// Adds the Aquiestan.Data.Module module.
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <returns></returns>
    public static PiranhaServiceBuilder UseAquiestan.Data.Module(this PiranhaServiceBuilder serviceBuilder)
{
    serviceBuilder.Services.AddAquiestan.Data.Module();

    return serviceBuilder;
}

/// <summary>
/// Uses the Aquiestan.Data.Module module.
/// </summary>
/// <param name="applicationBuilder">The current application builder</param>
/// <returns>The builder</returns>
public static PiranhaApplicationBuilder UseAquiestan.Data.Module(this PiranhaApplicationBuilder applicationBuilder)
{
    applicationBuilder.Builder.UseAquiestan.Data.Module();

    return applicationBuilder;
}

/// <summary>
/// Adds the Aquiestan.Data.Module module.
/// </summary>
/// <param name="services">The current service collection</param>
/// <returns>The services</returns>
public static IServiceCollection AddAquiestan.Data.Module(this IServiceCollection services)
{
    // Add the Aquiestan.Data.Module module
    Piranha.App.Modules.Register<Module>();

    // Setup authorization policies
    services.AddAuthorization(o =>
    {
        // Aquiestan.Data.Module policies
        o.AddPolicy(Permissions.Aquiestan.Data.Module, policy =>
        {
            policy.RequireClaim(Permissions.Aquiestan.Data.Module, Permissions.Aquiestan.Data.Module);
        });

        // Aquiestan.Data.Module add policy
        o.AddPolicy(Permissions.Aquiestan.Data.ModuleAdd, policy =>
        {
            policy.RequireClaim(Permissions.Aquiestan.Data.Module, Permissions.Aquiestan.Data.Module);
            policy.RequireClaim(Permissions.Aquiestan.Data.ModuleAdd, Permissions.Aquiestan.Data.ModuleAdd);
        });

        // Aquiestan.Data.Module edit policy
        o.AddPolicy(Permissions.Aquiestan.Data.ModuleEdit, policy =>
        {
            policy.RequireClaim(Permissions.Aquiestan.Data.Module, Permissions.Aquiestan.Data.Module);
            policy.RequireClaim(Permissions.Aquiestan.Data.ModuleEdit, Permissions.Aquiestan.Data.ModuleEdit);
        });

        // Aquiestan.Data.Module delete policy
        o.AddPolicy(Permissions.Aquiestan.Data.ModuleDelete, policy =>
        {
            policy.RequireClaim(Permissions.Aquiestan.Data.Module, Permissions.Aquiestan.Data.Module);
            policy.RequireClaim(Permissions.Aquiestan.Data.ModuleDelete, Permissions.Aquiestan.Data.ModuleDelete);
        });
    });

    // Return the service collection
    return services;
}

/// <summary>
/// Uses the Aquiestan.Data.Module.
/// </summary>
/// <param name="builder">The application builder</param>
/// <returns>The builder</returns>
public static IApplicationBuilder UseAquiestan.Data.Module(this IApplicationBuilder builder)
{
    return builder.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new EmbeddedFileProvider(typeof(Module).Assembly, "Aquiestan.Data.Module.assets.dist"),
        RequestPath = "/manager/Aquiestan.Data.Module"
    });
}

/// <summary>
/// Static accessor to Aquiestan.Data.Module module if it is registered in the Piranha application.
/// </summary>
/// <param name="modules">The available modules</param>
/// <returns>The Aquiestan.Data.Module module</returns>
public static Module Aquiestan.Data.Module(this Piranha.Runtime.AppModuleList modules)
{
    return modules.Get<Module>();
}
}
