using app.Business.Models;
using System;
using System.Collections.Generic;

namespace app.Business.Interfaces.ReadServices
{
    public interface IReadLegalPerson
    {
        IEnumerable<LegalPerson> Handle(Guid? legalPersonId = null, string documentNumber = null);
    }
}
