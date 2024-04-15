using EazzyRents.API.Configurations;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAllDependecies(builder.Configuration);

var myCors = "appCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myCors, policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseStaticFiles(); // For wwwroot folder

// Or to serve from a custom folder
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider("/"),
    RequestPath = ""
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCors);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.MapHub<ChatHub>("/chatHub");

app.Run();
