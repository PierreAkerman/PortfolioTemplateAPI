using Microsoft.AspNetCore.Mvc;
using PortfolioTemplateAPI.Data;
using PortfolioTemplateAPI.DTOs;

namespace PortfolioTemplateAPI.Controllers
{
    [IgnoreAntiforgeryToken]
    public class ArtController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArtController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        private string SaveNewFile(IFormFile modelImage)
        {   
            string fullFileName = Guid.NewGuid().ToString() + modelImage.FileName;
            string fullPath = Path.Combine(_webHostEnvironment.WebRootPath,
                "UploadedPics",
                fullFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                modelImage.CopyTo(stream);
            }
            return fullFileName;
        }

        //private IFormFile GetFile(string url)
        //{

        //}
        //[HttpGet]
        //public IActionResult Get(ArtPieceItemDto artPieceItem)
        //{
        //    var image = GetFile(artPieceItem.ImgUrl);
        //    var artPiece = new ArtPieceItemDto
        //    {
        //        Id = artPieceItem.Id,
        //        Title = artPieceItem.Title,
        //        ImgUrl = artPieceItem.ImgUrl,
        //    };
        //    //return Ok(_context.Gallery.Select(e => new ArtPieceItemDto
        //    //{
        //    //    Id = e.Id,
        //    //    Title = e.Title,
        //    //    ImgUrl = e.ImgUrl

        //    //}).ToList());
        //}

        [HttpGet]
        public IActionResult GetOne(int id)
        {
            var artPiece = _context.Gallery.FirstOrDefault(e => e.Id == id);
            if (artPiece == null)
                return NotFound();
            var result = new ArtPieceDto
            {
                Id = artPiece.Id,
                Title = artPiece.Title,
                Description = artPiece.Description,
                Created = artPiece.Created,
                Price = artPiece.Price,
                ImgUrl = artPiece.ImgUrl
            };
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(CreateArtPieceDto newArtPiece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var url = SaveNewFile(newArtPiece.ImgUrl);
            var artPiece = new ArtPiece
            {
                Title = newArtPiece.Title,
                Description = newArtPiece.Description,
                Created = DateTime.Now,
                Price = newArtPiece.Price,
                ImgUrl = url
            };
            _context.Gallery.Add(artPiece);
            _context.SaveChanges();

            var artPieceDto = new CreateArtPieceDto
            {
                Title = artPiece.Title,
                Description = artPiece.Description,
                Created = artPiece.Created,
                Price = artPiece.Price,
                ImageUrl = artPiece.ImgUrl
            };
            return CreatedAtAction(nameof(GetOne), new { id = artPiece.Id }, artPieceDto);
        }
    }
}
