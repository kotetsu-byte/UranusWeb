using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UranusWeb.Server.Interfaces;
using UranusWeb.Server.Models;
using UranusWeb.Shared.Dtos;

namespace UranusWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{aboutId}")]
        public async Task<IActionResult> GetAllReviews(int courseId, int aboutId)
        {
            var reviewDtos = _mapper.Map<List<ReviewDto>>(await _reviewRepository.GetAllReviews(courseId, aboutId));

            return Ok(reviewDtos);
        }

        [HttpGet("{courseId}/{aboutId}/{id}")]
        public async Task<IActionResult> GetReviewById(int courseId, int aboutId, int id)
        {
            var reviewDto = _mapper.Map<ReviewDto>(await _reviewRepository.GetReviewById(courseId, aboutId, id));

            return Ok(reviewDto);
        }

        [HttpPost("{courseId}/{aboutId}")]
        public IActionResult CreateReview([FromBody] ReviewDto reviewDto, int courseId, int aboutId)
        {
            var review = _mapper.Map<Review>(reviewDto);

            review.CourseId = courseId;
            review.AboutId = aboutId;

            _reviewRepository.Create(review);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateReview([FromBody] ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);

            _reviewRepository.Update(review);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            _reviewRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
