

using aquiestan.web.Site.DataTypes;
using Piranha.Extend.Fields.Settings;
using System.ComponentModel;

namespace aquiestan.web.Site.Blocks
{
    public class MapRegion
    {
        [Field]
        public StringField Title  { get; set; }

        [Field]
        public ImageField HeaderPicture { get; set; }

        [Field(Description="Motivo de este mapa.")]
        public TextField Body { get; set; }

        /// <summary>
        /// Colectivo para este mapa.
        /// Default = Todos (*).
        /// </summary>
        [Field]
        public DataSelectField<Colectivo> FiltroColectivos { get; set; }

    }
}
