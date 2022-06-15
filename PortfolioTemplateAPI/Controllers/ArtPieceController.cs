﻿using Microsoft.AspNetCore.Mvc;
using PortfolioTemplateAPI.Data;
using PortfolioTemplateAPI.DTOs;

namespace PortfolioTemplateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtPieceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArtPieceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Gallery.Select(e => new ArtPieceItemDto
            {
                Id = e.Id,
                Title = e.Title,
                ImgUrl = e.ImgUrl

            }).ToList());
        }

        [HttpGet]
        [Route("{id}")]
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

            var artPiece = new ArtPiece
            {
                Title = newArtPiece.Title,
                Description = newArtPiece.Description,
                Created = newArtPiece.Created,
                Price = newArtPiece.Price,
                ImgUrl = newArtPiece.ImgUrl
            };
            _context.Gallery.Add(artPiece);
            _context.SaveChanges();

            var artPieceDto = new CreateArtPieceDto
            {
                Title = artPiece.Title,
                Description = artPiece.Description,
                Created = artPiece.Created,
                Price = artPiece.Price,
                ImgUrl = artPiece.ImgUrl
            };
            return CreatedAtAction(nameof(GetOne), new { id = artPiece.Id }, artPieceDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateArtPieceDto revisedArtPiece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artPiece = _context.Gallery.FirstOrDefault(e => e.Id == id);
            if (artPiece == null) return NotFound();

            artPiece.Title = revisedArtPiece.Title;
            artPiece.Description = revisedArtPiece.Description;
            artPiece.Created = revisedArtPiece.Created;
            artPiece.Price = revisedArtPiece.Price;
            artPiece.ImgUrl = revisedArtPiece.ImgUrl;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var artPiece = _context.Gallery.FirstOrDefault(e => e.Id == id);
            if (artPiece == null)
                return NotFound();

            _context.Gallery.Remove(artPiece);
            _context.SaveChanges();

            return NoContent();
        }
    }
}