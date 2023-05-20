using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyectoSC.Models
{
    public class ParroquiaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [Required]
        [ForeignKey("ProvinciaId")]
        public string ProvinciaId { get; set; }
        public ProvinciaModel? Provincia { get; set; }

        public ICollection<DatoModel>? Datos { get; set; }
        public ICollection<DocumentoModel>? Documentos { get; set; }
        public ICollection<FotografiaModel>? Fotografias { get; set; }
        public ICollection<InventarioModel>? Inventarios { get; set; }
        public ICollection<MapaModel>? Mapas { get; set; }
    }
}
