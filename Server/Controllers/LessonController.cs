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
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonController(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessonsDto = _mapper.Map<List<LessonDto>>(await _lessonRepository.GetAllLessons());

            return Ok(lessonsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lessonDto = _mapper.Map<LessonDto>(await _lessonRepository.GetLessonById(id));

            return Ok(lessonDto);
        }

        [HttpPost]
        public IActionResult CreateLesson([FromBody] LessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Create(lesson);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateLesson([FromBody] LessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            _lessonRepository.Update(lesson);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            _lessonRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
