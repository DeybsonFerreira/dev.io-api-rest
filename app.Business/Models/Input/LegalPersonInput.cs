using app.Business.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace app.Business.Models.Input
{
    public class LegalPersonInput : PersonDto
    {
        [StringLength(16, ErrorMessage = "Maximum {2} characters exceeded")]
        public override string DocumentNumber { get; set; }
    }
}
