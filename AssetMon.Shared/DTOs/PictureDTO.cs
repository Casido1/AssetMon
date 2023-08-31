using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetMon.Shared.DTOs
{
    public class PictureDTO
    {
        public string Id { get; set; }

        public string PictureUrl { get; set; }

        public bool IsMain { get; set; }
    }
}