using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemistrySharp.Miscellaneous
{
	public enum CompoundIdentifierType
	{
		DEPOSITED = 0,
		STANDARDIZED,
		COMPONENT,
		NEUTRALIZED,
		MIXTURE,
		TAUTOMER,
		IONIZED,
		UNKNOWN = 255
	}

	public enum BondType
	{
		SINGLE = 1,
		DOUBLE,
		TRIPLE,
		QUADRUPLE,
		DATIVE,
		COMPLEX,
		IONIC,
		UNKNOWN = 255
	}

	public enum CoordinateType
	{
		TWO_D = 1,
		THREE_D,
		SUBMITTED,
		EXPERIMENTAL,
		COMPUTED,
		STANDARDIZED,
		AUGMENTED,
		ALIGNED,
		COMPACT,
		UNITS_ANGSTROMS,
		UNITS_NANOMETERS,
		UNITS_PIXEL,
		UNITS_POINTS,
		UNITS_STDBONDS,
		UNITS_UNKWNOWN = 255
	}
}
