using ProdigyWeb.Models;

namespace ProdigyWeb.Interfaces
{
    public interface ICookie
    {
        Usuario ValidarUsuario(string email, string senha);
        SFuncionario ValidarFuncionario(string email, string senha, string cnpj);
        Task GerarClaim(HttpContext context, Usuario usuario);
        Task GerarClaimFuncionario(HttpContext context, SFuncionario funcionario);
        Task Logout(HttpContext context);
    }
}
