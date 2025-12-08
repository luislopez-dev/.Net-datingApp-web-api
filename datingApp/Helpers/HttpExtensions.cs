﻿
using System.Text.Json;

namespace datingApp.Helpers;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
    {
        var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        
        response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }
}