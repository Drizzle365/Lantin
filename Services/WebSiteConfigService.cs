
namespace Lantin.Services;

public class WebSiteConfigService
{
    private List<Model.Config> Data { get; set; } = new ();

    public void Init(IFreeSql db)
    {
        Data = db.Select<Model.Config>().ToList();
    }

    public List<Model.Config> Get()
    {
        return Data;
    }

    public string GetValue(string key)
    {
        var value = Data.Find(x => x.Key == key)!.Value;
        return value ?? "";
    }
}