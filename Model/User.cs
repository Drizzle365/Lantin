using FreeSql.DataAnnotations;

namespace Lantin.Model;

public class User
{
    [Column(IsIdentity = true,IsPrimary = true)]
    public int UserId { get; set; }

    public string? UserName { get; set; }
    public string? PassWord { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
}