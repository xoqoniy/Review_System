
using Data.IRepositories;
using Data.Repositories;
using Domain.Entities;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;
namespace Review_System;
public class Program
{
    static async Task Main(string[] args)
    {
        //IAdminRepository adminRepository = new AdminRepository();
        //Admin admin = new Admin()
        //{
        //    Name = "Asadbek",
        //    Info = "Something",
        //    Username = "Asad",
        //    Password = "Asad",
        //    Email = "asad@gmail.com",
        //    PhoneNumber = "+991565589",
        //};
        //await adminRepository.InsertAdminAsync(admin);

        //IProductRepository productRepository = new ProductRepository();
        //Product product = new Product()
        //{
        //    Name = "Iphone 14 pro max",
        //    Description = "Chotki",
        //    Price = 1400,
        //    OrganizationId = 1

        //};
        //await productRepository.InsertProductAsync(product); 

        //IOrganizationRepository organizationRepository = new OrganizationRepository();
        //var organizations = organizationRepository.SelectAllOrgs();

        //string strJson = JsonSerializer.Serialize(organizations);

        //Console.WriteLine(strJson);
        


        //Organization organization = new Organization()
        //{

        //    Name = "Microsoft",
        //    Describtion = "Industrial revolutionary company",
        //    Tag = "#Tech|#Electronics|#Smartphones|#Laptops"
        //};
        //await organizationRepository.InsertOrgAsync(organization);
    }
}