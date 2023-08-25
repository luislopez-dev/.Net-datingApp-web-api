namespace clone1.Core.DTOs;

public class MemberDto
{
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime Created { get; set; } 
    public DateTime LastActive { get; set; }
    public string Gender { get; set; }
    public string Interests { get; set; }
    public string KnownAs { get; set; }
    public string LookingFor { get; set; }
    public string Introduction { get; set; }
    public string PhotoUrl { get; set; }
    public int Age { get; set; }
    public List<PhotoDto> Photos { get; set; }
}