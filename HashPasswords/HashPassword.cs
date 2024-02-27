using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashPasswords
{
    public class HashPassword
    {
        /// <summary>
        /// В этом методе реализуем хэширование пароля
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword1(string password)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] SoursebytePass = Encoding.UTF8.GetBytes(password);
                byte[] HashSourceBytePass = sha256hash.ComputeHash(SoursebytePass);
                string hashpass = BitConverter.ToString(HashSourceBytePass).Replace("-", string.Empty);
                return hashpass;
            }
        }
    }
}
