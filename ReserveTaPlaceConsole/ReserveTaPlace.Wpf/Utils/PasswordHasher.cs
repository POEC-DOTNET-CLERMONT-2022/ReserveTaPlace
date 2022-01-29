using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReserveTaPlace.Wpf.Utils
{
    public sealed class PasswordHasher
    {
        private byte[] _salt;
        private string _hash;
        public PasswordHasher(string password)
        {
            _salt = GenerateSalt();
            _hash = Hash(password);
        }
        public string HashedPassword { get { return _hash; } }
        private byte[] GenerateSalt()
        {
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(_salt);
                return _salt;
            }
        }
        private string Hash(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: _salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        }

    }
}
