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
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestController(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {
            var testsDto = _mapper.Map<List<TestDto>>(await _testRepository.GetAllTests());

            return Ok(testsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestById(int id)
        {
            var testDto = _mapper.Map<TestDto>(await _testRepository.GetTestById(id));

            return Ok(testDto);
        }

        [HttpPost]
        public IActionResult CreateTest([FromBody] TestDto testDto) 
        {
            var test = _mapper.Map<Test>(testDto);

            _testRepository.Create(test);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateTest([FromBody] TestDto testDto)
        {
            var test = _mapper.Map<Test>(testDto);

            _testRepository.Update(test);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            _testRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
