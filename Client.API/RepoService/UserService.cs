using Client.API.IRepoService;
using Client.Domain.Models;
using Client.Domain.Interfaces.IRepo;


namespace Client.API.RepoService;

public class UserService : IUserService
{
    private readonly IUser user;

    public UserService(IUser user)
    {
        this.user = user;
    }
    public void AddUsers(User user)
    {
      this.user.AddUsers(user);
    }

    public void DeleteUser(int id)
    {
       this.user.DeleteUser(id);
    }

    public User GetUserById(int id)
    {
        var userlist = this.user.GetUserById(id);
        return userlist;
       
    }
    public List<User> GetUsers()
    {
        var userslist = this.user.GetUsers();
        return userslist;
    }

    public void Register(Register register)
    {
        this.user.Register(register);
    }
}

