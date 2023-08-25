namespace clone1.Core.Helpers.Pagination;

public class PaginationHeader
{
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }

    public PaginationHeader(int totalPages, int currentPage, int pageSize, int totalItems)
    {
        TotalPages = totalPages;
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalItems = totalItems;
    }
}