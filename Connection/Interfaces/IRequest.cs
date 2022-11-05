using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Connection.Interfaces
{
    public interface IRequest
    {
        Task<HttpResponseMessage> Request(string url, string data);
    }
}
