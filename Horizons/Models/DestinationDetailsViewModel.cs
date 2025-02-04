namespace Horizons.Models
{
    public class DestinationDetailsViewModel
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Terrain { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PublisherId { get; set; } = string.Empty!;

        public string Publisher { get; set; } = string.Empty;

        public bool IsFavorite { get; set; }

        public string PublishedOn { get; set; } = string.Empty;
    }
}
