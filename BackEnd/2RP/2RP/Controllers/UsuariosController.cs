using _2RP.Domains;
using _2RP.Interfaces;
using _2RP.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace _2RP.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

       //[Authorize(Roles = "2,3")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }


        //[Authorize]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_usuarioRepository.BuscarPorId(idUsuario));
        }


        [Authorize(Roles = "2,3")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [Authorize]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(short idUsuario, Usuario UsuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idUsuario, UsuarioAtualizado);

            return StatusCode(204);
        }
   

        [Authorize(Roles = "3")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }

        [Authorize(Roles = "2,3")]
        [HttpPatch("{id}")]
        public IActionResult NovoStatus(int id, bool idStatus)
        {
            return Ok(_usuarioRepository.NovoStatus(id, idStatus));
        }

    }
}
