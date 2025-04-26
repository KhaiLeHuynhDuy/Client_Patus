using System;

public class SmallImage2
{
	public static int[][] smallImg;

	public static SmallImage2 instance;

	public static Image2[] imgbig;

	public static Small2[] imgNew;

	public static MyVector2 vKeys = new MyVector2();

	public static Image2 imgEmpty = null;

	public static sbyte[] newSmallVersion;

	public static int smallCount;

	public static short maxSmall;

	public SmallImage2()
	{
		readImage();
	}

	public static void loadBigRMS()
	{
		if (imgbig == null)
		{
			imgbig = new Image2[5]
			{
				GameCanvas2.loadImageRMS("/img/Big0.png"),
				GameCanvas2.loadImageRMS("/img/Big1.png"),
				GameCanvas2.loadImageRMS("/img/Big2.png"),
				GameCanvas2.loadImageRMS("/img/Big3.png"),
				GameCanvas2.loadImageRMS("/img/Big4.png")
			};
		}
	}

	public static void freeBig()
	{
		imgbig = null;
		mSystem2.gcc();
	}

	public static void loadBigImage()
	{
		imgEmpty = Image2.createRGBImage(new int[1], 1, 1, bl: true);
	}

	public static void init()
	{
		instance = null;
		instance = new SmallImage2();
	}

	public void readData(byte[] data)
	{
	}

	public void readImage()
	{
		int num = 0;
		try
		{
			DataInputStream2 dataInputStream = new DataInputStream2(Rms2.loadRMS("NR_image"));
			short num2 = dataInputStream.readShort();
			smallImg = new int[num2][];
			for (int i = 0; i < smallImg.Length; i++)
			{
				smallImg[i] = new int[5];
			}
			for (int j = 0; j < num2; j++)
			{
				num++;
				smallImg[j][0] = dataInputStream.readUnsignedByte();
				smallImg[j][1] = dataInputStream.readShort();
				smallImg[j][2] = dataInputStream.readShort();
				smallImg[j][3] = dataInputStream.readShort();
				smallImg[j][4] = dataInputStream.readShort();
			}
		}
		catch (Exception ex)
		{
			Cout2.LogError3("Loi readImage: " + ex.ToString() + "i= " + num);
		}
	}

	// public static void clearHastable()
	// {
	// }

	public static void createImage(int id)
	{
		// if (mGraphics2.zoomLevel == 1)
		// {
		// 	Image2 image = GameCanvas2.loadImage("/SmallImage/Small" + id + ".png");
		// 	if (image != null)
		// 	{
		// 		imgNew[id] = new Small2(image, id);
		// 		return;
		// 	}
		// 	imgNew[id] = new Small2(imgEmpty, id);
		// 	Service2.gI().requestIcon(id);
		// 	return;
		// }
		Image2 image2 = GameCanvas2.loadImage("/SmallImage/Small" + id + ".png");
		if (image2 != null)
		{
			imgNew[id] = new Small2(image2, id);
			return;
		}
		bool flag = false;
		sbyte[] array = Rms2.loadRMS(mGraphics2.zoomLevel + "Small" + id);
		if (array != null)
		{
			sbyte[] newArr = MainMod2.DecryptBytes(array);
			if (newSmallVersion != null && newArr.Length % 127 != newSmallVersion[id])
			{
				flag = true;
			}
			if (!flag)
			{
				Image2 image3 = Image2.createImage(newArr, 0, newArr.Length);
				if (image3 != null)
				{
					imgNew[id] = new Small2(image3, id);
				}
				else
				{
					flag = true;
				}
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			imgNew[id] = new Small2(imgEmpty, id);
			Service2.gI().requestIcon(id);
		}
	}

	public static void drawSmallImage(mGraphics2 g, int id, int x, int y, int transform, int anchor)
	{
		if (imgbig == null)
		{
			Small2 small = imgNew[id];
			if (small == null)
			{
				createImage(id);
			}
			else
			{
				g.drawRegion(small, 0, 0, mGraphics2.getImageWidth(small.img), mGraphics2.getImageHeight(small.img), transform, x, y, anchor);
			}
		}
		else if (smallImg != null)
		{
			if (id >= smallImg.Length || smallImg[id][1] >= 256 || smallImg[id][3] >= 256 || smallImg[id][2] >= 256 || smallImg[id][4] >= 256)
			{
				Small2 small2 = imgNew[id];
				if (small2 == null)
				{
					createImage(id);
				}
				else
				{
					small2.paint(g, transform, x, y, anchor);
				}
			}
			else if (imgbig[smallImg[id][0]] != null)
			{
				g.drawRegion(imgbig[smallImg[id][0]], smallImg[id][1], smallImg[id][2], smallImg[id][3], smallImg[id][4], transform, x, y, anchor);
			}
		}
		else if (GameCanvas2.currentScreen != GameScr2.gI())
		{
			Small2 small3 = imgNew[id];
			if (small3 == null)
			{
				createImage(id);
			}
			else
			{
				small3.paint(g, transform, x, y, anchor);
			}
		}
	}

	public static void drawSmallImage(mGraphics2 g, int id, int f, int x, int y, int w, int h, int transform, int anchor)
	{
		if (imgbig == null)
		{
			Small2 small = imgNew[id];
			if (small == null)
			{
				createImage(id);
			}
			else
			{
				g.drawRegion(small.img, 0, f * w, w, h, transform, x, y, anchor);
			}
		}
		else if (smallImg != null)
		{
			if (id >= smallImg.Length || smallImg[id] == null || smallImg[id][1] >= 256 || smallImg[id][3] >= 256 || smallImg[id][2] >= 256 || smallImg[id][4] >= 256)
			{
				Small2 small2 = imgNew[id];
				if (small2 == null)
				{
					createImage(id);
				}
				else
				{
					small2.paint(g, transform, f, x, y, w, h, anchor);
				}
			}
			else if (smallImg[id][0] != 4 && imgbig[smallImg[id][0]] != null)
			{
				g.drawRegion(imgbig[smallImg[id][0]], 0, f * w, w, h, transform, x, y, anchor);
			}
			else
			{
				Small2 small3 = imgNew[id];
				if (small3 == null)
				{
					createImage(id);
				}
				else
				{
					small3.paint(g, transform, f, x, y, w, h, anchor);
				}
			}
		}
		else if (GameCanvas2.currentScreen != GameScr2.gI())
		{
			Small2 small4 = imgNew[id];
			if (small4 == null)
			{
				createImage(id);
			}
			else
			{
				small4.paint(g, transform, f, x, y, w, h, anchor);
			}
		}
	}

	public static void update()
	{
		int num = 0;
		if (GameCanvas2.gameTick % 1000 != 0)
		{
			return;
		}
		for (int i = 0; i < imgNew.Length; i++)
		{
			if (imgNew[i] != null)
			{
				num++;
				imgNew[i].update();
				smallCount++;
			}
		}
		if (num > 200 && GameCanvas2.lowGraphic)
		{
			imgNew = new Small2[maxSmall];
		}
	}
}
