using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace proyectoSC.Models
{
    public class InventarioModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }


        [Required]
        [ForeignKey("ParroquiaId")]
        public string ParroquiaId { get; set; }
        public ParroquiaModel? Parroquia { get; set; }
    }
}
