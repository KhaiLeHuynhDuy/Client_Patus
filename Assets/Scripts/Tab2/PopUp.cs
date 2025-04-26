public class PopUp2
{
	public static MyVector2 vPopups = new MyVector2();

	public int sayWidth;

	public int sayRun;

	public string[] says;

	public int cx;

	public int cy;

	public int cw;

	public int ch;

	public static int f;

	public static int tF;

	public static int dir;

	public bool isWayPoint;

	public int tDelay;

	private int timeDelay;

	public Command2 command;

	public bool isPaint = true;

	public bool isHide;

	public static Image2 goc;

	public static Image2 imgPopUp;

	public static Image2 imgPopUp2;

	public Image2 imgFocus;

	public Image2 imgUnFocus;

	public PopUp2(string info, int x, int y)
	{
		sayWidth = 100;
		if (info.Length < 10)
		{
			sayWidth = 60;
		}
		if (GameCanvas2.w == 128)
		{
			sayWidth = 128;
		}
		says = mFont2.tahoma_7b_dark.splitFontArray(info, sayWidth - 10);
		sayRun = 7;
		cx = x - sayWidth / 2 - 1;
		cy = y - 15 + sayRun - says.Length * 12 - 10;
		cw = sayWidth + 2;
		ch = (says.Length + 1) * 12 + 1;
		while (cw % 10 != 0)
		{
			cw++;
		}
		while (ch % 10 != 0)
		{
			ch++;
		}
		if (x >= 0 && x <= 24)
		{
			cx += cw / 2 + 30;
		}
		if (x <= TileMap2.tmw * 24 && x >= TileMap2.tmw * 24 - 24)
		{
			cx -= cw / 2 + 6;
		}
		while (cx <= 30)
		{
			cx += 2;
		}
		while (cx + cw >= TileMap2.tmw * 24 - 30)
		{
			cx -= 2;
		}
	}

	public static void loadBg()
	{
		if (goc == null)
		{
			goc = GameCanvas2.loadImage("/mainImage/myTexture2dbd3.png");
		}
		if (imgPopUp == null)
		{
			imgPopUp = GameCanvas2.loadImage("/mainImage/myTexture2dimgPopup.png");
		}
		if (imgPopUp2 == null)
		{
			imgPopUp2 = GameCanvas2.loadImage("/mainImage/myTexture2dimgPopup2.png");
		}
	}

	public void updateXYWH(string[] info, int x, int y)
	{
		sayWidth = 0;
		for (int i = 0; i < info.Length; i++)
		{
			if (sayWidth < mFont2.tahoma_7b_dark.getWidth(info[i]))
			{
				sayWidth = mFont2.tahoma_7b_dark.getWidth(info[i]);
			}
		}
		sayWidth += 20;
		says = info;
		sayRun = 7;
		cx = x - sayWidth / 2 - 1;
		cy = y - 15 + sayRun - says.Length * 12 - 10;
		cw = sayWidth + 2;
		ch = (says.Length + 1) * 12 + 1;
		while (cw % 10 != 0)
		{
			cw++;
		}
		while (ch % 10 != 0)
		{
			ch++;
		}
		if (x >= 0 && x <= 24)
		{
			cx += cw / 2 + 30;
		}
		if (x <= TileMap2.tmw * 24 && x >= TileMap2.tmw * 24 - 24)
		{
			cx -= cw / 2 + 6;
		}
		while (cx <= 30)
		{
			cx += 2;
		}
		while (cx + cw >= TileMap2.tmw * 24 - 30)
		{
			cx -= 2;
		}
	}

	public static void addPopUp(int x, int y, string info)
	{
		vPopups.addElement(new PopUp2(info, x, y));
	}

	public static void addPopUp(PopUp2 p)
	{
		vPopups.addElement(p);
	}

	public static void removePopUp(PopUp2 p)
	{
		vPopups.removeElement(p);
	}

	public void paintClipPopUp(mGraphics2 g, int x, int y, int w, int h, int color, bool isFocus)
	{
		if (color == 1)
		{
			g.fillRect(x, y, w, h, 16777215, 90);
		}
		else
		{
			g.fillRect(x, y, w, h, 0, 77);
		}
	}

	public static void paintPopUp(mGraphics2 g, int x, int y, int w, int h, int color, bool isButton)
	{
		if (!isButton)
		{
			g.setColor(0);
			g.fillRect(x + 6, y, w - 14 + 1, h);
			g.fillRect(x, y + 6, w, h - 12 + 1);
			g.setColor(color);
			g.fillRect(x + 6, y + 1, w - 12, h - 2);
			g.fillRect(x + 1, y + 6, w - 2, h - 12);
			g.drawRegion(goc, 0, 0, 7, 6, 0, x, y, 0);
			g.drawRegion(goc, 0, 0, 7, 6, 2, x + w - 7, y, 0);
			g.drawRegion(goc, 0, 0, 7, 6, 1, x, y + h - 6, 0);
			g.drawRegion(goc, 0, 0, 7, 6, 3, x + w - 7, y + h - 6, 0);
			return;
		}
		Image2 arg = ((color != 1) ? imgPopUp : imgPopUp2);
		g.drawRegion(arg, 0, 0, 10, 10, 0, x, y, 0);
		g.drawRegion(arg, 0, 20, 10, 10, 0, x + w - 10, y, 0);
		g.drawRegion(arg, 0, 50, 10, 10, 0, x, y + h - 10, 0);
		g.drawRegion(arg, 0, 70, 10, 10, 0, x + w - 10, y + h - 10, 0);
		int num = (((w - 20) % 10 != 0) ? ((w - 20) / 10 + 1) : ((w - 20) / 10));
		int num2 = (((h - 20) % 10 != 0) ? ((h - 20) / 10 + 1) : ((h - 20) / 10));
		for (int i = 0; i < num; i++)
		{
			g.drawRegion(arg, 0, 10, 10, 10, 0, x + 10 + i * 10, y, 0);
		}
		for (int j = 0; j < num2; j++)
		{
			g.drawRegion(arg, 0, 30, 10, 10, 0, x, y + 10 + j * 10, 0);
		}
		for (int k = 0; k < num; k++)
		{
			g.drawRegion(arg, 0, 60, 10, 10, 0, x + 10 + k * 10, y + h - 10, 0);
		}
		for (int l = 0; l < num2; l++)
		{
			g.drawRegion(arg, 0, 40, 10, 10, 0, x + w - 10, y + 10 + l * 10, 0);
		}
		g.setColor((color != 1) ? 16770503 : 12052656);
		g.fillRect(x + 10, y + 10, w - 20, h - 20);
	}

	public void paint(mGraphics2 g)
	{
		if (isPaint && says != null && ChatPopup2.currChatPopup == null && !isHide)
		{
			paintClipPopUp(g, cx, cy - GameCanvas2.transY, cw, ch, (timeDelay != 0) ? 1 : 0, isFocus: true);
			for (int i = 0; i < says.Length; i++)
			{
				((timeDelay != 0) ? mFont2.tahoma_7b_green2 : mFont2.tahoma_7b_white).drawString(g, says[i], cx + cw / 2, cy + (ch / 2 - says.Length * 12 / 2) + i * 12 - GameCanvas2.transY, 2);
			}
		}
	}

	private void update()
	{
		if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId == 0)
		{
			if (cx + cw >= GameScr2.cmx && cx <= GameCanvas2.w + GameScr2.cmx && cy + ch >= GameScr2.cmy && cy <= GameCanvas2.h + GameScr2.cmy)
			{
				isHide = false;
			}
			else
			{
				isHide = true;
			}
		}
		if (Char2.myCharz().taskMaint == null || (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId != 0))
		{
			if (cx + cw / 2 >= Char2.myCharz().cx - 100 && cx + cw / 2 <= Char2.myCharz().cx + 100 && cy + ch >= GameScr2.cmy && cy <= GameCanvas2.h + GameScr2.cmy)
			{
				isHide = false;
			}
			else
			{
				isHide = true;
			}
		}
		if (timeDelay > 0)
		{
			timeDelay--;
			if (timeDelay == 0 && command != null)
			{
				command.performAction();
			}
		}
		if (!isWayPoint)
		{
			return;
		}
		if (Char2.myCharz().taskMaint != null)
		{
			if (Char2.myCharz().taskMaint.taskId == 0)
			{
				if (Char2.myCharz().taskMaint.index == 0)
				{
					isPaint = false;
				}
				if (Char2.myCharz().taskMaint.index == 1)
				{
					isPaint = true;
				}
				if (Char2.myCharz().taskMaint.index > 1 && Char2.myCharz().taskMaint.index < 6)
				{
					isPaint = false;
				}
			}
			else if (!isPaint)
			{
				tDelay++;
				if (tDelay == 10)
				{
					isPaint = true;
				}
			}
		}
		else if (!isPaint)
		{
			Hint2.isPaint = false;
			tDelay++;
			if (tDelay == 10)
			{
				isPaint = true;
				Hint2.isPaint = true;
			}
		}
	}

	public void doClick(int timeDelay)
	{
		this.timeDelay = timeDelay;
	}

	public static void paintAll(mGraphics2 g)
	{
		for (int i = 0; i < vPopups.size(); i++)
		{
			((PopUp2)vPopups.elementAt(i)).paint(g);
		}
	}

	public static void updateAll()
	{
		for (int i = 0; i < vPopups.size(); i++)
		{
			((PopUp2)vPopups.elementAt(i)).update();
		}
	}
}
