namespace Horizons.Models
{
    public class DestinationAllViewModel
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Terrain { get; set; } = string.Empty;

        public bool IsPublisher { get; set; } 

        public bool IsFavorite { get; set; }

        public int FavoritesCount { get; set; }

    }
}
