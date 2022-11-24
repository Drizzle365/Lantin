using FreeSql.DataAnnotations;

namespace Lantin.Model
{
    public class Categorize
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int CategorizeId { get; set; }
        public string? Name { get; set; }
    }
}
