using System;

namespace Popsi.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    public virtual List<Labour>? Tasks { get; set; }
}
