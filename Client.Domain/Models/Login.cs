using System;
using System.Collections.Generic;

namespace Client.Domain.Models;

public class Login
{
    public string MailId { get; set; } = null!;

    public string Password { get; set; } = null!;
}
