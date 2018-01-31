using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProjectBackend1.Utilities
{
    public class Auth
    {


        public static string generateSalt()
        {
            return Convert.ToBase64String(generateSaltBytes());

        }

        private static byte[] generateSaltBytes()
        {
            byte[] salt;
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt = new byte[16]);
            return salt;

        }
    }
}
