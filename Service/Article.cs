namespace Lantin.Service;

public class Article
{
     private readonly IFreeSql _db;
     public Article(IFreeSql db)
     {
          _db = db;
     }

     public async Task<long> Post(Model.Article request)
     {
          return await _db.Insert<Model.Article>()
               .AppendData(request)
               .ExecuteIdentityAsync();
     }
     
}