using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemistrySharp.Connection;
using ChemistrySharp.Miscellaneous;
using Newtonsoft.Json.Linq;

namespace ChemistrySharp.Classes
{
	public class Substance
	{
        private JObject _record;
        private readonly Getters _get = new Getters();

        public int SID
        {
            get
            {
                return _record["sid"]!["id"]!.ToObject<int>()!;
            }
        }

        public IEnumerable<string> Synonyms
        {
            get
            {
                if (!_record.ContainsKey("synonyms"))
                    return Array.Empty<string>();

                return _record["synonyms"]!.ToObject<IEnumerable<string>>()!;
            }
        }

        public string SourceName
        {
            get
            {
                return _record["source"]!["db"]!["name"]!.ToString()!;
            }
        }

        public string SourceID
        {
            get
            {
                return _record["source"]!["db"]!["source_id"]!["str"]!.ToString()!;
            }
        }

        public Compound DepositedCompound
        {
            get
            {
                JObject compound = _record["compound"]!.ToObject<JObject>()!;
                
                foreach(KeyValuePair<string, JToken?> c in compound)
                {
                    JObject cmp = c.Value!.ToObject<JObject>()!;

                    if (cmp["id"]!["type"]!.ToString()! == Convert.ToString(CompoundIdentifierType.DEPOSITED))
                    {
                        return new Compound(cmp);
                    }
                }

                return null!;
            }
        }

        public Substance(JObject record)
        {
            _record = record;           
        }

        public async Task<Substance> FromSid(int sid)
        {
            JObject result = await _get.GetSubstance(sid);

            return new Substance(result);
        }

        public override string ToString()
        {
            return new string($"Substance({SID})");
        }

        public override bool Equals(object? obj)
        {
            return obj is Substance substance && 
                substance.SID == SID &&
                substance.DepositedCompound == DepositedCompound &&
                substance.SourceID == SourceID &&
                substance.SourceName == SourceName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
