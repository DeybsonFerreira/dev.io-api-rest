using app.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Business.Validation.Create
{
    internal static class CreateLoginValidation
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
        public static List<string> ValidRequiredDataToCreate(User modelDb)
        {
            List<string> listErros = new();

            if (modelDb == null)
                listErros.Add("Usuário não foi encontrado");

            return listErros;
        }
        /// <summary>
        /// Validação para dados existentes 
        /// </summary>
        /// <returns></returns>
        public static List<string> ValidateExistent(IQueryable<Login> query, Login modelToCreate)
        {
            List<string> listErros = new();

            query = query.Where(c => c.Username == modelToCreate.Username);

            if (query.Any())
                listErros.Add("Nome de usuário já existente, tente outro");

            return listErros;
        }
    }
}
