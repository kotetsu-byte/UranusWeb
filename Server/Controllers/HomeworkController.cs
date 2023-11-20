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
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworkController(IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHomeworks()
        {
            var homeworksDto = _mapper.Map<List<HomeworkDto>>(await _homeworkRepository.GetAllHomeworks());

            return Ok(homeworksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHomeworkById(int id)
        {
            var homeworkDto = _mapper.Map<HomeworkDto>(await _homeworkRepository.GetHomeworkById(id));

            return Ok(homeworkDto);
        }

        [HttpPost]
        public IActionResult CreateHomework([FromBody] HomeworkDto homeworkDto)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            _homeworkRepository.Create(homework);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateHomework([FromBody] HomeworkDto homeworkDto)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            _homeworkRepository.Update(homework);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHomework(int id)
        {
            _homeworkRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
