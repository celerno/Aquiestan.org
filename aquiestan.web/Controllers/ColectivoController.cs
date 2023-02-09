using aquiestan.web.Site.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Piranha.AspNetCore.Models;
using Piranha.AspNetCore.Services;

namespace aquiestan.web.Controllers
{
    public class ColectivoController : Controller
    {
        private readonly IApi Api;
        private readonly IModelLoader Loader;
        public ColectivoController(IApi api, IModelLoader loader) {
        Api = api;
            Loader = loader;
        }
        [HttpGet]
        [HttpPost]
        public IActionResult Incidencia(Guid id)
        {
            if (id == Guid.Empty)
            {
                var model = new SinglePostWithComments<IncidenciaPost>(Api, Loader);

                model.Data = new IncidenciaPost
                {
                    Id = id,
                    Content =
                    new IncidenciaBlock { Colectivo = new DataSelectField<Colectivo>() { Value = new Colectivo { Id = id, Nombre = "sample" } } }
                };
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), model.ModelState);
                model.Data.Category = new Taxonomy { Id = id, Slug = "incidencia", Type = TaxonomyType.Category, Title = "Incidencia" };



                return View("IncidenciaPost", model);
            }
            else
            {
                var post = Loader.GetPostAsync<IncidenciaPost>(id, User).Result;
                post.Excerpt = string.Empty;
                var model = new SinglePostWithComments<IncidenciaPost>(Api, Loader);
                model.Data = post;
                

                return View("IncidenciaPost", model);
            }
        }
    }
}
