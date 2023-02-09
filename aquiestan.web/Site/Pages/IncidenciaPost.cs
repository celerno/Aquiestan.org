using aquiestan.web.Models;
using Piranha.AttributeBuilder;
using Piranha.Extend.Blocks;
using Piranha.Extend.Fields;

namespace aquiestan.web.Site.Pages
{
    [PostType(Title = "Incidencia")]
    [ContentTypeRoute(Title = "Incidencia", Route = "/colectivo/incidencia")]
    public class IncidenciaPost : StandardPost
    {
        [Region(Description = "Datos de la Incidencia", Display = RegionDisplayMode.Content, Title = "Datos")]
        public IncidenciaBlock Content { get; set; }
        public IncidenciaPost() {
        }

        public new string Excerpt
        {
            get => string.IsNullOrWhiteSpace(base.Excerpt) ? Content.AsRow: base.Excerpt;
            set {
                base.Excerpt = Content.AsRow;
            }
        }

        [Region(Display = RegionDisplayMode.Content, Title = "Documentos y fotografías", Description = "Archivos obtenidos relacionados a esta incidencia.", ListExpand = true)]
        public IList<ImageField> MediaAssets { get; set; }

    }
}
