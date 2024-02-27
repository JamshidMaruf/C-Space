using C_Space.Models;
using C_Space.Services;

namespace C_Space.Display;

public class UserMenu
{
    private readonly UserService userService;
    public UserMenu(UserService userService)
    {
        this.userService = userService;
    }

    public void Create()
    {
        var user = new User();

        Console.Write("Enter FirstName: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Enter LastName: ");
        user.LastName = Console.ReadLine();

        Console.Write("Enter Phone: ");
        user.Phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        user.Email = Console.ReadLine();

        userService.Create(user);
    }

    public void Update()
    {
        var user = new User();

        Console.Write("Enter ID: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Enter FirstName: ");
        user.FirstName = Console.ReadLine();

        Console.Write("Enter LastName: ");
        user.LastName = Console.ReadLine();

        Console.Write("Enter Phone: ");
        user.Phone = Console.ReadLine();

        Console.Write("Enter Email: ");
        user.Email = Console.ReadLine();

        try
        {
            userService.Update(id, user);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete()
    {

    }

    public void GetById()
    {

    }

    public void GetAll()
    {

    }
}
