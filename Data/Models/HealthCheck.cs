using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Models
{
    public class HealthCheck
    {
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Fecha { get; set; }
        public string Notas { get; set; } = null!;
    }
}
