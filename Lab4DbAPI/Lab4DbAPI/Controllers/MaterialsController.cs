using AutoMapper;
using Lab4DbAPI.Models;
using Lab4DbAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4DbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly TableContext _context;
        private readonly IMapper _mapper;
        public MaterialsController(TableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetMaterials()
        {
            var materials = await _context.Materials.ToListAsync();
            var materialsDTO = _mapper.Map<IEnumerable<MaterialDTO>>(materials);
            return Ok(materialsDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            MaterialDTO materialdto = _mapper.Map<MaterialDTO>(material);

            return Ok(materialdto);
        }

        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterial(MaterialCreateDTO materialcdto)
        {
            var materialdto = _mapper.Map<MaterialDTO>(materialcdto);
            var material = _mapper.Map<Material>(materialdto);
            _context.Materials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.MaterialId }, material);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, MaterialCreateDTO materialcdto)
        {
            var existingMaterial = await _context.Materials.FindAsync(id);
            if (existingMaterial == null)
            {
                return NotFound();
            }

            existingMaterial.MaterialName = materialcdto.MaterialName;
            existingMaterial.Quantity = materialcdto.Quantity;
            existingMaterial.UnitPrice = materialcdto.UnitPrice;
            existingMaterial.SupplierId = materialcdto.SupplierId;
            existingMaterial.ProjectId = materialcdto.ProjectId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Materials.Any(e => e.MaterialId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
