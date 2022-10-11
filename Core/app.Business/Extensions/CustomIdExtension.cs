using System;
using System.ComponentModel.DataAnnotations;

namespace app.Business.Extensions
{
    public abstract class CustomIdExtension
    {
        [Key]
        public Guid Id{ get; set; }
    }
}
