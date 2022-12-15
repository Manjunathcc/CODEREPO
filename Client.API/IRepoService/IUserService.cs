using Client.Domain.Models;


namespace Client.API.IRepoService;

public interface IUserService
{
    List<User> GetUsers();

    User GetUserById(int id);
    void AddUsers(User user);

    void DeleteUser(int id);

    void Register(Register register);
}
