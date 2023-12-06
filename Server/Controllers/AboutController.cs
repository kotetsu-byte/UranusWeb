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
    public class AboutController : ControllerBase
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public AboutController(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetAllAbouts(int courseId)
        {
            var aboutDtos = _mapper.Map<List<AboutDto>>(await _aboutRepository.GetAllAbouts(courseId));

            return Ok(aboutDtos);
        }

        [HttpGet("{courseId}/{id}")]
        public async Task<IActionResult> GetAboutById(int courseId, int id)
        {
            var aboutDto = _mapper.Map<AboutDto>(await _aboutRepository.GetAboutById(courseId, id));

            return Ok(aboutDto);
        }

        [HttpPost("{courseId}")]
        public IActionResult CreateAbout([FromBody] AboutDto aboutDto, int courseId)
        {
            var about = _mapper.Map<About>(aboutDto);

            about.CourseId = courseId;

            _aboutRepository.Create(about);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateAbout([FromBody] AboutDto aboutDto)
        {
            var about = _mapper.Map<About>(aboutDto);
            
            _aboutRepository.Update(about);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            _aboutRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
