using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ChemistrySharp.Helpers
{
	public class IEnumerableHelper
	{
		public static IEnumerable<string> RemoveNull(IEnumerable<string> values)
		{
			values = values.Where(x => x is not null);
			return values;
		}

		public static Dictionary<int, int> Join(int[] key, int[] val)
		{
			if (key.Length != val.Length)
				throw new Exception("Error parsing elements");

			Dictionary<int, int> data = new Dictionary<int, int>();
			int i = 0;

			foreach(int k in key)
			{
				data[k] = val[i];
				i++;
			}

			return data;
		}

		public static Dictionary<int, float[]> JoinLongest(int[] keys, int[] coordsIds, float[] xCoords, float[] yCoords, float?[] zCoords = null!)
		{
			if ((coordsIds.Length != xCoords.Length &&
				coordsIds.Length != yCoords.Length &&
				coordsIds.Length != keys.Length) || (zCoords is not null && zCoords.Length != coordsIds.Length))
			{
				throw new Exception("Error parsing elements");
			}

			Dictionary<int, float[]> data = new Dictionary<int, float[]>();
			int i = 0;

			foreach (int k in keys)
			{
				if (zCoords is null)
					data[k] = new float[] { xCoords[i], yCoords[i] };
				else
					data[k] = new float[] { xCoords[i], yCoords[i], (float)zCoords[i]! };
			}

			return data;
		}
	}
}
