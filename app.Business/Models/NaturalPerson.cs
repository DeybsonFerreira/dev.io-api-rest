using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Business.Models
{
    [Table("NaturalPerson")]
    public class NaturalPerson : Person
    {
        [StringLength(14, ErrorMessage = "Maximum {2} characters exceeded")]
        public override string DocumentNumber { get; set; }
    }
}
