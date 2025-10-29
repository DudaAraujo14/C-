using Microsoft.AspNetCore.Mvc;

namespace Atendimentos.Api.Helpers
{
    public static class HateoasHelper
    {
        public static object BuildResource<T>(ControllerBase controller, string controllerName, T entity, Guid id)
        {
            return new
            {
                data = entity,
                links = new[]
                {
                    new { rel = "self", href = controller.Url.Action("GetById", controllerName, new { id }), method = "GET" },
                    new { rel = "update", href = controller.Url.Action("Update", controllerName, new { id }), method = "PUT" },
                    new { rel = "delete", href = controller.Url.Action("Delete", controllerName, new { id }), method = "DELETE" }
                }
            };
        }
    }
}
