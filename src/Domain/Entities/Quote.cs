using System.ComponentModel.DataAnnotations.Schema;

namespace MovieQuoteService.Domain.Entities;

public class Quote : BaseAuditableEntity
{
    public string Text { get; set; } = default!;

    [ForeignKey(nameof(Movie))]
    public int MovieId { get; set; }

    [ForeignKey(nameof(Character))]
    public int CharacterId { get; set; }

    public Movie Movie { get; set; } = default!;
    public Character Character { get; set; } = default!;
}