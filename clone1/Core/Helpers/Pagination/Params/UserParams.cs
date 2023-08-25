namespace clone1.Core.Helpers.Pagination.Params;

public class UserParams  : PaginationParams
{
    public string OrderBy { get; set; } = "lastActive";
    public int MinAge { get; set; } = 18;
    public int MaxAge { get; set; } = 50;
    public string CurrentUserName { get; set; }
    public string Gender { get; set; }
}