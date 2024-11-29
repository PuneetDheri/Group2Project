using API.Data;
using API.Models.Entities;
using API.Models.Helpers; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageHelper _imageHelper;

        public ImageController(ApplicationDbContext context, ImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper; // Inject ImageHelper
        }

        //// 1. Add Image to User
        //[HttpPost("{userId}/image")]
        //public async Task<IActionResult> AddImageToUser(Guid userId, [FromBody] Image image)
        //{
        //    if (image == null)
        //        return BadRequest("Image data is required.");

        //    // Fetch tags from Imagga API using the ImageHelper
        //    var tags = _imageHelper.GetTags(image.Url).ToList();

        //    // If no tags were fetched, return a BadRequest
        //    if (!tags.Any())
        //        return BadRequest("No tags found for the image.");

        //    // Create Tag entities for each tag fetched
        //    image.Tags = tags.Select(tag => new Tag { Text = tag }).ToList();
        //    //image.UserId = userId;

        //    // Add the image to the database
        //    _context.Images.Add(image);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetImageById), new { id = image.Id }, image);
        //}

        // 2. Get All Images with Pagination
        [HttpGet]
        public async Task<IActionResult> GetImages(int page = 1, int pageSize = 10)
        {
            var totalImages = await _context.Images.CountAsync();
            var totalPages = (int)Math.Ceiling(totalImages / (double)pageSize);

            var images = await _context.Images
                //.OrderByDescending(i => i.CreatedAt) // Assuming CreatedAt property for sorting by date
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                meta = new { totalPages, totalImages },
                data = images.Select(i => new { i.Id, i.Url, Username = i.User.Name }),
                links = new
                {
                    first = Url.Action(nameof(GetImages), new { page = 1, pageSize }),
                    prev = page > 1 ? Url.Action(nameof(GetImages), new { page = page - 1, pageSize }) : null,
                    next = page < totalPages ? Url.Action(nameof(GetImages), new { page = page + 1, pageSize }) : null,
                    last = Url.Action(nameof(GetImages), new { page = totalPages, pageSize })
                }
            };

            return Ok(result);
        }


        // 3. Get Image by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await _context.Images
                .Include(i => i.Tags)
                .Include(i => i.User)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (image == null)
                return NotFound();

            return Ok(new
            {
                image.Id,
                image.Url,
                Username = image.User.Name,
                UserId = image.User.Id,
                Tags = image.Tags.Select(t => t.Text)
            });
        }

        // 4. Get Images by Tag with Pagination
        [HttpGet("byTag")]
        public async Task<IActionResult> GetImagesByTag(string tag, int page = 1, int pageSize = 10)
        {
            var totalImages = await _context.Images
                .Where(i => i.Tags.Any(t => t.Text == tag))
                .CountAsync();

            if (totalImages == 0)
                return NotFound("No images found for the given tag.");

            var totalPages = (int)Math.Ceiling(totalImages / (double)pageSize);

            var images = await _context.Images
                .Where(i => i.Tags.Any(t => t.Text == tag))
                //.OrderByDescending(i => i.CreatedAt) // Assuming CreatedAt property for sorting by date
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = new
            {
                meta = new { totalPages, totalImages },
                data = images.Select(i => new { i.Id, i.Url, Username = i.User.Name }),
                links = new
                {
                    first = Url.Action(nameof(GetImagesByTag), new { tag, page = 1, pageSize }),
                    prev = page > 1 ? Url.Action(nameof(GetImagesByTag), new { tag, page = page - 1, pageSize }) : null,
                    next = page < totalPages ? Url.Action(nameof(GetImagesByTag), new { tag, page = page + 1, pageSize }) : null,
                    last = Url.Action(nameof(GetImagesByTag), new { tag, page = totalPages, pageSize })
                }
            };

            return Ok(result);
        }


        // 4. Get Images by Popular Tags

        [HttpGet("api/images/populartags")]
        public IActionResult GetPopularTags()
        {
            var tags = _context.Tags
                .OrderByDescending(t => t.Images.Count)
                .Take(5)
                .Select(t => new { Tag = t.Id, Count = t.Images.Count })
                .ToList();

            return Ok(tags);
        }

    }
}
