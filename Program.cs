﻿using MudBlazor.Services;
using MudBlazor;
using Lantin.Model;

var builder = WebApplication.CreateBuilder(args);
Func<IServiceProvider, IFreeSql> freeSqlFactory = _ =>
{
    IFreeSql freeSql = new FreeSql.FreeSqlBuilder()
        .UseConnectionString(FreeSql.DataType.MySql,
            $"Data Source={builder.Configuration.GetSection("MySql:Host").Value};" +
            $"Port={builder.Configuration.GetSection("MySql:Port").Value};" +
            $"User ID={builder.Configuration.GetSection("MySql:UserName").Value};" +
            $"Password={builder.Configuration.GetSection("MySql:PassWord").Value}; " +
            $"Initial Catalog={builder.Configuration.GetSection("MySql:DBName").Value};" +
            $"Charset=utf8; SslMode=none;Min pool size=1")
        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}")) //监听SQL语句
        .Build();
    return freeSql;
};
builder.Services.AddSingleton<IFreeSql>(freeSqlFactory);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 2000;
    config.SnackbarConfiguration.HideTransitionDuration = 100;
    config.SnackbarConfiguration.ShowTransitionDuration = 100;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

var app = builder.Build();

using (IServiceScope serviceScope = app.Services.CreateScope())
{
     var freeSql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
     freeSql.CodeFirst.SyncStructure(typeof(Article));
     freeSql.CodeFirst.SyncStructure(typeof(Comment));
     freeSql.CodeFirst.SyncStructure(typeof(User));
    freeSql.CodeFirst.SyncStructure(typeof(Categorize));
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