using aquiestan.web.Models;
using Piranha.AttributeBuilder;

namespace aquiestan.web.Site.Pages
{
    [PostType(Title = "Incidencia")]
    [ContentTypeRoute(Title = "Incidencia", Route = "/colectivo/incidencia")]
    [PageType(Title = "Incidencia")]
    [BlockItemType(typeof(IncidenciaBlock))]
    [BlockItemType(typeof(IList<MediaField>))]
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
        public IList<MediaField> MediaAssets { get; set; }

    }
}
