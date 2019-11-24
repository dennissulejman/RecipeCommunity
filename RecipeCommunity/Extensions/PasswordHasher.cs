using RecipeLibrary;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RecipeCommunity.Extensions
{
    public static class PasswordHasher
    {
        public static bool IsPasswordCorrect(string username, string password)
        {
            using var db = new RecipeContext();
            if (db.Users.Where(x => x.Username == username).FirstOrDefault().Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
