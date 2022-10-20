using ChemistrySharp.URL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Connection
{
	sealed class Request : IRequest
	{
		public Task<HttpResponseMessage> MakeRequest()
		{
			string url = RequestURL.Create()
			throw new NotImplementedException();
		}
	}
}
