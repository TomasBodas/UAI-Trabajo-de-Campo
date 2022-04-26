using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Abstractions;
using System.Security.Cryptography; 

namespace UAICampo.Services
{
    public class Encryption
    {
        public string Encrypt(string pUsername)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(pUsername))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}
