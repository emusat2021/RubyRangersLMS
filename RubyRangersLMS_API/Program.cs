using Microsoft.EntityFrameworkCore;
using RubyRangersLMS_API.Data;
using RubyRangersLMS_API.IRepositories;
using RubyRangersLMS_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContextFactory<LMSContext>(options =>
//    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// If SQL debugging is needed use this instead:
builder.Services.AddDbContextFactory<LMSContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
          .EnableSensitiveDataLogging());

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddScoped<IUoW, UoW>();
builder.Services.AddAutoMapper(typeof(LmsMappings));

var app = builder.Build();

// Ensure UseRouting is called before UseEndpoints
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Run seeding if needed
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<LMSContext>();
//    await SeedInitialData.SeedFirstCourse(dbContext);
//}

app.Run();
