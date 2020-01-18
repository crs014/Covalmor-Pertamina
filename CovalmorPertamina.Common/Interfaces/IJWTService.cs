using System.Collections.Generic;
using System.Security.Claims;

namespace CovalmorPertamina.Common.Interfaces
{
    public interface IJWTService
    {
        void SetVariable(string secretKey);
        string SecretKey { get; set; }
        bool IsTokenValid(string token);
        string GenerateToken(IJWTContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
