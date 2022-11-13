using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Classes
{
	public class Assay
	{
		private JObject _record;

		public int AID 
		{
			get
			{
				return _record["assay"]!["descr"]!["aid"]!["id"]!.ToObject<int>()!;
			}
		}

		public string Name
		{
			get
			{
				return _record["assay"]!["descr"]!["name"]!.ToString();
			}
		}

		public string Description
		{
			get
			{
				return _record["assay"]!["descr"]!["description"]!.ToString();
			}
		}

		public int ProjectCategory 
		{
			get
			{
				if (!_record["assay"]!["descr"]!.ToObject<JObject>()!.ContainsKey("project_category"))
				{
					return 0;
				}

				return _record["assay"]!["descr"]!["project_category"]!.ToObject<int>()!;
			}
		}

		public IEnumerable<string> Comments
		{
			get
			{
				if (!_record["assay"]!["descr"]!.ToObject<JObject>()!.ContainsKey("comment"))
				{
					return Array.Empty<string>();
				}

				return _record["assay"]!["descr"]!["comment"]!.ToObject<IEnumerable<string>>()!;
			}
		}

		public JObject Results
		{
			get
			{
				return _record["assay"]!["descr"]!["results"]!.ToObject<JObject>()!;
			}
		}

		public int Revision
		{
			get
			{
				return _record["assay"]!["descr"]!["revision"]!.ToObject<int>()!;
			}
		}

		public int AssayIdentifierVersion
		{
			get
			{
				return _record["assay"]!["descr"]!["aid"]!["version"]!.ToObject<int>()!;
			}
		}

		public Assay(JObject record)
		{
			_record = record;
		}

		public override string ToString()
		{
			return new string($"Assay({AID})");	
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object? obj)
		{
			return obj is Assay other &&
				other.AID == AID &&
				other.Results == Results &&
				other.Description == Description &&
				other.Revision == Revision &&
				other.AssayIdentifierVersion == AssayIdentifierVersion &&
				other.Comments == Comments &&
				other.Name == Name &&
				other.ProjectCategory == ProjectCategory;
		}
	}
}
