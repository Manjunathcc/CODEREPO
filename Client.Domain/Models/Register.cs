using System;
using System.Collections.Generic;

namespace Client.Domain.Models;

public partial class Register
{
    public string UserId { get; set; } = null!;

    public string MailId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
