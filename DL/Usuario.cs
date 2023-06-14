using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Username { get; set; }

    public byte[]? Password { get; set; }

    public virtual ICollection<SuperDigito> SuperDigitos { get; set; } = new List<SuperDigito>();

}
