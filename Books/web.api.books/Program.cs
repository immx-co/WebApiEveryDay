using Microsoft.EntityFrameworkCore;
using web.api.books.Database;

namespace web.api.books;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataAccess();
        builder.Services.AddBusinessLogic();

        var app = builder.Build();

        //using(var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        //    db.Database.Migrate();
        //}

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.UseAuthorization();

        app.Run();            
    }
}
