using System;

namespace app.Business.Models.Output
{
    public abstract class PersonOutput
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
    }
}
