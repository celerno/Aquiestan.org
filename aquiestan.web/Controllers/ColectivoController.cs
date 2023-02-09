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
         
                var post = Loader.GetPostAsync<IncidenciaPost>(id, User).Result;
                post.Excerpt = string.Empty;
                var model = new SinglePostWithComments<IncidenciaPost>(Api, Loader);
                model.Data = post;
                

                return View("IncidenciaPost", model);
            
        }
    }
}
