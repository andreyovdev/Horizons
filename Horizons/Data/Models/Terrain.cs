using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Horizons.Common.ValidationConstants;

namespace Horizons.Data.Models
{
    public class Terrain
    {
        [Key]
        [Comment("Identifier of the terrain")]
        public int Id { get; set; }

        [Required]
        [StringLength(TerrainNameMaxLength, MinimumLength = TerrainNameMinLength)]
        [Comment("Name of the terrain")]
        public string Name { get; set; } = null!;

        public ICollection<Destination> Destinations { get; set; }
        = new List<Destination>();
    }
}
