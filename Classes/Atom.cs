using ChemistrySharp.Helpers;
using ChemistrySharp.Miscellaneous;
using System.Runtime.InteropServices;

namespace ChemistrySharp.Classes
{
	public class Atom : IDisposable
	{
		private bool _isDisposed;
		public int AtomID { get; set; }
		public int Number { get; set; }
		public int Charge { get; set; }
		public float? X { get; set; }
		public float? Y { get; set; }
		public float? Z { get; set; }
		public Element Element { get => ChemistryHelper.GetElement(Number); }
		public string CoordinateType { get => Z is not null ? "3D" : "2D"; }

		public Atom(int atomId, int number, float? x = null, float? y = null, float? z = null, int charge = 0)
		{
			AtomID = atomId;
			Number = number;
			X = x;
			Y = y;
			Z = z;
			Charge = charge;
		}

		public Dictionary<string, string> ToDictionary()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				["AID"] = Convert.ToString(AtomID),
				["Number"] = Convert.ToString(Number),
				["Element"] = Convert.ToString(Element)!
			};

			foreach(string coord in new string[] { "X", "Y", "Z"})
			{
				if (ObjectHelper.GetAttr(this, coord) is not null)
				{
					data[coord] = (ObjectHelper.GetAttr(this, coord) as string)!;
				}
			}

			if (Charge is not 0)
				data["Charge"] = Convert.ToString(Charge);

			return data;
		}

		public void SetCoordinates(float x, float y, float? z = null)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString() => new ($"Atom({AtomID},{Element})");
		

		public override bool Equals(object? obj)
		{
			return (obj is Atom) &&
				AtomID == ((Atom)obj).AtomID &&
				Number == ((Atom)obj).Number &&
				X == ((Atom)obj).X &&
				Y == ((Atom)obj).Y &&
				Z == ((Atom)obj).Z &&
				Charge == ((Atom)obj).Charge &&
				Element == ((Atom)obj).Element;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		// The bulk of the clean-up code is implemented in Dispose(bool)
		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed) return;

			if (disposing)
			{
				AtomID = 0;
				Number = 0;
				X = 0;
				Y = 0;
				Z = 0;
				Charge = 0;
			}

			_isDisposed = true;
		}

		~Atom()
		{
			Dispose(false);
		}
	}
}
