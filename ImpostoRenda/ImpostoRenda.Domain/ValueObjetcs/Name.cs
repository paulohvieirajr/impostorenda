using Flunt.Validations;
using ImpostoRenda.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpostoRenda.Dominio.ValueObjetcs
{
    public class Name : ValueObject
    {
        public Name(string name)
        {
            FullName = name;

            if (string.IsNullOrEmpty(FullName))
            {
                AddNotification("Name.FullName", "Por favor, informe um nome com pelo menos 3 caracteres");
                return;
            }

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FullName, 3, "Name.FullName", "Por favor, informe um nome com pelo menos 3 caracteres")
                .HasMaxLen(FullName, 50, "Name.FullName", "Por favor, informe um nome com no máximo 50 caracteres"));
        }

        public string FullName { get; private set; }

        private bool Validar()
        {
            return string.IsNullOrEmpty(FullName);
        }
    }
}
