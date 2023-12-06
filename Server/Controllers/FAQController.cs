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
    public class FAQController : ControllerBase
    {
        private readonly IFAQRepository _faqRepository;
        private readonly IMapper _mapper;

        public FAQController(IFAQRepository faqRepository, IMapper mapper)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
        }

        [HttpGet("{courseId}/{aboutId}")]
        public async Task<IActionResult> GetAllFAQs(int courseId, int aboutId)
        {
            var faqDtos = _mapper.Map<List<FAQDto>>(await _faqRepository.GetAllFAQs(courseId, aboutId));

            return Ok(faqDtos);
        }

        [HttpGet("{courseId}/{aboutId}/{id}")]
        public async Task<IActionResult> GetFAQById(int courseId, int aboutId, int id)
        {
            var faqDto = _mapper.Map<FAQDto>(await _faqRepository.GetFAQById(courseId, aboutId, id));

            return Ok(faqDto);
        }

        [HttpPost("{courseId}/{aboutId}")]
        public IActionResult CreateFAQ([FromBody] FAQDto faqDto, int courseId, int aboutId)
        {
            var faq = _mapper.Map<FAQ>(faqDto);

            faq.CourseId = courseId;
            faq.AboutId = aboutId;

            _faqRepository.Create(faq);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateFAQ([FromBody] FAQDto faqDto)
        {
            var faq = _mapper.Map<FAQ>(faqDto);

            _faqRepository.Update(faq);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFAQ(int id)
        {
            _faqRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
