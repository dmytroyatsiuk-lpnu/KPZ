using AutoMapper;
using Lab4DbAPI.Models;
using Lab4DbAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4DbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly TableContext _context;
        private readonly IMapper _mapper;

        public SuppliersController(TableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            var suppliersDTO = _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
            return Ok(suppliersDTO);
        }

        // GET: api/Suppliers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
            return Ok(supplierDTO);
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplier(SupplierCreateDTO suppliercDTO)
        {
            var supplierdto = _mapper.Map<SupplierDTO>(suppliercDTO);
            var supplier = _mapper.Map<Supplier>(supplierdto);
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, suppliercDTO);
        }

        // PUT: api/Suppliers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SupplierCreateDTO suppliercDTO)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(id);
            if (existingSupplier == null)
            {
                return NotFound();
            }

            existingSupplier.SupplierName = suppliercDTO.SupplierName;
            existingSupplier.ContactNumber = suppliercDTO.ContactNumber;
            existingSupplier.Email = suppliercDTO.Email;
            existingSupplier.Address = suppliercDTO.Address;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Suppliers.Any(s => s.SupplierId == id))
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

        // DELETE: api/Suppliers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
