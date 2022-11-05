using ChemistrySharp.Helpers;
using ChemistrySharp.URL.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChemistrySharp.URL
{
	public class RequestURL
	{
		private static readonly string _baseUrl = "https://pubchem.ncbi.nlm.nih.gov/rest/pug/";
		private static readonly IEnumerable<Namespaces> @namespaces = new Namespaces[] {
				Namespaces.listkey,
				Namespaces.formula,
				Namespaces.sourceid,
				Namespaces.xref,
				Namespaces.cid };


		// https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/cid/2244/property/MolecularFormula/JSON

		public static string[] Create(object id, Domain domain = Domain.compound, Namespaces @namespace = Namespaces.cid, Operations? operation = null, Output output = Output.JSON, string? extra = null)
		{
			StringBuilder sb = new StringBuilder(_baseUrl);
			
			if (id is null)
				throw new ArgumentNullException(nameof(id));

			string identifier = ObjectHelper.CheckType(id), 
				urlid = string.Empty, 
				data = string.Empty;
			
			if (@namespace is Namespaces.sourceid)
			{
				identifier = identifier.Replace('/', '.');
			}

			if (@namespaces.Contains(@namespace) || domain is Domain.sources)
			{
				urlid = HttpUtility.UrlEncode(identifier);
			}
			else
			{
				data = HttpUtility.UrlEncode(string.Join(",", @namespace, identifier));
			}

			if (operation is Operations.property)
			{
				extra = $"{operation}/{extra}";
			}

			IEnumerable<string> components = IEnumerableHelper.RemoveNull(
				new string[] 
				{
					Convert.ToString(domain)!,
					Convert.ToString(@namespace)!,
					urlid,
					Convert.ToString(operation)!,
					extra!,
					Convert.ToString(output)!
				});

			sb.AppendJoin('/', components);

			return new string[]
			{
				sb.ToString(),
				data
			};
		}
	}
}
