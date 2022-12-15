using System;
using System.Collections.Generic;

namespace Client.Domain.Models;

public partial class User
{
 public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public int Age { get; set; }

    public string? StreetName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
