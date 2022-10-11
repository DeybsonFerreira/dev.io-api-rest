using app.Business.Models;
using System;
using System.Collections.Generic;

namespace app.Business.Interfaces.ReadServices
{
    public interface IReadNaturalPerson
    {
        IEnumerable<NaturalPerson> Handle();

        IEnumerable<NaturalPerson> Handle(Guid? naturalPersonId = null, string documentNumber = null);
    }
}
