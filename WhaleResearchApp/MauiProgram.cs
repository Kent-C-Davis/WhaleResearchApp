using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WhaleResearchApp.Data;
using WhaleResearchApp.Services;
using WhaleResearchApp.Shared.Services;

namespace WhaleResearchApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Database
            var dbPath = Path.Combine(
                FileSystem.AppDataDirectory,
                "whaleresearch.db"
            );

            builder.Services.AddDbContext<WhaleDbContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));

            // Services
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddScoped<ILogbookService, LogbookService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

            // Ensure the SQLite database and schema exist
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<WhaleDbContext>();
                context.Database.EnsureCreated();
            }

            return app;
        }
    }
}