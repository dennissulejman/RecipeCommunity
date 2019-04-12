using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RecipeWPFUI.ViewModel
{
    public static class UserHelper
    {

        public static void LoginUser(ref RecipeContext db, string username, string password)
        {
            PasswordHasher.UserGetHashedPassword(ref db, username, password);
        }

        //public static void DeleteUser(ref RecipeContext db)
        //{
        //    bool passwordConfirmation = true;
        //    while (passwordConfirmation)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Please enter your username:");
        //        string userName = Console.ReadLine();
        //        Console.WriteLine("Please enter your password:");
        //        string passWord = UserPasswordMasking();
        //        Console.WriteLine("Please confirm your password:");
        //        string passWordConfirm = UserPasswordMasking();
        //        if (passWord == passWordConfirm)
        //        {
        //            Console.WriteLine("This action will delete your account");
        //            Console.WriteLine("Would you like to proceed? (y/n)");
        //            string response = Console.ReadLine();
        //            if (response == "y")
        //            {
        //                string hashedPassword = UserPasswordHashing(passWordConfirm);
        //                RemoveUser(ref db, userName, hashedPassword);
        //                break;
        //            }
        //            else if (response == "n")
        //            {
        //                break;
        //            }
        //        }
        //        else if (passWord != passWordConfirm)
        //        {
        //            Console.WriteLine("The password was not confirmed!");
        //            Console.WriteLine("Press enter to try again.");
        //            Console.ReadLine();
        //            passwordConfirmation = true;
        //        }
        //    }
        //}

        //public static void RemoveUser(ref RecipeContext db, string userName, string hashedPassword)
        //{
        //    try
        //    {
        //        db.Users.Remove(new User
        //        {
        //            Username = userName,
        //            Password = hashedPassword,
        //        });
        //        db.SaveChanges();
        //        db.RecipeLists.Remove(new RecipeList
        //        {
        //            RecipeListId = db.GetRecipeListId()
        //        });
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        Console.WriteLine("Username not found!");
        //        Console.WriteLine("Press enter to try again.");
        //        Console.ReadLine();
        //        db.DetachAllEntities();
        //        DeleteUser(ref db);
        //    }
        //}

        public static void UserAuthentication(ref RecipeContext db, string userName, string passWord)
        {
            try
            {
                string existingUser = db.Users.Single(u => u.Username == userName).ToString();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("User does not exist!");
                Console.WriteLine("Press enter to try again.");
                Console.ReadLine();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("User does not exist!");
                Console.WriteLine("Press enter to try again.");
                Console.ReadLine();
            }
            try
            {
                string savedPasswordHash = db.Users.Where(u => u.Username == userName)
                                        .SingleOrDefault().Password;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Password empty");
            }
        }

    }
}
