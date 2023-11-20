using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UranusAdmin.Models;
using UranusWeb.Server.Dtos;
using UranusWeb.Server.Interfaces;

namespace UranusWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public VideoController(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVideos()
        {
            var videosDto = _mapper.Map<List<VideoDto>>(await _videoRepository.GetAllVideos());

            return Ok(videosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideoById(int id)
        {
            var videDto = _mapper.Map<VideoDto>(await _videoRepository.GetVideoById(id));

            return Ok(videDto);
        }

        [HttpPost]
        public IActionResult CreateVideo([FromBody] VideoDto videoDto)
        {
            var video = _mapper.Map<Video>(videoDto);

            _videoRepository.Create(video);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateVideo([FromBody] VideoDto videoDto)
        {
            var video = _mapper.Map<Video>(videoDto);

            _videoRepository.Update(video);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            _videoRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
