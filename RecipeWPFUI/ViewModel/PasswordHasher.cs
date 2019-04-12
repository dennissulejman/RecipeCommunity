using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI.ViewModel
{
    public static class PasswordHasher
    {
        public static string UserPasswordHashing(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static void UserGetHashedPassword(ref RecipeContext db, string username, string password)
        {
            UserHelper.UserAuthentication(ref db, username, password);
            string savedPasswordHash = db.Users.Where(u => u.Username == username)
            .SingleOrDefault().Password;

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            ConvertToHashedPassword(ref db, password, salt);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] == hash[i])
                {
                    UserHelper.UserAuthentication(ref db, username, password);
                }
                else if (hashBytes[i + 16] != hash[i])
                {
                    Console.WriteLine("Password is incorrect!");
                    Console.WriteLine("Press enter to try again.");
                    break;
                }
        }

        public static void ConvertToHashedPassword(ref RecipeContext db, string password, byte[] salt)
        {
            try
            {
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            }
            catch (Exception)
            {
                Console.WriteLine("Password is incorrect!");
                Console.WriteLine("Press enter to try again.");
                Console.ReadLine();
                //LoginUser(ref db);
            }
        }
    }
}
