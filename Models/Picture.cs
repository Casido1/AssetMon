using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssetMon.Models
{
    public class Picture
    {
        public string Id { get; set; }

        [Required]
        [ForeignKey("UserProfile")]
        public string UserProfileId { get; set; }

        public string PictureUrl { get; set; }

        public bool IsMain { get; set; } = false;

        public string PublicId { get; set; }

        //Nav prop
        [JsonIgnore]
        public virtual UserProfile UserProfile { get; set; }

        public Picture()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
