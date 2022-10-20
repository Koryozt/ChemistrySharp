using ChemistrySharp.URL.Path;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.URL
{
	public class RequestURL
	{
		private static readonly string _baseUrl = "https://pubchem.ncbi.nlm.nih.gov/rest/pug/";
		private static StringBuilder? _sb;

		// https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/cid/2244/property/MolecularFormula/JSON

		public static string Create(object id, Domain domain, Namespaces namespaces, Operations operation, Output output)
		{
			_sb = new StringBuilder(_baseUrl);
			string strId = CheckType(id);
		}

		public static string Create(object id, Namespaces namespaces, Operations operation, Output output, StructureSearch structureSearch)
		{
			_sb = new StringBuilder(_baseUrl);
		}
		public static string CreateURL(object id, Namespaces namespaces, Operations operation, Output output, FastSearch fastSearch)
		{
			_sb = new StringBuilder(_baseUrl);
		}

		public static string CreateURL(object id, Domain domain, Namespaces namespaces, Operations operation, Output output, Xref xref)
		{
			_sb = new StringBuilder(_baseUrl);
		}

		public static string CreateURL(object id, Namespaces namespaces, Operations operation, Output output, string sourceName)
		{
			_sb = new StringBuilder(_baseUrl);
		}

		public static string CreateURL(object id, Namespaces namespaces, Operations operation, Output output, AssayType assayType)
		{
			_sb = new StringBuilder(_baseUrl);
		}

		public static string CreateURL(object id, Namespaces namespaces, Operations operation, Output output, AssayTarget target)
		{
			_sb = new StringBuilder(_baseUrl);
		}

		public static string CreateURL(object id, Domain domain, Namespaces namespaces, Operations operation, Output output, params string[] identifiers)
		{
			_sb = new StringBuilder(_baseUrl);
		}
	}
}
