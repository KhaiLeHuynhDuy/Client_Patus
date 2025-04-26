namespace Mod2.XMAP
{
    public struct MapNext2
	{
		public MapNext2(int mapID, TypeMapNext2 type, int[] info)
		{
			MapID = mapID;
			Type = type;
			Info = info;
		}

		public int MapID;

		public TypeMapNext2 Type;

		public int[] Info;
	}
}
