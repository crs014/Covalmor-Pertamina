using System;
using System.Security.Cryptography;
using System.Text;

namespace CovalmorPertamina.Common.Statics
{
    public static class PasswordHash
    {
        public static string Salt = "1safA121aAZZq1321A7979A";

        public static string GetHash(string password)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(String.Concat(Salt, password));

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);
            string base64String = Convert.ToBase64String(hashedBytes);
            return base64String;
        }

        public static bool CompareHash(string attemptedPassword, string hash)
        {
            string base64AttemptedHash = GetHash(attemptedPassword);
            return hash == base64AttemptedHash;
        }
    }
}
