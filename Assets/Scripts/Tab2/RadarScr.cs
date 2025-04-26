using System;
using UnityEngine;

public class RadarScr2 : mScreen2
{
	public const sbyte SUBCMD_ALL = 0;

	public const sbyte SUBCMD_USE = 1;

	public const sbyte SUBCMD_LEVEL = 2;

	public const sbyte SUBCMD_AMOUNT = 3;

	public const sbyte SUBCMD_AURA = 4;

	public static RadarScr2 instance;

	public static bool TYPE_UI;

	public static FrameImage2 fraImgFocus;

	public static FrameImage2 fraImgFocusNone;

	public static FrameImage2 fraEff;

	private static Image2 imgUI;

	private static Image2 imgUIText;

	private static Image2 imgArrow_Left;

	private static Image2 imgArrow_Right;

	private static Image2 imgArrow_Down;

	private static Image2 imgLock;

	private static Image2 imgUse_0;

	private static Image2 imgUse;

	private static Image2 imgBack;

	private static Image2 imgChange;

	private static Image2 imgBar_0;

	private static Image2 imgBar_1;

	private static Image2 imgPro_0;

	private static Image2 imgPro_1;

	private static Image2[] imgRank;

	public static int xUi;

	public static int yUi;

	public static int wUi;

	public static int hUi;

	public static int xMon;

	public static int yMon;

	public static int xText;

	public static int yText;

	public static int wText;

	public static int cmyText;

	public static int hText;

	public static int yCmd;

	public static int[] xCmd = new int[0];

	public static int[] dxCmd = new int[0];

	private static int[][] xyArrow;

	private static int[][] xyItem;

	private static int[] index = new int[5] { -2, -1, 0, 1, 2 };

	private int dyArrow;

	private int[] dxArrow;

	private int page;

	private int maxpage;

	private int indexFocus;

	public static MyVector2 list;

	public static MyVector2 listUse;

	private static int num;

	private static int numMax;

	private Info_RadaScr2 focus_card;

	private int pxx;

	private int pyy;

	private int xClip;

	private int wClip;

	private int yClip;

	private int hClip;

	public RadarScr2()
	{
		TYPE_UI = true;
		Image2 img = mSystem2.loadImage("/radar/17.png");
		Image2 img2 = mSystem2.loadImage("/radar/3.png");
		Image2 img3 = mSystem2.loadImage("/radar/23.png");
		fraImgFocus = new FrameImage2(img, 28, 28);
		fraImgFocusNone = new FrameImage2(img2, 30, 30);
		fraEff = new FrameImage2(img3, 11, 11);
		imgUI = mSystem2.loadImage("/radar/0.png");
		imgArrow_Left = mSystem2.loadImage("/radar/1.png");
		imgArrow_Right = mSystem2.loadImage("/radar/2.png");
		imgUIText = mSystem2.loadImage("/radar/17.png");
		imgArrow_Down = mSystem2.loadImage("/radar/4.png");
		imgLock = mSystem2.loadImage("/radar/5.png");
		imgUse_0 = mSystem2.loadImage("/radar/6.png");
		imgRank = new Image2[7];
		for (int i = 0; i < 7; i++)
		{
			imgRank[i] = mSystem2.loadImage("/radar/" + (i + 7) + ".png");
		}
		imgUse = mSystem2.loadImage("/radar/14.png");
		imgBack = mSystem2.loadImage("/radar/15.png");
		imgChange = mSystem2.loadImage("/radar/16.png");
		imgUIText = mSystem2.loadImage("/radar/18.png");
		imgBar_1 = mSystem2.loadImage("/radar/19.png");
		imgPro_0 = mSystem2.loadImage("/radar/20.png");
		imgPro_1 = mSystem2.loadImage("/radar/21.png");
		imgBar_0 = mSystem2.loadImage("/radar/22.png");
		wUi = 200;
		hUi = 219;
		xUi = GameCanvas2.hw - (wUi + 40) / 2;
		yUi = GameCanvas2.hh - hUi / 2;
		xText = xUi + wUi - 81;
		yText = yUi + 29;
		wText = 120;
		hText = 80;
		xyArrow = new int[3][]
		{
			new int[2]
			{
				xUi + 34,
				yUi + hUi - 42
			},
			new int[2]
			{
				xUi + wUi / 2 - imgArrow_Down.getWidth() / 2,
				yUi + hUi / 2 + 33
			},
			new int[2]
			{
				xUi + wUi - 41,
				yUi + hUi - 42
			}
		};
		xyItem = new int[5][]
		{
			new int[2]
			{
				xUi + 25,
				yUi + hUi - 82
			},
			new int[2]
			{
				xUi + 57,
				yUi + hUi - 62
			},
			new int[2]
			{
				xUi + wUi / 2 - 14,
				yUi + hUi - 102
			},
			new int[2]
			{
				xUi + wUi - 57 - 28,
				yUi + hUi - 62
			},
			new int[2]
			{
				xUi + wUi - 25 - 28,
				yUi + hUi - 82
			}
		};
		dxArrow = new int[2];
		dyArrow = 0;
		xMon = xUi + 73;
		yMon = yUi + hUi / 2 + 5;
		yCmd = yUi + hUi - 22;
		xCmd = new int[3]
		{
			xUi + wUi / 2 - 8 - 80,
			xUi + wUi / 2 - 8,
			xUi + wUi / 2 - 8 + 80
		};
		dxCmd = new int[3];
		yClip = yText + 10 + 70;
		hClip = 0;
		list = new MyVector2();
		listUse = new MyVector2();
		page = 1;
		maxpage = 2;
	}

	public static RadarScr2 gI()
	{
		if (instance == null)
		{
			instance = new RadarScr2();
		}
		return instance;
	}

	public void SetRadarScr(MyVector2 list, int num, int numMax)
	{
		RadarScr2.list = list;
		SetNum(num, numMax);
		page = 1;
		indexFocus = 2;
		listIndex();
		TYPE_UI = true;
		SetListUse();
		if (TYPE_UI)
		{
			maxpage = list.size() / 5 + ((list.size() % 5 > 0) ? 1 : 0);
		}
		else
		{
			maxpage = listUse.size() / 5 + ((listUse.size() % 5 > 0) ? 1 : 0);
		}
	}

	public static void SetNum(int num, int numMax)
	{
		RadarScr2.num = num;
		RadarScr2.numMax = numMax;
	}

	public static void SetListUse()
	{
		listUse = new MyVector2(string.Empty);
		for (int i = 0; i < list.size(); i++)
		{
			Info_RadaScr2 info_RadaScr = (Info_RadaScr2)list.elementAt(i);
			if (info_RadaScr != null && info_RadaScr.isUse == 1)
			{
				listUse.addElement(info_RadaScr);
			}
		}
	}

	public void listIndex()
	{
		MyVector2 myVector = listUse;
		if (TYPE_UI)
		{
			myVector = list;
		}
		int num = (page - 1) * 5;
		int num2 = num + 5;
		for (int i = num; i < num2; i++)
		{
			if (i >= myVector.size())
			{
				index[i - num] = -1;
				continue;
			}
			Info_RadaScr2 info_RadaScr = (Info_RadaScr2)myVector.elementAt(i);
			if (info_RadaScr != null)
			{
				index[i - num] = info_RadaScr.id;
			}
		}
		cmyText = 0;
		hText = 0;
		SoundMn2.gI().radarItem();
	}

	public override void update()
	{
		try
		{
			if (hText < 80)
			{
				hText += 4;
				if (hText > 80)
				{
					hText = 80;
				}
			}
			focus_card = Info_RadaScr2.GetInfo(listUse, index[indexFocus]);
			if (TYPE_UI)
			{
				focus_card = Info_RadaScr2.GetInfo(list, index[indexFocus]);
			}
			GameScr2.gI().update();
			if (GameCanvas2.gameTick % 10 < 6)
			{
				if (GameCanvas2.gameTick % 2 == 0)
				{
					dyArrow--;
				}
			}
			else
			{
				dyArrow = 0;
			}
			if (focus_card != null)
			{
				int num = focus_card.amount * 100 / focus_card.max_amount;
				hClip = num * imgBar_1.getHeight() / 100;
				int num2 = RadarScr2.num * 100 / list.size();
				wClip = num2 * imgPro_1.getWidth() / 100;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("-upd-radaScr-null: " + ex.ToString());
		}
	}

	public override void updateKey()
	{
		if (!InfoDlg2.isLock)
		{
			if (GameCanvas2.isTouch && !ChatTextField2.gI().isShow && !GameCanvas2.menu.showMenu)
			{
				updateKeyTouchControl();
			}
			if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = false;
				doKeyText(1);
			}
			if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = false;
				doKeyText(-1);
			}
			if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] = false;
				doKeyItem(1);
			}
			if (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] = false;
				doKeyItem(0);
			}
			if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
				doClickUse(1);
			}
			if (GameCanvas2.keyPressed[13])
			{
				doClickUse(2);
			}
			if (GameCanvas2.keyPressed[12])
			{
				GameCanvas2.keyPressed[12] = false;
				doClickUse(0);
			}
			GameCanvas2.clearKeyPressed();
		}
	}

	private void doChangeUI()
	{
		TYPE_UI = !TYPE_UI;
		page = 1;
		indexFocus = 0;
		if (TYPE_UI)
		{
			maxpage = list.size() / 5 + ((list.size() % 5 > 0) ? 1 : 0);
		}
		else
		{
			maxpage = listUse.size() / 5 + ((listUse.size() % 5 > 0) ? 1 : 0);
		}
		listIndex();
	}

	private void updateKeyTouchControl()
	{
		if (GameCanvas2.isPointerClick)
		{
			for (int i = 0; i < 5; i++)
			{
				if (GameCanvas2.isPointerHoldIn(xyItem[i][0], xyItem[i][1], 30, 30) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease && i != indexFocus)
				{
					doClickItem(i);
				}
			}
			if (GameCanvas2.isPointerHoldIn(xyArrow[0][0] - 5, xyArrow[0][1] - 5, 20, 20))
			{
				if (GameCanvas2.isPointerDown)
				{
					dxArrow[0] = 1;
				}
				if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					doClickArrow(0);
					dxArrow[0] = 0;
				}
			}
			if (GameCanvas2.isPointerHoldIn(xyArrow[2][0] - 5, xyArrow[2][1] - 5, 20, 20))
			{
				if (GameCanvas2.isPointerDown)
				{
					dxArrow[1] = 1;
				}
				if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					doClickArrow(1);
					dxArrow[1] = 0;
				}
			}
			for (int j = 0; j < xCmd.Length; j++)
			{
				if (GameCanvas2.isPointerHoldIn(xCmd[j] - 5, yCmd - 5, 20, 20))
				{
					if (GameCanvas2.isPointerDown)
					{
						dxCmd[j] = 1;
					}
					if (GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
					{
						doClickUse(j);
						dxCmd[j] = 0;
					}
				}
			}
		}
		else
		{
			dxCmd[0] = 0;
			dxCmd[1] = 0;
			dxCmd[2] = 0;
			dxArrow[0] = 0;
			dxArrow[1] = 0;
		}
		if (!GameCanvas2.isPointerHoldIn(xText, 0, wText, yText + hText))
		{
			return;
		}
		if (GameCanvas2.isPointerMove)
		{
			if (pyy == 0)
			{
				pyy = GameCanvas2.py;
			}
			pxx = pyy - GameCanvas2.py;
			if (pxx != 0)
			{
				cmyText += pxx;
				pyy = GameCanvas2.py;
			}
			if (cmyText < 0)
			{
				cmyText = 0;
			}
			if (cmyText > focus_card.cp.lim)
			{
				cmyText = focus_card.cp.lim;
			}
		}
		else
		{
			pyy = 0;
			pyy = 0;
		}
	}

	private void doClickUse(int i)
	{
		switch (i)
		{
		case 0:
			doChangeUI();
			break;
		case 1:
			if (focus_card != null)
			{
				Service2.gI().SendRada(1, focus_card.id);
			}
			break;
		case 2:
			GameScr2.gI().switchToMe();
			break;
		}
		SoundMn2.gI().radarClick();
	}

	private void doClickArrow(int dir)
	{
		if (TYPE_UI)
		{
			maxpage = list.size() / 5 + ((list.size() % 5 > 0) ? 1 : 0);
		}
		else
		{
			maxpage = listUse.size() / 5 + ((listUse.size() % 5 > 0) ? 1 : 0);
		}
		int num = page;
		if (dir == 0)
		{
			if (page == 1)
			{
				return;
			}
			num--;
			if (num < 1)
			{
				num = 1;
			}
		}
		else
		{
			if (page == maxpage)
			{
				return;
			}
			num++;
			if (num > maxpage)
			{
				num = maxpage;
			}
		}
		if (num != page)
		{
			page = num;
			listIndex();
		}
	}

	private void doClickItem(int focus)
	{
		indexFocus = focus;
		listIndex();
	}

	private void doKeyText(int type)
	{
		cmyText += 12 * type;
		if (cmyText < 0)
		{
			cmyText = 0;
		}
		if (cmyText > focus_card.cp.lim)
		{
			cmyText = focus_card.cp.lim;
		}
	}

	private void doKeyItem(int type)
	{
		int num = indexFocus;
		int num2 = page;
		num = ((type != 0) ? (num - 1) : (num + 1));
		if (num >= index.Length)
		{
			if (page < maxpage)
			{
				num = 0;
				num2++;
			}
			else
			{
				num = index.Length - 1;
			}
		}
		if (num < 0)
		{
			if (page > 1)
			{
				num = index.Length - 1;
				num2--;
			}
			else
			{
				num = 0;
			}
		}
		if (num != indexFocus)
		{
			indexFocus = num;
			cmyText = 0;
			hText = 0;
		}
		if (num2 != page)
		{
			page = num2;
			listIndex();
		}
	}

	public override void paint(mGraphics2 g)
	{
		try
		{
			GameScr2.gI().paint(g);
			g.translate(-GameScr2.cmx, -GameScr2.cmy);
			g.translate(0, GameCanvas2.transY);
			GameScr2.resetTranslate(g);
			g.drawImage(imgUI, xUi, yUi, 0);
			g.drawImage(imgPro_0, xUi + wUi / 2 - imgPro_0.getWidth() / 2, yUi - imgPro_0.getHeight() / 2 - 2, 0);
			g.setClip(xUi + wUi / 2 - imgPro_0.getWidth() / 2 + 13, yUi - imgPro_0.getHeight() / 2 + 3, wClip, imgPro_0.getHeight());
			g.drawImage(imgPro_1, xUi + wUi / 2 - imgPro_0.getWidth() / 2 + 13, yUi - imgPro_0.getHeight() / 2 + 3, 0);
			GameScr2.resetTranslate(g);
			g.drawImage(imgChange, xCmd[0], yCmd + dxCmd[0], 0);
			g.drawImage(imgUse_0, xCmd[1], yCmd + dxCmd[1], 0);
			g.drawImage(imgBack, xCmd[2], yCmd + dxCmd[2], 0);
			if (TYPE_UI)
			{
				g.drawRegion(imgUse, 0, 0, 17, 17, 0, xCmd[1], yCmd + dxCmd[1], 0);
			}
			else
			{
				g.drawRegion(imgUse, 0, 0, 17, 17, 1, xCmd[1], yCmd + dxCmd[1], 0);
			}
			if (focus_card != null)
			{
				g.setClip(xUi + 30, yUi + 13, wUi - 60, hUi / 2);
				focus_card.paintInfo(g, xMon, yMon);
				GameScr2.resetTranslate(g);
				mFont2.tahoma_7b_yellow.drawString(g, ((focus_card.level <= 0) ? " " : ("Lv." + focus_card.level + " ")) + focus_card.name, xUi + wUi / 2, yUi + 15, 2);
				mFont2.tahoma_7_white.drawString(g, "no." + focus_card.no, xUi + 30, yText - 2, 0);
				g.drawImage(imgBar_0, xUi + 36, yText + 10, 0);
				g.setClip(xUi + 36, yClip - hClip, 7, hClip);
				g.drawImage(imgBar_1, xUi + 36, yText + 10, 0);
				GameScr2.resetTranslate(g);
				g.drawImage(imgRank[focus_card.rank], xUi + 39 - 5 + 14, yText + 12, 0);
			}
			g.setClip(xText, yText, wText + 5, hText + 8);
			if (focus_card != null)
			{
				g.drawImage(imgUIText, xText, yText, 0);
			}
			GameScr2.resetTranslate(g);
			g.setClip(xText, yText + 1, wText, hText + 5);
			if (focus_card != null && focus_card.cp != null)
			{
				if (focus_card.cp.says == null)
				{
					return;
				}
				focus_card.cp.paintRada(g, cmyText);
			}
			GameScr2.resetTranslate(g);
			if ((!TYPE_UI && listUse.size() > 5) || TYPE_UI)
			{
				if (page > 1)
				{
					g.drawImage(imgArrow_Left, xyArrow[0][0], xyArrow[0][1] + dxArrow[0], 0);
				}
				if (page < maxpage)
				{
					g.drawImage(imgArrow_Right, xyArrow[2][0], xyArrow[2][1] + dxArrow[1], 0);
				}
			}
			for (int i = 0; i < index.Length; i++)
			{
				int num = 0;
				int num2 = 0;
				int idx = 0;
				if (i == indexFocus)
				{
					num = dyArrow;
					num2 = -10;
					idx = 1;
					g.drawImage(imgArrow_Down, xyItem[i][0] + 10, xyItem[i][1] + dyArrow + 29 + num2, 0);
				}
				Info_RadaScr2 info = Info_RadaScr2.GetInfo(listUse, index[i]);
				if (TYPE_UI)
				{
					info = Info_RadaScr2.GetInfo(list, index[i]);
				}
				if (info != null)
				{
					fraImgFocus.drawFrame(info.rank, xyItem[i][0], xyItem[i][1] + num + num2, 0, 0, g);
					SmallImage2.drawSmallImage(g, info.idIcon, xyItem[i][0] + 14, xyItem[i][1] + 14 + num + num2, 0, StaticObj2.VCENTER_HCENTER);
					info.paintEff(g, xyItem[i][0], xyItem[i][1] + num + num2);
					if (info.level == 0)
					{
						g.drawImage(imgLock, xyItem[i][0], xyItem[i][1] + num + num2, 0);
					}
					if (i == indexFocus)
					{
						fraImgFocus.drawFrame(7, xyItem[i][0], xyItem[i][1] + num + num2, 0, 0, g);
					}
					if (info.isUse == 1)
					{
						fraImgFocus.drawFrame(8, xyItem[i][0], xyItem[i][1] + num + num2, 0, 0, g);
					}
				}
				else
				{
					fraImgFocusNone.drawFrame(idx, xyItem[i][0] - 1, xyItem[i][1] - 1 + num + num2, 0, 0, g);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("-pnt-radaScr-null: " + ex.ToString());
		}
	}

	public override void switchToMe()
	{
		GameScr2.isPaintOther = true;
		base.switchToMe();
	}
}
