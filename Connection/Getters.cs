using ChemistrySharp.Classes;
using ChemistrySharp.Connection.Interfaces;
using ChemistrySharp.Helpers;
using ChemistrySharp.URL;
using ChemistrySharp.URL.Path;
using Newtonsoft.Json.Linq;

namespace ChemistrySharp.Connection
{
	public class Getters : IGetters
	{
		private readonly IRequest _request = new Requester();

		public async Task<JObject> Get(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
			Operations? operation = null, Output output = Output.JSON, string? extra = null)
		{
			HttpResponseMessage response;
			string[] values;

			if (@namespace is Namespaces.formula || @namespace is Namespaces.xref)
			{
				values = RequestURL.Create(identifier, domain, @namespace, operation, Output.JSON, extra);
				response = await _request.Request(values[0], values[1]);

				return JObject.Parse(await response.Content.ReadAsStringAsync());
			}

			values = RequestURL.Create(identifier, domain, @namespace, operation, output);
			response = await _request.Request(values[0], values[1]);

			return JObject.Parse(await response.Content.ReadAsStringAsync());
		}

		public async Task<JObject> GetAssay(object identifier, Namespaces @namespace = Namespaces.aid)
		{
			JObject content = await GetJSON(identifier, @namespace, Domain.assay, Operations.description);
			
			if (content is null)
				return null!;
			

			JObject container = content["PC_AssayContainer"]![0]!.ToObject<JObject>()!;

			return container;
		}

		public async Task<JObject> GetCompound(object identifier, Namespaces @namespace = Namespaces.cid)
		{
			JObject content = await GetJSON(identifier, @namespace, operation: Operations.record);

			if (content is null)
				return null!;

			JObject container = content["PC_Compounds"]![0]!.ToObject<JObject>()!;

			return container;

		}

		public async Task<JObject> GetJSON(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound, Operations? operation = null)
		{
			try
			{
				JObject results = await Get(identifier, @namespace, domain, operation, Output.JSON);
				return results;
			}
			// Make exception
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<JObject> GetProperties(object properties, object identifier, Namespaces @namespace = Namespaces.cid)
		{
			string prop = string.Empty;

			if (properties is IEnumerable<string>)
				prop = string.Join(",", properties);
			else
				prop = (properties as string)!;

			JObject content = await Get(identifier, @namespace, Domain.compound, Operations.property, Output.JSON, prop);
			JObject result = content["PropertyTable"]!["Properties"]!.ToObject<JObject>()!;

			return result;

		}

		public async Task<JObject> GetSDF(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound, Operations? operation = null)
		{
			try
			{
				JObject results = await Get(identifier, @namespace, domain, operation, Output.SDF);
				return results;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<JObject> GetSubstance(object identifier, Namespaces @namespace = Namespaces.sid)
		{
			JObject content = await GetJSON(identifier, @namespace, Domain.substance);

			if (content is null)
				return null!;

			JObject container = content["PC_Substances"]![0]!.ToObject<JObject>()!;

			return container;

		}

		public async Task<JObject> GetSubstanceIdentifiers(object identifier, Namespaces @namespace = Namespaces.sid, Domain domain = Domain.compound)
		{
			JObject content = await GetJSON(identifier, @namespace, domain, Operations.sids);

			if (content is null)
				return null!;
			if (content.ContainsKey("InformationList"))
				return content["InformationList"]!["Information"]!.ToObject<JObject>()!;

			return content["IdentifierList"]!["SID"]!.ToObject<JObject>()!;
		}

		public async Task<JObject> GetAtomIdentifiers(object identifier, Namespaces @namespace = Namespaces.aid, Domain domain = Domain.compound, Operations? operation = null)
		{
			JObject content = await GetJSON(identifier, @namespace, domain, Operations.aids);

			if (content is null)
				return null!;
			if (content.ContainsKey("InformationList"))
				return content["InformationList"]!["Information"]!.ToObject<JObject>()!;

			return content["IdentifierList"]!["AID"]!.ToObject<JObject>()!;
		}

		public async Task<JObject> GetCompoundIdentifiers(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound, Operations? operation = null)
		{
			JObject content = await GetJSON(identifier, @namespace, domain, Operations.cids);

			if (content is null)
				return null!;
			if (content.ContainsKey("InformationList"))
				return content["InformationList"]!["Information"]!.ToObject<JObject>()!;

			return content["IdentifierList"]!["CID"]!.ToObject<JObject>()!;
		}

		public async Task<JObject> GetSynonyms(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound)
		{
			JObject content = await GetJSON(identifier, @namespace, domain, Operations.synonyms);
			JObject result = content["InformationList"]!["Information"]!.ToObject<JObject>()!;

			return result;
		}
	}
}
