using System.ComponentModel.DataAnnotations;

namespace TravelMK.Models
{
    public class Hotel
    {
        [Key]
        [MaxLength(20)]
        public string Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Lat { get; set; }
        [Required]
        [MaxLength(20)]
        public string Lon { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name_EN { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name_MK { get; set; }
        [Required]
        [MaxLength(30)]
        public string Municipality_EN { get; set; }
        [Required]
        [MaxLength(30)]
        public string Municipality_MK { get; set; }
        public Hotel() { }
    }
}
