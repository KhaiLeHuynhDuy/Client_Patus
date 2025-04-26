public class PlayerDart2
{
	public Char2 charBelong;

	public DartInfo2 info;

	public MyVector2 darts = new MyVector2();

	public int angle;

	public int vx;

	public int vy;

	public int va;

	public int x;

	public int y;

	public int z;

	private int life;

	private int dx;

	private int dy;

	public bool isActive = true;

	public bool isSpeedUp;

	public SkillPaint2 skillPaint;

	public PlayerDart2(Char2 charBelong, int dartType, SkillPaint2 sp, int x, int y)
	{
		skillPaint = sp;
		this.charBelong = charBelong;
		info = GameScr2.darts[dartType];
		va = info.va;
		this.x = x;
		this.y = y;
		object obj;
		if (charBelong.mobFocus == null)
		{
			IMapObject2 charFocus = charBelong.charFocus;
			obj = charFocus;
		}
		else
		{
			obj = charBelong.mobFocus;
		}
		IMapObject2 mapObject = (IMapObject2)obj;
		setAngle(Res2.angle(mapObject.getX() - x, mapObject.getY() - y));
	}

	public void setAngle(int angle)
	{
		this.angle = angle;
		vx = va * Res2.cos(angle) >> 10;
		vy = va * Res2.sin(angle) >> 10;
	}

	public void update()
	{
		if (!isActive)
		{
			return;
		}
		if (charBelong.mobFocus == null && charBelong.charFocus == null)
		{
			endMe();
			return;
		}
		object obj;
		if (charBelong.mobFocus == null)
		{
			IMapObject2 charFocus = charBelong.charFocus;
			obj = charFocus;
		}
		else
		{
			obj = charBelong.mobFocus;
		}
		IMapObject2 mapObject = (IMapObject2)obj;
		for (int i = 0; i < info.nUpdate; i++)
		{
			if (info.tail.Length > 0)
			{
				darts.addElement(new SmallDart2(x, y));
			}
			int num = ((charBelong.getX() <= mapObject.getX()) ? (-10) : 10);
			dx = mapObject.getX() + num - x;
			dy = mapObject.getY() - mapObject.getH() / 2 - y;
			life++;
			if (Res2.abs(dx) < 20 && Res2.abs(dy) < 20)
			{
				if (charBelong.charFocus != null && charBelong.charFocus.me)
				{
					charBelong.charFocus.doInjure(charBelong.charFocus.damHP, 0, charBelong.charFocus.isCrit, charBelong.charFocus.isMob);
				}
				endMe();
				return;
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

	private void endMe()
	{
		if (!charBelong.isUseSkillAfterCharge && x >= GameScr2.cmx && x <= GameScr2.cmx + GameCanvas2.w)
		{
			SoundMn2.gI().explode_1();
		}
		charBelong.setAttack();
		if (charBelong.me)
		{
			charBelong.saveLoadPreviousSkill();
		}
		if (charBelong.isUseSkillAfterCharge)
		{
			charBelong.isUseSkillAfterCharge = false;
			if (charBelong.isLockMove && charBelong.me && charBelong.statusMe != 14 && charBelong.statusMe != 5)
			{
				charBelong.isLockMove = false;
			}
			GameScr2.gI().activeSuperPower(x, y);
		}
		charBelong.dart = null;
		charBelong.isCreateDark = false;
		charBelong.skillPaint = null;
		charBelong.skillPaintRandomPaint = null;
	}

	public void paint(mGraphics2 g)
	{
		if (!isActive)
		{
			return;
		}
		int num = MonsterDart2.findDirIndexFromAngle(360 - angle);
		int num2 = MonsterDart2.FRAME[num];
		int transform = MonsterDart2.TRANSFORM[num];
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
			if (Res2.abs(MonsterDart2.r.nextInt(100)) < info.xdPercent)
			{
				SmallImage2.drawSmallImage(g, (GameCanvas2.gameTick % 2 != 0) ? info.xd2[smallDart3.index] : info.xd1[smallDart3.index], smallDart3.x, smallDart3.y, 0, 3);
			}
		}
		g.setColor(16711680);
	}
}
