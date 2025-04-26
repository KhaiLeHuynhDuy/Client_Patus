using System;
using UnityEngine;

public class ChatPopup2 : Effect2_2, IActionListener2
{
	public int sayWidth = 100;

	public int delay;

	public int sayRun;

	public string[] says;

	public int cx;

	public int cy;

	public int ch;

	public int cmx;

	public int cmy;

	public int lim;

	public Npc2 c;

	private bool outSide;

	public static long curr;

	public static long last;

	private int currentLine;

	private string[] lines;

	public Command2 cmdNextLine;

	public Command2 cmdMsg1;

	public Command2 cmdMsg2;

	public static ChatPopup2 currChatPopup;

	public static ChatPopup2 serverChatPopUp;

	public static string nextMultiChatPopUp;

	public static Npc2 nextChar;

	public bool isShopDetail;

	public sbyte starSlot;

	public sbyte maxStarSlot;

	public static Scroll2 scr;

	public static bool isHavePetNpc;

	public int mH;

	public static int performDelay;

	public int dx;

	public int dy;

	public int second;

	public static int numSlot = 7;

	private int nMaxslot_duoi;

	private int nMaxslot_tren;

	private int nslot_duoi;

	private Image2 imgStar;

	public int strY;

	private int iconID;

	public bool isClip;

	public static int cmyText;

	private int pxx;

	private int pyy;

	public static void addNextPopUpMultiLine(string strNext, Npc2 next)
	{
		nextMultiChatPopUp = strNext;
		nextChar = next;
		if (currChatPopup == null)
		{
			addChatPopupMultiLine(nextMultiChatPopUp, 100000, nextChar);
			nextMultiChatPopUp = null;
			nextChar = null;
		}
	}

	public static void addBigMessage(string chat, int howLong, Npc2 c)
	{
		string[] array = new string[1] { chat };
		if (c.charID != 5 && GameScr2.info1.isDone)
		{
			GameScr2.info1.isUpdate = false;
		}
		Char2.isLockKey = true;
		serverChatPopUp = addChatPopup(array[0], howLong, c);
		serverChatPopUp.strY = 5;
		serverChatPopUp.cx = GameCanvas2.w / 2 - serverChatPopUp.sayWidth / 2 - 1;
		serverChatPopUp.cy = GameCanvas2.h - 20 - serverChatPopUp.ch;
		serverChatPopUp.currentLine = 0;
		serverChatPopUp.lines = array;
		scr = new Scroll2();
		int nItem = serverChatPopUp.says.Length;
		scr.setStyle(nItem, 12, serverChatPopUp.cx, serverChatPopUp.cy - serverChatPopUp.strY + 12, serverChatPopUp.sayWidth + 2, serverChatPopUp.ch - 25, styleUPDOWN: true, 1);
		SoundMn2.gI().openDialog();
	}

	public static void addChatPopupMultiLine(string chat, int howLong, Npc2 c)
	{
		string[] array = Res2.split(chat, "\n", 0);
		Char2.isLockKey = true;
		currChatPopup = addChatPopup(array[0], howLong, c);
		currChatPopup.currentLine = 0;
		currChatPopup.lines = array;
		string caption = mResources2.CONTINUE;
		if (array.Length == 1)
		{
			caption = mResources2.CLOSE;
		}
		currChatPopup.cmdNextLine = new Command2(caption, currChatPopup, 8000, null);
		currChatPopup.cmdNextLine.x = GameCanvas2.w / 2 - 35;
		currChatPopup.cmdNextLine.y = GameCanvas2.h - 35;
		SoundMn2.gI().openDialog();
	}

	public static ChatPopup2 addChatPopupWithIcon(string chat, int howLong, Npc2 c, int idIcon)
	{
		performDelay = 10;
		ChatPopup2 chatPopup = new ChatPopup2();
		chatPopup.sayWidth = GameCanvas2.w - 30 - (GameCanvas2.menu.showMenu ? GameCanvas2.menu.menuX : 0);
		if (chatPopup.sayWidth > 320)
		{
			chatPopup.sayWidth = 320;
		}
		if (chat.Length < 10)
		{
			chatPopup.sayWidth = 64;
		}
		if (GameCanvas2.w == 128)
		{
			chatPopup.sayWidth = 128;
		}
		chatPopup.says = mFont2.tahoma_7_red.splitFontArray(chat, chatPopup.sayWidth - 10);
		chatPopup.delay = howLong;
		chatPopup.c = c;
		chatPopup.iconID = idIcon;
		Char2.chatPopup = chatPopup;
		chatPopup.ch = 15 - chatPopup.sayRun + chatPopup.says.Length * 12 + 10;
		if (chatPopup.ch > GameCanvas2.h - 80)
		{
			chatPopup.ch = GameCanvas2.h - 80;
		}
		chatPopup.mH = 10;
		if (GameCanvas2.menu.showMenu)
		{
			chatPopup.mH = 0;
		}
		Effect2_2.vEffect2.addElement(chatPopup);
		isHavePetNpc = false;
		if (c != null && c.charID == 5)
		{
			isHavePetNpc = true;
			GameScr2.info1.addInfo(string.Empty, 1);
		}
		curr = (last = mSystem2.currentTimeMillis());
		chatPopup.ch += 15;
		return chatPopup;
	}

	public static ChatPopup2 addChatPopup(string chat, int howLong, Npc2 c)
	{
		performDelay = 10;
		ChatPopup2 chatPopup = new ChatPopup2();
		chatPopup.sayWidth = GameCanvas2.w - 30 - (GameCanvas2.menu.showMenu ? GameCanvas2.menu.menuX : 0);
		if (chatPopup.sayWidth > 320)
		{
			chatPopup.sayWidth = 320;
		}
		if (chat.Length < 10)
		{
			chatPopup.sayWidth = 64;
		}
		if (GameCanvas2.w == 128)
		{
			chatPopup.sayWidth = 128;
		}
		chatPopup.says = mFont2.tahoma_7_red.splitFontArray(chat, chatPopup.sayWidth - 10);
		chatPopup.delay = howLong;
		chatPopup.c = c;
		Char2.chatPopup = chatPopup;
		chatPopup.ch = 15 - chatPopup.sayRun + chatPopup.says.Length * 12 + 10;
		if (chatPopup.ch > GameCanvas2.h - 80)
		{
			chatPopup.ch = GameCanvas2.h - 80;
		}
		chatPopup.mH = 10;
		if (GameCanvas2.menu.showMenu)
		{
			chatPopup.mH = 0;
		}
		Effect2_2.vEffect2.addElement(chatPopup);
		isHavePetNpc = false;
		if (c != null && c.charID == 5)
		{
			isHavePetNpc = true;
			GameScr2.info1.addInfo(string.Empty, 1);
		}
		curr = (last = mSystem2.currentTimeMillis());
		return chatPopup;
	}

	public override void update()
	{
		if (scr != null)
		{
			GameScr2.info1.isUpdate = false;
			scr.updatecm();
		}
		else
		{
			GameScr2.info1.isUpdate = true;
		}
		if (GameCanvas2.menu.showMenu)
		{
			strY = 0;
			cx = GameCanvas2.w / 2 - sayWidth / 2 - 1;
			cy = GameCanvas2.menu.menuY - ch;
		}
		else
		{
			strY = 0;
			if (GameScr2.gI().right != null || GameScr2.gI().left != null || GameScr2.gI().center != null || cmdNextLine != null || cmdMsg1 != null)
			{
				strY = 5;
				cx = GameCanvas2.w / 2 - sayWidth / 2 - 1;
				cy = GameCanvas2.h - 20 - ch;
			}
			else
			{
				cx = GameCanvas2.w / 2 - sayWidth / 2 - 1;
				cy = GameCanvas2.h - 5 - ch;
			}
		}
		if (delay > 0)
		{
			delay--;
		}
		if (performDelay > 0)
		{
			performDelay--;
		}
		else
		{
			GameScr2.info1.info.time = 0;
			for (int i = 0; i < GameScr2.info1.info.infoWaitToShow.size(); i++)
			{
				if (((InfoItem2)GameScr2.info1.info.infoWaitToShow.elementAt(i)).speed != 70)
				{
					((InfoItem2)GameScr2.info1.info.infoWaitToShow.elementAt(i)).speed = 10;
				}
			}
		}
		if (sayRun > 1)
		{
			sayRun--;
		}
		if ((c != null && Char2.chatPopup != null && Char2.chatPopup != this) || (c != null && Char2.chatPopup == null) || delay <= 0)
		{
			Effect2_2.vEffect2Outside.removeElement(this);
			Effect2_2.vEffect2.removeElement(this);
		}
	}

	public override void paint(mGraphics2 g)
	{
		if (GameScr2.gI().activeRongThan && GameScr2.gI().isUseFreez)
		{
			return;
		}
		GameCanvas2.resetTrans(g);
		int num = cx;
		int num2 = cy;
		int num3 = sayWidth + 2;
		int num4 = ch;
		if ((num <= 0 || num2 <= 0) && !GameCanvas2.panel.isShow)
		{
			return;
		}
		PopUp2.paintPopUp(g, num, num2, num3, num4, 16777215, isButton: false);
		int num5 = 0;
		if (c != null)
		{
			num5 = ((GameCanvas2.gameTick % 10 <= 2) ? 1 : 0);
			SmallImage2.drawSmallImage(g, c.avatar, cx + 14, cy + num5, 0, StaticObj2.BOTTOM_LEFT);
		}
		if (iconID != 0)
		{
			num5 = ((GameCanvas2.gameTick % 10 <= 2) ? 1 : 0);
			SmallImage2.drawSmallImage(g, iconID, cx + num3 / 2, cy + ch - 15 + num5, 0, StaticObj2.VCENTER_HCENTER);
		}
		if (scr != null)
		{
			g.setClip(num, num2, num3, num4 - 16);
			g.translate(0, -scr.cmy);
		}
		int tx = 0;
		int ty = 0;
		if (isClip)
		{
			tx = g.getTranslateX();
			ty = g.getTranslateY();
			g.setClip(num, num2 + 1, num3, num4 - 17);
			g.translate(0, -cmyText);
		}
		int num6 = -1;
		for (int i = 0; i < says.Length; i++)
		{
			if (says[i].StartsWith("--"))
			{
				g.setColor(0);
				g.fillRect(num + 10, cy + sayRun + i * 12 + 6, num3 - 20, 1);
				continue;
			}
			mFont2 mFont2 = mFont2.tahoma_7;
			int num7 = 2;
			string st = says[i];
			int num8 = 0;
			if (says[i].StartsWith("|"))
			{
				string[] array = Res2.split(says[i], "|", 0);
				if (array.Length == 3)
				{
					st = array[2];
				}
				if (array.Length == 4)
				{
					st = array[3];
					num7 = int.Parse(array[2]);
				}
				num8 = int.Parse(array[1]);
				num6 = num8;
			}
			else
			{
				num8 = num6;
			}
			switch (num8)
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
			case 8:
				mFont2 = mFont2.tahoma_7b_yellow;
				break;
			}
			if (says[i].StartsWith("<"))
			{
				string[] array2 = Res2.split(says[i], "<", 0);
				string[] array3 = Res2.split(array2[1], ">", 1);
				if (second == 0)
				{
					second = int.Parse(array3[1]);
				}
				else
				{
					curr = mSystem2.currentTimeMillis();
					if (curr - last >= 1000)
					{
						last = curr;
						second--;
					}
				}
				st = second + " " + array3[2];
				mFont2.drawString(g, st, cx + sayWidth / 2, cy + sayRun + i * 12 - strY + 12, num7);
			}
			else
			{
				if (num7 == 2)
				{
					mFont2.drawString(g, st, cx + sayWidth / 2, cy + sayRun + i * 12 - strY + 12, num7);
				}
				if (num7 == 1)
				{
					mFont2.drawString(g, st, cx + sayWidth - 5, cy + sayRun + i * 12 - strY + 12, num7);
				}
			}
		}
		if (isClip)
		{
			GameCanvas2.resetTrans(g);
			g.translate(tx, ty);
		}
		if (maxStarSlot > 4)
		{
			nMaxslot_tren = (maxStarSlot + 1) / 2;
			nMaxslot_duoi = maxStarSlot - nMaxslot_tren;
			for (int j = 0; j < nMaxslot_tren; j++)
			{
				g.drawImage(Panel2.imgMaxStar, num + num3 / 2 - nMaxslot_tren * 20 / 2 + j * 20 + mGraphics2.getImageWidth(Panel2.imgMaxStar), num2 + num4 - 17, 3);
			}
			for (int k = 0; k < nMaxslot_duoi; k++)
			{
				g.drawImage(Panel2.imgMaxStar, num + num3 / 2 - nMaxslot_duoi * 20 / 2 + k * 20 + mGraphics2.getImageWidth(Panel2.imgMaxStar), num2 + num4 - 8, 3);
			}
			if (starSlot > 0)
			{
				imgStar = Panel2.imgStar;
				if (starSlot >= nMaxslot_tren)
				{
					nslot_duoi = starSlot - nMaxslot_tren;
					for (int l = 0; l < nMaxslot_tren; l++)
					{
						g.drawImage(imgStar, num + num3 / 2 - nMaxslot_tren * 20 / 2 + l * 20 + mGraphics2.getImageWidth(imgStar), num2 + num4 - 17, 3);
					}
					for (int m = 0; m < nslot_duoi; m++)
					{
						if (m + nMaxslot_tren >= numSlot)
						{
							imgStar = Panel2.imgStar8;
						}
						g.drawImage(imgStar, num + num3 / 2 - nMaxslot_duoi * 20 / 2 + m * 20 + mGraphics2.getImageWidth(imgStar), num2 + num4 - 8, 3);
					}
				}
				else
				{
					for (int n = 0; n < starSlot; n++)
					{
						g.drawImage(imgStar, num + num3 / 2 - nMaxslot_tren * 20 / 2 + n * 20 + mGraphics2.getImageWidth(imgStar), num2 + num4 - 17, 3);
					}
				}
			}
		}
		else
		{
			for (int num9 = 0; num9 < maxStarSlot; num9++)
			{
				g.drawImage(Panel2.imgMaxStar, num + num3 / 2 - maxStarSlot * 20 / 2 + num9 * 20 + mGraphics2.getImageWidth(Panel2.imgMaxStar), num2 + num4 - 13, 3);
			}
			if (starSlot > 0)
			{
				for (int num10 = 0; num10 < starSlot; num10++)
				{
					g.drawImage(Panel2.imgStar, num + num3 / 2 - maxStarSlot * 20 / 2 + num10 * 20 + mGraphics2.getImageWidth(Panel2.imgStar), num2 + num4 - 13, 3);
				}
			}
		}
		paintCmd(g);
	}

	public void paintRada(mGraphics2 g, int cmyText)
	{
		int num = cx;
		int num2 = cy;
		int num3 = sayWidth;
		int num4 = ch;
		int num5 = 0;
		int num6 = 0;
		num5 = g.getTranslateX();
		num6 = g.getTranslateY();
		g.translate(0, -cmyText);
		if ((num <= 0 || num2 <= 0) && !GameCanvas2.panel.isShow)
		{
			return;
		}
		int num7 = -1;
		for (int i = 0; i < says.Length; i++)
		{
			if (says[i].StartsWith("--"))
			{
				g.setColor(16777215);
				g.fillRect(num + 10, cy + sayRun + i * 12 - 6, num3 - 20, 1);
				continue;
			}
			mFont2 mFont2 = mFont2.tahoma_7_white;
			int num8 = 2;
			string st = says[i];
			int num9 = 0;
			if (says[i].StartsWith("|"))
			{
				string[] array = Res2.split(says[i], "|", 0);
				if (array.Length == 3)
				{
					st = array[2];
				}
				if (array.Length == 4)
				{
					st = array[3];
					num8 = int.Parse(array[2]);
				}
				num9 = int.Parse(array[1]);
				num7 = num9;
			}
			else
			{
				num9 = num7;
			}
			switch (num9)
			{
			case -1:
				mFont2 = mFont2.tahoma_7_white;
				break;
			case 0:
				mFont2 = mFont2.tahoma_7b_white;
				break;
			case 1:
				mFont2 = mFont2.tahoma_7b_green;
				break;
			case 2:
				mFont2 = mFont2.tahoma_7b_red;
				break;
			}
			if (says[i].StartsWith("<"))
			{
				string[] array2 = Res2.split(says[i], "<", 0);
				string[] array3 = Res2.split(array2[1], ">", 1);
				if (second == 0)
				{
					second = int.Parse(array3[1]);
				}
				else
				{
					curr = mSystem2.currentTimeMillis();
					if (curr - last >= 1000)
					{
						last = curr;
						second--;
					}
				}
				st = second + " " + array3[2];
				mFont2.drawString(g, st, cx + sayWidth / 2, cy + sayRun + i * 12 - strY, num8);
			}
			else
			{
				if (num8 == 2)
				{
					mFont2.drawString(g, st, cx + sayWidth / 2, cy + sayRun + i * 12 - strY, num8);
				}
				if (num8 == 1)
				{
					mFont2.drawString(g, st, cx + sayWidth - 5, cy + sayRun + i * 12 - strY, num8);
				}
			}
		}
		GameCanvas2.resetTrans(g);
		g.translate(num5, num6);
	}

	private void doKeyText(int type)
	{
		cmyText += 12 * type;
		if (cmyText < 0)
		{
			cmyText = 0;
		}
		if (cmyText > lim)
		{
			cmyText = lim;
		}
	}

	public void updateKey()
	{
		if (isClip)
		{
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
			if (GameCanvas2.isPointerHoldIn(cx, 0, sayWidth + 2, ch))
			{
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
					if (cmyText > lim)
					{
						cmyText = lim;
					}
				}
				else
				{
					pyy = 0;
					pyy = 0;
				}
			}
		}
		if (scr != null)
		{
			if (GameCanvas2.isTouch)
			{
				scr.updateKey();
			}
			if (GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21])
			{
				scr.cmtoY -= 12;
				if (scr.cmtoY < 0)
				{
					scr.cmtoY = 0;
				}
			}
			if (GameCanvas2.keyHold[(!Main2.isPC) ? 8 : 22])
			{
				GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = false;
				scr.cmtoY += 12;
				if (scr.cmtoY > scr.cmyLim)
				{
					scr.cmtoY = scr.cmyLim;
				}
			}
		}
		if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || mScreen2.getCmdPointerLast(GameCanvas2.currentScreen.center))
		{
			GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
			mScreen2.keyTouch = -1;
			if (cmdNextLine != null)
			{
				cmdNextLine.performAction();
			}
			else if (cmdMsg1 != null)
			{
				cmdMsg1.performAction();
			}
			else if (cmdMsg2 != null)
			{
				cmdMsg2.performAction();
			}
		}
		if (scr == null || !scr.pointerIsDowning)
		{
			if (cmdMsg1 != null && (GameCanvas2.keyPressed[12] || GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || mScreen2.getCmdPointerLast(cmdMsg1)))
			{
				GameCanvas2.keyPressed[12] = false;
				GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] = false;
				GameCanvas2.isPointerClick = false;
				GameCanvas2.isPointerJustRelease = false;
				cmdMsg1.performAction();
				mScreen2.keyTouch = -1;
			}
			if (cmdMsg2 != null && (GameCanvas2.keyPressed[13] || mScreen2.getCmdPointerLast(cmdMsg2)))
			{
				GameCanvas2.keyPressed[13] = false;
				GameCanvas2.isPointerClick = false;
				GameCanvas2.isPointerJustRelease = false;
				cmdMsg2.performAction();
				mScreen2.keyTouch = -1;
			}
		}
	}

	public void paintCmd(mGraphics2 g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
		GameCanvas2.paintz.paintTabSoft(g);
		if (cmdNextLine != null)
		{
			GameCanvas2.paintz.paintCmdBar(g, null, cmdNextLine, null);
		}
		if (cmdMsg1 != null)
		{
			GameCanvas2.paintz.paintCmdBar(g, cmdMsg1, null, cmdMsg2);
		}
	}

	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			try
			{
				string url = (string)p;
				GameMidlet2.instance.platformRequest(url);
			}
			catch (Exception)
			{
			}
			if (!Main2.isPC)
			{
				GameMidlet2.instance.notifyDestroyed();
			}
			else
			{
				idAction = 1001;
			}
			GameCanvas2.endDlg();
		}
		if (idAction == 1001)
		{
			scr = null;
			Char2.chatPopup = null;
			serverChatPopUp = null;
			GameScr2.info1.isUpdate = true;
			Char2.isLockKey = false;
			if (isHavePetNpc)
			{
				GameScr2.info1.info.time = 0;
				GameScr2.info1.info.info.speed = 10;
			}
		}
		if (idAction != 8000 || performDelay > 0)
		{
			return;
		}
		int num = currChatPopup.currentLine;
		num++;
		if (num >= currChatPopup.lines.Length)
		{
			Char2.chatPopup = null;
			currChatPopup = null;
			GameScr2.info1.isUpdate = true;
			Char2.isLockKey = false;
			if (nextMultiChatPopUp != null)
			{
				num = 0;
				addChatPopupMultiLine(nextMultiChatPopUp, 100000, nextChar);
				nextMultiChatPopUp = null;
				nextChar = null;
			}
			else
			{
				if (!isHavePetNpc)
				{
					return;
				}
				GameScr2.info1.info.time = 0;
				for (int i = 0; i < GameScr2.info1.info.infoWaitToShow.size(); i++)
				{
					if (((InfoItem2)GameScr2.info1.info.infoWaitToShow.elementAt(i)).speed == 10000000)
					{
						((InfoItem2)GameScr2.info1.info.infoWaitToShow.elementAt(i)).speed = 10;
					}
				}
			}
		}
		else
		{
			ChatPopup2 chatPopup = addChatPopup(currChatPopup.lines[num], currChatPopup.delay, currChatPopup.c);
			chatPopup.currentLine = num;
			chatPopup.lines = currChatPopup.lines;
			chatPopup.cmdNextLine = currChatPopup.cmdNextLine;
			currChatPopup = chatPopup;
		}
	}
}
