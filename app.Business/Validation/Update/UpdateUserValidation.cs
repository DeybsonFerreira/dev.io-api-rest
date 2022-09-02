using app.Business.Models;
using System;
using System.Collections.Generic;

namespace app.Business.Validation.Create
{
    internal class UpdateUserValidation
    {
        public static List<string> ValidParams(Guid id, User model)
        {
            List<string> listErros = new();

            if (id == Guid.Empty)
                listErros.Add("param {id} deve ser informado");
            if (model.Id != id)
                listErros.Add("param {id} é difente do objeto.Id");
            return listErros;
        }

        /// <summary>
        /// Dados obrigatórios para criação
        /// </summary>
        public static List<string> ValidRequiredDataToUpdate(User userDb)
        {
            List<string> listErros = new();
            if (userDb == null)
                listErros.Add("Usuário não encontrado");

            return listErros;
        }
    }
}
