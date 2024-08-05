using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SentimentalChat.AI;
using SentimentalChat.Data;

namespace SentimentalChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR().AddAzureSignalR(Environment.GetEnvironmentVariable("SIGNALR_CONNECTION_STRING"));

            builder.Services.AddControllers();

            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<ISentimentAnalizer>(
                provider => new SentimentAnalizer(Environment.GetEnvironmentVariable("COGNITIVE_SERVICES_ENDPOINT"), 
                                                  Environment.GetEnvironmentVariable("COGNITIVE_SERVICES_KEY")));

            builder.Services.AddDbContext<DBAccess>(
                options => options.UseSqlServer(Environment.GetEnvironmentVariable("AZURESQL_CONNECTION_STRING")));

            var app = builder.Build();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "UI")),
                    RequestPath = "/app"
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapHub<ChatHub>("/chat");

            app.Run();
        }
    }
}
