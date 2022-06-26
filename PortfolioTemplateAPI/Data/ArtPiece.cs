using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateAPI.Data
{
    public class ArtPiece
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
    }
}
