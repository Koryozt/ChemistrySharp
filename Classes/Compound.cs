using ChemistrySharp.Connection;
using ChemistrySharp.Helpers;
using ChemistrySharp.Miscellaneous;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Classes
{
	public class Compound
	{
		private static Getters _getter = new();
		private JObject? _record;
		private Dictionary<int, Atom> _atoms;
		private Dictionary<int[], Bond> _bonds;

		public int CompoundID { get; set; }
		public Dictionary<int, Atom> Atoms
		{
			get => _atoms ?? (_atoms = new Dictionary<int, Atom>());
		}

		public Dictionary<int[], Bond> Bonds
		{
			get => _bonds ?? (_bonds = new Dictionary<int[], Bond>());
		}

		public IEnumerable<Element> Elements 
		{
			get => _atoms.Values.Select(x => x.Element);
		}

		public JObject Record
		{
			get => _record!;

			set
			{
				_record = value;
				SetupAtoms();
				SetupBonds();
			}
		}

		public Compound(JObject record)
		{
			_atoms = new Dictionary<int, Atom>();
			_bonds = new Dictionary<int[], Bond>();
			Record = record;
			CompoundID = Record["id"]!["id"]!["cid"]!.ToObject<int>();
		}

		public static async Task<Compound> FromCompoundIdentifier(long cid)
		{
			JObject record = await _getter.GetCompound(cid);
			return new Compound(record);
		}




		private void SetupAtoms()
		{
			_atoms = new Dictionary<int, Atom>();

			int[] aids = Record["atoms"]!["aid"]!.ToObject<int[]>()!;
			int[] elements = Record["atoms"]!["element"]!.ToObject<int[]>()!;

			CreateAtoms(aids, elements);

			SetAtomsCoordinates(aids);

			SetAtomsCharge();
		}

		private void SetupBonds()
		{
			_bonds = new Dictionary<int[], Bond>();

			if (!Record.ContainsKey("bonds"))
				return;

			int[] firstAids = Record["bonds"]!["aid1"]!.ToObject<int[]>()!;
			int[] secondAids = Record["bonds"]!["aid2"]!.ToObject<int[]>()!;
			int[] orders = Record["bonds"]!["order"]!.ToObject<int[]>()!;

			CreateBonds(firstAids, secondAids, orders);

			//SetBondCoordinates();

		}

		#region SetupMethods
		private void CreateAtoms(int[] aids, int[] elements)
		{
			Dictionary<int, int> data = IEnumerableHelper.Join(aids, elements);

			foreach (KeyValuePair<int, int> d in data)
			{
				Atom atom = new Atom(d.Key, d.Value);
				
				_atoms[d.Key] = atom;
			}
		}
	
		private void SetAtomsCoordinates(int[] aids)
		{
			if (Record.ContainsKey("coords"))
			{
				int[] coordsIds = Record["coords"]![0]!["aid"]!.ToObject<int[]>()!;
				float[] xCoords = Record["coords"]![0]!["conformers"]![0]!["x"]!.ToObject<float[]>()!;
				float[] yCoords = Record["coords"]![0]!["conformers"]![0]!["y"]!.ToObject<float[]>()!;
				float?[] zCoords = null!;

				if ((Record["coords"]![0]!["conformers"]![0]!.ToObject<JObject>()!).ContainsKey("z"))
				{
					zCoords = Record["coords"]![0]!["conformers"]![0]!["z"]!.ToObject<float?[]>()!;
				}

				Dictionary<int, float[]> dataCoords = IEnumerableHelper.JoinLongest(aids, coordsIds, xCoords, yCoords, zCoords);

				if (zCoords is null)
				{
					foreach (KeyValuePair<int, float[]> dc in dataCoords)
					{
						float x = dc.Value[0], y = dc.Value[1];

						_atoms[dc.Key].SetCoordinates(x, y);
					}
				}
				else
				{
					foreach (KeyValuePair<int, float[]> dc in dataCoords)
					{
						float x = dc.Value[0], y = dc.Value[1], z = dc.Value[2];

						_atoms[dc.Key].SetCoordinates(x, y, z);
					}
				}

			}
		}

		private void SetAtomsCharge()
		{
			if (Record.ContainsKey("charge"))
				_atoms.Values.First().Charge = Record["charge"]!.ToObject<int>()!;
		}

		private void CreateBonds(int[] firstAids, int[] secondAids, int[] orders)
		{
			if ((firstAids.Length != secondAids.Length) && (firstAids.Length != orders.Length))
				throw new Exception("Error parsing elements");

			for (int i = 0; i < firstAids.Length; i++)
			{
				int[] keys = new int[] { firstAids[i], secondAids[i] };

				Bond bond = new Bond(keys[0], keys[1], (BondType)orders[i]);
				
				_bonds[keys] = bond;
				
			}
		}

		//private void SetBondCoordinates()
		//{
		//	if (Record.ContainsKey("coords") && (Record["coords"]![0]!["conformers"]![0]!.ToObject<JObject>()!).ContainsKey("style"))
		//	{
		//		int[] firstAids = Record["coords"]![0]!["conformers"]![0]!["style"]!["aid1"]!.ToObject<int[]>()!;
		//		int[] secondAids = Record["coords"]![0]!["conformers"]![0]!["style"]!["aid2"]!.ToObject<int[]>()!;
		//		int[] styles = firstAids = Record["coords"]![0]!["conformers"]![0]!["style"]!["annotation"]!.ToObject<int[]>()!;

		//		for (int i = 0; i < styles.Length; i++)
		//		{
		//			int[] keys = new int[] { firstAids[i], secondAids[i] };
		//			_bonds[keys].Style = styles[i];
		//		}
		//	}
		//}
		#endregion

		public override string ToString()
		{
			return new string($"Compound{CompoundID}");
		}

		public override bool Equals(object? obj)
		{
			return obj is Compound compound &&
				compound.CompoundID == CompoundID &&
				compound.Record == Record;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
