using FreeSql.DataAnnotations;

namespace Lantin.Model;

public class Comment
{
    [Column(IsIdentity = true, IsPrimary = true)]
    public int CommentId { get; set; }

    public int ArticleId { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }

    public string? Content { get; set; }
    public DateTime Datetime { get; set; }
}