using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Horizons.Common.ValidationConstants;

namespace Horizons.Data.Models
{
    public class Destination
    {
        [Key]
        [Comment("Identifier of the destination")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        [Comment("Name of the product")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DestinationDescriptionMaxLength)]
        [Comment("Description of the product")]
        public string Description { get; set; } = null!;

        [Comment("Image url of the product")]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Identifier of the publisher of the destination")]
        public string PublisherId { get; set; } = null!;

        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = DestinationPublishedDateFormat)]
        [Comment("Date when destination was added to website")]
        public DateTime PublishedOn { get; set; }

        [Required]
        [Comment("Identifier of the terrain of the product")]
        public int TerrainId { get; set; }

        [ForeignKey(nameof(TerrainId))]
        public Terrain Terrain { get; set; }

        [Comment("Is destination deleted from website")]
        public bool IsDeleted { get; set; } = false;


        public virtual ICollection<UserDestination> UsersDestinations { get; set; }
        = new List<UserDestination>();

    }
}
