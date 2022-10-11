using System;
using System.ComponentModel.DataAnnotations;

namespace app.Api.Models
{
    public class LoginModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public Guid UserId { get; set; }
    }
}