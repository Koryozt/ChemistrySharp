using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Connection
{
	public interface IRequest
	{
		Task<HttpResponseMessage> MakeRequest();
	}
}
