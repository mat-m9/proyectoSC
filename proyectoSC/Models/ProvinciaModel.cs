namespace proyectoSC.Models
{
    public class ProvinciaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<ParroquiaModel>? Parroquias { get; set; }
    }
}
