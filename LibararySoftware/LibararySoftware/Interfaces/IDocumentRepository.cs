using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibararySoftware.Interfaces
{
    internal interface IDocumentRepository
    {
        Document GetDocumentByNumber(string documentNumber);
    }
}
