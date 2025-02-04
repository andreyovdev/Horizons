using Horizons.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

using static Horizons.Common.ValidationConstants;

namespace Horizons.Models
{
    public class DestinationEditViewModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(DestinationNameMaxLength, MinimumLength = DestinationNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DestinationDescriptionMaxLength, MinimumLength = DestinationDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [RegexStringValidator(@"^\d{2}-\d{2}-\d{4}$")]
        public string PublishedOn { get; set; } = string.Empty;

        [Required]
        public string PublisherId { get; set; } = string.Empty;

        [Required]
        public int TerrainId { get; set; }

        public virtual List<TerrainViewModel>? Terrains { get; set; }

    }
}
