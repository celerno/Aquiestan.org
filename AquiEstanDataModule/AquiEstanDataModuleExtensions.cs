using AquiEstanDataModule;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Piranha;
using Piranha.AspNetCore;

public static class AquiEstanDataModuleExtensions
{
    /// <summary>
    /// Adds the AquiEstanDataModule module.
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <returns></returns>
    public static PiranhaServiceBuilder UseAquiEstanDataModule(this PiranhaServiceBuilder serviceBuilder)
    {
        serviceBuilder.Services.AddAquiEstanDataModule();

        return serviceBuilder;
    }

    /// <summary>
    /// Uses the AquiEstanDataModule module.
    /// </summary>
    /// <param name="applicationBuilder">The current application builder</param>
    /// <returns>The builder</returns>
    public static PiranhaApplicationBuilder UseAquiEstanDataModule(this PiranhaApplicationBuilder applicationBuilder)
    {
        applicationBuilder.Builder.UseAquiEstanDataModule();

        return applicationBuilder;
    }

    /// <summary>
    /// Adds the AquiEstanDataModule module.
    /// </summary>
    /// <param name="services">The current service collection</param>
    /// <returns>The services</returns>
    public static IServiceCollection AddAquiEstanDataModule(this IServiceCollection services)
    {
        // Add the AquiEstanDataModule module
        Piranha.App.Modules.Register<Module>();

        // Setup authorization policies
        services.AddAuthorization(o =>
        {
            // AquiEstanDataModule policies
            o.AddPolicy(Permissions.AquiEstanDataModule, policy =>
            {
                policy.RequireClaim(Permissions.AquiEstanDataModule, Permissions.AquiEstanDataModule);
            });

            // AquiEstanDataModule add policy
            o.AddPolicy(Permissions.AquiEstanDataModuleAdd, policy =>
            {
                policy.RequireClaim(Permissions.AquiEstanDataModule, Permissions.AquiEstanDataModule);
                policy.RequireClaim(Permissions.AquiEstanDataModuleAdd, Permissions.AquiEstanDataModuleAdd);
            });

            // AquiEstanDataModule edit policy
            o.AddPolicy(Permissions.AquiEstanDataModuleEdit, policy =>
            {
                policy.RequireClaim(Permissions.AquiEstanDataModule, Permissions.AquiEstanDataModule);
                policy.RequireClaim(Permissions.AquiEstanDataModuleEdit, Permissions.AquiEstanDataModuleEdit);
            });

            // AquiEstanDataModule delete policy
            o.AddPolicy(Permissions.AquiEstanDataModuleDelete, policy =>
            {
                policy.RequireClaim(Permissions.AquiEstanDataModule, Permissions.AquiEstanDataModule);
                policy.RequireClaim(Permissions.AquiEstanDataModuleDelete, Permissions.AquiEstanDataModuleDelete);
            });
        });

        // Return the service collection
        return services;
    }

    /// <summary>
    /// Uses the AquiEstanDataModule.
    /// </summary>
    /// <param name="builder">The application builder</param>
    /// <returns>The builder</returns>
    public static IApplicationBuilder UseAquiEstanDataModule(this IApplicationBuilder builder)
    {
        return builder.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new EmbeddedFileProvider(typeof(Module).Assembly, "AquiEstanDataModule.assets.dist"),
            RequestPath = "/manager/AquiEstanDataModule"
        });
    }

    /// <summary>
    /// Static accessor to AquiEstanDataModule module if it is registered in the Piranha application.
    /// </summary>
    /// <param name="modules">The available modules</param>
    /// <returns>The AquiEstanDataModule module</returns>
    public static Module AquiEstanDataModule(this Piranha.Runtime.AppModuleList modules)
    {
        return modules.Get<Module>();
    }
}
