using Service.DTOs;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_System;
using Review_System.AdminPageUI;
using Review_System.UserPage;

namespace Review_System.RegistrationUI
{
    public class Login
    {
        UserService userService = new UserService();
        UserCreationDto user = new UserCreationDto();
        public string log = "";
        public async Task LoginPageAsync()
        {
            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                Console.WriteLine("1.Registration");
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                Console.WriteLine("2.Login");
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                Console.WriteLine("3.Exit");
                Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                Console.Write("\nPress any number given above: ");
                string N = Console.ReadLine();
                switch (N)
                {

                    case "1":
                        Console.Clear();
                        Console.WriteLine("\t---Please fill your info for Registration---");
                        Console.Write("Input your firstname: ");
                        user.Name = Console.ReadLine();
                        Console.Write("Input your email: ");
                        user.Email = Console.ReadLine();
                        Console.Write("Inform your phone number: ");
                        user.Phone = Console.ReadLine();
                        Console.Write("Create your username: ");
                        user.UserName = Console.ReadLine();
                        log = user.UserName;


                        Console.Write("Create your password: ");

                        user.Password = Console.ReadLine();
                        var response = await userService.CreateAsync(user);

                        if (response.Value is null)
                        {
                            Console.WriteLine("This user already exists");
                            goto case "2";
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Successfully created\n");
                            var user = new UserPageUI();
                            await user.UserPage();

                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Enter login informations: ");
                        Console.Write("Username: ");
                        user.UserName = Console.ReadLine();
                        log = user.UserName;
                        Console.Write("Password: ");
                        user.Password = Console.ReadLine();
                        var response1 = await userService.ChechkForExists(user.UserName, user.Password);
                        if (user.UserName == "admin" && user.Password == "admin")
                        {
                            Console.Clear();
                            var admin = new AdminPage();
                            await admin.AdminPageRun();
                            return;

                        }
                        else if (response1.Value is null)
                        {
                            Console.Clear();

                            Console.WriteLine("User is not found");
                        }
                        else
                        {
                            Console.Clear();
                            //var user = new UserPageUI();
                            //await user.UserPage(log);
                            return;
                        }
                        break;

                    case "3":
                        Console.Write("Are you sure:(Y) or (N) ");

                        string javob = Console.ReadLine();
                        if (javob.ToLower() == "y")
                        {
                            return;
                        }
                        else if (javob.ToLower() == "n")
                        {
                            Console.Clear();
                            goto case "1";
                        }
                        else
                        {
                            goto case "1";
                        }

                    default:
                        Console.Clear();
                        Console.WriteLine("You chose invalid number!");
                        goto case "1";

                }




            }
        }
    }
}
