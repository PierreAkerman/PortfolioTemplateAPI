using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateAPI.DTOs
{
    public class UpdateArtPieceDto
    {
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
