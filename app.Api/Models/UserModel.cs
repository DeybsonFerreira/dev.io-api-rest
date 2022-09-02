using System;
using System.ComponentModel.DataAnnotations;

namespace app.Api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}