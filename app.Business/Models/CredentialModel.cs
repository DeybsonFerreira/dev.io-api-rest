using System.ComponentModel.DataAnnotations;

namespace app.Business.Models
{
    public class CredentialModel 
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Username { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string Password { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        public string GrantType { get; set; }
    }
}