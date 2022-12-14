using FreeSql.DataAnnotations;

namespace Lantin.Model;

public class UpLoad
{
    [Column(IsPrimary = true)] public string Guid { get; set; } = System.Guid.NewGuid().ToString();

    public string? Name { get; set; }
    public string? Path { get; set; }
    public DateTime DateTime { get; set; }
}