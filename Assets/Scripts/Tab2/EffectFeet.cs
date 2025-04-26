public class EffectFeet2 : Effect2_2
{
	private int x;

	private int y;

	private int trans;

	private long endTime;

	private bool isF;

	public static Image2 imgFeet1 = GameCanvas2.loadImage("/mainImage/myTexture2dmove-1.png");

	public static Image2 imgFeet3 = GameCanvas2.loadImage("/mainImage/myTexture2dmove-3.png");

	public static void addFeet(int cx, int cy, int ctrans, int timeInMillisSecond, bool isCF)
	{
		EffectFeet2 effectFeet = new()
		{
			x = cx,
			y = cy,
			trans = ctrans,
			isF = isCF,
			endTime = mSystem2.currentTimeMillis() + timeInMillisSecond
		};
		Effect2_2.vEffectFeet.addElement(effectFeet);
	}

	public override void update()
	{
		if (mSystem2.currentTimeMillis() - endTime > 0)
		{
			Effect2_2.vEffectFeet.removeElement(this);
		}
	}

	public override void paint(mGraphics2 g)
	{
		int num = TileMap2.size;
		if (TileMap2.tileTypeAt(x + num / 2, y + 1, 4))
		{
			g.setClip(x / num * num, (y - 30) / num * num, num, 100);
		}
		else if (TileMap2.tileTypeAt((x - num / 2) / num, (y + 1) / num) == 0)
		{
			g.setClip(x / num * num, (y - 30) / num * num, 100, 100);
		}
		else if (TileMap2.tileTypeAt((x + num / 2) / num, (y + 1) / num) == 0)
		{
			g.setClip(x / num * num, (y - 30) / num * num, num, 100);
		}
		else if (TileMap2.tileTypeAt(x - num / 2, y + 1, 8))
		{
			g.setClip(x / 24 * num, (y - 30) / num * num, num, 100);
		}
		g.drawRegion((!isF) ? imgFeet3 : imgFeet1, 0, 0, imgFeet1.getWidth(), imgFeet1.getHeight(), trans, x, y, mGraphics2.BOTTOM | mGraphics2.HCENTER);
		g.setClip(GameScr2.cmx, GameScr2.cmy - GameCanvas2.transY, GameScr2.gW, GameScr2.gH + 2 * GameCanvas2.transY);
	}
}
