using RubyRangersLMS_Blazor.Components;
using RubyRangersLMS_Blazor.IServices;
using RubyRangersLMS_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient for API calls
builder.Services.AddHttpClient<ITeacherServices, TeacherServices>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7249/api/"); // Replace with your API base address
});

builder.Services.AddScoped<ITeacherServices, TeacherServices>();

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
