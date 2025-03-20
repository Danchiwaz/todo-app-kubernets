using BackendApi.Data;
using BackendApi.Services;
using Microsoft.EntityFrameworkCore;





var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:8081");
builder.Services.AddScoped<ITodoService, TodoService>();
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
} );

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    //CONFIGURE HTTP FOR THE PIPELINE 
    
    var app = builder.Build();
    app.UseCors(myAllowSpecificOrigins);
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    } 
    
    app.UseAuthorization();
    app.MapControllers();
    
    app.Run();