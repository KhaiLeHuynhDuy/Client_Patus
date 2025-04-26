using System;

public class BackgroudEffect2
{
	public static MyVector2 vBgEffect = new MyVector2();

	private int[] x;

	private int[] y;

	private int[] vx;

	private int[] vy;

	public static int[] wP;

	private int num;

	private int xShip;

	private int yShip;

	private int way;

	private int trans;

	private int frameFire;

	private int tFire;

	private int tStart;

	private int speed;

	private bool isFly;

	public static Image2 imgSnow;

	public static Image2 imgHatMua;

	public static Image2 imgMua1;

	public static Image2 imgMua2;

	public static Image2 imgSao;

	private static Image2 imgLacay;

	private static Image2 imgShip;

	private static Image2 imgFire1;

	private static Image2 imgFire2;

	private int[] type;

	private int sum;

	public int typeEff;

	public int xx;

	public int waterY;

	private bool[] isRainEffect;

	private int[] frame;

	private int[] t;

	private bool[] activeEff;

	private int yWater;

	private int colorWater;

	public const int TYPE_MUA = 0;

	public const int TYPE_LATRAIDAT_1 = 1;

	public const int TYPE_LATRAIDAT_2 = 2;

	public const int TYPE_SAMSET = 3;

	public const int TYPE_SAO = 4;

	public const int TYPE_LANAMEK_1 = 5;

	public const int TYPE_LASAYAI_1 = 6;

	public const int TYPE_LANAMEK_2 = 7;

	public const int TYPE_SHIP_TRAIDAT = 8;

	public const int TYPE_HANHTINH = 9;

	public const int TYPE_WATER = 10;

	public const int TYPE_SNOW = 11;

	public const int TYPE_MUA_FRONT = 12;

	public const int TYPE_CLOUD = 13;

	public const int TYPE_FOG = 14;

	public const int TYPE_LUNAR_YEAR = 15;

	public static int PIXEL = 16;

	public static Image2 water1 = GameCanvas2.loadImage("/mainImage/myTexture2dwater1.png");

	public static Image2 water2 = GameCanvas2.loadImage("/mainImage/myTexture2dwater2.png");

	public static Image2 imgChamTron1;

	public static Image2 imgChamTron2;

	public static short id_water1;

	public static short id_water2;

	public static Image2 water3 = null;

	public static bool isFog;

	public static bool isPaintFar;

	public static int nCloud;

	public static Image2 imgFog;

	public static int xfog;

	public static int yfog;

	public static int fogw;

	private int[] dem = new int[6] { 0, 1, 2, 1, 0, 0 };

	private int[] tick;

	public BackgroudEffect2(int typeS)
	{
		isFog = true;
		initCloud();
		typeEff = typeS;
		switch (typeEff)
		{
		case 10:
		{
			this.num = 30;
			x = new int[this.num];
			y = new int[this.num];
			wP = new int[this.num];
			vx = new int[this.num];
			int num = 0;
			for (int l = 0; l < this.num; l++)
			{
				x[l] = Res2.abs(Res2.random(0, GameCanvas2.w)) + GameScr2.cmx;
				num++;
				if (num > this.num / 2)
				{
					y[l] = Res2.abs(Res2.random(20, 60));
					wP[l] = 10;
				}
				else
				{
					y[l] = Res2.abs(Res2.random(0, 20));
					wP[l] = 7;
				}
				vx[l] = wP[l] / 2 - 2;
			}
			break;
		}
		case 9:
		{
			if (imgChamTron1 == null)
			{
				imgChamTron1 = GameCanvas2.loadImageRMS("/bg/cham-tron1.png");
			}
			if (imgChamTron2 == null)
			{
				imgChamTron2 = GameCanvas2.loadImageRMS("/bg/cham-tron2.png");
			}
			this.num = 20;
			x = new int[this.num];
			y = new int[this.num];
			wP = new int[this.num];
			vx = new int[this.num];
			for (int i = 0; i < this.num; i++)
			{
				x[i] = Res2.abs(Res2.random(0, GameCanvas2.w));
				y[i] = Res2.abs(Res2.random(10, 80));
				wP[i] = Res2.abs(Res2.random(1, 3));
				vx[i] = wP[i];
			}
			break;
		}
		case 0:
		case 12:
		{
			if (imgHatMua == null)
			{
				imgHatMua = GameCanvas2.loadImageRMS("/bg/mua.png");
			}
			if (imgMua1 == null)
			{
				imgMua1 = GameCanvas2.loadImageRMS("/bg/mua1.png");
			}
			if (imgMua2 == null)
			{
				imgMua2 = GameCanvas2.loadImageRMS("/bg/mua2.png");
			}
			sum = Res2.random(GameCanvas2.w / 3, GameCanvas2.w / 2);
			x = new int[sum];
			y = new int[sum];
			vx = new int[sum];
			vy = new int[sum];
			type = new int[sum];
			t = new int[sum];
			frame = new int[sum];
			isRainEffect = new bool[sum];
			activeEff = new bool[sum];
			for (int k = 0; k < sum; k++)
			{
				y[k] = Res2.random(-10, GameCanvas2.h + 100) + GameScr2.cmy;
				x[k] = Res2.random(-10, GameCanvas2.w + 300) + GameScr2.cmx;
				t[k] = Res2.random(0, 1);
				vx[k] = -12;
				vy[k] = 12;
				type[k] = Res2.random(1, 3);
				isRainEffect[k] = false;
				if (type[k] == 2 && k % 2 == 0)
				{
					isRainEffect[k] = true;
				}
				activeEff[k] = false;
				frame[k] = Res2.random(1, 2);
			}
			break;
		}
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
		case 15:
		{
			if (typeEff == 1)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/lacay.png");
				PIXEL = 10;
			}
			if (typeEff == 2)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/lacay2.png");
				PIXEL = 18;
			}
			if (typeEff == 5)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/lacay3.png");
				PIXEL = 14;
			}
			if (typeEff == 6)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/lacay4.png");
				PIXEL = 14;
			}
			if (typeEff == 7)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/lacay5.png");
				PIXEL = 12;
			}
			if (typeEff == 11)
			{
				imgLacay = GameCanvas2.loadImageRMS("/bg/tuyet.png");
			}
			if (typeEff == 15)
			{
				Small2 small = SmallImage2.imgNew[11120];
				if (small == null)
				{
					SmallImage2.createImage(11120);
				}
				PIXEL = 16;
			}
			sum = Res2.random(15, 25);
			if (typeEff == 11)
			{
				sum = 100;
			}
			x = new int[sum];
			y = new int[sum];
			vx = new int[sum];
			vy = new int[sum];
			t = new int[sum];
			frame = new int[sum];
			activeEff = new bool[sum];
			for (int j = 0; j < sum; j++)
			{
				x[j] = Res2.random(-10, TileMap2.pxw + 10);
				y[j] = Res2.random(0, TileMap2.pxh);
				frame[j] = Res2.random(0, 1);
				t[j] = Res2.random(0, 1);
				vx[j] = Res2.random(-3, 3);
				vy[j] = Res2.random(1, 4);
				if (typeEff == 11)
				{
					frame[j] = Res2.random(0, 2);
					vx[j] = Res2.abs(Res2.random(1, 3));
					vy[j] = Res2.abs(Res2.random(1, 3));
				}
				if (typeEff == 15)
				{
					frame[j] = Res2.random(0, 2);
					vx[j] = Res2.abs(Res2.random(1, 3));
					vy[j] = Res2.abs(Res2.random(1, 3));
				}
			}
			break;
		}
		case 4:
		{
			sum = Res2.random(5, 10);
			if (imgSao == null)
			{
				imgSao = GameCanvas2.loadImageRMS("/bg/sao.png");
			}
			x = new int[sum];
			y = new int[sum];
			frame = new int[sum];
			t = new int[sum];
			tick = new int[sum];
			for (int m = 0; m < sum; m++)
			{
				x[m] = Res2.random(0, GameCanvas2.w);
				y[m] = Res2.random(0, 50);
				if (m % 2 == 0)
				{
					tick[m] = 0;
				}
				else if (m % 3 == 0)
				{
					tick[m] = 1;
				}
				else if (m % 4 == 0)
				{
					tick[m] = 2;
				}
				else
				{
					tick[m] = 3;
				}
				t[m] = Res2.random(0, 10);
			}
			break;
		}
		case 3:
			GameCanvas2.isBoltEff = true;
			break;
		case 8:
			tStart = Res2.random(100, 300);
			if (imgShip == null)
			{
				imgShip = GameCanvas2.loadImageRMS("/bg/ship.png");
			}
			if (imgFire1 == null)
			{
				imgFire1 = GameCanvas2.loadImageRMS("/bg/fire1.png");
			}
			if (imgFire2 == null)
			{
				imgFire2 = GameCanvas2.loadImageRMS("/bg/fire2.png");
			}
			isFly = false;
			reloadShip();
			break;
		case 13:
			if (Res2.abs(Res2.random(0, 2)) == 0)
			{
				if (Res2.abs(Res2.random(0, 2)) == 0)
				{
					isPaintFar = true;
				}
				else
				{
					isPaintFar = false;
				}
				nCloud = Res2.abs(Res2.random(2, 5));
				initCloud();
			}
			break;
		case 14:
			if (Res2.abs(Res2.random(0, 2)) == 0)
			{
				isFog = true;
				initCloud();
			}
			break;
		}
	}

	public static void clearImage()
	{
		TileMap2.yWater = 0;
	}

	public static bool isHaveRain()
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			BackgroudEffect2 backgroudEffect = (BackgroudEffect2)vBgEffect.elementAt(i);
			if (backgroudEffect.typeEff == 0 || backgroudEffect.typeEff == 12)
			{
				return true;
			}
		}
		return false;
	}

	public static void initCloud()
	{
		if (mSystem2.clientType == 1)
		{
			imgFog = null;
			return;
		}
		if (GameCanvas2.lowGraphic)
		{
			imgFog = null;
			return;
		}
		if (!isFog)
		{
			imgFog = null;
			return;
		}
		if (imgFog == null)
		{
			imgFog = GameCanvas2.loadImage("/bg/fog0.png");
		}
		fogw = 287;
	}

	public static void updateFog()
	{
		if (mSystem2.clientType != 1 && !GameCanvas2.lowGraphic && isFog)
		{
			xfog--;
			if (xfog < -fogw)
			{
				xfog = 0;
			}
		}
	}

	public static void paintFog(mGraphics2 g)
	{
		if (mSystem2.clientType == 1 || GameCanvas2.lowGraphic || !isFog || imgFog == null)
		{
			return;
		}
		for (int i = xfog; i < TileMap2.pxw; i += fogw)
		{
			if (i >= GameScr2.cmx - fogw)
			{
				g.drawImageFog(imgFog, i, yfog, 0);
			}
		}
	}

	private void reloadShip()
	{
		int cmx = GameScr2.cmx;
		int cmy = GameScr2.cmy;
		way = Res2.random(1, 3);
		isFly = false;
		speed = Res2.random(3, 5);
		if (way == 1)
		{
			xShip = -50;
			yShip = Res2.random(cmy, GameCanvas2.h - 100 + cmy);
			trans = 0;
		}
		else if (way == 2)
		{
			xShip = TileMap2.pxw + 50;
			yShip = Res2.random(cmy, GameCanvas2.h - 100 + cmy);
			trans = 2;
		}
		else if (way == 3)
		{
			xShip = Res2.random(50 + cmx, GameCanvas2.w - 50 + cmx);
			yShip = -50;
			int num = Res2.random(0, 2);
			trans = ((num != 0) ? 2 : 0);
		}
		else if (way == 4)
		{
			xShip = Res2.random(50 + cmx, GameCanvas2.w - 50 + cmx);
			yShip = TileMap2.pxh + 50;
			int num2 = Res2.random(0, 2);
			trans = ((num2 != 0) ? 2 : 0);
		}
	}

	public void paintWater(mGraphics2 g)
	{
		if (typeEff != 10)
		{
			return;
		}
		g.setColor(colorWater);
		for (int i = 0; i < num; i++)
		{
			g.drawImage((i >= num / 2) ? water1 : water2, x[i], y[i] + yWater, 0);
		}
		if (id_water1 != 0 && water3 == null)
		{
			water3 = SmallImage2.imgNew[id_water1].img;
		}
		if (water3 != null)
		{
			for (int j = 0; j < num / 2; j++)
			{
				g.drawImage(water3, x[j], y[j] + yWater, 0);
			}
		}
	}

	public void paintFar(mGraphics2 g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		if (typeEff == 4)
		{
			for (int i = 0; i < sum; i++)
			{
				g.drawRegion(imgSao, 0, 16 * frame[i], 16, 16, 0, x[i], y[i], 0);
			}
		}
		if (typeEff == 9)
		{
			g.setColor(16777215);
			for (int j = 0; j < num; j++)
			{
				g.drawImage((wP[j] != 1) ? imgChamTron2 : imgChamTron1, x[j], y[j], 3);
			}
		}
	}

	public void update()
	{
		try
		{
			switch (typeEff)
			{
			case 10:
			{
				for (int m = 0; m < this.num; m++)
				{
					x[m] -= vx[m];
					if (x[m] < -vx[m] + GameScr2.cmx)
					{
						x[m] = GameCanvas2.w + vx[m] + GameScr2.cmx;
					}
				}
				break;
			}
			case 9:
			{
				for (int i = 0; i < this.num; i++)
				{
					x[i] -= vx[i];
					if (x[i] < -vx[i])
					{
						wP[i] = Res2.abs(Res2.random(1, 3));
						vx[i] = wP[i];
						x[i] = GameCanvas2.w + vx[i];
					}
				}
				break;
			}
			case 3:
				break;
			case 0:
			case 12:
			{
				for (int l = 0; l < sum; l++)
				{
					if (l % 3 != 0 && typeEff != 12 && TileMap2.tileTypeAt(x[l], y[l] - GameCanvas2.transY, 2))
					{
						activeEff[l] = true;
					}
					if (l % 3 == 0 && y[l] > GameCanvas2.h + GameScr2.cmy)
					{
						x[l] = Res2.random(-10, GameCanvas2.w + 300) + GameScr2.cmx;
						y[l] = Res2.random(-100, 0) + GameScr2.cmy;
					}
					if (!activeEff[l])
					{
						y[l] += vy[l];
						x[l] += vx[l];
					}
					if (!activeEff[l])
					{
						continue;
					}
					t[l]++;
					if (t[l] > 2)
					{
						frame[l]++;
						t[l] = 0;
						if (frame[l] > 1)
						{
							frame[l] = 0;
							activeEff[l] = false;
							x[l] = Res2.random(-10, GameCanvas2.w + 300) + GameScr2.cmx;
							y[l] = Res2.random(-100, 0) + GameScr2.cmy;
						}
					}
				}
				break;
			}
			case 1:
			case 2:
			case 5:
			case 6:
			case 7:
			case 11:
			case 15:
			{
				for (int j = 0; j < sum; j++)
				{
					if (j % 3 != 0 && TileMap2.tileTypeAt(x[j], y[j] + ((TileMap2.tileID == 15) ? 10 : 0), 2))
					{
						activeEff[j] = true;
					}
					if (j % 3 == 0 && y[j] > TileMap2.pxh)
					{
						x[j] = Res2.random(-10, TileMap2.pxw + 50);
						y[j] = Res2.random(-50, 0);
					}
					if (!activeEff[j])
					{
						for (int k = 0; k < Teleport2.vTeleport.size(); k++)
						{
							Teleport2 teleport = (Teleport2)Teleport2.vTeleport.elementAt(k);
							if (teleport != null && teleport.paintFire && x[j] < teleport.x + 80 && x[j] > teleport.x - 80 && y[j] < teleport.y + 80 && y[j] > teleport.y - 80)
							{
								x[j] += ((x[j] >= teleport.x) ? 10 : (-10));
							}
						}
						y[j] += vy[j];
						x[j] += vx[j];
						t[j]++;
						int num = ((typeEff != 11) ? 4 : 3);
						num = ((typeEff != 15) ? 4 : 4);
						if (t[j] > ((typeEff == 2) ? 4 : 2))
						{
							if (typeEff != 11 && typeEff != 15)
							{
								frame[j]++;
							}
							t[j] = 0;
							if (frame[j] > num - 1)
							{
								frame[j] = 0;
							}
						}
					}
					else
					{
						t[j]++;
						if (t[j] == 100)
						{
							t[j] = 0;
							x[j] = Res2.random(-10, TileMap2.pxw + 50);
							y[j] = Res2.random(-50, 0);
							activeEff[j] = false;
						}
					}
				}
				break;
			}
			case 4:
			{
				for (int n = 0; n < sum; n++)
				{
					t[n]++;
					if (t[n] > 10)
					{
						tick[n]++;
						t[n] = 0;
						if (tick[n] > 5)
						{
							tick[n] = 0;
						}
						frame[n] = dem[tick[n]];
					}
				}
				break;
			}
			case 8:
				tFire++;
				if (tFire == 3)
				{
					tFire = 0;
					frameFire++;
					if (frameFire > 1)
					{
						frameFire = 0;
					}
				}
				if (GameCanvas2.gameTick % tStart == 0)
				{
					isFly = true;
				}
				if (!isFly)
				{
					break;
				}
				if (way == 1)
				{
					xShip += speed;
					if (xShip > TileMap2.pxw + 50)
					{
						reloadShip();
					}
				}
				else if (way == 2)
				{
					xShip -= speed;
					if (xShip < -50)
					{
						reloadShip();
					}
				}
				else if (way == 3)
				{
					yShip += speed;
					if (yShip > TileMap2.pxh + 50)
					{
						reloadShip();
					}
				}
				else if (way == 4)
				{
					yShip -= speed;
					if (yShip < -50)
					{
						reloadShip();
					}
				}
				break;
			case 14:
				updateFog();
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintFront(mGraphics2 g)
	{
		try
		{
			switch (typeEff)
			{
			case 3:
				break;
			case 0:
			case 12:
			{
				int cmx = GameScr2.cmx;
				int cmy = GameScr2.cmy;
				for (int i = 0; i < sum; i++)
				{
					if (type[i] == 2 && x[i] >= GameScr2.cmx && x[i] <= GameCanvas2.w + GameScr2.cmx && y[i] >= GameScr2.cmy && y[i] <= GameCanvas2.h + GameScr2.cmy)
					{
						if (activeEff[i])
						{
							g.drawRegion(imgHatMua, 0, 10 * frame[i], 13, 10, 0, x[i], y[i] - 10, 0);
						}
						else
						{
							g.drawImage(imgMua1, x[i], y[i], 0);
						}
					}
				}
				break;
			}
			case 1:
			case 2:
			case 5:
			case 6:
			case 7:
			case 11:
			case 15:
				if (typeEff == 15)
				{
					if (SmallImage2.imgNew[11120] != null && SmallImage2.imgNew[11120].img != null)
					{
						imgLacay = SmallImage2.imgNew[11120].img;
					}
					if (imgLacay == null)
					{
						break;
					}
				}
				paintLacay1(g, imgLacay);
				break;
			case 4:
			case 8:
			case 9:
			case 10:
			case 14:
				break;
			}
		}
		catch (Exception)
		{
		}
	}

	public void paintLacay1(mGraphics2 g, Image2 img)
	{
		int num = ((typeEff != 11) ? 4 : 3);
		num = ((typeEff != 15) ? 4 : 4);
		for (int i = 0; i < sum; i++)
		{
			if (i % 3 == 0 && x[i] >= GameScr2.cmx && x[i] <= GameCanvas2.w + GameScr2.cmx && y[i] >= GameScr2.cmy && y[i] <= GameCanvas2.h + GameScr2.cmy && img != null)
			{
				g.drawRegion(img, 0, PIXEL * frame[i], img.getWidth(), PIXEL, 0, x[i], y[i], 0);
			}
		}
	}

	public void paintLacay2(mGraphics2 g, Image2 img)
	{
		int num = ((typeEff != 11) ? 4 : 3);
		num = ((typeEff != 15) ? 4 : 4);
		for (int i = 0; i < sum; i++)
		{
			if (i % 3 != 0 && x[i] >= GameScr2.cmx && x[i] <= GameCanvas2.w + GameScr2.cmx && y[i] >= GameScr2.cmy && y[i] <= GameCanvas2.h + GameScr2.cmy && img != null)
			{
				g.drawRegion(img, 0, PIXEL * frame[i], img.getWidth(), PIXEL, 0, x[i], y[i], 0);
			}
		}
	}

	public void paintBehindTile(mGraphics2 g)
	{
		switch (typeEff)
		{
		case 8:
			g.drawRegion(imgShip, 0, 0, imgShip.getWidth(), imgShip.getHeight(), trans, xShip, yShip, 3);
			if (way == 1 || way == 2)
			{
				int num = ((trans != 0) ? 25 : (-25));
				g.drawRegion(imgFire1, 0, frameFire * 8, 20, 8, trans, xShip + num, yShip + 5, 3);
			}
			else
			{
				int num2 = ((trans != 0) ? (-11) : 11);
				g.drawRegion(imgFire2, 0, frameFire * 18, 8, 18, trans, xShip + num2, yShip + 22, 3);
			}
			break;
		}
	}

	public void paintBack(mGraphics2 g)
	{
		switch (typeEff)
		{
		case 3:
			break;
		case 0:
		{
			int cmx = GameScr2.cmx;
			int cmy = GameScr2.cmy;
			g.setColor(10742731);
			for (int i = 0; i < sum; i++)
			{
				if (type[i] != 2 && x[i] >= GameScr2.cmx && x[i] <= GameCanvas2.w + GameScr2.cmx && y[i] >= GameScr2.cmy && y[i] <= GameCanvas2.h + GameScr2.cmy)
				{
					g.drawImage(imgMua2, x[i], y[i], 0);
				}
			}
			break;
		}
		case 1:
		case 2:
		case 5:
		case 6:
		case 7:
		case 11:
		case 15:
			if (typeEff == 15)
			{
				if (SmallImage2.imgNew[11120] != null && SmallImage2.imgNew[11120].img != null)
				{
					imgLacay = SmallImage2.imgNew[11120].img;
				}
				if (imgLacay == null)
				{
					break;
				}
			}
			paintLacay2(g, imgLacay);
			break;
		case 4:
		case 8:
		case 9:
		case 10:
		case 12:
		case 13:
		case 14:
			break;
		}
	}

	public static void addEffect(int id)
	{
		if (!GameCanvas2.lowGraphic)
		{
			BackgroudEffect2 o = new BackgroudEffect2(id);
			vBgEffect.addElement(o);
		}
	}

	public static void addWater(int color, int yWater)
	{
		BackgroudEffect2 backgroudEffect = new BackgroudEffect2(10);
		backgroudEffect.colorWater = color;
		backgroudEffect.yWater = yWater;
		vBgEffect.addElement(backgroudEffect);
	}

	public static void paintWaterAll(mGraphics2 g)
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).paintWater(g);
		}
	}

	public static void paintBehindTileAll(mGraphics2 g)
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).paintBehindTile(g);
		}
	}

	public static void paintFrontAll(mGraphics2 g)
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).paintFront(g);
		}
	}

	public static void paintFarAll(mGraphics2 g)
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).paintFar(g);
		}
	}

	public static void paintBackAll(mGraphics2 g)
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).paintBack(g);
		}
	}

	public static void updateEff()
	{
		for (int i = 0; i < vBgEffect.size(); i++)
		{
			((BackgroudEffect2)vBgEffect.elementAt(i)).update();
		}
	}
}
