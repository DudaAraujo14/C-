using System.Reflection;

namespace Atendimentos.Api.Helpers
{
    public static class DynamicOrderHelper
    {
        /// <summary>
        /// Aplica ordenação dinâmica em um IQueryable com base no nome da propriedade e direção.
        /// </summary>
        public static IQueryable<T> OrderByDynamic<T>(
            this IQueryable<T> source,
            string? sortBy,
            string? order = "asc")
        {
            if (string.IsNullOrEmpty(sortBy))
                return source;

            // Busca a propriedade correspondente ignorando case (ex: "Nome", "nome", "NOME")
            var prop = typeof(T).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (prop == null)
                return source; // se a propriedade não existir, retorna sem ordenar

            // Executa ordenação
            return order?.ToLower() == "desc"
                ? source.OrderByDescending(x => prop.GetValue(x, null))
                : source.OrderBy(x => prop.GetValue(x, null));
        }
    }
}
