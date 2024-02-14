using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            try
            {
                var reviews = await _reviewService.GetAllReviewsAsync();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving reviews: {ex.Message}");
            }
        }

        //[Authorize(Roles = "Applicant")]
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            var addedReview = await _reviewService.AddReviewAsync(review);
            return Ok(addedReview);
        }

        //[Authorize(Roles = "Applicant")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] Review updatedReview)
        {
            try
            {
                var updated = await _reviewService.UpdateReviewAsync(id, updatedReview);
                if (updated == null)
                {
                    return NotFound($"Review with ID {id} not found");
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the review: {ex.Message}");
            }
        }

        //[Authorize(Roles = "Applicant")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var deleted = await _reviewService.DeleteReviewAsync(id);
                if (!deleted)
                {
                    return NotFound($"Review with ID {id} not found");
                }
                return Ok($"Review with ID {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the review: {ex.Message}");
            }
        }
    }
}
