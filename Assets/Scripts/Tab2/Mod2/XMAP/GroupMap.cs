using System.Collections.Generic;

namespace Mod2.XMAP
{
    public struct GroupMap2
	{
		public GroupMap2(string nameGroup, List<int> idMaps)
		{
			NameGroup = nameGroup;
			IdMaps = idMaps;
		}

		public string NameGroup;

		public List<int> IdMaps;
	}
}
