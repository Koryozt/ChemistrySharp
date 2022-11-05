using ChemistrySharp.Miscellaneous;

namespace ChemistrySharp.Classes
{
	public class Bond : IDisposable
	{
		private bool _isDisposed;
		public int FirstAtomID { get; set; }
		public int SecondAtomID { get; set; }
		public BondType? Order { get; set; }
		public int? Style { get; set; } = 0;

		public Bond(int firstAtomID, int secondAtomID, BondType order = BondType.SINGLE, int? style = null)
		{
			FirstAtomID = firstAtomID;
			SecondAtomID = secondAtomID;
			Order = order;
			Style = style;

		}

		public Dictionary<string, string> ToDictionary()
		{
			Dictionary<string, string> data = new Dictionary<string, string>
			{
				["FirstAtomID"] = Convert.ToString(FirstAtomID),
				["SecondAtomID"] = Convert.ToString(SecondAtomID),
				["Order"] = Convert.ToString(Order)!
			};

			if (Style is not null)
			{
				data["Style"] = Convert.ToString(Style)!;
			}

			return data;
		}

		public override string ToString() => $"Bond({FirstAtomID}, {SecondAtomID}, {Order})";

		public override bool Equals(object? obj)
		{
			return obj is Bond bond &&
				FirstAtomID == ((Bond)obj).FirstAtomID &&
				SecondAtomID == ((Bond)obj).SecondAtomID &&
				Style == ((Bond)obj).Style &&
				Order == ((Bond)obj).Order;
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
				FirstAtomID = 0;
				SecondAtomID = 0;
				Style = 0;
				Order = null;
			}

			_isDisposed = true;
		}

		~Bond()
		{
			Dispose(false);
		}
	}
}
