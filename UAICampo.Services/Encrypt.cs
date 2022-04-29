using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UAICampo.Services
{
    public class Encrypt
    {
        public bool HashComparer(string inputPassword, string storedHash)
        {
            bool isEqual = false;
            if (hashRetriever(inputPassword) == storedHash)
            {
                isEqual = true;
            }
            return isEqual;
        }
        private string hashRetriever(string inputString)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
