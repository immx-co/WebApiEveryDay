using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef.core.demo.OneToOne;

public class UserOneToOne
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public UserProfileOneToOne? Profile { get; set; }
}

public class UserProfileOneToOne
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public int UserId { get; set; }

    public UserOneToOne? User { get; set; }
}

