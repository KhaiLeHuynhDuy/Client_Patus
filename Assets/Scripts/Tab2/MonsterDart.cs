public class MonsterDart2 : Effect2_2
{
	public int va;

	private DartInfo2 info;

	public static MyRandom2 r = new MyRandom2();

	public int angle;

	public int vx;

	public int vy;

	public int x;

	public int y;

	public int z;

	public int xTo;

	public int yTo;

	private int life;

	public bool isSpeedUp;

	public int dame;

	public int dameMp;

	public Char2 c;

	public bool isBoss;

	public MyVector2 darts = new MyVector2();

	private int dx;

	private int dy;

	public static int[] ARROWINDEX = new int[18]
	{
		0, 15, 37, 52, 75, 105, 127, 142, 165, 195,
		217, 232, 255, 285, 307, 322, 345, 370
	};

	public static int[] TRANSFORM = new int[16]
	{
		0, 0, 0, 7, 6, 6, 6, 2, 2, 3,
		3, 4, 5, 5, 5, 1
	};

	public static sbyte[] FRAME = new sbyte[25]
	{
		0, 1, 2, 1, 0, 1, 2, 1, 0, 1,
		2, 1, 0, 1, 2, 1, 0, 1, 2, 1,
		0, 1, 2, 1, 0
	};

	public MonsterDart2(int x, int y, bool isBoss, int dame, int dameMp, Char2 c, int dartType)
	{
		info = GameScr2.darts[dartType];
		this.x = x;
		this.y = y;
		this.isBoss = isBoss;
		this.dame = dame;
		this.dameMp = dameMp;
		this.c = c;
		va = info.va;
		setAngle(Res2.angle(c.cx - x, c.cy - y));
		if (x >= GameScr2.cmx && x <= GameScr2.cmx + GameCanvas2.w)
		{
			SoundMn2.gI().mobKame(dartType);
		}
	}

	public MonsterDart2(int x, int y, bool isBoss, int dame, int dameMp, int xTo, int yTo, int dartType)
	{
		info = GameScr2.darts[dartType];
		this.x = x;
		this.y = y;
		this.isBoss = isBoss;
		this.dame = dame;
		this.dameMp = dameMp;
		this.xTo = xTo;
		this.yTo = yTo;
		va = info.va;
		setAngle(Res2.angle(xTo - x, yTo - y));
		if (x >= GameScr2.cmx && x <= GameScr2.cmx + GameCanvas2.w)
		{
			SoundMn2.gI().mobKame(dartType);
		}
		c = null;
	}

	public void setAngle(int angle)
	{
		this.angle = angle;
		vx = va * Res2.cos(angle) >> 10;
		vy = va * Res2.sin(angle) >> 10;
	}

	public static void addMonsterDart(int x, int y, bool isBoss, int dame, int dameMp, Char2 c, int dartType)
	{
		Effect2_2.vEffect2.addElement(new MonsterDart2(x, y, isBoss, dame, dameMp, c, dartType));
	}

	public static void addMonsterDart(int x, int y, bool isBoss, int dame, int dameMp, int xTo, int yTo, int dartType)
	{
		Effect2_2.vEffect2.addElement(new MonsterDart2(x, y, isBoss, dame, dameMp, xTo, yTo, dartType));
	}

	public override void update()
	{
		for (int i = 0; i < info.nUpdate; i++)
		{
			if (info.tail.Length > 0)
			{
				darts.addElement(new SmallDart2(x, y));
			}
			dx = ((c == null) ? xTo : c.cx) - x;
			dy = ((c == null) ? yTo : c.cy) - 10 - y;
			int num = 60;
			if (TileMap2.mapID == 0)
			{
				num = 600;
			}
			life++;
			if ((c != null && (c.statusMe == 5 || c.statusMe == 14)) || c == null)
			{
				x += (((c == null) ? xTo : c.cx) - x) / 2;
				y += (((c == null) ? yTo : c.cy) - y) / 2;
			}
			if ((Res2.abs(dx) < 16 && Res2.abs(dy) < 16) || life > num)
			{
				if (c != null && c.charID >= 0 && dameMp != -1)
				{
					if (dameMp != -100)
					{
						c.doInjure(dame, dameMp, isCrit: false, isMob: true);
					}
					else
					{
						ServerEffect2.addServerEffect(80, c, 1);
					}
				}
				Effect2_2.vEffect2.removeElement(this);
				if (dameMp != -100)
				{
					ServerEffect2.addServerEffect(81, c, 1);
					if (x >= GameScr2.cmx && x <= GameScr2.cmx + GameCanvas2.w)
					{
						SoundMn2.gI().explode_2();
					}
				}
			}
			int num2 = Res2.angle(dx, dy);
			if (Math2.abs(num2 - angle) < 90 || dx * dx + dy * dy > 4096)
			{
				if (Math2.abs(num2 - angle) < 15)
				{
					angle = num2;
				}
				else if ((num2 - angle >= 0 && num2 - angle < 180) || num2 - angle < -180)
				{
					angle = Res2.fixangle(angle + 15);
				}
				else
				{
					angle = Res2.fixangle(angle - 15);
				}
			}
			if (!isSpeedUp && va < 8192)
			{
				va += 1024;
			}
			vx = va * Res2.cos(angle) >> 10;
			vy = va * Res2.sin(angle) >> 10;
			dx += vx;
			int num3 = dx >> 10;
			x += num3;
			dx &= 1023;
			dy += vy;
			int num4 = dy >> 10;
			y += num4;
			dy &= 1023;
		}
		for (int j = 0; j < darts.size(); j++)
		{
			SmallDart2 smallDart = (SmallDart2)darts.elementAt(j);
			smallDart.index++;
			if (smallDart.index >= info.tail.Length)
			{
				darts.removeElementAt(j);
			}
		}
	}

	public static int findDirIndexFromAngle(int angle)
	{
		for (int i = 0; i < ARROWINDEX.Length - 1; i++)
		{
			if (angle >= ARROWINDEX[i] && angle <= ARROWINDEX[i + 1])
			{
				if (i >= 16)
				{
					return 0;
				}
				return i;
			}
		}
		return 0;
	}

	public override void paint(mGraphics2 g)
	{
		int num = findDirIndexFromAngle(360 - angle);
		int num2 = FRAME[num];
		int transform = TRANSFORM[num];
		for (int i = darts.size() / 2; i < darts.size(); i++)
		{
			SmallDart2 smallDart = (SmallDart2)darts.elementAt(i);
			SmallImage2.drawSmallImage(g, info.tailBorder[smallDart.index], smallDart.x, smallDart.y, 0, 3);
		}
		int num3 = GameCanvas2.gameTick % info.headBorder.Length;
		SmallImage2.drawSmallImage(g, info.headBorder[num3][num2], x, y, transform, 3);
		for (int j = 0; j < darts.size(); j++)
		{
			SmallDart2 smallDart2 = (SmallDart2)darts.elementAt(j);
			SmallImage2.drawSmallImage(g, info.tail[smallDart2.index], smallDart2.x, smallDart2.y, 0, 3);
		}
		SmallImage2.drawSmallImage(g, info.head[num3][num2], x, y, transform, 3);
		for (int k = 0; k < darts.size(); k++)
		{
			SmallDart2 smallDart3 = (SmallDart2)darts.elementAt(k);
			if (Res2.abs(r.nextInt(100)) < info.xdPercent)
			{
				SmallImage2.drawSmallImage(g, (GameCanvas2.gameTick % 2 != 0) ? info.xd2[smallDart3.index] : info.xd1[smallDart3.index], smallDart3.x, smallDart3.y, 0, 3);
			}
		}
	}

	public static void addMonsterDart(int x2, int y2, bool checkIsBoss, int dame2, int dameMp2, Mob2 mobToAttack, sbyte dartType)
	{
		addMonsterDart(x2, y2, checkIsBoss, dame2, dameMp2, mobToAttack.x, mobToAttack.y, dartType);
	}
}
