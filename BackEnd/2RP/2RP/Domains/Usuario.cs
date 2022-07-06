using System;
using System.Collections.Generic;

#nullable disable

namespace _2RP.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public short? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool StatusSituacao { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
