using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhaleResearchApp.Shared.Models;

public class LogbookEntry
{
    public Guid LogbookEntryId { get; set; } = Guid.NewGuid();

    public DateOnly TourDate { get; set; }

    public TimeOnly TourTime { get; set; }

    public string Skipper { get; set; } = "";

    public string Researchers { get; set; } = "";

    public string Sightings { get; set; } = "";

    public string? PhotosReference { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
}