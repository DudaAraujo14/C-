using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Atendimentos.Api.Helpers
{
    public record Link(string Rel, string Href, string Method);

    public static class HateoasHelper
    {
        public static object BuildResource(ControllerBase controller, string entity, object resource, object id)
        {
            var baseUrl = $"{controller.Request.Scheme}://{controller.Request.Host}/api/{entity}/{id}";
            var collectionUrl = $"{controller.Request.Scheme}://{controller.Request.Host}/api/{entity}";

            var links = new List<Link>
            {
                new("self", baseUrl, "GET"),
                new("update", baseUrl, "PUT"),
                new("delete", baseUrl, "DELETE"),
                new("collection", collectionUrl, "GET")
            };

            return new { data = resource, links };
        }
    }
}
