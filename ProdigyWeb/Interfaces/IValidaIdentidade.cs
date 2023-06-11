namespace ProdigyWeb.Interfaces
{
    public interface IValidaIdentidade
    {
        bool ValidaCpf(string cpf);
        bool ValidaCnpj(string cnpj);
    }
}
