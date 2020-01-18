using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Model.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository.Interfaces
{
    public interface IUserRepository : ILoadRepository<IUserRepository>
    {
        IQueryable<User> GetAll();

        Task<User> GetOne(int id);

        Task<User> Create(User data);

        Task<User> Delete(int id);

        Task<User> Update(int id, User data);

        Task<DataToken> UserLogin(LoginData login);

        Task<DataToken> RefreshToken(string refreshToken);
    }
}
