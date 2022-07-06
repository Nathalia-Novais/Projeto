using _2RP.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2RP.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        List<Usuario> Listar();
        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);
        Usuario NovoStatus(int idUsuario, bool idStatus);
        Usuario BuscarPorId(int idUsuario);
        void Deletar(int idUsuario);
        void Cadastrar(Usuario novoUsuario);
    }
}
