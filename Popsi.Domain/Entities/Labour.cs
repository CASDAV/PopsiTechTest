using System;
using Popsi.Domain.Enums;

namespace Popsi.Domain.Entities;

public class Labour
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Owner { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public State State { get; set; }

    public virtual User User { get; set; } = null!;
}
