using System;
using System.Collections.Generic;
namespace JoyaMovil.Models
{
    public class Usuario
    {
        public string UniqueId { get; private set; }

        public string username { get; set; }
        public string password { get; set; }
        public TipoUsuario NivelUsuario { get; set; }
        public Usuario()
        {
            UniqueId = Guid.NewGuid().ToString();
        }
        public Usuario(string username, string password, TipoUsuario nivelUsuario)
        {
            this.username = username;
            this.password = password;
            this.NivelUsuario = nivelUsuario;
            
        }
    }
}
