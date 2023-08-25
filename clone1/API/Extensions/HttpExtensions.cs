using System.Text.Json;
using clone1.Core.Helpers.Pagination;

namespace clone1.API.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response,
        PaginationHeader paginationHeader)
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
    }
}