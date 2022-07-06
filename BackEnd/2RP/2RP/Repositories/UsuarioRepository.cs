using _2RP.Contexts;
using _2RP.Domains;
using _2RP.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2RP.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ProcessoSeletivoContext ctx = new();

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);

            if (UsuarioAtualizado != null)
            {
                usuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
                usuarioBuscado.Nome = UsuarioAtualizado.Nome;
                usuarioBuscado.Email = UsuarioAtualizado.Email;
                usuarioBuscado.Senha = UsuarioAtualizado.Senha;

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Cadastro(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(U => U.Email == email && U.Senha == senha);
        }

        public Usuario NovoStatus(int idUsuario, bool idStatus)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);
            if (usuarioBuscado != null)
            {
                usuarioBuscado.StatusSituacao = idStatus;

                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public List<Usuario> ListarG(int idUsuario)
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation)
            .Where(c => c.IdUsuario == idUsuario)
            .ToList();

        }

        
    }
}
