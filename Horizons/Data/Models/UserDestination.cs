using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horizons.Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(DestinationId))]
    public class UserDestination
    {
        [Comment("Identifier of the user")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        [Comment("Identifier of the destination")]
        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; }
    }
}
