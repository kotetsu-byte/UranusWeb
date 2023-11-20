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
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaterials()
        {
            var materialsDto = _mapper.Map<List<MaterialDto>>(await _materialRepository.GetAllMaterials());

            return Ok(materialsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialById(int id)
        {
            var materialDto = _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialById(id));

            return Ok(materialDto);
        }

        [HttpPost]
        public IActionResult CreateMaterial([FromBody] MaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);

            _materialRepository.Create(material);

            return Ok("Succeeded");
        }

        [HttpPatch]
        public IActionResult UpdateMaterial([FromBody] MaterialDto materialDto)
        {
            var material = _mapper.Map<Material>(materialDto);

            _materialRepository.Update(material);

            return Ok("Succeeded");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            _materialRepository.Delete(id);

            return Ok("Succeeded");
        }
    }
}
