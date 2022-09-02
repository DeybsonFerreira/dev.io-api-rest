using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using app.Business.Extensions;

namespace app.Business.Models
{
    [Table("Login")]
    public class Login : CustomIdExtension
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50,ErrorMessage ="Campo no máx 50 caracteres")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public Guid UserId { get; set; }
    }
}