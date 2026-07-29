using WhaleResearchApp.Shared.Models;

namespace WhaleResearchApp.Shared.Services;

public interface ILogbookService
{
    Task Save(LogbookEntry entry);
}