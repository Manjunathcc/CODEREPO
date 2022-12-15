using Client.Domain.Models;

namespace Client.Domain.Interfaces.IRepo;

public interface IUser
{

    List<User> GetUsers();

    User GetUserById(int id);
    void AddUsers(User user);

    void DeleteUser(int id);

    void Register(Register register);

}
