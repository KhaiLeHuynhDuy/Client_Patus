using System.Threading;
using Mod2.XMAP;

public class InfoMe2
{
	public static InfoMe2 me;

	public int[][] charId = new int[3][];

	public Info2 info = new Info2();

	public int dir;

	public int f;

	public int tF;

	public int cmtoY;

	public int cmy;

	public int cmdy;

	public int cmvy;

	public int cmyLim;

	public int cmtoX;

	public int cmx;

	public int cmdx;

	public int cmvx;

	public int cmxLim;

	public bool isDone;

	public bool isUpdate = true;

	public int timeDelay;

	public int playerID;

	public int timeCount;

	public Command2 cmdChat;

	public bool isShow;

	public InfoMe2()
	{
		for (int i = 0; i < charId.Length; i++)
		{
			charId[i] = new int[3];
		}
	}

	public static InfoMe2 gI()
	{
		if (me == null)
		{
			me = new InfoMe2();
		}
		return me;
	}

	public void loadCharId()
	{
		for (int i = 0; i < charId.Length; i++)
		{
			charId[i] = new int[3];
		}
	}

	public void paint(mGraphics2 g)
	{
		if ((Equals(GameScr2.info2) && GameScr2.gI().isVS()) || (Equals(GameScr2.info2) && GameScr2.gI().popUpYesNo != null) || !GameScr2.isPaint || (GameCanvas2.currentScreen != GameScr2.gI() && GameCanvas2.currentScreen != CrackBallScr2.gI()) || ChatPopup2.serverChatPopUp != null || !isUpdate || Char2.ischangingMap || (GameCanvas2.panel.isShow && Equals(GameScr2.info2)))
		{
			return;
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
		if (info != null)
		{
			info.paint(g, cmx, cmy, dir);
			if (info.info == null || info.info.charInfo == null || cmdChat != null || !GameCanvas2.isTouch)
			{
			}
			if (info.info != null && info.info.charInfo != null && cmdChat == null)
			{
			}
		}
		if (info.info != null && info.info.charInfo == null && charId != null)
		{
			SmallImage2.drawSmallImage(g, charId[Char2.myCharz().cgender][f], cmx, cmy + 3 + ((GameCanvas2.gameTick % 10 > 5) ? 1 : 0), (dir != 1) ? 2 : 0, StaticObj2.VCENTER_HCENTER);
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
	}

	public void hide()
	{
		info.hide();
	}

	public void moveCamera()
	{
		if (cmy != cmtoY)
		{
			cmvy = cmtoY - cmy << 2;
			cmdy += cmvy;
			cmy += cmdy >> 4;
			cmdy &= 15;
		}
		if (cmx != cmtoX)
		{
			cmvx = cmtoX - cmx << 2;
			cmdx += cmvx;
			cmx += cmdx >> 4;
			cmdx &= 15;
		}
		tF++;
		if (tF == 5)
		{
			tF = 0;
			if (f == 0)
			{
				f = 1;
			}
			else
			{
				f = 0;
			}
		}
	}

	public void doClick(int t)
	{
		timeDelay = t;
	}

	public void update()
	{
		if (info != null && info.infoWaitToShow != null && info.infoWaitToShow.size() == 0 && cmy != -40)
		{
			info.timeW--;
			if (info.timeW <= 0)
			{
				cmy = -40;
				info.time = 0;
				info.infoWaitToShow.removeAllElements();
				info.says = null;
				info.timeW = 200;
			}
		}
		if ((Equals(GameScr2.info2) && GameScr2.gI().popUpYesNo != null) || !isUpdate)
		{
			return;
		}
		moveCamera();
		if (info == null || (info != null && info.info == null))
		{
			return;
		}
		if (!isDone)
		{
			if (timeDelay > 0)
			{
				timeDelay--;
				if (timeDelay == 0)
				{
					GameCanvas2.panel.setTypeMessage();
					GameCanvas2.panel.show();
				}
			}
			if (GameCanvas2.gameTick % 3 == 0)
			{
				if (Char2.myCharz().cdir == 1)
				{
					cmtoX = Char2.myCharz().cx - 20 - GameScr2.cmx;
				}
				if (Char2.myCharz().cdir == -1)
				{
					cmtoX = Char2.myCharz().cx + 20 - GameScr2.cmx;
				}
				if (cmtoX <= 24)
				{
					cmtoX += info.sayWidth / 2;
				}
				if (cmtoX >= GameCanvas2.w - 24)
				{
					cmtoX -= info.sayWidth / 2;
				}
				cmtoY = Char2.myCharz().cy - 40 - GameScr2.cmy;
				if (info.says != null && cmtoY < (info.says.Length + 1) * 12 + 10)
				{
					cmtoY = (info.says.Length + 1) * 12 + 10;
				}
				if (info.info.charInfo != null)
				{
					if (GameCanvas2.w - 50 > 155 + info.W)
					{
						cmtoX = GameCanvas2.w - 60 - info.W / 2;
						cmtoY = info.H + 10;
					}
					else
					{
						cmtoX = GameCanvas2.w - 20 - info.W / 2;
						cmtoY = 45 + info.H;
						if (GameCanvas2.w > GameCanvas2.h || GameCanvas2.w < 220)
						{
							cmtoX = GameCanvas2.w - 20 - info.W / 2;
							cmtoY = info.H + 10;
						}
					}
				}
			}
			if (cmx > Char2.myCharz().cx - GameScr2.cmx)
			{
				dir = -1;
			}
			else
			{
				dir = 1;
			}
		}
		if (info.info == null)
		{
			return;
		}
		if (info.infoWaitToShow.size() > 1)
		{
			if (info.info.timeCount == 0)
			{
				info.time++;
				if (info.time >= info.info.speed)
				{
					info.time = 0;
					info.infoWaitToShow.removeElementAt(0);
					InfoItem2 infoItem = (InfoItem2)info.infoWaitToShow.firstElement();
					info.info = infoItem;
					info.getInfo();
				}
				return;
			}
			info.info.curr = mSystem2.currentTimeMillis();
			if (info.info.curr - info.info.last >= 100)
			{
				info.info.last = mSystem2.currentTimeMillis();
				info.info.timeCount--;
			}
			if (info.info.timeCount == 0)
			{
				info.infoWaitToShow.removeElementAt(0);
				if (info.infoWaitToShow.size() != 0)
				{
					InfoItem2 infoItem2 = (InfoItem2)info.infoWaitToShow.firstElement();
					info.info = infoItem2;
					info.getInfo();
				}
			}
		}
		else
		{
			if (info.infoWaitToShow.size() != 1)
			{
				return;
			}
			if (info.info.timeCount == 0)
			{
				info.time++;
				if (info.time >= info.info.speed)
				{
					isDone = true;
				}
				if (info.time == info.info.speed)
				{
					cmtoY = -40;
					cmtoX = Char2.myCharz().cx - GameScr2.cmx + ((Char2.myCharz().cdir != 1) ? 20 : (-20));
				}
				if (info.time >= info.info.speed + 20)
				{
					info.time = 0;
					info.infoWaitToShow.removeAllElements();
					info.says = null;
					info.timeW = 200;
				}
			}
			else
			{
				info.info.curr = mSystem2.currentTimeMillis();
				if (info.info.curr - info.info.last >= 100)
				{
					info.info.last = mSystem2.currentTimeMillis();
					info.info.timeCount--;
				}
				if (info.info.timeCount == 0)
				{
					isDone = true;
					cmtoY = -40;
					cmtoX = Char2.myCharz().cx - GameScr2.cmx + ((Char2.myCharz().cdir != 1) ? 20 : (-20));
					info.time = 0;
					info.infoWaitToShow.removeAllElements();
					info.says = null;
					cmdChat = null;
				}
			}
		}
	}

	public void addInfoWithChar(string s, Char2 c, bool isChatServer)
	{
		playerID = c.charID;
		info.addInfo(s, 3, c, isChatServer);
		isDone = false;
	}

	public void addInfo(string s, int Type)
	{
		s = Res2.changeString(s);
		AutoXmap2.Info(s);
		if (MainMod2.isAutoVQMM)
		{
			if (s.ToLower().Contains("hành trang đã đầy"))
			{
				MainMod2.isAutoVQMM = false;
				s = "Hành trang đầy, đã tắt Auto VQMM (1)";
			}
			else if (s.ToLower().Contains("rương") && s.ToLower().Contains("đã đầy"))
			{
				MainMod2.fullChestVQMM = true;
			}
		}
		if (info.infoWaitToShow.size() > 0 && s.Equals(((InfoItem2)info.infoWaitToShow.lastElement()).s))
		{
			return;
		}
		if (info.infoWaitToShow.size() > 10)
		{
			for (int i = 0; i < 5; i++)
			{
				info.infoWaitToShow.removeElementAt(0);
			}
		}
		Char2 cInfo = null;
		info.addInfo(s, Type, cInfo, isChatServer: false);
		if (info.infoWaitToShow.size() == 1)
		{
			cmy = 0;
			cmx = Char2.myCharz().cx - GameScr2.cmx + ((Char2.myCharz().cdir != 1) ? 20 : (-20));
		}
		isDone = false;
	}
}
