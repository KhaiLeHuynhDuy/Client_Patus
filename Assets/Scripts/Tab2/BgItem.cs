public class BgItem2
{
	public int id;

	public int trans;

	public short idImage;

	public int x;

	public int y;

	public int dx;

	public int dy;

	public sbyte layer;

	public int nTilenotMove;

	public int[] tileX;

	public int[] tileY;

	public static MyHashTable2 imgNew = new MyHashTable2();

	public static MyVector2 vKeysNew = new MyVector2();

	public static MyVector2 vKeysLast = new MyVector2();

	private bool isBlur;

	public int transX;

	public int transY;

	public static int[] idNotBlend = new int[61]
	{
		79, 80, 81, 82, 83, 84, 85, 86, 87, 88,
		89, 90, 91, 92, 95, 144, 99, 100, 101, 102,
		103, 104, 105, 106, 107, 108, 109, 110, 111, 112,
		113, 114, 115, 117, 118, 119, 120, 121, 122, 123,
		124, 125, 126, 127, 132, 133, 134, 139, 140, 141,
		142, 143, 144, 145, 146, 147, 171, 121, 122, 229,
		218
	};

	public static int[] isMiniBgz = new int[18]
	{
		79, 80, 81, 85, 86, 90, 91, 92, 99, 100,
		101, 102, 103, 104, 105, 106, 107, 108
	};

	public static sbyte[] newSmallVersion;

	// public static void clearHashTable()
	// {
	// }

	public static bool isExistKeyNews(string keyNew)
	{
		for (int i = 0; i < vKeysNew.size(); i++)
		{
			string text = (string)vKeysNew.elementAt(i);
			if (text.Equals(keyNew))
			{
				return true;
			}
		}
		return false;
	}

	public static bool isExistKeyLast(string keyLast)
	{
		for (int i = 0; i < vKeysLast.size(); i++)
		{
			string text = (string)vKeysLast.elementAt(i);
			if (text.Equals(keyLast))
			{
				return true;
			}
		}
		return false;
	}

	public bool isNotBlend()
	{
		if (mGraphics2.zoomLevel == 1)
		{
			return true;
		}
		if (TileMap2.isInAirMap())
		{
			return true;
		}
		for (int i = 0; i < idNotBlend.Length; i++)
		{
			if (idImage == idNotBlend[i])
			{
				return true;
			}
		}
		return false;
	}

	public bool isMiniBg()
	{
		for (int i = 0; i < isMiniBgz.Length; i++)
		{
			if (idImage == isMiniBgz[i])
			{
				return true;
			}
		}
		return false;
	}

	public void changeColor()
	{
		if (isNotBlend() || layer == 2 || layer == 4 || imgNew.containsKey(idImage + "blend" + layer))
		{
			return;
		}
		Image2 image = (Image2)imgNew.get(idImage + string.Empty);
		if (image != null && image.getRealImageWidth() > 4)
		{
			sbyte[] array = Rms2.loadRMS("x" + mGraphics2.zoomLevel + "blend" + idImage + "layer" + layer);
			if (array == null)
			{
				imgNew.put(idImage + "blend" + layer, BgItemMn2.blendImage(image, layer, idImage));
				return;
			}
			Image2 v = Image2.createImage(array, 0, array.Length);
			imgNew.put(idImage + "blend" + layer, v);
		}
	}

	public void paint(mGraphics2 g)
	{
		if (Char2.isLoadingMap || (idImage == 279 && GameScr2.gI().tMabuEff >= 110))
		{
			return;
		}
		int cmx = GameScr2.cmx;
		int cmy = GameScr2.cmy;
		Image2 image = null;
		image = ((layer == 2 || layer == 4) ? ((Image2)imgNew.get(idImage + string.Empty)) : (isNotBlend() ? ((Image2)imgNew.get(idImage + string.Empty)) : ((Image2)imgNew.get(idImage + "blend" + layer))));
		if (image == null || idImage == 96)
		{
			return;
		}
		if (layer == 4)
		{
			transX = -cmx / 2 + 100;
		}
		if (idImage == 28 && layer == 3)
		{
			transX = -cmx / 3 + 200;
		}
		if ((idImage == 67 || idImage == 68 || idImage == 69 || idImage == 70) && layer == 3)
		{
			transX = -cmx / 3 + 200;
		}
		if (isMiniBg() && layer < 4)
		{
			transX = -(cmx >> 4) + 50;
			transY = (cmy >> 5) - 15;
		}
		int num = x + dx + transX;
		int num2 = y + dy + transY;
		if (x + dx + image.getWidth() + transX >= cmx && x + dx + transX <= cmx + GameCanvas2.w && y + dy + transY + image.getHeight() >= cmy && y + dy + transY <= cmy + GameCanvas2.h)
		{
			g.drawRegion(image, 0, 0, mGraphics2.getImageWidth(image), mGraphics2.getImageHeight(image), trans, x + dx + transX, y + dy + transY, 0);
			if (idImage == 11 && TileMap2.mapID != 122)
			{
				g.setClip(num, num2 + 24, 48, 14);
				for (int i = 0; i < 2; i++)
				{
					g.drawRegion(TileMap2.imgWaterflow, 0, (GameCanvas2.gameTick % 8 >> 2) * 24, 24, 24, 0, num + i * 24, num2 + 24, 0);
				}
				g.setClip(GameScr2.cmx, GameScr2.cmy, GameScr2.gW, GameScr2.gH);
			}
		}
		if (TileMap2.isDoubleMap() && idImage > 137 && idImage != 156 && idImage != 159 && idImage != 157 && idImage != 165 && idImage != 167 && idImage != 168 && idImage != 169 && idImage != 170 && idImage != 238 && TileMap2.pxw - (x + dx + transX) >= cmx && TileMap2.pxw - (x + dx + transX + image.getWidth()) <= cmx + GameCanvas2.w && y + dy + transY + image.getHeight() >= cmy && y + dy + transY <= cmy + GameCanvas2.h && (idImage < 241 || idImage >= 266))
		{
			g.drawRegion(image, 0, 0, mGraphics2.getImageWidth(image), mGraphics2.getImageHeight(image), 2, TileMap2.pxw - (x + dx + transX), y + dy + transY, StaticObj2.TOP_RIGHT);
		}
	}
}
