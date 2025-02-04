namespace Horizons.Models
{
    public class DestinationAddToFavoriteViewModel
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Terrain{ get; set; } = string.Empty;
    }
}
