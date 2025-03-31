using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.user_validation
{
    class Login
    {
        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.hashedPassword = HashPassword(password);
        }
        public string username { get; set; }
        public string password { get; set; }
        public string hashedPassword { get; set; }
        private string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
