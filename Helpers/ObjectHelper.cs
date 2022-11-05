using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChemistrySharp.Helpers
{
	public static class ObjectHelper
	{
		public static string CheckType(this object obj)
		{
			if (obj is null)
				return string.Empty;

			if (obj.GetType() == typeof(int))
				return Convert.ToString(obj)!;

			if (obj.GetType() == typeof(IEnumerable<object>))
				return string.Join(",", obj);

			return HttpUtility.UrlEncode(Convert.ToString(obj)!);
		}

		public static object GetAttr(this object obj, string name)
		{
			Type type = obj.GetType();
			BindingFlags flags = BindingFlags.Instance |
									 BindingFlags.Public |
									 BindingFlags.GetProperty;

			return type.InvokeMember(name, flags, Type.DefaultBinder, obj, null)!;
		}
	}
}
