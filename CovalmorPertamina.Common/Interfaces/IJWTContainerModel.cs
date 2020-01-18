using System.Security.Claims;

namespace CovalmorPertamina.Common.Interfaces
{
    public interface IJWTContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        Claim[] Claims { get; set; }
    }
}
