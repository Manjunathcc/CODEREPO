using Client.Domain.Interfaces.IRepo;
using Client.Domain.Models;
using Client.Infrastructure.Context;

namespace Client.Infrastructure.Repositories;

public class UserRepo:IUser
{
    private readonly HskeletonContext dbcontext;

    public UserRepo(HskeletonContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    public void AddUsers(User user)
    {
        this.dbcontext.Users.Add(user);
        this.dbcontext.SaveChangesAsync();
    }

    public void DeleteUser(int id)
    {
       User userslist = this.dbcontext.Users.Where(x=>x.UserId==id).Select(x=>x).FirstOrDefault();
       this.dbcontext.Users.Remove(userslist);
       this.dbcontext.SaveChangesAsync();
    
    }

    public User GetUserById(int id)
    {
        var  userlist = this.dbcontext.Users.Where(x=>x.UserId == id).Select(x=>x).FirstOrDefault();
        return userlist;
    }

    public List<User> GetUsers()
    {
        var userlist =  this.dbcontext.Users.ToList();
         return userlist;
    }

     public void Register(Register register){
        var userlist = this.dbcontext.Registers.Add(register);
        this.dbcontext.SaveChangesAsync();
     }
}
