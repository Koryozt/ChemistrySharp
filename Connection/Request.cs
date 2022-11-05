using ChemistrySharp.Connection.Interfaces;
using ChemistrySharp.URL;
using ChemistrySharp.URL.Path;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChemistrySharp.Connection
{
	public class Requester : IRequest
	{
		private readonly HttpClient _client = new HttpClient();
		private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
		{
			{ "XML", "application/xml" },
			{ "JSON", "application/json" },
			{ "JSONP", "application/javascript" },
			{ "ASNB", "application/ber-encoded" },
			{ "SDF", "chemical/x-mdl-sdfile" },
			{ "CSV", "text/csv" },
			{ "PNG", "image/png" },
			{ "TXT", "text/plain" }
		};

		public async Task<HttpResponseMessage> Request(string url, string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				string acceptValue = CheckOutput(url) ?? "application/json";

				_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(acceptValue));

				try
				{
					return await _client.GetAsync(url);
				}
				catch (HttpRequestException)
				{
					throw;
				}
			}

			Dictionary<string, string> values = new Dictionary<string, string>() { ["data"] = data };
			FormUrlEncodedContent content = new FormUrlEncodedContent(values);

			_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data")); 

			try
			{
				return await _client.PostAsync(url, content);
			}
			catch (HttpRequestException)
			{
				throw;
			}

		}

		private string? CheckOutput(string url) => _headers.FirstOrDefault(x => url.Contains(x.Key)).Value;

	}
}
