using aquiestan.web.Models;
using Piranha.AspNetCore.Models;
using Piranha.AttributeBuilder;
using Piranha.Extend.Fields.Settings;

namespace aquiestan.web.Site.Pages
{
    [PageType(Title = "Página para colectivo", 
        IsArchive = true)]
    [PageTypeArchiveItem(typeof(IncidenciaPost))]
    public class ColectivoArchivePage:StandardArchive
    {
        [Region(Display = RegionDisplayMode.Content)]
        public MapRegion Mapa { get; set; }

        [Field(Description ="Color para el fondo del mapa. Default: sin color añadido")]
        [ColorFieldSettings(DefaultValue = "#00000000")]
        public ColorField Color { get; set; }

        [Field(Title="Nombre", Description = " para mostrar en el mapa")]
        public new TextField Title { get; set; }

        [Field]
        public TextField Body { get; set; }

        [Region(Display = RegionDisplayMode.Content, Title ="Documentos y fotografías.",Description ="Archivos recabados por este colectivo. Para cargar documentos relacionados a una incidencia, preferentemente ir a la incidencia en particular.", ListExpand = true)]
        public IList<MediaField> MediaAssets { get; set; }

    }
}
