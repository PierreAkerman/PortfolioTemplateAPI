using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateAPI.DTOs
{
    public class UpdateArtPieceDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public IFormFile? ImgUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}
