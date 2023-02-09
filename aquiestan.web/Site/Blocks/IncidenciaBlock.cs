using Markdig.Parsers;

using Piranha.Extend;

namespace aquiestan.web.Site.Blocks
{
    public class IncidenciaBlock : Block
    {
        public IncidenciaBlock()
        {
        }

        [Field]
        public DataSelectField<Colectivo> Colectivo { get; set; }
        [Field]
        public DateField FechaHallazgo { get; set; }

        [Field(Description = "Usado para ubicar la incidencia en el mapa. De no encontrarse se utilizará el campo Localidad.")]
        public StringField Latitud { get; set; }

        [Field(Description = "Usado para ubicar la incidencia en el mapa. De no encontrarse se utilizará el campo Localidad.")]
        public StringField Longitud { get; set; }

        [Field(Description = "Un valor encontrable en un mapa (Municipio, Ranchería, Ejido, etcétera).")]
        public StringField Localidad { get; set; }

        [Field(Description = "Para indicar algún comentario referente a la ubicación del hallazgo tipo señalizaciones, indicaciones para llegar, condiciones especiales, etcétera.")]
        public StringField ReferenciasDeUbicacion { get; set; }

        [Field(Description = "Campos extraídos sin formato apropiado o sin formato en modo json", Title = "Campos sin procesamiento")]
        public StringField CamposSinFormato { get; set; }

        public string AsHtmlTable => $"<table><tr><td>{FechaHallazgo.Value}</td><td>{Longitud.Value}</td><td>{Latitud.Value}</td><td>{Localidad.Value}</td></table>";

        public string AsRow => $"<td>{FechaHallazgo.Value?.ToShortDateString()}</td><td>{Longitud.Value}</td><td>{Latitud.Value}</td><td>{Localidad.Value}</td>";
        public override string ToString()
        {
            return $"{Longitud}::{Latitud}::{Localidad}::{FechaHallazgo}";
        }
    }
}
