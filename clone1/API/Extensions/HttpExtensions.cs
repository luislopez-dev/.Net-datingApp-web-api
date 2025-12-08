﻿using System.Text.Json;
using clone1.Core.Helpers.Pagination;

namespace clone1.API.Extensions;


/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
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