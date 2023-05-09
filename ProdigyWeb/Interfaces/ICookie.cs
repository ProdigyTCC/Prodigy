using ProdigyWeb.Models;

namespace ProdigyWeb.Interfaces
{
    public interface ICookie
    {
        Usuario ValidarUsuario(string email, string senha);
        Task GerarClaim(HttpContext context, Usuario usuario);
        Task Logout(HttpContext context);
    }
}
