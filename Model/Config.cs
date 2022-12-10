using FreeSql.DataAnnotations;

namespace Lantin.Model;

public class Config
{
    [Column(IsIdentity = true, IsPrimary = true)]
    public string? Key { get; set; }

    public string? Value { get; set; }
}