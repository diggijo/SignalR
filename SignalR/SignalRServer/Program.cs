var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async (context) =>
{
    context.Response.Redirect("/index.html");
    await Task.CompletedTask;
});

app.MapHub<SignalRHub>("/SignalR");

app.Run();