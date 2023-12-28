﻿/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */
using Microsoft.EntityFrameworkCore;

namespace clone1.Core.Helpers.Pagination;

public class PagedList<T> : List<T>
{ 
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }

    private PagedList(IEnumerable<T> items, int pageSize, int count, int pageNumber)
    {
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        PageSize = pageSize;
        TotalItems = count;
        CurrentPage = pageNumber;
        AddRange(items);
    }

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, pageSize, count, pageNumber);
    }
}