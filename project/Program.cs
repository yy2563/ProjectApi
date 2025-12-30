//using Microsoft.EntityFrameworkCore;
//using project.Customer.Interface;
//using project.Customer.Repository;
//using project.Customer.Service;
//using project.Customer.Servise;
//using project.Data;


//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        var builder = WebApplication.CreateBuilder(args);

//        // Add services to the container.

//        builder.Services.AddControllers();
//        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//        builder.Services.AddOpenApi();


//        // builder.Services.AddDbContext<ApplicationDbContext>(options =>
//        //   options.UseSqlServer("Server=Srv2\\pupils;DataBase=215861006_ChineseSale;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;"));
//        builder.Services.AddDbContext<ApplicationDbContext>(options =>
//   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//        //register service
//        builder.Services.AddScoped<IUserService, UserService>();
//        //register Reposutory
//        builder.Services.AddScoped<IUserRepository, UserRepository>();
//        //get gift repository
//        builder.Services.AddScoped<IGiftRepository, GiftRepository>();
//        //get gift srvice
//        builder.Services.AddScoped<IGiftService, GiftService>();



//        builder.Services.AddEndpointsApiExplorer();
//        builder.Services.AddSwaggerGen();

//        var app = builder.Build();

//        // Configure the HTTP request pipeline.
//        if (app.Environment.IsDevelopment())
//        {
//            app.MapOpenApi();
//        }
//        if (app.Environment.IsDevelopment())
//        {
//            app.UseSwagger();
//            app.UseSwaggerUI();
//        }

//        app.UseHttpsRedirection();

//        app.UseAuthorization();

//        app.MapControllers();

//        app.Run();
//    }
//}

using Microsoft.EntityFrameworkCore;
using project.Customer.Interface;
using project.Customer.Repository;
using project.Customer.Service;
using project.Customer.Servise;
using project.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Add Swagger/OpenAPI
        builder.Services.AddSwaggerGen();  // תיקון כאן - השתמש רק ב־AddSwaggerGen ולא ב־AddOpenApi

        // Configure DbContext with SQL Server
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register services
        builder.Services.AddScoped<IUserService, UserService>();

        // Register Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IGiftRepository, GiftRepository>();

        // Register Gift Service
        builder.Services.AddScoped<IGiftService, GiftService>();

        // Add Swagger for OpenAPI documentation
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();  // גישה ל־Swagger
            app.UseSwaggerUI();  // ממשק משתמש ל־Swagger
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();  // אם אתה לא צריך אימות, אפשר להסיר שורה זו

        app.MapControllers();  // מיפוי של ה־Controllers

        app.Run();
    }
}