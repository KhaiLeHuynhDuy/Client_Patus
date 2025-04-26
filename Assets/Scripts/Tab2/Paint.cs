public class Paint2
{
	public static int COLORBACKGROUND = 15787715;

	public static int COLORLIGHT = 16383818;

	public static int COLORDARK = 3937280;

	public static int COLORBORDER = 15224576;

	public static int COLORFOCUS = 16777215;

	public static Image2 imgBg;

	public static Image2 imgLogo;

	public static Image2 imgLB;

	public static Image2 imgLT;

	public static Image2 imgRB;

	public static Image2 imgRT;

	public static Image2 imgChuong;

	public static Image2 imgSelectBoard;

	public static Image2 imgtoiSmall;

	public static Image2 imgTayTren;

	public static Image2 imgTayDuoi;

	public static Image2[] imgTick = new Image2[2];

	public static Image2[] imgMsg = new Image2[2];

	public static Image2[] goc = new Image2[6];

	public static int hTab = 24;

	public static int lenCaption = 0;

	public int[] color = new int[7] { 15970400, 13479911, 2250052, 16374659, 15906669, 12931125, 3108954 };

	public static Image2 imgCheck = GameCanvas2.loadImage("/mainImage/myTexture2dcheck.png");

	public static void loadbg()
	{
		for (int i = 0; i < goc.Length; i++)
		{
			goc[i] = GameCanvas2.loadImage("/mainImage/myTexture2dgoc" + (i + 1) + ".png");
		}
	}

	public void paintDefaultBg(mGraphics2 g)
	{
		g.setColor(8916494);
		g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
		g.drawImage(imgBg, GameCanvas2.w / 2, GameCanvas2.h / 2 - hTab / 2 - 1, 3);
		g.drawImage(imgLT, 0, 0, 0);
		g.drawImage(imgRT, GameCanvas2.w, 0, mGraphics2.TOP | mGraphics2.RIGHT);
		g.drawImage(imgLB, 0, GameCanvas2.h - hTab - 2, mGraphics2.BOTTOM | mGraphics2.LEFT);
		g.drawImage(imgRB, GameCanvas2.w, GameCanvas2.h - hTab - 2, mGraphics2.BOTTOM | mGraphics2.RIGHT);
		g.setColor(16774843);
		g.drawRect(0, 0, GameCanvas2.w, 0);
		g.drawRect(0, GameCanvas2.h - hTab - 2, GameCanvas2.w, 0);
		g.drawRect(0, 0, 0, GameCanvas2.h - hTab);
		g.drawRect(GameCanvas2.w - 1, 0, 0, GameCanvas2.h - hTab);
	}

	public void paintfillDefaultBg(mGraphics2 g)
	{
		g.setColor(205314);
		g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
	}

	public void repaintCircleBg()
	{
	}

	public void paintSolidBg(mGraphics2 g)
	{
	}

	public void paintDefaultPopup(mGraphics2 g, int x, int y, int w, int h)
	{
		g.setColor(8411138);
		g.fillRect(x, y, w, h);
		g.setColor(13606712);
		g.drawRect(x, y, w, h);
	}

	public void paintWhitePopup(mGraphics2 g, int y, int x, int width, int height)
	{
		g.setColor(16776363);
		g.fillRect(x, y, width, height);
		g.setColor(0);
		g.drawRect(x - 1, y - 1, width + 1, height + 1);
	}

	public void paintDefaultPopupH(mGraphics2 g, int h)
	{
		g.setColor(14279153);
		g.fillRect(8, GameCanvas2.h - (h + 37), GameCanvas2.w - 16, h + 4);
		g.setColor(4682453);
		g.fillRect(10, GameCanvas2.h - (h + 35), GameCanvas2.w - 20, h);
	}

	public void paintCmdBar(mGraphics2 g, Command2 left, Command2 center, Command2 right)
	{
		mFont2 mFont2 = ((!GameCanvas2.isTouch) ? mFont2.tahoma_7b_dark : mFont2.tahoma_7b_dark);
		int num = 3;
		if (left != null)
		{
			lenCaption = mFont2.getWidth(left.caption);
			if (lenCaption > 0)
			{
				if (left.x >= 0 && left.y > 0)
				{
					left.paint(g);
				}
				else
				{
					g.drawImage((mScreen2.keyTouch != 0) ? GameScr2.imgLbtn : GameScr2.imgLbtnFocus, 1, GameCanvas2.h - mScreen2.cmdH - 1, 0);
					mFont2.drawString(g, left.caption, 35, GameCanvas2.h - mScreen2.cmdH + 3 + num, 2);
				}
			}
		}
		if (center != null)
		{
			lenCaption = mFont2.getWidth(center.caption);
			if (lenCaption > 0)
			{
				if (center.x > 0 && center.y > 0)
				{
					center.paint(g);
				}
				else
				{
					g.drawImage((mScreen2.keyTouch != 1) ? GameScr2.imgLbtn : GameScr2.imgLbtnFocus, GameCanvas2.hw - 35, GameCanvas2.h - mScreen2.cmdH - 1, 0);
					mFont2.drawString(g, center.caption, GameCanvas2.hw, GameCanvas2.h - mScreen2.cmdH + 3 + num, 2);
				}
			}
		}
		if (right == null)
		{
			return;
		}
		lenCaption = mFont2.getWidth(right.caption);
		if (lenCaption > 0)
		{
			if (right.x > 0 && right.y > 0)
			{
				right.paint(g);
				return;
			}
			g.drawImage((mScreen2.keyTouch != 2) ? GameScr2.imgLbtn : GameScr2.imgLbtnFocus, GameCanvas2.w - 71, GameCanvas2.h - mScreen2.cmdH - 1, 0);
			mFont2.drawString(g, right.caption, GameCanvas2.w - 35, GameCanvas2.h - mScreen2.cmdH + 3 + num, 2);
		}
	}

	public void paintTabSoft(mGraphics2 g)
	{
	}

	public void paintSelect(mGraphics2 g, int x, int y, int w, int h)
	{
		g.setColor(16774843);
		g.fillRect(x, y, w, h);
	}

	public void paintLogo(mGraphics2 g, int x, int y)
	{
		g.drawImage(imgLogo, x, y, 3);
	}

	public void paintHotline(mGraphics2 g, string number)
	{
	}

	public void paintBackMenu(mGraphics2 g, int x, int y, int w, int h, bool iss)
	{
		if (iss)
		{
			g.setColor(16646144);
			g.fillRoundRect(x, y, w, h, 10, 10);
			g.setColor(16770612);
		}
		else
		{
			g.setColor(16775097);
			g.fillRoundRect(x, y, w, h, 10, 10);
			g.setColor(16775097);
		}
		g.fillRoundRect(x + 3, y + 3, w - 6, h - 6, 10, 10);
	}

	public void paintMsgBG(mGraphics2 g, int x, int y, int w, int h, string title, string subTitle, string check)
	{
	}

	public void paintDefaultScrList(mGraphics2 g, string title, string subTitle, string check)
	{
	}

	public void paintCheck(mGraphics2 g, int x, int y, int index)
	{
		g.drawImage(imgTick[1], x, y, 3);
		if (index == 1)
		{
			g.drawImage(imgTick[0], x + 1, y - 3, 3);
		}
	}

	public void paintImgMsg(mGraphics2 g, int x, int y, int index)
	{
		g.drawImage(imgMsg[index], x, y, 0);
	}

	public void paintTitleBoard(mGraphics2 g, int roomId)
	{
		paintDefaultBg(g);
	}

	public void paintCheckPass(mGraphics2 g, int x, int y, bool check, bool focus)
	{
		if (focus)
		{
			g.drawRegion(imgCheck, 0, ((!check) ? 1 : 3) * 18, 20, 18, 0, x, y, 0);
		}
		else
		{
			g.drawRegion(imgCheck, 0, (check ? 2 : 0) * 18, 20, 18, 0, x, y, 0);
		}
	}

	public void paintInputDlg(mGraphics2 g, int x, int y, int w, int h, string[] str)
	{
		paintFrame(x, y, w, h, g);
		int num = y + 20 - mFont2.tahoma_8b.getHeight();
		int num2 = 0;
		int num3 = num;
		while (num2 < str.Length)
		{
			mFont2.tahoma_8b.drawString(g, str[num2], x + w / 2, num3, 2);
			num2++;
			num3 += mFont2.tahoma_8b.getHeight();
		}
	}

	public void paintIconMainMenu(mGraphics2 g, int x, int y, bool iss, bool isSe, int i, int wStr)
	{
	}

	public void paintLineRoom(mGraphics2 g, int x, int y, int xTo, int yTo)
	{
		g.setColor(16774843);
		g.drawLine(x, y, xTo, yTo);
	}

	public void paintCellContaint(mGraphics2 g, int x, int y, int w, int h, bool iss)
	{
		if (iss)
		{
			g.setColor(13132288);
			g.fillRect(x + 2, y + 2, w - 3, w - 3);
		}
		g.setColor(3502080);
		g.drawRect(x, y, w, w);
	}

	public void paintScroll(mGraphics2 g, int x, int y, int h)
	{
		g.setColor(3847752);
		g.fillRect(x, y, 4, h);
	}

	public int[] getColorMsg()
	{
		return color;
	}

	public void paintLogo(mGraphics2 g)
	{
		g.setColor(8916494);
		g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
		g.drawImage(imgLogo, GameCanvas2.h >> 1, GameCanvas2.w >> 1, 3);
	}

	public void paintTextLogin(mGraphics2 g, bool isRes)
	{
		int num = 0;
		if (!isRes && GameCanvas2.h <= 240)
		{
			num = 15;
		}
		mFont2.tahoma_7b_green2.drawString(g, mResources2.LOGINLABELS[0], GameCanvas2.hw, GameCanvas2.hh + 60 - num, 2);
		mFont2.tahoma_7b_green2.drawString(g, mResources2.LOGINLABELS[1], GameCanvas2.hw, GameCanvas2.hh + 73 - num, 2);
	}

	public void paintSellectBoard(mGraphics2 g, int x, int y, int w, int h)
	{
		g.drawImage(imgSelectBoard, x - 7, y, 0);
	}

	public int isRegisterUsingWAP()
	{
		return 0;
	}

	public string getCard()
	{
		return "/vmg/card.on";
	}

	public void paintSellectedShop(mGraphics2 g, int x, int y, int w, int h)
	{
		g.setColor(16777215);
		g.drawRect(x, y, 40, 40);
		g.drawRect(x + 1, y + 1, 38, 38);
	}

	public string getUrlUpdateGame()
	{
		return "http://wap.teamobi.com?info=checkupdate&game=3&version=" + GameMidlet2.VERSION + "&provider=" + GameMidlet2.PROVIDER;
	}

	public void doSelect(int focus)
	{
	}

	public void paintPopUp(int x, int y, int w, int h, mGraphics2 g)
	{
		g.setColor(9340251);
		g.drawRect(x + 18, y, (w - 36) / 2 - 32, h);
		g.drawRect(x + 18 + (w - 36) / 2 + 32, y, (w - 36) / 2 - 22, h);
		g.drawRect(x, y + 8, w, h - 17);
		g.setColor(COLORBACKGROUND);
		g.fillRect(x + 18, y + 3, (w - 36) / 2 - 32, h - 4);
		g.fillRect(x + 18 + (w - 36) / 2 + 31, y + 3, (w - 38) / 2 - 22, h - 4);
		g.fillRect(x + 1, y + 6, w - 1, h - 11);
		g.setColor(14667919);
		g.fillRect(x + 18, y + 1, (w - 36) / 2 - 32, 2);
		g.fillRect(x + 18 + (w - 36) / 2 + 32, y + 1, (w - 36) / 2 - 12, 2);
		g.fillRect(x + 18, y + h - 2, (w - 36) / 2 - 31, 2);
		g.fillRect(x + 18 + (w - 36) / 2 + 32, y + h - 2, (w - 36) / 2 - 31, 2);
		g.fillRect(x + 1, y + 11, 2, h - 18);
		g.fillRect(x + w - 2, y + 11, 2, h - 18);
		g.drawImage(goc[0], x - 3, y - 2, mGraphics2.TOP | mGraphics2.LEFT);
		g.drawImage(goc[2], x + w + 3, y - 2, StaticObj2.TOP_RIGHT);
		g.drawImage(goc[1], x - 3, y + h + 3, StaticObj2.BOTTOM_LEFT);
		g.drawImage(goc[3], x + w + 4, y + h + 2, StaticObj2.BOTTOM_RIGHT);
		g.drawImage(goc[4], x + w / 2, y, StaticObj2.TOP_CENTER);
		g.drawImage(goc[5], x + w / 2, y + h + 1, StaticObj2.BOTTOM_HCENTER);
	}

	public void paintFrame(int x, int y, int w, int h, mGraphics2 g)
	{
		g.setColor(13524492);
		g.drawRect(x + 6, y, w - 12, h);
		g.drawRect(x, y + 6, w, h - 12);
		g.drawRect(x + 7, y + 1, w - 14, h - 2);
		g.drawRect(x + 1, y + 7, w - 2, h - 14);
		g.setColor(14338484);
		g.fillRect(x + 8, y + 2, w - 16, h - 3);
		g.fillRect(x + 2, y + 8, w - 3, h - 14);
		g.drawImage(GameCanvas2.imgBorder[2], x, y, mGraphics2.TOP | mGraphics2.LEFT);
		g.drawRegion(GameCanvas2.imgBorder[2], 0, 0, 16, 16, 2, x + w + 1, y, StaticObj2.TOP_RIGHT);
		g.drawRegion(GameCanvas2.imgBorder[2], 0, 0, 16, 16, 1, x, y + h + 1, StaticObj2.BOTTOM_LEFT);
		g.drawRegion(GameCanvas2.imgBorder[2], 0, 0, 16, 16, 3, x + w + 1, y + h + 1, StaticObj2.BOTTOM_RIGHT);
	}

	public void paintFrameSimple(int x, int y, int w, int h, mGraphics2 g)
	{
		g.setColor(6702080);
		g.fillRect(x, y, w, h);
		g.setColor(14338484);
		g.fillRect(x + 1, y + 1, w - 2, h - 2);
	}

	public void paintFrameBorder(int x, int y, int w, int h, mGraphics2 g)
	{
		paintFrame(x, y, w, h, g);
	}

	public void paintFrameInside(int x, int y, int w, int h, mGraphics2 g)
	{
		g.setColor(COLORBACKGROUND);
		g.fillRect(x, y, w, h);
	}

	public void paintFrameInsideSelected(int x, int y, int w, int h, mGraphics2 g)
	{
		g.setColor(COLORLIGHT);
		g.fillRect(x, y, w, h);
	}
}
