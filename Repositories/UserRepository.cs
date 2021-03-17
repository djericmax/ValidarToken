using System.Collections.Generic;
using System.Linq;
using validatoken.Models;

namespace validatoken.Repositories
{
    public class UserRepository
    {
        public static User Get(string usuario, string senha)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Editora="DC Comics",   Usuario = "batman",         Senha="654321",     Role = "admin"});
            users.Add(new User { Id = 1, Editora="Marvel",      Usuario = "ironman",        Senha="654321",     Role = "admin"});
            users.Add(new User { Id = 1, Editora="DC Comics",   Usuario = "robin",          Senha="4321",       Role = "empregado"});
            users.Add(new User { Id = 1, Editora="Marvel",      Usuario = "gaviao",         Senha="4321",       Role = "empregado"});
            users.Add(new User { Id = 2, Editora="DC Comics",   Usuario = "superman",       Senha="1234",       Role = "heroi"});
            users.Add(new User { Id = 2, Editora="Marvel",      Usuario = "hulk",           Senha="1234",       Role = "heroi"});
            users.Add(new User { Id = 2, Editora="DC Comics",   Usuario = "wonder woman",   Senha="1234",       Role = "heroi"});
            users.Add(new User { Id = 2, Editora="Marvel",      Usuario = "capitã marvel",  Senha="1234",       Role = "heroi"});
            users.Add(new User { Id = 2, Editora="DC Comics",   Usuario = "aquaman",        Senha="1234",       Role = "heroi"});
            users.Add(new User { Id = 2, Editora="Marvel",      Usuario = "thor",           Senha="1234",       Role = "heroi"});
            
            return users.Where(x => 
                x.Usuario.ToLower() == usuario.ToLower() && x.Senha == senha).FirstOrDefault();
        }
    }
}