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
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseRepository _userCourseRepository;
        private readonly IMapper _mapper;

        public UserCourseController(IUserCourseRepository userCourseRepository, IMapper mapper)
        {
            _userCourseRepository = userCourseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserCourses()
        {
            var userCourseDto = _mapper.Map<UserCourseDto>(await _userCourseRepository.GetAllUserCourses());

            return Ok(userCourseDto);
        }

        [HttpPost]
        public IActionResult CreateUserCourse([FromBody] UserCourseDto userCourseDto)
        {
            var userCourse = _mapper.Map<UserCourse>(userCourseDto);

            _userCourseRepository.Create(userCourse);

            return Ok("Succeeded");
        }

        [HttpPost("Delete")]
        public IActionResult DeleteUserCourse([FromBody] UserCourse userCourseDto) 
        {
            var userCourse = _mapper.Map<UserCourse>(userCourseDto);

            _userCourseRepository.Delete(userCourse);

            return Ok("Succeeded");
        }
    }
}
