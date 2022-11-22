using MudBlazor.Services;
using Lantin.Model;
var builder = WebApplication.CreateBuilder(args);
Func<IServiceProvider, IFreeSql> freeSqlFactory = _ =>
{
    IFreeSql freeSql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.Sqlite, @"")
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) //监听SQL语句
        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
        .Build();
    return freeSql;
};
builder.Services.AddSingleton<IFreeSql>(freeSqlFactory);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

var app = builder.Build();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
    var freeSql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
    freeSql.CodeFirst.SyncStructure(typeof(Article)); 
    freeSql.CodeFirst.SyncStructure(typeof(Comment));
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();