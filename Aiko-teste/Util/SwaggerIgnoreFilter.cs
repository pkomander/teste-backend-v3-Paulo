using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aiko_teste.Util
{
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null) return;

            var ignoreProperties = context.Type.GetProperties()
                .Where(p => p.GetCustomAttributes<JsonIgnoreAttribute>().Any());

            foreach (var prop in ignoreProperties)
            {
                var propName = char.ToLowerInvariant(prop.Name[0]) + prop.Name[1..];
                if (schema.Properties.ContainsKey(propName))
                {
                    schema.Properties.Remove(propName);
                }
            }
        }
    }
}
