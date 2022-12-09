namespace Lantin.Services;

public class WebSiteConfigService
{
    private List<Model.Config> Data { get; set; }
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
        return Data.Find(x => x.Key == key)!.Value;
    }
    

}