using Review_System.RegistrationUI;
using System;
namespace Review_System;
public class Program
{
    static async Task Main(string[] args)
    {
        var Login = new Login();
        await Login.LoginPageAsync();
    }
}