using Piranha.AttributeBuilder;
using Piranha.Models;

namespace aquiestan.web.Models
{
    [PostType(Title = "Standard post")]
    public class StandardPost  : Post<StandardPost>
    {
    }
}