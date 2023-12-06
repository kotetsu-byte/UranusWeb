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
    public class ResultController : ControllerBase
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultController(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{aboutId}")]
        public async Task<IActionResult> GetAllResults(int courseId, int aboutId)
        {
            var resultDtos = _mapper.Map<List<ResultDto>>(await _resultRepository.GetAllResults(courseId, aboutId));

            return Ok(resultDtos);
        }

        [HttpGet("{courseId}/{aboutId}/{id}")]
        public async Task<IActionResult> GetResultById(int courseId, int aboutId, int id)
        {
            var resultDto = _mapper.Map<ResultDto>(await _resultRepository.GetResultById(courseId, aboutId, id));

            return Ok(resultDto);
        }

        [HttpPost("{courseId}/{aboutId}")]
        public IActionResult CreateResult([FromBody] ResultDto resultDto, int courseId, int aboutId)
        {
            var result = _mapper.Map<Result>(resultDto);

            result.CourseId = courseId;
            result.AboutId = aboutId;

            _resultRepository.Create(result);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateResult([FromBody] ResultDto resultDto)
        {
            var result = _mapper.Map<Result>(resultDto);

            _resultRepository.Update(result);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResult(int id)
        {
            _resultRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
