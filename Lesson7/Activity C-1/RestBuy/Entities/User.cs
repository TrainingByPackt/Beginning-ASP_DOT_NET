
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestBuy.Entities
{
    public class User : BaseEntity
    {
        readonly static byte[] secretBytes = Encoding.ASCII.GetBytes("RESTBUY_SECRET");
        string userName;
        string password;
        public User(string userName, string password)
        {
            this.userName = userName;

            this.password = GetHash(userName, password);
        }

        User()
        {

        }

        public static string GetHash(string userName, string password)
        {
            using (var algorithm = SHA256.Create())
            {
                var passwordBytes = Encoding.ASCII.GetBytes(password);
                var userNameBytes = Encoding.ASCII.GetBytes(userName);
                var totalBytes = passwordBytes.Concat(userNameBytes).Concat(secretBytes).ToArray();
                var hash = algorithm.ComputeHash(totalBytes);
                return Encoding.ASCII.GetString(hash);
            }
        }
        public string UserName => this.userName;
        public string Password => this.password;
    }
}


