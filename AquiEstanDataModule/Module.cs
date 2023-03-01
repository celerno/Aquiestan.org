using Piranha;
using Piranha.Extend;
using Piranha.Manager;
using Piranha.Security;

namespace AquiEstanDataModule
{
    public class Module : IModule
    {
        private readonly List<PermissionItem> _permissions = new List<PermissionItem>
        {
            new PermissionItem { Name = Permissions.AquiEstanDataModule, Title = "List AquiEstanDataModule content", Category = "AquiEstanDataModule", IsInternal = true },
            new PermissionItem { Name = Permissions.AquiEstanDataModuleAdd, Title = "Add AquiEstanDataModule content", Category = "AquiEstanDataModule", IsInternal = true },
            new PermissionItem { Name = Permissions.AquiEstanDataModuleEdit, Title = "Edit AquiEstanDataModule content", Category = "AquiEstanDataModule", IsInternal = true },
            new PermissionItem { Name = Permissions.AquiEstanDataModuleDelete, Title = "Delete AquiEstanDataModule content", Category = "AquiEstanDataModule", IsInternal = true }
        };

        /// <summary>
        /// Gets the module author
        /// </summary>
        public string Author => "Celerino Herrera";

        /// <summary>
        /// Gets the module name
        /// </summary>
        public string Name => "Connector con Google Sheets";

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
                App.Permissions["AquiEstanDataModule"].Add(permission);
            }

            // Add manager menu items
            Menu.Items.Add(new MenuItem
            {
                InternalId = "AquiEstanDataModule",
                Name = "Carga de Datos",
                Css = "fas fa-box"
            });
            Menu.Items["AquiEstanDataModule"].Items.AddRange(new MenuItem[]{
            new MenuItem
            {
                InternalId = "AquiEstanDataModuleStart",
                Name = "Configuración",
                Route = "~/manager/aquiestandatamodule",
                Policy = Permissions.AquiEstanDataModule,
                Css = "fas fa-box"
            }
            });
        }
    }
}
