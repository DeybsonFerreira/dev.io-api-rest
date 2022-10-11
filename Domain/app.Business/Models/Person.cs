using app.Business.Extensions;
using System.ComponentModel.DataAnnotations;

namespace app.Business.Models
{
    public abstract class Person : CustomIdExtension
    {
        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Maximum {2} characters exceeded")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Maximum {2} characters exceeded")]
        public string LastName { get; set; }
        public abstract string DocumentNumber { get; set; }

    }
}
