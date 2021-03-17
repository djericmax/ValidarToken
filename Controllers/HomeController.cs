using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using validatoken.Models;
using validatoken.Services;
using validatoken.Repositories;

namespace validatoken.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Usuario, model.Senha);

            if(user == null)
            return NotFound(new {message = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(user);
            user.Senha = "";
            return new{
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => String.Format("Autenticado como {0}", User.Identity.Name);

        [HttpGet]
        [Route("empregado")]
        [Authorize(Roles = "empregado, heroi, admin")]
        public string Empregado() => String.Format("Funcionário: {0}", User.Identity.Name.ToUpper());

        [HttpGet]
        [Route("heroi")]
        [Authorize(Roles = "heroi, admin")]
        public string Heroi() => String.Format("Herói: {0}", User.Identity.Name.ToUpper());

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string Admin() => String.Format("Gerente: {0}", User.Identity.Name.ToUpper());
    }
}