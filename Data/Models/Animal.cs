using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Raza { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
    }
}
