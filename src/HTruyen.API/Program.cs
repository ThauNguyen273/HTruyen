using HTruyen.API.Configurations;
using HTruyen.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<MongoDBConnectionOptions>(builder.Configuration.GetSection(MongoDBConnectionOptions.SectionName));
builder.Services.AddDatabase();
builder.Services.AddRepositories();
builder.Services.AddEntityServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Default",policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("Default");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
