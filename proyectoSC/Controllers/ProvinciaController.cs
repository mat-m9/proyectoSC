using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoSC.ModelRequest;
using proyectoSC.Models;
using proyectoSC.ResponseModels;

namespace proyectoSC.Controllers
{
    [ApiController]
    [Route("pai/Provincias")]
    public class ProvinciaController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ProvinciaController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostProvincia(string name)
        {
            context.Provincias.Add(new ProvinciaModel { Name = name });
            try
            {
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<DocumentsResponse>>> GetProvincias()
        {
            var documents = await context.Provincias
                            .Select(a => new DocumentsResponse()
                            {
                                id = a.Id,
                                name = a.Name

                            }).ToListAsync();
            if (!documents.Any())
                return NotFound();
            return documents;
        }
    }
}
