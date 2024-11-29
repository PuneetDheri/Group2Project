using API.Data;
using API.Models.Entities;
using API.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ImageHelper _imageHelper;

        public UserController(ApplicationDbContext context, ImageHelper imageHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
        }

        // 1. Add a New User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                return BadRequest("User data is invalid.");

            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return BadRequest("Email already exists.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }




        // 2. Get User by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email,
                ImagesUrls = user.Images.Select(i => i.Url)
            });
        }

        // 3. Get All Images of a User with Pagination
        [HttpGet("{id}/images")]
        public async Task<IActionResult> GetUserImages(Guid id, int page = 1, int pageSize = 10)
        {
            var user = await _context.Users
                .Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            var totalImages = user.Images.Count;
            var totalPages = (int)Math.Ceiling(totalImages / (double)pageSize);

            var images = user.Images
                //.OrderByDescending(i => i.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var result = new
            {
                meta = new { totalPages, totalImages },
                data = images.Select(i => new { i.Id, i.Url }),
                links = new
                {
                    first = Url.Action(nameof(GetUserImages), new { id, page = 1, pageSize }),
                    prev = page > 1 ? Url.Action(nameof(GetUserImages), new { id, page = page - 1, pageSize }) : null,
                    next = page < totalPages ? Url.Action(nameof(GetUserImages), new { id, page = page + 1, pageSize }) : null,
                    last = Url.Action(nameof(GetUserImages), new { id, page = totalPages, pageSize })
                }
            };

            return Ok(result);
        }

        // 4. Delete User by ID (and their images)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            _context.Images.RemoveRange(user.Images); // Remove all user images as well
            await _context.SaveChangesAsync();

            return NoContent();
        }




        [HttpPost("{id}/image")]
        public async Task<IActionResult> AddImageToUser(Guid id, [FromBody] AddImageRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.ImageUrl))
            {
                return BadRequest(new { error = "Invalid request. ImageUrl cannot be null or empty." });
            }

            // Check if the user exists
            var user = await _context.Users
                .Include(u => u.Images)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new { error = "User not found." });
            }

            try
            {
                // Generate tags using ImageHelper
                var tags = _imageHelper.GetTags(request.ImageUrl)
                    .Select(tagText => new Tag { Id = Guid.NewGuid(), Text = tagText })
                    .ToList();

                // Create and add a new image to the database
                var newImage = new Image
                {
                    Id = Guid.NewGuid(),
                    Url = request.ImageUrl,
                    PostingDate = DateTime.UtcNow,
                    User = user,
                    Tags = tags
                };

                _context.Images.Add(newImage);
                await _context.SaveChangesAsync();

                // Fetch the last 10 images added by the user
                var latestImages = await _context.Images
                    .Where(i => i.User.Id == id)
                    .OrderByDescending(i => i.PostingDate)
                    .Take(10)
                    .ToListAsync();

                // Generate a minimal response with the user's latest images
                var response = new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    Images = latestImages.Select(i => new
                    {
                        i.Id,
                        i.Url,
                        Tags = i.Tags.Select(t => t.Text)
                    })
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"An error occurred: {ex.Message}" });
            }
        }


        public class AddImageRequest
        {
            public string ImageUrl { get; set; }
        }

    }
}