using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autocare_WPF.domain.user_validation
{
    class Signup
    {
        public Signup(string firstName, string lastName, string password, string email, string username) 
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.hashedPassword=HashPassword(password);
        }
        private string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string hashedPassword { get; set; }
        public string username {  get; set; }

    }
}
