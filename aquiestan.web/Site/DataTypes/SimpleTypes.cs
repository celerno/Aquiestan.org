using aquiestan.web.Site.Pages;
using Piranha.AttributeBuilder;
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
            var colectivo = await api.Pages.GetByIdAsync<ColectivoPage>(Guid.Parse(id));
            if (colectivo == null)
                return null;

            return new Colectivo
            {
                Id = Guid.Parse(colectivo?.Id.ToString()),
                Nombre = colectivo?.Nombre?.Value
            };
        }

        // Gets all of the available items to choose from using
        // the injected services you specify.
        public static async Task<IEnumerable<DataSelectFieldItem>> GetList(IApi api)
        {
            var colectivos = await api.Pages.GetAllAsync<ColectivoPage>();
            if(colectivos== null) 
                return null;

            return colectivos?.Select(p => new DataSelectFieldItem
            {
                Id = p?.Id.ToString(),
                Name = p?.Nombre?.Value
            });
        }

    }

    public class IncidenciaParametros
    {
        [Field]
        public DataSelectField<Colectivo> Colectivo { get; set; }
        [Field]
        public DateField FechaHallazgo { get; set; }

        [Field(Description ="Usado para ubicar la incidencia en el mapa. De no encontrarse se utilizará el campo Localidad.")]
        public StringField Latitud { get; set; }

        [Field(Description = "Usado para ubicar la incidencia en el mapa. De no encontrarse se utilizará el campo Localidad.")]
        public StringField Longitud { get; set; }

        [Field(Description ="Un valor encontrable en un mapa (Municipio, Ranchería, Ejido, etcétera).")]
        public StringField Localidad { get; set; }

        [Field(Description ="Para indicar algún comentario referente a la ubicación del hallazgo tipo señalizaciones, indicaciones para llegar, condiciones especiales, etcétera.")]
        public StringField ReferenciasDeUbicacion { get; set; }
    }

    [PageType(Description = "Entrada relativa a una incidencia en particular.")]
    public class IncidenciaPost:Post<IncidenciaPost>
    {
        public Guid Id { get; set; }


        [Region(Display = RegionDisplayMode.Content)]
        public IncidenciaParametros Parametros { get; set; }

        [Region(Display = RegionDisplayMode.Content, Title = "Documentos y fotografías", Description ="Archivos obtenidos relacionados a esta incidencia.", ListExpand = true)]
        public IList<MediaField> MediaAssets { get; set; }

    }
}
