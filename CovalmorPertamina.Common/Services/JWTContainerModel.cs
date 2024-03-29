﻿using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using CovalmorPertamina.Common.Interfaces;

namespace CovalmorPertamina.Common.Services
{
    public class JWTContainerModel : IJWTContainerModel
    {
        public int ExpireMinutes { get; set; } = 10;
        public string SecretKey { get; set; } = "TaU77T1iX123XJPxda4rSDK";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public Claim[] Claims { get; set; }
    }
}
