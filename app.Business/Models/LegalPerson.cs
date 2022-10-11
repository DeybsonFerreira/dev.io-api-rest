using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app.Business.Models
{
    [Table("LegalPerson")]
    public class LegalPerson: Person
    {
        [StringLength(18, ErrorMessage = "Maximum {2} characters exceeded")]
        public override string DocumentNumber { get; set; }
    }
}
