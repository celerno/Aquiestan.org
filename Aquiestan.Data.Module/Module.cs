using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;

namespace Aquiestan.Data.Module
{
    public class Module : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.Aquiestan.Data.Module, Title = "List Aquiestan.Data.Module content", Category = "Aquiestan.Data.Module", IsInternal = true },
            new PermissionItem { Name = Permissions.Aquiestan.Data.ModuleAdd, Title = "Add Aquiestan.Data.Module content", Category = "Aquiestan.Data.Module", IsInternal = true },
            new PermissionItem { Name = Permissions.Aquiestan.Data.ModuleEdit, Title = "Edit Aquiestan.Data.Module content", Category = "Aquiestan.Data.Module", IsInternal = true },
            new PermissionItem { Name = Permissions.Aquiestan.Data.ModuleDelete, Title = "Delete Aquiestan.Data.Module content", Category = "Aquiestan.Data.Module", IsInternal = true }
        };

        /// <summary>
        /// Gets the module author
        /// </summary>
        public string Author => "Celerino Herrera";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "Conector de datos AquiEstán y GoogleSheets";

        /// <summary>
        /// Gets the module version
        /// </summary>
        public string Version => Utils.GetAssemblyVersion(GetType().Assembly);

        /// <summary>
        /// Gets the module description
        /// </summary>
        public string Description => "";

        /// <summary>
        /// Gets the module package url
        /// </summary>
        public string PackageUrl => "";

        /// <summary>
        /// Gets the module icon url
        /// </summary>
        public string IconUrl => "/manager/PiranhaModule/piranha-logo.png";

        public void Init()
        {
            // Register permissions
            foreach (var permission in _permissions)
            {
                App.Permissions["Aquiestan.Data.Module"].Add(permission);
            }

            // Add manager menu items
            Menu.Items.Add(new MenuItem
            {
                InternalId = "Aquiestan.Data.Module",
                Name = "Aquiestan.Data.Module",
                Css = "fas fa-box"
            });
            Menu.Items["Aquiestan.Data.Module"].Items.Add(new MenuItem
            {
                InternalId = "Aquiestan.Data.ModuleStart",
                Name = "Module Start",
                Route = "~/manager/aquiestan.data.module",
                Policy = Permissions.Aquiestan.Data.Module,
                Css = "fas fa-box"
            });
        }
    }
}
