using System;

public class TileMap2
{
	public const int T_EMPTY = 0;

	public const int T_TOP = 2;

	public const int T_LEFT = 4;

	public const int T_RIGHT = 8;

	public const int T_TREE = 16;

	public const int T_WATERFALL = 32;

	public const int T_WATERFLOW = 64;

	public const int T_TOPFALL = 128;

	public const int T_OUTSIDE = 256;

	public const int T_DOWN1PIXEL = 512;

	public const int T_BRIDGE = 1024;

	public const int T_UNDERWATER = 2048;

	public const int T_SOLIDGROUND = 4096;

	public const int T_BOTTOM = 8192;

	public const int T_DIE = 16384;

	public const int T_HEBI = 32768;

	public const int T_BANG = 65536;

	public const int T_JUM8 = 131072;

	public const int T_NT0 = 262144;

	public const int T_NT1 = 524288;

	public const int T_CENTER = 1;

	public static int tmw;

	public static int tmh;

	public static int pxw;

	public static int pxh;

	public static int tileID;

	public static int lastTileID = -1;

	public static int[] maps;

	public static int[] types;

	public static Image2[] imgTile;

	public static Image2 imgTileSmall;

	public static Image2 imgMiniMap;

	public static Image2 imgWaterfall;

	public static Image2 imgTopWaterfall;

	public static Image2 imgWaterflow;

	public static Image2 imgWaterlowN;

	public static Image2 imgWaterlowN2;

	public static Image2 imgWaterF;

	public static Image2 imgLeaf;

	public static sbyte size = 24;

	private static int bx;

	private static int dbx;

	private static int fx;

	private static int dfx;

	public static string[] instruction;

	public static int[] iX;

	public static int[] iY;

	public static int[] iW;

	public static int iCount;

	public static bool isMapDouble = false;

	public static string mapName = string.Empty;

	public static sbyte versionMap = 1;

	public static int mapID;

	public static int lastBgID = -1;

	public static int zoneID;

	public static int bgID;

	public static int bgType;

	public static int lastType = -1;

	public static int typeMap;

	public static sbyte planetID;

	public static sbyte lastPlanetId = -1;

	public static long timeTranMini;

	public static MyVector2 vGo = new MyVector2();

	public static MyVector2 vItemBg = new MyVector2();

	public static MyVector2 vCurrItem = new MyVector2();

	public static string[] mapNames;

	public static sbyte MAP_NORMAL = 0;

	public static Image2 bong;

	public const int TRAIDAT_DOINUI = 0;

	public const int TRAIDAT_RUNG = 1;

	public const int TRAIDAT_DAORUA = 2;

	public const int TRAIDAT_DADO = 3;

	public const int NAMEK_THUNGLUNG = 5;

	public const int NAMEK_DOINUI = 4;

	public const int NAMEK_RUNG = 6;

	public const int NAMEK_DAO = 7;

	public const int SAYAI_DOINUI = 8;

	public const int SAYAI_RUNG = 9;

	public const int SAYAI_CITY = 10;

	public const int SAYAI_NIGHT = 11;

	public const int KAMISAMA = 12;

	public const int TIME_ROOM = 13;

	public const int HELL = 15;

	public const int BEERUS = 16;

	public const int THE_HELL = 19;

	public static Image2[] bgItem = new Image2[8];

	public static MyVector2 vObject = new MyVector2();

	public static int[] offlineId = new int[6] { 21, 22, 23, 39, 40, 41 };

	public static int[] highterId = new int[6] { 21, 22, 23, 24, 25, 26 };

	public static int[] toOfflineId = new int[3] { 0, 7, 14 };

	public static int[][] tileType;

	public static int[][][] tileIndex;

	public static Image2 imgLight = GameCanvas2.loadImage("/bg/light.png");

	public static int sizeMiniMap = 2;

	public static int gssx;

	public static int gssxe;

	public static int gssy;

	public static int gssye;

	public static int countx;

	public static int county;

	private static int[] colorMini = new int[2] { 5257738, 8807192 };

	public static int yWater = 0;

	public static void loadBg()
	{
		bong = GameCanvas2.loadImage("/mainImage/myTexture2dbong.png");
		if (mGraphics2.zoomLevel != 1 && !Main2.isIpod && !Main2.isIphone4)
		{
			imgLight = GameCanvas2.loadImage("/bg/light.png");
		}
	}

	public static bool isVoDaiMap()
	{
		if (mapID == 51 || mapID == 103 || mapID == 112 || mapID == 113 || mapID == 129 || mapID == 130)
		{
			return true;
		}
		return false;
	}

	public static bool isTrainingMap()
	{
		if (mapID == 39 || mapID == 40 || mapID == 41)
		{
			return true;
		}
		return false;
	}

	public static bool mapPhuBang()
	{
		if (GameScr2.phuban_Info != null && mapID == GameScr2.phuban_Info.idmapPaint)
		{
			return true;
		}
		return false;
	}

	public static BgItem2 getBIById(int id)
	{
		for (int i = 0; i < vItemBg.size(); i++)
		{
			BgItem2 bgItem = (BgItem2)vItemBg.elementAt(i);
			if (bgItem.id == id)
			{
				return bgItem;
			}
		}
		return null;
	}

	public static bool isOfflineMap()
	{
		for (int i = 0; i < offlineId.Length; i++)
		{
			if (mapID == offlineId[i])
			{
				return true;
			}
		}
		return false;
	}

	public static bool isHighterMap()
	{
		for (int i = 0; i < offlineId.Length; i++)
		{
			if (mapID == highterId[i])
			{
				return true;
			}
		}
		return false;
	}

	public static bool isToOfflineMap()
	{
		for (int i = 0; i < toOfflineId.Length; i++)
		{
			if (mapID == toOfflineId[i])
			{
				return true;
			}
		}
		return false;
	}

	public static void freeTilemap()
	{
		imgTile = null;
		mSystem2.gcc();
	}

	public static void loadTileCreatChar()
	{
	}

	public static bool isExistMoreOne(int id)
	{
		if (id == 156 || id == 330 || id == 345 || id == 334)
		{
			return false;
		}
		if (mapID == 54 || mapID == 55 || mapID == 56 || mapID == 57 || mapID == 58 || mapID == 59 || mapID == 103)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < vCurrItem.size(); i++)
		{
			BgItem2 bgItem = (BgItem2)vCurrItem.elementAt(i);
			if (bgItem.id == id)
			{
				num++;
			}
		}
		if (num > 2)
		{
			return true;
		}
		return false;
	}

	public static void loadTileImage()
	{
		if (imgWaterfall == null)
		{
			imgWaterfall = GameCanvas2.loadImageRMS("/tWater/wtf.png");
		}
		if (imgTopWaterfall == null)
		{
			imgTopWaterfall = GameCanvas2.loadImageRMS("/tWater/twtf.png");
		}
		if (imgWaterflow == null)
		{
			imgWaterflow = GameCanvas2.loadImageRMS("/tWater/wts.png");
		}
		if (imgWaterlowN == null)
		{
			imgWaterlowN = GameCanvas2.loadImageRMS("/tWater/wtsN.png");
		}
		if (imgWaterlowN2 == null)
		{
			imgWaterlowN2 = GameCanvas2.loadImageRMS("/tWater/wtsN2.png");
		}
		mSystem2.gcc();
	}

	public static void setTile(int index, int[] mapsArr, int type)
	{
		for (int i = 0; i < mapsArr.Length; i++)
		{
			if (maps[index] == mapsArr[i])
			{
				types[index] |= type;
				break;
			}
		}
	}

	public static void loadMap(int tileId)
	{
		pxh = tmh * size;
		pxw = tmw * size;
		Res2.outz("load tile ID= " + tileID);
		int num = tileId - 1;
		try
		{
			for (int i = 0; i < tmw * tmh; i++)
			{
				for (int j = 0; j < tileType[num].Length; j++)
				{
					setTile(i, tileIndex[num][j], tileType[num][j]);
				}
			}
		}
		catch (Exception)
		{
			Cout2.println("Error Load Map");
			GameMidlet2.instance.exit();
		}
	}

	public static bool isInAirMap()
	{
		if (mapID == 45 || mapID == 46 || mapID == 48)
		{
			return true;
		}
		return false;
	}

	public static bool isDoubleMap()
	{
		if (isMapDouble || mapID == 45 || mapID == 46 || mapID == 48 || mapID == 51 || mapID == 52 || mapID == 103 || mapID == 112 || mapID == 113 || mapID == 115 || mapID == 117 || mapID == 118 || mapID == 119 || mapID == 120 || mapID == 121 || mapID == 125 || mapID == 129 || mapID == 130)
		{
			return true;
		}
		return false;
	}

	public static void getTile()
	{
		if (Main2.typeClient == 3 || Main2.typeClient == 5)
		{
			if (mGraphics2.zoomLevel == 1)
			{
				imgTile = new Image2[1];
				imgTile[0] = GameCanvas2.loadImage("/tx1/" + tileID + ".png");
				return;
			}
			imgTile = new Image2[100];
			for (int i = 0; i < imgTile.Length; i++)
			{
				imgTile[i] = GameCanvas2.loadImage("/tx1/" + tileID + "/" + (i + 1) + ".png");
			}
			return;
		}
		if (mGraphics2.zoomLevel == 1)
		{
			if (imgTile != null)
			{
				for (int j = 0; j < imgTile.Length; j++)
				{
					if (imgTile[j] != null)
					{
						imgTile[j].texture = null;
						imgTile[j] = null;
					}
				}
				mSystem2.gcc();
			}
			imgTile = new Image2[100];
			for (int k = 0; k < imgTile.Length; k++)
			{
				string empty = (k >= 9) ? ("/tx1/" + tileID + "/t_" + (k + 1)) : ("/tx1/" + tileID + "/t_0" + (k + 1));
				imgTile[k] = GameCanvas2.loadImage(empty);
			}
			return;
		}
		Image2 image = GameCanvas2.loadImageRMS("/t/" + tileID + "$1.png");
		if (image != null)
		{
			Rms2.DeleteStorage("x" + mGraphics2.zoomLevel + "t" + tileID);
			imgTile = new Image2[100];
			for (int l = 0; l < imgTile.Length; l++)
			{
				imgTile[l] = GameCanvas2.loadImageRMS("/t/" + tileID + "$" + (l + 1) + ".png");
			}
		}
		else
		{
			image = GameCanvas2.loadImageRMS("/t/" + tileID + ".png");
			if (image != null)
			{
				Rms2.DeleteStorage("$");
				imgTile = new Image2[1];
				imgTile[0] = image;
			}
		}
	}

	public static void paintTile(mGraphics2 g, int frame, int indexX, int indexY)
	{
		if (imgTile != null)
		{
			if (imgTile.Length == 1)
			{
				g.drawRegion(imgTile[0], 0, frame * size, size, size, 0, indexX * size, indexY * size, 0);
			}
			else
			{
				g.drawImage(imgTile[frame], indexX * size, indexY * size, 0);
			}
		}
	}

	public static void paintTile(mGraphics2 g, int frame, int x, int y, int w, int h)
	{
		if (imgTile != null)
		{
			if (imgTile.Length == 1)
			{
				g.drawRegion(imgTile[0], 0, frame * w, w, w, 0, x, y, 0);
			}
			else
			{
				g.drawImage(imgTile[frame], x, y, 0);
			}
		}
	}

	public static void paintTilemapLOW(mGraphics2 g)
	{
		for (int i = GameScr2.gssx; i < GameScr2.gssxe; i++)
		{
			for (int j = GameScr2.gssy; j < GameScr2.gssye; j++)
			{
				int num = maps[j * tmw + i] - 1;
				if (num != -1)
				{
					paintTile(g, num, i, j);
				}
				if ((tileTypeAt(i, j) & 0x20) == 32)
				{
					g.drawRegion(imgWaterfall, 0, 24 * (GameCanvas2.gameTick % 4), 24, 24, 0, i * size, j * size, 0);
				}
				else if ((tileTypeAt(i, j) & 0x40) == 64)
				{
					if ((tileTypeAt(i, j - 1) & 0x20) == 32)
					{
						g.drawRegion(imgWaterfall, 0, 24 * (GameCanvas2.gameTick % 4), 24, 24, 0, i * size, j * size, 0);
					}
					else if ((tileTypeAt(i, j - 1) & 0x1000) == 4096)
					{
						paintTile(g, 21, i, j);
					}
					Image2 image = null;
					image = ((tileID == 5) ? imgWaterlowN : ((tileID != 8) ? imgWaterflow : imgWaterlowN2));
					g.drawRegion(image, 0, (GameCanvas2.gameTick % 8 >> 2) * 24, 24, 24, 0, i * size, j * size, 0);
				}
				if ((tileTypeAt(i, j) & 0x800) == 2048)
				{
					if ((tileTypeAt(i, j - 1) & 0x20) == 32)
					{
						g.drawRegion(imgWaterfall, 0, 24 * (GameCanvas2.gameTick % 4), 24, 24, 0, i * size, j * size, 0);
					}
					else if ((tileTypeAt(i, j - 1) & 0x1000) == 4096)
					{
						paintTile(g, 21, i, j);
					}
					paintTile(g, maps[j * tmw + i] - 1, i, j);
				}
			}
		}
	}

	public static void paintTilemap(mGraphics2 g)
	{
		if (Char2.isLoadingMap)
		{
			return;
		}
		GameScr2.gI().paintBgItem(g, 1);
		for (int i = 0; i < GameScr2.vItemMap.size(); i++)
		{
			((ItemMap2)GameScr2.vItemMap.elementAt(i)).paintAuraItemEff(g);
		}
		for (int j = GameScr2.gssx; j < GameScr2.gssxe; j++)
		{
			for (int k = GameScr2.gssy; k < GameScr2.gssye; k++)
			{
				if (j == 0 || j == tmw - 1)
				{
					continue;
				}
				int num = maps[k * tmw + j] - 1;
				if ((tileTypeAt(j, k) & 0x100) == 256)
				{
					continue;
				}
				if ((tileTypeAt(j, k) & 0x20) == 32)
				{
					g.drawRegion(imgWaterfall, 0, 24 * (GameCanvas2.gameTick % 8 >> 1), 24, 24, 0, j * size, k * size, 0);
				}
				else if ((tileTypeAt(j, k) & 0x80) == 128)
				{
					g.drawRegion(imgTopWaterfall, 0, 24 * (GameCanvas2.gameTick % 8 >> 1), 24, 24, 0, j * size, k * size, 0);
				}
				else
				{
					if (tileID == 13 && num != -1)
					{
						continue;
					}
					if (tileID == 2 && (tileTypeAt(j, k) & 0x200) == 512 && num != -1)
					{
						paintTile(g, num, j * size, k * size, 24, 1);
						paintTile(g, num, j * size, k * size + 1, 24, 24);
					}
					if (tileID == 3)
					{
					}
					if ((tileTypeAt(j, k) & 0x10) == 16)
					{
						bx = j * size - GameScr2.cmx;
						dbx = bx - GameScr2.gW2;
						dfx = (size - 2) * dbx / size;
						fx = dfx + GameScr2.gW2;
						paintTile(g, num, fx + GameScr2.cmx, k * size, 24, 24);
					}
					else if ((tileTypeAt(j, k) & 0x200) == 512)
					{
						if (num != -1)
						{
							paintTile(g, num, j * size, k * size, 24, 1);
							paintTile(g, num, j * size, k * size + 1, 24, 24);
						}
					}
					else if (num != -1)
					{
						paintTile(g, num, j, k);
					}
				}
			}
		}
		if (GameScr2.cmx < 24)
		{
			for (int l = GameScr2.gssy; l < GameScr2.gssye; l++)
			{
				int num2 = maps[l * tmw + 1] - 1;
				if (num2 != -1)
				{
					paintTile(g, num2, 0, l);
				}
			}
		}
		if (GameScr2.cmx <= GameScr2.cmxLim)
		{
			return;
		}
		int num3 = tmw - 2;
		for (int m = GameScr2.gssy; m < GameScr2.gssye; m++)
		{
			int num4 = maps[m * tmw + num3] - 1;
			if (num4 != -1)
			{
				paintTile(g, num4, num3 + 1, m);
			}
		}
	}

	public static bool isWaterEff()
	{
		if (mapID == 54 || mapID == 55 || mapID == 56 || mapID == 57 || mapID == 138 || mapID == 167)
		{
			return false;
		}
		return true;
	}

	public static void paintOutTilemap(mGraphics2 g)
	{
		if (GameCanvas2.lowGraphic)
		{
			return;
		}
		int num = 0;
		for (int i = GameScr2.gssx; i < GameScr2.gssxe; i++)
		{
			for (int j = GameScr2.gssy; j < GameScr2.gssye; j++)
			{
				num++;
				if ((tileTypeAt(i, j) & 0x40) != 64)
				{
					continue;
				}
				Image2 image = null;
				image = ((tileID == 5) ? imgWaterlowN : ((tileID != 8) ? imgWaterflow : imgWaterlowN2));
				if (!isWaterEff())
				{
					g.drawRegion(image, 0, 0, 24, 24, 0, i * size, j * size - 1, 0);
					g.drawRegion(image, 0, 0, 24, 24, 0, i * size, j * size - 3, 0);
				}
				g.drawRegion(image, 0, (GameCanvas2.gameTick % 8 >> 2) * 24, 24, 24, 0, i * size, j * size - 12, 0);
				if (yWater == 0 && isWaterEff())
				{
					yWater = j * size - 12;
					int color = 16777215;
					if (GameCanvas2.typeBg == 2)
					{
						color = 10871287;
					}
					else if (GameCanvas2.typeBg == 4)
					{
						color = 8111470;
					}
					else if (GameCanvas2.typeBg == 7)
					{
						color = 5693125;
					}
					else if (GameCanvas2.typeBg == 19)
					{
						color = 16711680;
					}
					BackgroudEffect2.addWater(color, yWater + 15);
				}
			}
		}
		BackgroudEffect2.paintWaterAll(g);
	}

	public static void loadMapFromResource(int mapID)
	{
		DataInputStream2 dataInputStream = null;
		dataInputStream = MyStream2.readFile("/mymap/" + mapID);
		tmw = (ushort)dataInputStream.read();
		tmh = (ushort)dataInputStream.read();
		maps = new int[dataInputStream.available()];
		for (int i = 0; i < tmw * tmh; i++)
		{
			maps[i] = (ushort)dataInputStream.read();
		}
		types = new int[maps.Length];
	}

	public static int tileAt(int x, int y)
	{
		try
		{
			return maps[y * tmw + x];
		}
		catch (Exception)
		{
			return 1000;
		}
	}

	public static int tileTypeAt(int x, int y)
	{
		try
		{
			return types[y * tmw + x];
		}
		catch (Exception)
		{
			return 1000;
		}
	}

	public static int tileTypeAtPixel(int px, int py)
	{
		try
		{
			return types[py / size * tmw + px / size];
		}
		catch (Exception)
		{
			return 1000;
		}
	}

	public static bool tileTypeAt(int px, int py, int t)
	{
		try
		{
			return (types[py / size * tmw + px / size] & t) == t;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void setTileTypeAtPixel(int px, int py, int t)
	{
		types[py / size * tmw + px / size] |= t;
	}

	public static void setTileTypeAt(int x, int y, int t)
	{
		types[y * tmw + x] = t;
	}

	public static void killTileTypeAt(int px, int py, int t)
	{
		types[py / size * tmw + px / size] &= ~t;
	}

	public static int tileYofPixel(int py)
	{
		return py / size * size;
	}

	public static int tileXofPixel(int px)
	{
		return px / size * size;
	}

	public static void loadMainTile()
	{
		if (lastTileID != tileID)
		{
			getTile();
			lastTileID = tileID;
		}
	}
}
