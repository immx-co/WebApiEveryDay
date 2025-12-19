using Microsoft.EntityFrameworkCore;
using web.api.books.Database;

namespace web.api.books;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDataAccess();
        builder.Services.AddBusinessLogic();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapControllers();

        app.UseAuthorization();

        app.Run();            
    }
}
