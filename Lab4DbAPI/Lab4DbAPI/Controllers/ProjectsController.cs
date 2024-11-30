using AutoMapper;
using Lab4DbAPI.Models;
using Lab4DbAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4DbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly TableContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(TableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();
            var projectsDTO = _mapper.Map<IEnumerable<ProjectDTO>>(projects);
            return Ok(projectsDTO);
        }

        // GET: api/Projects/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDTO = _mapper.Map<ProjectDTO>(project);
            return Ok(projectDTO);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> PostProject(ProjectCreateDTO projectcDTO)
        {
            var projectdto = _mapper.Map<ProjectDTO>(projectcDTO);
            var project = _mapper.Map<Project>(projectdto);
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, projectcDTO);
        }

        // PUT: api/Projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectCreateDTO projectDTO)
        {
            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.ProjectName = projectDTO.ProjectName;
            existingProject.StartDate = projectDTO.StartDate;
            existingProject.EndDate = projectDTO.EndDate;
            existingProject.Budget = projectDTO.Budget;
            existingProject.Address = projectDTO.Address;
            existingProject.ProjectStatus = projectDTO.ProjectStatus;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(p => p.ProjectId == id))
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


        // DELETE: api/Projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
