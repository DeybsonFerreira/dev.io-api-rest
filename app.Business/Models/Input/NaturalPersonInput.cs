using app.Business.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace app.Business.Models.Input
{
    public class NaturalPersonInput : PersonDto
    {
        [StringLength(14, ErrorMessage = "Maximum {2} characters exceeded")]
        public override string DocumentNumber { get; set; }
    }
}
