using hack4splitBORBAapi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var policy = "MyPolicy";

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConn"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyPolicy", policy => {
        policy.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
    });
});

builder.Services.AddRouting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("MyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.MapControllers();

app.Run();
