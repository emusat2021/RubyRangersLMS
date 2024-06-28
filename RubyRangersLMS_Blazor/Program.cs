using RubyRangersLMS_Blazor.Components;
using RubyRangersLMS_Blazor.IServices;
using RubyRangersLMS_Blazor.Models;
using RubyRangersLMS_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(option =>
new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["https://localhost:7085"] ?? "http://localhost:5033")
});

builder.Services.AddHttpClient("DefaultClient"); // You can specify a name for your client


// Add services to the container.
builder.Services.AddScoped<IService<Student>, StudentService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();