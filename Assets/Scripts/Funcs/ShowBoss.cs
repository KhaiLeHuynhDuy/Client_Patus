using System;

namespace Mod
{
	public class ShowBoss
	{
		public ShowBoss(string text)
		{
			text = text.Replace(text[..5], "|");
			text = text.Replace(" vừa xuất hiện tại", "|");
			text = text.Replace(" khu vực", "|");
			string[] array = text.Split(new char[] { '|' });
			nameBoss = array[1].Trim();
			mapName = array[2].Trim();
			mapID = MainMod.GI().GetMapID(mapName);
			time = DateTime.Now.Ticks;
		}

		public void PaintBoss(mGraphics g, int x, int y)
		{
			long elapsedTicks = DateTime.Now.Ticks - time;
			long elapsedSeconds = elapsedTicks / TimeSpan.TicksPerSecond;
			string timeFormatted;

			if (elapsedSeconds >= 60)
			{
				long minutes = elapsedSeconds / 60;
				long seconds = elapsedSeconds % 60;
				timeFormatted = string.Format("{0}m {1}s", minutes, seconds);
			}
			else
			{
				timeFormatted = elapsedSeconds.ToString() + "s";
			}

			mFont mFont = mFont.tahoma_7_yellow;

			if (TileMap.mapName.Trim().ToLower() == mapName.Trim().ToLower())
			{
				y += 2;
				mFont = mFont.tahoma_7_yellow;

				for (int i = 0; i < GameScr.vCharInMap.size(); i++)
				{
					Char @char = (Char)GameScr.vCharInMap.elementAt(i);
					if (@char.charID < 0 && @char.cName == nameBoss)
					{
						mFont = mFont.tahoma_7_red;
						break;
					}
				}
			}

			string str = nameBoss + " - " + mapName + " - " + timeFormatted;
			stringLength = mFont.getWidthExactOf(str);
			g.FillRect(x - stringLength - 3, y + 3, stringLength + 2, 10, 0, 0.2f);
			mFont.drawStringBorder(g, str, x, y, mFont.RIGHT, mFont.tahoma_7_grey);
		}

		public void PaintBoss2(mGraphics2 g, int x, int y)
		{
			long elapsedTicks = DateTime.Now.Ticks - time;
			long elapsedSeconds = elapsedTicks / TimeSpan.TicksPerSecond;
			string timeFormatted;

			if (elapsedSeconds >= 60)
			{
				long minutes = elapsedSeconds / 60;
				long seconds = elapsedSeconds % 60;
				timeFormatted = string.Format("{0}m {1}s", minutes, seconds);
			}
			else
			{
				timeFormatted = elapsedSeconds.ToString() + "s";
			}

			mFont2 mFont = mFont2.tahoma_7_yellow;

			if (TileMap.mapName.Trim().ToLower() == mapName.Trim().ToLower())
			{
				y += 2;
				mFont = mFont2.tahoma_7_yellow;

				for (int i = 0; i < GameScr.vCharInMap.size(); i++)
				{
					Char @char = (Char)GameScr.vCharInMap.elementAt(i);
					if (@char.charID < 0 && @char.cName == nameBoss)
					{
						mFont = mFont2.tahoma_7_red;
						break;
					}
				}
			}

			string str = nameBoss + " - " + mapName + " - " + timeFormatted;
			stringLength = mFont.getWidthExactOf(str);
			g.FillRect(x - stringLength - 3, y + 3, stringLength + 2, 10, 0, 0.2f);
			mFont.drawStringBorder(g, str, x, y, mFont2.RIGHT, mFont2.tahoma_7_grey);
		}

		public string nameBoss;

		public string mapName;

		public string playerKill;

		public int mapID;

		public long time;

		public int stringLength;
	}
}
