using System.ComponentModel.DataAnnotations;

namespace PortfolioTemplateAPI.DTOs
{
    public class CreateArtPieceDto
    {
        [Required(ErrorMessage = "The title field is required!")]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required(ErrorMessage = "The description field is required!")]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The date created field is required!")]
        public DateTime Created { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "This field is required, upload an image.")]
        public IFormFile ImgFile { get; set; }
        public string? ImgUrl { get; set; }
    }
}
