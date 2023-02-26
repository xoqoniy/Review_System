using Domain.Entities;
using Newtonsoft.Json.Linq;
using Review_System.RegistrationUI;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_System.UserPage
{
    public class UserPageUI
    {
        UserService userService = new UserService();
        
        ReviewService reviewService = new ReviewService();
        Login login = new Login();
        OrganizationService organizationService = new OrganizationService();
        Organization organization= new Organization();


        public async Task UserPage(string log)
        {


            //var userId = (await userService.GetByIdAsync(log)).Value.Id;

        start:
            Console.WriteLine("\t\t-- User Page --");
            Console.WriteLine("1. Search Organization ");
            Console.WriteLine("2. Show Organizations ");
            Console.WriteLine("3. My Comments ");
            Console.WriteLine("4. RATINGS ");
            Console.WriteLine("5. Back ");

            Console.Write("\nChoose one option: ");
            int press = int.Parse(Console.ReadLine());

            switch (press)
            {
                case 1:
                    Console.Clear();
                    Console.Write("Enter organization's name: ");
                    string name = Console.ReadLine();
                    var response = await organizationService.SearchByNameAsync(name);
                    if (response is null)
                        Console.WriteLine("Not Found!");
                    else
                    {
                        var items = new List<long>();
                        
                    choose:
                        foreach (var item in response)
                        {

                            Console.WriteLine($"{item.Name} | {item.Description} | {item.Type} ");
                        }

                        


                    
                                Console.Write("\nEnter 5 to return: ");
                                Console.Write("\nEnter 0 to return to Main Menu: ");


                                int pres = int.Parse(Console.ReadLine());
                                if (pres == 5)
                                {
                                    Console.Clear();
                                    goto choose;
                                }
                                else if (pres == 0)
                                {
                                    Console.Clear();
                                    goto start;
                                }

                            


                        


                    }
                    break;

                case 2:
                    Console.Clear();
                    var response1 = await organizationService.GetAllAsync();

                    if (response1.StatusCode == 200)
                    {
                        Console.WriteLine("All Organizations:");
                        foreach (var org in response1.Value)
                        {
                            Console.WriteLine($"Name: {org.Name}\tDescription: {org.Describtion}\tType: {org.Type}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response1.Message}");
                    }


                    while (true)
                    {
                        Console.Write("\nEnter 5 to return: ");
                        Console.Write("\nEnter 0 to return to Main Menu: ");


                        int pres = int.Parse(Console.ReadLine());
                        if (pres == 5)
                        {
                            Console.Clear();
                            goto case 1;
                        }
                        else if (pres == 0)
                        {
                            Console.Clear();
                            goto start;
                        }
                    }
                    
                    break;

                case 3:
                    Console.Write("Enter the name of the organization you want to rate: ");
                    string organizationname = Console.ReadLine();
                    var response2 = await organizationService.SearchByNameAsync(organizationname);
                    foreach(var item in response2)
                    {
                        if (item == null)
                        {
                            Console.WriteLine($"Organization '{item.Name}' is not found.");
                            return;
                        }
                        else
                        {
                            Console.Write("Enter the title of review: ");
                            var title = Console.ReadLine();
                            Console.Write("Give describtion: ");
                            var desc = Console.ReadLine();
                            Console.Write("Enter star number from 1 to 5: ");
                            int value = int.Parse(Console.ReadLine());

                            var createcomment = new Review()
                            {
                                Title = title,
                                Comment = desc,
                                Value = value

                            };
                            var response3 = await reviewService.CreateAsync(createcomment);

                            if (response3.StatusCode == 200)
                            {
                                Console.WriteLine($"Review for '{item.Name}' created successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Error creating review: {response3.Message}");
                            }
                        }
                    }
                    while (true)
                    {
                        Console.Write("\nEnter 5 to return: ");
                        Console.Write("\nEnter 0 to return to Main Menu: ");


                        int pres = int.Parse(Console.ReadLine());
                        if (pres == 5)
                        {
                            Console.Clear();
                            goto case 1;
                        }
                        else if (pres == 0)
                        {
                            Console.Clear();
                            goto start;
                        }
                    }

                    break;
                case 4:
                    Console.Clear();
                    var allreviews = await reviewService.GetAllAsync();
                    Console.Write("Enter the name of the business to see ratings: ");
                   
                    if (allreviews.StatusCode == 200)
                    {
                        
                        Console.WriteLine("All Organizations:");
                        foreach (var org in allreviews.Value)
                        {
                            Console.WriteLine($"Title: {org.Title}\tComment: {org.Comment}\tuser_id: {org.UserId}\n" +
                                $"Organization Name: {org.OrganisationName}\tRate: {org.Value}");
                           
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {allreviews.Message}");
                    }
                    while (true)
                    {
                        Console.Write("\nEnter 5 to return: ");
                        Console.Write("\nEnter 0 to return to Main Menu: ");


                        int pres = int.Parse(Console.ReadLine());
                        if (pres == 5)
                        {
                            Console.Clear();
                            goto case 1;
                        }
                        else if (pres == 0)
                        {
                            Console.Clear();
                            goto start;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("You clicked the wrong number:");
                    goto start;
                    

            }



        }
    }
}
