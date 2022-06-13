using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateAPI.DTOs
{
    public class ArtPieceItemDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public string ImgUrl { get; set; }
    }
}
