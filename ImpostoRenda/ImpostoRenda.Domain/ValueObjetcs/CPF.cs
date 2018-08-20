using Flunt.Validations;
using ImpostoRenda.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.ValueObjetcs
{
    public class CPF : ValueObject
    {
        public CPF(string cpf)
        {
            Document = cpf;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(ValidarCPF(), "CPF.Document", "Por favor, informe um CPF válido"));
        }

        public string Document { get; private set; }

        private bool ValidarCPF()
        {
            if (string.IsNullOrEmpty(Document))
                return false;

            string strValor = Document.Replace(".", "");
            strValor = strValor.Replace("-", "");
            strValor = strValor.Replace("_", "");

            //Verifica se o campo contém 
            if (strValor.Length != 11)
                return false;

            bool bolIgual = true;

            for (int i = 1; i < 11 && bolIgual; i++)
                if (strValor[i] != strValor[0])
                    bolIgual = false;

            if (bolIgual || strValor == "12345678909")
                return false;

            int[] intNumeros = new int[11];

            for (int i = 0; i < 11; i++)
                intNumeros[i] = int.Parse(
                  strValor[i].ToString());

            int intSoma = 0;

            for (int i = 0; i < 9; i++)
                intSoma += (10 - i) * intNumeros[i];

            int intResultado = intSoma % 11;

            if (intResultado == 1 || intResultado == 0)
            {
                if (intNumeros[9] != 0)
                    return false;
            }
            else if (intNumeros[9] != 11 - intResultado)
                return false;

            intSoma = 0;
            for (int i = 0; i < 10; i++)
                intSoma += (11 - i) * intNumeros[i];

            intResultado = intSoma % 11;

            if (intResultado == 1 || intResultado == 0)
            {
                if (intNumeros[10] != 0)
                    return false;
            }
            else
                if (intNumeros[10] != 11 - intResultado)
                return false;

            return true;
        }
    }
}
