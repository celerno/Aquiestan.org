using aquiestan.web.Site.Pages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields;
using System.Runtime.Serialization;
using static Piranha.Manager.Models.PageListModel;

namespace aquiestan.web.Site.DataTypes
{
    public class Colectivo
    {
        // The id of the page
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public IList<IncidenciaPost> Incidencias { get; set; }
        // Gets a single item with the provided id using the
        // injected services you specify.
        public static async Task<Colectivo> GetById(string id, IApi api)
        {
            var colectivo = await api.Pages.GetByIdAsync<ColectivoArchivePage>(Guid.Parse(id));
            if (colectivo == null)
                return null;

            return new Colectivo
            {
                Id = Guid.Parse(colectivo?.Id.ToString()),
                Nombre = colectivo?.Title?.Value
            };
        }

        // Gets all of the available items to choose from using
        // the injected services you specify.
        public static async Task<IEnumerable<DataSelectFieldItem>> GetList(IApi api)
        {
            var colectivos = await api.Pages.GetAllAsync<ColectivoArchivePage>();
            if(colectivos== null) 
                return null;

            return colectivos?.Select(p => new DataSelectFieldItem
            {
                Id = p?.Id.ToString(),
                Name = p?.Title?.Value
            });
        }

    }
}
