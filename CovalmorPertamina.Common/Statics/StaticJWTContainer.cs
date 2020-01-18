using CovalmorPertamina.Common.Interfaces;
using CovalmorPertamina.Common.Services;
using System.Security.Claims;

namespace CovalmorPertamina.Common.Statics
{
    public static class StaticJWTContainer
    {
        public static IJWTContainerModel GetAuthModel(string id = "")
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }
            };
        }
    }
}
