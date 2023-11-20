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
    public class DocController : ControllerBase
    {
        private readonly IDocRepository _docRepository;
        private readonly IMapper _mapper;

        public DocController(IDocRepository docRepository, IMapper mapper)
        {
            _docRepository = docRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocs()
        {
            var docsDto = _mapper.Map<List<DocDto>>(await _docRepository.GetAllDocs());

            return Ok(docsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocById(int id)
        {
            var docDto = _mapper.Map<DocDto>(await _docRepository.GetDocById(id));

            return Ok(docDto);
        }

       
        [HttpPost]
        public IActionResult CreateDoc([FromBody] DocDto docDto) 
        {
            var doc = _mapper.Map<Doc>(docDto);

            _docRepository.Create(doc);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateDoc([FromBody] DocDto docDto)
        {
            var doc = _mapper.Map<Doc>(docDto);

            _docRepository.Update(doc);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoc(int id)
        {
            _docRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
