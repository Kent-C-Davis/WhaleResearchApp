using System.Diagnostics;
using WhaleResearchApp.Data;
using WhaleResearchApp.Shared.Models;
using WhaleResearchApp.Shared.Services;

namespace WhaleResearchApp.Services;

public class LogbookService : ILogbookService
{
    private readonly WhaleDbContext _context;

    public LogbookService(WhaleDbContext context)
    {
        _context = context;
    }


    public async Task Save(LogbookEntry entry)
    {
        entry.LogbookEntryId = Guid.NewGuid();

        entry.CreatedAt = DateTimeOffset.Now;
        entry.UpdatedAt = DateTimeOffset.Now;

        _context.LogbookEntries.Add(entry);

        await _context.SaveChangesAsync();

        WriteToDebug(entry);
    }

    private void WriteToDebug(LogbookEntry entry)
    {
        Debug.WriteLine($"Saved: TourDate: {entry.TourDate}");
        Debug.WriteLine($"Saved: Skipper: {entry.Skipper}");
        Debug.WriteLine($"Saved: Researchers: {entry.Researchers}");
        Debug.WriteLine($"Saved: TourTime: {entry.TourTime}");
        Debug.WriteLine($"Saved: Sightings: {entry.Sightings}");
        Debug.WriteLine($"Saved: PhotosReference: {entry.PhotosReference}");
    }
}