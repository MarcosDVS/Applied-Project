using TORO.Data.Requets;
using TORO.Data.Responses;

namespace TORO.Data.Services
{
    public interface IUserService
    {
        Task<Resul<List<UserResponse>>> Consultar(string filtro);
        Task<Result> Crear(UserRequest request);
        Task<Result> Eliminar(UserRequest request);
        Task<Result> Modificar(UserRequest request);
    }
}