using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WhaleResearchApp.Shared.Models;

public class LogbookEntry
{
    public Guid LogbookEntryId { get; set; } = Guid.NewGuid();

    [Required]
    public DateOnly TourDate { get; set; }

    [Required]
    public TimeOnly TourTime { get; set; }

    [Required]
    public string Skipper { get; set; } = "";

    [Required]
    public string Researchers { get; set; } = "";

    [Required]
    public string Sightings { get; set; } = "";

    public string? PhotosReference { get; set; }

    [Required] 
    public bool NewbornSighted { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
}