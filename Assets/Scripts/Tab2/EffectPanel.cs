public class EffectPanel2 : Effect2_2
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
		EffectPanel2 effectPanel = new EffectPanel2();
		effectPanel.eff = GameScr2.efs[id - 1];
		effectPanel.x = cx;
		effectPanel.y = cy;
		effectPanel.loopCount = (short)loopCount;
		Effect2_2.vEffect3.addElement(effectPanel);
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
			SmallImage2.drawSmallImage(g, eff.arrEfInfo[i0].idImg, num, num2, trans, mGraphics2.VCENTER | mGraphics2.HCENTER);
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
				Effect2_2.vEffect3.removeElement(this);
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
					Effect2_2.vEffect3.removeElement(this);
				}
				else
				{
					i0 = 0;
				}
			}
		}
		if (GameCanvas2.gameTick % 11 == 0 && c != null && c != Char2.myCharz() && !GameScr2.vCharInMap.contains(c))
		{
			Effect2_2.vEffect3.removeElement(this);
		}
	}
}
