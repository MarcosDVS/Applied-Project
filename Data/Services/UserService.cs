using Microsoft.EntityFrameworkCore;
using TORO.Data.Context;
using TORO.Data.Models;
using TORO.Data.Requets;
using TORO.Data.Responses;

namespace TORO.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class Resul<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class UserService : IUserService
    {
        private readonly IToroDbContext dbContext;

        public UserService(IToroDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(UserRequest request)
        {
            try
            {
                var user = User.Crear(request);
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(UserRequest request)
        {
            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (user == null) return new Result() { Message = "No se encontro", Success = false };

                if (user.Modificar(request)) await dbContext.SaveChangesAsync();

                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(UserRequest request)
        {
            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.Id);

                if (user == null) return new Result() { Message = "No se encontro", Success = false };

                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return new Result { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result { Message = E.Message, Success = false };
            }
        }

        public async Task<Resul<List<UserResponse>>> Consultar(string filtro)
        {
            try
            {
                var users = await dbContext.Users
                    .Where(c =>
                        (c.Nombre + " " + c.Apellido + " " + c.Email + " " + c.Clave)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();

                return new Resul<List<UserResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = users
                };
            }
            catch (Exception E)
            {

                return new Resul<List<UserResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
