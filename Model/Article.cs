using FreeSql.DataAnnotations;

namespace Lantin.Model;

public enum Visibility
{
   Open,
   Hide,
   Cypher
}

public class Article
{
    [Column(IsIdentity = true, IsPrimary = true)]
    public int ArticleId { get; set; }

    public int CategorizeId { get; set; }
    public int UserId { get; set; }
    public string? Title { get; set; }
    [Column(DbType = "longtext")]
    public string? Content { get; set; }
    public DateTime DateTime { get; set; }
    public Visibility Visibility { get; set; } = Visibility.Open;
    public string? Additional { get; set; }
}