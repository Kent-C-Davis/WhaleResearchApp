using Microsoft.EntityFrameworkCore;
using WhaleResearchApp.Shared.Models;

namespace WhaleResearchApp.Data;

public class WhaleDbContext : DbContext
{
    public DbSet<LogbookEntry> LogbookEntries { get; set; }

    public WhaleDbContext(DbContextOptions<WhaleDbContext> options)
        : base(options)
    {
    }
}