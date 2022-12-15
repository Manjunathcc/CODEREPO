using Client.API.IRepoService;
using Microsoft.AspNetCore.Mvc;
using  Client.Domain.Models;
using Microsoft.AspNetCore.Authorization;

namespace Client.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientCOntroller : ControllerBase
{
    private readonly IUserService userservice;

    public ClientCOntroller(IUserService userservic̣e)
    {
        this.userservice = userservic̣e;
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var userslist = this.userservice.GetUsers();
        return Ok(userslist);
    }

    [HttpGet]
    [Route("GetUser")]

    public IActionResult GetUserByID(int id)
    {
        var userslist = this.userservice.GetUserById(id);
        return Ok(userslist);

    }

    [HttpPost]

    public IActionResult AddUsers(User user)
    {
        this.userservice.AddUsers(user);
        return Ok();
    }

    [HttpDelete]

    public IActionResult DeleteUsers(int id)
    {
        this.userservice.DeleteUser(id);
        return Ok();
    }
}
