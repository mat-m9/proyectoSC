using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoSC.ModelRequest;
using proyectoSC.Models;
using proyectoSC.ResponseModels;
using System.Reflection.Metadata;

namespace proyectoSC.Controllers
{

    [ApiController]
    [Route("api/Datos")]
    public class DatoController : ControllerBase
    {
        private readonly DatabaseContext context;
        
        public DatoController(DatabaseContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public async Task<ActionResult<string>> SaveDocument(UploadRequest request)
        {
            context.Datos.Add(new DatoModel { Name = request.name, Content = request.content });
            try
            {
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }

        [HttpGet("id")]
        public async Task<ActionResult<byte[]>> GetDocumentContent(string id)
        {
            var document = await context.Datos.Where(d => d.Id == id).FirstOrDefaultAsync();
            if(document == null) { return NoContent(); }
            return document?.Content;
        }

        [HttpGet(template: ApiRoutes.Files.Parroquia)]
        public async Task<ActionResult<ICollection<DocumentsResponse>>> GetDocuments(string parroquiaID)
        {
            var documents = await context.Datos
                            .Where(d => d.ParroquiaId.Equals(parroquiaID))
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
