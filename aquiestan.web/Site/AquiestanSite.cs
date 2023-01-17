using Piranha.AttributeBuilder;
using Piranha.Extend;
using Piranha.Extend.Fields;
using Piranha.Models;

namespace aquiestan.web.Site
{
    [SiteType(Title ="Aqui están - main")]
    public class AquiestanSite: SiteContent<AquiestanSite>
    {
        [Field(Title= "Título default para el sitio")]
        public string Title { get; set; }

        [Region(Description = "Logo")]
        public ImageField Logo { get; set; }


    }
}
