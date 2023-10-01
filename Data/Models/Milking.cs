using System.ComponentModel.DataAnnotations;

namespace TORO.Data.Models
{
    public class Milking
    {
        [Key]
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime Fecha { get; set; }
        public double LitrosLeche { get; set; }
    }
}
