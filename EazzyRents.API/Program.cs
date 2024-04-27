using EazzyRents.API.Configurations;
using EazzyRents.API.Hub;
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

builder.Services.AddDirectoryBrowser();


var app = builder.Build();
app.UseRouting();

app.UseStaticFiles(); // For wwwroot folder

// Or to serve from a custom folder
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "StaticFiles")),
    RequestPath = "/StaticFiles"
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myCors);


app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chat");
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//app.MapHub<ChatHub>("/chat");

app.Run();
