using RubyRangersLMS_Blazor.Components;
using RubyRangersLMS_Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:41853") // Replace with your Blazor app's URL
                      .AllowAnyHeader()
                      .AllowAnyMethod());
});

// Register HttpClient with IHttpClientFactory
builder.Services.AddHttpClient("DefaultClient"); // You can specify a name for your client

// Add services to the container.
builder.Services.AddScoped<StudentService>(); // Assuming StudentService is defined elsewhere in your project

var app = builder.Build();

// Apply CORS policy
app.UseCors("AllowMyOrigin");

// Existing middleware configurations...
app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseAntiforgery();

app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();

app.Run();
