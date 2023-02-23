using Domain.Entities;
using Domain.Enums;
using Service.DTOs;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_System.AdminPageUI
{

    public class AdminPage
    {
        private readonly OrganizationService organizationService;
        private readonly ReviewService reviewService;
        //Organization organization = new Organization(); //product service 
        //Review comment = new Review();  //order service
        public AdminPage()
        {
            organizationService = new OrganizationService();
            reviewService = new ReviewService();
        }

        public async Task AdminPageRun()
        {
            while (true)
            {
                Console.WriteLine("                      ");
                Console.WriteLine("                        Welcome to Admin Page                    ");
                Console.WriteLine("                        **********************                    ");
                Console.WriteLine("                                                                  ");
                Console.WriteLine("                     1 ----- Create a new Organization                     ");
                Console.WriteLine("                     2 ----- GetAll Organizations                      ");
                Console.WriteLine("                     3 ----- GetById Organization                       ");
                Console.WriteLine("                     4 ----- Update Organization                         ");
                Console.WriteLine("                     5 ----- Delete Organization                        ");
                Console.WriteLine("                     6 -----  GetAllComments                           ");
                Console.WriteLine("                     7 ----- Change Statues                            ");
                Console.WriteLine("                     10 ----- To exit                                 ");

                int num = int.Parse(Console.ReadLine());

                if (num == 1)
                {
                    Console.Clear();
                    Console.Write("Enter Business Name:  ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Organization Description: ");
                    string description = Console.ReadLine();
                 
                    Console.Write("Enter Organization Type:  ");
                    OrganizationType type = (OrganizationType)int.Parse(Console.ReadLine());

                    OrganizationCreationDto organization = new OrganizationCreationDto
                    {
                        Name = name,
                        Description = description,
                        Type = type,

                    };
                    var repo = await organizationService.CreateAsync(organization);
                    Console.Clear();
                    Console.WriteLine(repo.Message);
                    //Console.Clear();
                }
                else if (num == 2)
                {
                    Console.Clear();

                    var products = await organizationService.GetAllAsync();
                    foreach (var product in products.Value)
                    {
                        Console.WriteLine($"Id: {product.Id}");
                        Console.WriteLine($"Name: {product.Name}");
                       
                        Console.WriteLine($"Description: {product.Describtion}");
                       
                        Console.WriteLine($"Type: {product.Type}");
                        Console.WriteLine("**********************");
                    }

                }
                else if (num == 3)
                {
                    Console.Clear();
                    Console.Write("Enter Product Id: ");
                    long id = long.Parse(Console.ReadLine());

                    var product = await organizationService.GetByIdAsync(id);
                    Console.WriteLine($"Id: {product.Value.Id}");
                    Console.WriteLine($"Name: {product.Value.Name}");
                    
                    Console.WriteLine($"Description: {product.Value.Describtion}");
                   ;
                    Console.WriteLine($"Type: {product.Value.Type}");
                    Console.WriteLine("**********************");
                }
                else if (num == 4)
                {
                    Console.Clear();

                    Console.Write("Enter Product Id:  ");
                    long id = long.Parse(Console.ReadLine());
                    Console.Write("Enter Product Name:  ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Product Price:  ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Product Description:  ");
                    string description = Console.ReadLine();
                    Console.Write("Enter Product Count:  ");
                    int count = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product Type:  ");
                    OrganizationType type = (OrganizationType)int.Parse(Console.ReadLine());

                    OrganizationCreationDto organizationCreationDto = new OrganizationCreationDto
                    {
                        Name = name,
                        
                        Description = description,
                        
                        Type = type
                    };

                    await organizationService.UpdateAsync(id, organizationCreationDto);
                    Console.Clear();
                }
                else if (num == 5)
                {
                    Console.Clear();

                    Console.Write("Enter Product Id:  ");
                    long id = long.Parse(Console.ReadLine());

                    await organizationService.DeleteAsync(id);

                }
                else if (num == 6)
                {
                    Console.Clear();

                    var res = await reviewService.GetAllAsync();
                    foreach (var item in res.Value)
                    {
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine($"Comment: {item.Comment}");
                        Console.WriteLine($"Value: {item.Value}");
                        var les = item.Organizations;
                        foreach (var utem in les)
                        {
                            Console.WriteLine(utem.Name);
                          
                            Console.WriteLine(utem.Type);
                           
                            Console.WriteLine(utem.Describtion);
                            Console.WriteLine(utem.UpdatedAt);
                        }

                    }
                }
                else if (num == 7)
                {
                    Console.Clear();

                    Console.Write("Enter Order Id:  ");
                    long id = long.Parse(Console.ReadLine());
                    Console.Write("Enter Status:  ");
                    PostStatus status = (PostStatus)int.Parse(Console.ReadLine());
                    // await orderService.ChangeStatusAsync(id, status); shu funksiyani yozib quyish kerak
                }
                else if (num == 10)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"There is no service numbered {num}");
                }

            }
        }
    }
}