using app.Business.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Business.Models
{
    [Table("User")]
    public class User : CustomIdExtension
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Campo no máx 50 caracteres")]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
