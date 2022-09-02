using app.Business.Models;
using System;
using System.Collections.Generic;

namespace app.Business.Validation.Create
{
    internal static class UpdateLoginValidation
    {
        public static List<string> ValidParams(Guid id, Login model)
        {
            List<string> listErros = new();
            if (id == Guid.Empty)
                listErros.Add("param {id} deve ser informado");
            if (model.UserId == Guid.Empty)
                listErros.Add("param {UserId} deve ser informado");
            if (model.Id != id)
                listErros.Add("param {id} é difente do objeto.Id");

            return listErros;
        }

        /// <summary>
        /// Dados obrigatórios para criação
        /// </summary>
        public static List<string> ValidRequiredDataToUpdate(Login loginDb, User userDb)
        {
            List<string> listErros = new();

            if (loginDb == null)
                listErros.Add("Login não encontrado");

            if (userDb == null)
                listErros.Add("Usuário não foi encontrado");

            return listErros;
        }
    }
}
