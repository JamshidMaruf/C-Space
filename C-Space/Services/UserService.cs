using C_Space.Interfaces;
using C_Space.Models;

namespace C_Space.Services;

public class UserService : IUserService
{
    private List<User> users;
    public UserService()
    {
        users = new List<User>();
    }

    public User Create(User user)
    {
        
        var existUser = users.FirstOrDefault(user => user.Phone == user.Phone);
        if (existUser is not null)
            throw new Exception("This user already exists");

        users.Add(user);
        return user;
    }

    public bool Delete(int id)
    {
        var user = users.FirstOrDefault(user => user.Id == id);
        if (user is null)
            throw new Exception("This user is not found");

        return users.Remove(user);
    }

    public List<User> GetAll() => users;

    public User GetById(int id)
    {
        var user = users.FirstOrDefault(user => user.Id == id);
        if (user is null)
            throw new Exception("This user is not found");

        return user;
    }

    public User Update(int id, User user)
    {
        var existUser = users.FirstOrDefault(user => user.Id == id);
        if (existUser is null)
            throw new Exception("This user is not found");

        existUser.Id = id;
        existUser.Email = user.Email;
        existUser.Phone = user.Phone;
        existUser.LastName = user.LastName;
        existUser.FirstName = user.FirstName;

        return existUser;
    }
}