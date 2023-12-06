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
    public class PartVideoController : ControllerBase
    {
        private readonly IPartVideoRepository _partVideoRepository;
        private readonly IMapper _mapper;

        public PartVideoController(IPartVideoRepository partVideoRepository, IMapper mapper)
        {
            _partVideoRepository = partVideoRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{aboutId}")]
        public async Task<IActionResult> GetAllPartVideos(int courseId, int aboutId)
        {
            var partVideoDtos = _mapper.Map<List<PartVideoDto>>(await _partVideoRepository.GetAllPartVideos(courseId, aboutId));

            return Ok(partVideoDtos);
        }

        [HttpGet("{courseId}/{aboutId}/{id}")]
        public async Task<IActionResult> GetPartVideosById(int courseId, int aboutId, int id)
        {
            var partVideoDto = _mapper.Map<PartVideoDto>(await _partVideoRepository.GetPartVideoById(courseId, aboutId, id));

            return Ok(partVideoDto);
        }

        [HttpPost("{courseId}/{aboutId}")]
        public IActionResult CreatePartVideo([FromBody] PartVideoDto partVideoDto, int courseId, int aboutId)
        {
            var partVideo = _mapper.Map<PartVideo>(partVideoDto);

            partVideo.CourseId = courseId;
            partVideo.AboutId = aboutId;

            _partVideoRepository.Create(partVideo);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdatePartVideo([FromBody] PartVideoDto partVideoDto)
        {
            var partVideo = _mapper.Map<PartVideo>(partVideoDto);

            _partVideoRepository.Update(partVideo);

            return Ok("Succeeded");
        }

        [HttpDelete]
        public IActionResult DeleteVideo(int id)
        {
            _partVideoRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
