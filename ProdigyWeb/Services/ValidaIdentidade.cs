using ProdigyWeb.Interfaces;

namespace ProdigyWeb.Services
{
    public class ValidaIdentidade : IValidaIdentidade
    {
        public bool ValidaCnpj(string cnpj)
        {
            bool resp = false;

            int digito01 = 0, digito02 = 0;

            digito01 += int.Parse(cnpj.Substring(14, 1)) * 2;
            digito01 += int.Parse(cnpj.Substring(13, 1)) * 3;
            digito01 += int.Parse(cnpj.Substring(12, 1)) * 4;
            digito01 += int.Parse(cnpj.Substring(11, 1)) * 5;
            digito01 += int.Parse(cnpj.Substring(9, 1)) * 6;
            digito01 += int.Parse(cnpj.Substring(8, 1)) * 7;
            digito01 += int.Parse(cnpj.Substring(7, 1)) * 8;
            digito01 += int.Parse(cnpj.Substring(5, 1)) * 9;
            digito01 += int.Parse(cnpj.Substring(4, 1)) * 2;
            digito01 += int.Parse(cnpj.Substring(3, 1)) * 3;
            digito01 += int.Parse(cnpj.Substring(1, 1)) * 4;
            digito01 += int.Parse(cnpj.Substring(0, 1)) * 5;

            digito01 %= 11;

            if (digito01 < 2)
            {
                digito01 = 0;
            }
            else
            {
                digito01 = 11 - digito01;
            }

            digito02 += int.Parse(cnpj.Substring(16, 1)) * 2;
            digito02 += int.Parse(cnpj.Substring(14, 1)) * 3;
            digito02 += int.Parse(cnpj.Substring(13, 1)) * 4;
            digito02 += int.Parse(cnpj.Substring(12, 1)) * 5;
            digito02 += int.Parse(cnpj.Substring(11, 1)) * 6;
            digito02 += int.Parse(cnpj.Substring(9, 1)) * 7;
            digito02 += int.Parse(cnpj.Substring(8, 1)) * 8;
            digito02 += int.Parse(cnpj.Substring(7, 1)) * 9;
            digito02 += int.Parse(cnpj.Substring(5, 1)) * 2;
            digito02 += int.Parse(cnpj.Substring(4, 1)) * 3;
            digito02 += int.Parse(cnpj.Substring(3, 1)) * 4;
            digito02 += int.Parse(cnpj.Substring(1, 1)) * 5;
            digito02 += int.Parse(cnpj.Substring(0, 1)) * 6;

            digito02 %= 11;

            if (digito02 < 2)
            {
                digito02 = 0;
            }
            else
            {
                digito02 = 11 - digito02;
            }

            if (cnpj.Substring(16, 1) == digito01.ToString()
                && cnpj.Substring(17, 1) == digito02.ToString())
            {
                resp = true;
            }

            return resp;
        }

        public bool ValidaCpf(string cpf)
        {
            bool resp = false;
            int digito01 = 0, digito02 = 0;

            digito01 += int.Parse(cpf.Substring(10, 1)) * 2;
            digito01 += int.Parse(cpf.Substring(9, 1)) * 3;
            digito01 += int.Parse(cpf.Substring(8, 1)) * 4;
            digito01 += int.Parse(cpf.Substring(6, 1)) * 5;
            digito01 += int.Parse(cpf.Substring(5, 1)) * 6;
            digito01 += int.Parse(cpf.Substring(4, 1)) * 7;
            digito01 += int.Parse(cpf.Substring(2, 1)) * 8;
            digito01 += int.Parse(cpf.Substring(1, 1)) * 9;
            digito01 += int.Parse(cpf.Substring(0, 1)) * 10;

            digito01 %= 11;

            if (digito01 < 2)
            {
                digito01 = 0;
            }
            else
            {
                digito01 = 11 - digito01;
            }

            digito02 += int.Parse(cpf.Substring(12, 1)) * 2;
            digito02 += int.Parse(cpf.Substring(10, 1)) * 3;
            digito02 += int.Parse(cpf.Substring(9, 1)) * 4;
            digito02 += int.Parse(cpf.Substring(8, 1)) * 5;
            digito02 += int.Parse(cpf.Substring(6, 1)) * 6;
            digito02 += int.Parse(cpf.Substring(5, 1)) * 7;
            digito02 += int.Parse(cpf.Substring(4, 1)) * 8;
            digito02 += int.Parse(cpf.Substring(2, 1)) * 9;
            digito02 += int.Parse(cpf.Substring(1, 1)) * 10;
            digito02 += int.Parse(cpf.Substring(0, 1)) * 11;

            digito02 %= 11;

            if (digito02 < 2)
            {
                digito02 = 0;
            }
            else
            {
                digito02 = 11 - digito02;
            }

            if (cpf.Substring(12, 1) == digito01.ToString()
                && cpf.Substring(13, 1) == digito02.ToString())
            {
                resp = true;
            }

            return resp;
        }
    }
}
