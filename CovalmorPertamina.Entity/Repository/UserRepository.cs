using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Statics;
using CovalmorPertamina.Entity.Enum;
using CovalmorPertamina.Entity.Model;
using CovalmorPertamina.Entity.Model.Auth;
using CovalmorPertamina.Entity.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CovalmorPertamina.Entity.Repository
{
    public class UserRepository : IUserRepository
    {
        private IJWTService _jwtService;
        private IDBCovalmor _db;
        private string _secretKeyRefreshToken = "1zA12F24124FGasfas123ldsa";

        public ERepository repository => ERepository.User;

        public UserRepository(IDBCovalmor db, IJWTService jwtService)
        {
            _db = db;
            _jwtService = jwtService;
        }



        public Task<User> Create(User data)
        {
            return Task.Run(() =>
            {
                data.Password = PasswordHash.GetHash(data.Password);
                User user = _db.Users.Add(data);
                _db.SaveChanges();
                return user;
            });
        }

        public Task<User> Delete(int id)
        {
            return Task.Run(() =>
            {
                User user = _db.Users.Find(id);
                if(user != null)
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();
                }
                return user;
            });
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public Task<User> GetOne(int id)
        {
            return Task.Run(() => _db.Users.Find(id));
        }

        public Task<User> Update(int id, User data)
        {
            return Task.Run(() =>
            {
                User user = _db.Users.Find(id);
                if(user != null)
                {
                    user.Name = data.Name;
                    user.Email = data.Email;
                    user.Jabatan = data.Jabatan;
                    user.Role = data.Role;
                    user.UpdatedAt = data.UpdatedAt;
                    _db.SaveChanges();
                }
                return user;
            });
        }

        public Task<DataToken> UserLogin(LoginData login)
        {
            return Task.Run(() =>
            {
                User user = _db.Users.Where(e => e.Email == login.Email).FirstOrDefault();
                if(user != null) 
                {
                    if(PasswordHash.CompareHash(login.Password, user.Password))
                    {
                        return new DataToken()
                        {
                            Token = _generateToken(user.Id),
                            RefreshToken = _generateRefreshToken(user.Id)
                        };
                    }
                }
                return null;
            });
        }

        public Task<DataToken> RefreshToken(string refreshToken)
        {
            return Task.Run(() =>
            {
                //IJWTService jwtService = new JWTService(_secretKeyRefreshToken);
                _jwtService.SetVariable(_secretKeyRefreshToken);
                if (_jwtService.IsTokenValid(refreshToken))
                {
                    List<Claim> claims = _jwtService.GetTokenClaims(refreshToken).ToList();
                    int userId = Convert.ToInt32(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value);
                    return new DataToken()
                    {
                        RefreshToken = _generateRefreshToken(userId),
                        Token = _generateToken(userId)
                    };
                }
                return null;
            });
        }

        #region private method
        private string _generateRefreshToken(int id)
        {
            IJWTContainerModel jwtModel = StaticJWTContainer.GetAuthModel(id.ToString());
            jwtModel.SecretKey = _secretKeyRefreshToken;
            jwtModel.ExpireMinutes = 13;
            _jwtService.SetVariable(jwtModel.SecretKey);
            return _jwtService.GenerateToken(jwtModel);
        }

        private string _generateToken(int id)
        {
            string token = null;
            IJWTContainerModel jwtModel = StaticJWTContainer.GetAuthModel(id.ToString());
            _jwtService.SetVariable(jwtModel.SecretKey);
            token = _jwtService.GenerateToken(jwtModel);
            return token;
        }
        #endregion
    }
}
