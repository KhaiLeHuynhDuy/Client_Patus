public class MobCapcha2
{
	public static Image2 imgMob;

	public static int cmtoY;

	public static int cmy;

	public static int cmdy;

	public static int cmvy;

	public static int cmyLim;

	public static int cmtoX;

	public static int cmx;

	public static int cmdx;

	public static int cmvx;

	public static int cmxLim;

	public static bool explode;

	public static int delay;

	public static bool isCreateMob;

	public static int tF;

	public static int f;

	public static int dir;

	public static bool isAttack;

	public static void init()
	{
		imgMob = GameCanvas2.loadImage("/mainImage/myTexture2dmobCapcha.png");
	}

	public static void paint(mGraphics2 g, int x, int y)
	{
		if (!isAttack)
		{
			if (GameCanvas2.gameTick % 3 == 0)
			{
				if (Char2.myCharz().cdir == 1)
				{
					cmtoX = x - 20 - GameScr2.cmx;
				}
				if (Char2.myCharz().cdir == -1)
				{
					cmtoX = x + 20 - GameScr2.cmx;
				}
			}
			cmtoY = Char2.myCharz().cy - 40 - GameScr2.cmy;
		}
		else
		{
			delay++;
			if (delay == 5)
			{
				isAttack = false;
				delay = 0;
			}
			cmtoX = x - GameScr2.cmx;
			cmtoY = y - GameScr2.cmy;
		}
		if (cmx > x - GameScr2.cmx)
		{
			dir = -1;
		}
		else
		{
			dir = 1;
		}
		g.drawImage(GameScr2.imgCapcha, cmx, cmy - 40, 3);
		PopUp2.paintPopUp(g, cmx - 25, cmy - 70, 50, 20, 16777215, isButton: false);
		mFont2.tahoma_7b_dark.drawString(g, GameScr2.gI().keyInput, cmx, cmy - 65, 2);
		if (isCreateMob)
		{
			isCreateMob = false;
			EffecMn2.addEff(new Effect2_(18, cmx + GameScr2.cmx, cmy + GameScr2.cmy, 2, 10, -1));
		}
		if (explode)
		{
			explode = false;
			EffecMn2.addEff(new Effect2_(18, cmx + GameScr2.cmx, cmy + GameScr2.cmy, 2, 10, -1));
			GameScr2.gI().mobCapcha = null;
			cmtoX = -GameScr2.cmx;
			cmtoY = -GameScr2.cmy;
		}
		g.drawRegion(imgMob, 0, f * 40, 40, 40, (dir != 1) ? 2 : 0, cmx, cmy + 3 + ((GameCanvas2.gameTick % 10 > 5) ? 1 : 0), 3);
		moveCamera();
	}

	public static void moveCamera()
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
			f++;
			if (f > 2)
			{
				f = 0;
			}
		}
	}
}
