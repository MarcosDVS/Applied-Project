namespace TORO.Data.Requets
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;
    }
}
