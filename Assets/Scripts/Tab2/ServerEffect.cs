public class ServerEffect2 : Effect2_2
{
	public EffectCharPaint2 eff;

	private int i0;

	private int dx0;

	private int dy0;

	private int x;

	private int y;

	private Char2 c;

	private Mob2 m;

	private short loopCount;

	private long endTime;

	private int trans;

	public static void addServerEffect(int id, int cx, int cy, int loopCount)
	{
        ServerEffect2 serverEffect = new()
        {
            eff = GameScr2.efs[id - 1],
            x = cx,
            y = cy,
            loopCount = (short)loopCount
        };
        vEffect2.addElement(serverEffect);
	}

	public static void addServerEffect(int id, int cx, int cy, int loopCount, int trans)
	{
        ServerEffect2 serverEffect = new()
        {
            eff = GameScr2.efs[id - 1],
            x = cx,
            y = cy,
            loopCount = (short)loopCount,
            trans = trans
        };
        vEffect2.addElement(serverEffect);
	}

	public static void addServerEffect(int id, Mob2 m, int loopCount)
	{
        ServerEffect2 serverEffect = new()
        {
            eff = GameScr2.efs[id - 1],
            m = m,
            loopCount = (short)loopCount
        };
        vEffect2.addElement(serverEffect);
	}

	public static void addServerEffect(int id, Char2 c, int loopCount)
	{
		ServerEffect2 serverEffect = new ServerEffect2();
		serverEffect.eff = GameScr2.efs[id - 1];
		serverEffect.c = c;
		serverEffect.loopCount = (short)loopCount;
		Effect2_2.vEffect2.addElement(serverEffect);
	}

	public static void addServerEffect(int id, Char2 c, int loopCount, int trans)
	{
		ServerEffect2 serverEffect = new ServerEffect2();
		serverEffect.eff = GameScr2.efs[id - 1];
		serverEffect.c = c;
		serverEffect.loopCount = (short)loopCount;
		serverEffect.trans = trans;
		Effect2_2.vEffect2.addElement(serverEffect);
	}

	public static void addServerEffectWithTime(int id, int cx, int cy, int timeLengthInSecond)
	{
		ServerEffect2 serverEffect = new ServerEffect2();
		serverEffect.eff = GameScr2.efs[id - 1];
		serverEffect.x = cx;
		serverEffect.y = cy;
		serverEffect.endTime = mSystem2.currentTimeMillis() + timeLengthInSecond * 1000;
		Effect2_2.vEffect2.addElement(serverEffect);
	}

	public static void addServerEffectWithTime(int id, Char2 c, int timeLengthInSecond)
	{
		ServerEffect2 serverEffect = new ServerEffect2();
		serverEffect.eff = GameScr2.efs[id - 1];
		serverEffect.c = c;
		serverEffect.endTime = mSystem2.currentTimeMillis() + timeLengthInSecond * 1000;
		Effect2_2.vEffect2.addElement(serverEffect);
	}

	public override void paint(mGraphics2 g)
	{
		if (mGraphics2.zoomLevel == 1)
		{
			GameScr2.countEff++;
		}
		if (GameScr2.countEff < 8)
		{
			if (c != null)
			{
				x = c.cx;
				y = c.cy + GameCanvas2.transY;
			}
			if (m != null)
			{
				x = m.x;
				y = m.y + GameCanvas2.transY;
			}
			int num = x + dx0 + eff.arrEfInfo[i0].dx;
			int num2 = y + dy0 + eff.arrEfInfo[i0].dy;
			if (GameCanvas2.isPaint(num, num2))
			{
				SmallImage2.drawSmallImage(g, eff.arrEfInfo[i0].idImg, num, num2, trans, mGraphics2.VCENTER | mGraphics2.HCENTER);
			}
		}
	}

	public override void update()
	{
		if (endTime != 0)
		{
			i0++;
			if (i0 >= eff.arrEfInfo.Length)
			{
				i0 = 0;
			}
			if (mSystem2.currentTimeMillis() - endTime > 0)
			{
				Effect2_2.vEffect2.removeElement(this);
			}
		}
		else
		{
			i0++;
			if (i0 >= eff.arrEfInfo.Length)
			{
				loopCount--;
				if (loopCount <= 0)
				{
					Effect2_2.vEffect2.removeElement(this);
				}
				else
				{
					i0 = 0;
				}
			}
		}
		if (GameCanvas2.gameTick % 11 == 0 && c != null && c != Char2.myCharz() && !GameScr2.vCharInMap.contains(c))
		{
			Effect2_2.vEffect2.removeElement(this);
		}
	}
}
