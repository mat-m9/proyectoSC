using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoSC.ModelRequest;
using proyectoSC.Models;
using proyectoSC.ResponseModels;

namespace proyectoSC.Controllers
{
    [ApiController]
    [Route("api/Parroquias")]
    public class ParroquiaController : ControllerBase
    {
        private readonly DatabaseContext context;

        public ParroquiaController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostParroquia(ParroquiaPostRequest request)
        {
            context.Parroquias.Add(new ParroquiaModel { Name = request.Name, ProvinciaId = request.ProvinciaID});
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


        [HttpGet(template: ApiRoutes.Files.Provincia)]
        public async Task<ActionResult<ICollection<DocumentsResponse>>> GetDocuments(string provinciaID)
        {
            var documents = await context.Parroquias
                            .Where(d => d.ProvinciaId.Equals(provinciaID))
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
