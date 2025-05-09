public class Info2 : IActionListener2
{
	public MyVector2 infoWaitToShow = new MyVector2();

	public InfoItem2 info;

	public int p1 = 5;

	public int p2;

	public int p3;

	public int x;

	public int strWidth;

	public int limLeft = 2;

	public int hI = 20;

	public int xChar;

	public int yChar;

	public int sayWidth = 100;

	public int sayRun;

	public string[] says;

	public int cx;

	public int cy;

	public int ch;

	public bool outSide;

	public int f;

	public int tF;

	public Image2 img;

	public static Image2 gocnhon = GameCanvas2.loadImage("/mainImage/myTexture2dgocnhon.png");

	public int time;

	public int timeW;

	public int type;

	public int X;

	public int Y;

	public int W;

	public int H;

	public void hide()
	{
		says = null;
		infoWaitToShow.removeAllElements();
	}

	public void paint(mGraphics2 g, int x, int y, int dir)
	{
		if (infoWaitToShow.size() == 0)
		{
			return;
		}
		g.translate(x, y);
		if (says != null && says.Length != 0 && type != 1)
		{
			if (outSide)
			{
				cx -= GameScr2.cmx;
				cy -= GameScr2.cmy;
				cy += 35;
			}
			int num = ((mGraphics2.zoomLevel != 1) ? 10 : 0);
			if (info.charInfo == null)
			{
				PopUp2.paintPopUp(g, X, Y, W, H, 16777215, isButton: false);
			}
			else
			{
				mSystem2.paintPopUp2(g, X - 23, Y - num / 2, W + 15, H + ((!GameCanvas2.isTouch) ? 14 : 0) + num);
			}
			if (info.charInfo == null)
			{
				g.drawRegion(gocnhon, 0, 0, 9, 8, (dir != 1) ? 2 : 0, cx - 3 + ((dir != 1) ? 20 : (-15)), cy - ch - 20 + sayRun + 2, mGraphics2.TOP | mGraphics2.HCENTER);
			}
			int num2 = -1;
			for (int i = 0; i < says.Length; i++)
			{
				mFont2 mFont2 = mFont2.tahoma_7;
				int num3 = 2;
				string text = says[i];
				int num4 = 0;
				if (says[i].StartsWith("|"))
				{
					string[] array = Res2.split(says[i], "|", 0);
					if (array.Length == 3)
					{
						text = array[2];
					}
					if (array.Length == 4)
					{
						text = array[3];
						num3 = int.Parse(array[2]);
					}
					num4 = int.Parse(array[1]);
					num2 = num4;
				}
				else
				{
					num4 = num2;
				}
				switch (num4)
				{
					case -1:
						mFont2 = mFont2.tahoma_7;
						break;
					case 0:
						mFont2 = mFont2.tahoma_7b_dark;
						break;
					case 1:
						mFont2 = mFont2.tahoma_7b_green;
						break;
					case 2:
						mFont2 = mFont2.tahoma_7b_blue;
						break;
					case 3:
						mFont2 = mFont2.tahoma_7_red;
						break;
					case 4:
						mFont2 = mFont2.tahoma_7_green;
						break;
					case 5:
						mFont2 = mFont2.tahoma_7_blue;
						break;
					case 7:
						mFont2 = mFont2.tahoma_7b_red;
						break;
				}
				if (info.charInfo == null)
				{
					mFont2.drawString(g, text, cx, cy - ch - 15 + sayRun + i * 12 - says.Length * 12 - 9, 2);
					continue;
				}
				int num5 = X - 23;
				int num6 = Y - num / 2;
				int num7 = ((mSystem2.clientType != 1) ? (W + 25) : (W + 28));
				int num8 = H + ((!GameCanvas2.isTouch) ? 14 : 0) + num;
				g.setColor(4465169);
				g.fillRect(num5, num6 + num8, num7, 2);
				int num9 = info.timeCount * num7 / info.maxTime;
				if (num9 < 0)
				{
					num9 = 0;
				}
				g.setColor(43758);
				g.fillRect(num5, num6 + num8, num9, 2);
				if (info.timeCount == 0)
				{
					return;
				}
				info.charInfo.paintHead(g, X + 5, Y + H / 2, 0);
				if (mGraphics2.zoomLevel == 1)
				{
					((!info.isChatServer) ? mFont2.tahoma_7b_greenSmall : mFont2.tahoma_7b_yellowSmall2).drawString(g, (info.charInfo.isTichXanh ? "     " : string.Empty) + info.charInfo.cName, X + 12, Y + 3, 0);
					if (info.charInfo.isTichDo)
					{
						MainMod2.PaintTicks(g, false, X + 8, Y + 2);
					}
					else if (info.charInfo.isTichXanh)
					{
						MainMod2.PaintTicks(g, true, X + 8, Y + 2);
					}
				}
				else
				{
					((!info.isChatServer) ? mFont2.tahoma_7b_greenSmall : mFont2.tahoma_7b_yellowSmall2).drawString(g, (info.charInfo.isTichXanh ? "     " : string.Empty) + info.charInfo.cName, X + 12, Y - 3, 0);
					if (info.charInfo.isTichDo)
					{
						MainMod2.PaintTicks(g, false, X + 9, Y - 2);
					}
					else if (info.charInfo.isTichXanh)
					{
						MainMod2.PaintTicks(g, true, X + 9, Y - 2);
					}
				}
				if (!GameCanvas2.isTouch)
				{
					if (!TField2.isQwerty)
					{
						mFont2.tahoma_7b_green2Small.drawString(g, "Nhấn # để chat", X + W / 2 + 10, Y + H, mFont2.CENTER);
					}
					else
					{
						mFont2.tahoma_7b_green2Small.drawString(g, "Nhấn Y để chat", X + W / 2 + 10, Y + H, mFont2.CENTER);
					}
				}
				if (mGraphics2.zoomLevel == 1)
				{
					TextInfo2.paint(g, text, X + 14, Y + H / 2 + 2, W - 16, H, mFont2.tahoma_7_whiteSmall);
					continue;
				}
				string[] array2 = mFont2.tahoma_7_whiteSmall.splitFontArray(text, 120);
				for (int j = 0; j < array2.Length; j++)
				{
					mFont2.tahoma_7_whiteSmall.drawString(g, array2[j], X + 12, Y + 12 + j * 12 - 3, 0);
				}
				GameCanvas2.resetTrans(g);
			}
			if (info.charInfo == null)
			{
			}
		}
		g.translate(-x, -y);
	}

	public void update()
	{
		if (infoWaitToShow.size() == 0 || info.timeCount != 0)
		{
			return;
		}
		time++;
		if (time >= info.speed)
		{
			time = 0;
			infoWaitToShow.removeElementAt(0);
			if (infoWaitToShow.size() != 0)
			{
				InfoItem2 infoItem = (InfoItem2)infoWaitToShow.firstElement();
				info = infoItem;
				getInfo();
			}
		}
	}

	public void getInfo()
	{
		sayWidth = 100;
		if (GameCanvas2.w == 128)
		{
			sayWidth = 128;
		}
		int num;
		if (info.charInfo != null)
		{
			says = new string[1] { info.s };
			if (mGraphics2.zoomLevel == 1)
			{
				num = says.Length;
			}
			else
			{
				string[] array = mFont2.tahoma_7_whiteSmall.splitFontArray(info.s, 120);
				num = array.Length;
			}
		}
		else
		{
			says = mFont2.tahoma_7.splitFontArray(info.s, sayWidth - 10);
			num = says.Length;
		}
		sayRun = 7;
		X = cx - sayWidth / 2 - 1;
		Y = cy - ch - 15 + sayRun - num * 12 - 15;
		W = sayWidth + 2 + ((info.charInfo != null) ? 30 : 0);
		H = (num + 1) * 12 + 1 + ((info.charInfo != null) ? 5 : 0);
	}

	public void addInfo(string s, int Type, Char2 cInfo, bool isChatServer)
	{
		type = Type;
		if (GameCanvas2.w == 128)
		{
			limLeft = 1;
		}
		if (infoWaitToShow.size() > 10)
		{
			infoWaitToShow.removeElementAt(0);
		}
		if (infoWaitToShow.size() <= 0 || s.Equals(((InfoItem2)infoWaitToShow.lastElement()).s))
		{
		}
		InfoItem2 infoItem = new InfoItem2(s);
		if (type == 0)
		{
			infoItem.speed = s.Length;
		}
		if (infoItem.speed < 70)
		{
			infoItem.speed = 70;
		}
		if (type == 1)
		{
			infoItem.speed = 10000000;
		}
		if (type == 3)
		{
			infoItem.speed = 300;
			infoItem.last = mSystem2.currentTimeMillis();
			infoItem.maxTime = infoItem.timeCount = 80;
		}
		if (cInfo != null)
		{
			infoItem.charInfo = cInfo;
			infoItem.isChatServer = isChatServer;
			GameCanvas2.panel.addChatMessage(infoItem);
			if (GameCanvas2.isTouch && GameCanvas2.panel.isViewChatServer)
			{
				GameScr2.info2.cmdChat = new Command2(mResources2.CHAT, this, 1000, infoItem);
			}
		}
		if ((cInfo != null && GameCanvas2.panel.isViewChatServer) || cInfo == null)
		{
			infoWaitToShow.addElement(infoItem);
		}
		if (infoWaitToShow.size() == 1)
		{
			info = (InfoItem2)infoWaitToShow.firstElement();
			getInfo();
		}
		if (GameCanvas2.isTouch && cInfo != null && GameCanvas2.panel.isViewChatServer && GameCanvas2.w - 50 > 155 + W)
		{
			GameScr2.info2.cmdChat.x = GameCanvas2.w - W - 50;
			GameScr2.info2.cmdChat.y = 35;
		}
	}

	public void addInfo(string s, int speed, mFont2 f)
	{
		if (GameCanvas2.w == 128)
		{
			limLeft = 1;
		}
		if (infoWaitToShow.size() > 10)
		{
			infoWaitToShow.removeElementAt(0);
		}
		infoWaitToShow.addElement(new InfoItem2(s, f, speed));
	}

	public bool isEmpty()
	{
		return p1 == 5 && infoWaitToShow.size() == 0;
	}

	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			ChatTextField2.gI().startChat(GameScr2.gI(), mResources2.chat_player);
		}
	}

	public void onCancelChat()
	{
	}
}
