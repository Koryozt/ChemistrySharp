using ChemistrySharp.Classes;
using ChemistrySharp.URL.Path;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ChemistrySharp.Connection.Interfaces
{
	public interface IGetters
	{
		Task<JObject> Get(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
			Operations? operation = null, Output output = Output.JSON, string? extra = null);

		Task<JObject> GetJSON(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
		Operations? operation = null);

		Task<JObject> GetSDF(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
		Operations? operation = null);

		Task<JObject> GetProperties(object properties, object identifier, Namespaces @namespace = Namespaces.cid);

		Task<JObject> GetSynonyms(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound);

		Task<JObject> GetCompoundIdentifiers(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
		Operations? operation = null);

		Task<JObject> GetSubstanceIdentifiers(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound);

		Task<JObject> GetAtomIdentifiers(object identifier, Namespaces @namespace = Namespaces.cid, Domain domain = Domain.compound,
		Operations? operation = null);

		Task<JObject> GetCompound(object identifier, Namespaces @namespace = Namespaces.sid);

		Task<JObject> GetSubstance(object identifier, Namespaces @namespace = Namespaces.sid);

		Task<JObject> GetAssay(object identifier, Namespaces @namespace = Namespaces.aid);
	}
}
