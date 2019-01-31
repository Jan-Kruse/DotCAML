using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SP = Microsoft.SharePoint.Client;

namespace CAML.Models.Operations
{
    public interface IFinalizable : IFinalizableToString
    {
         SP.CamlQuery ToCamlQuery();
    }
}
