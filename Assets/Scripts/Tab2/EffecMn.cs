public class EffecMn2
{
	public static MyVector2 vEff = new MyVector2();

	public static void addEff(Effect2_ me)
	{
		vEff.addElement(me);
	}

	public static void removeEff(int id)
	{
		if (getEffById(id) != null)
		{
			vEff.removeElement(getEffById(id));
		}
	}

	public static Effect2_ getEffById(int id)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			Effect2_ effect = (Effect2_)vEff.elementAt(i);
			if (effect.effId == id)
			{
				return effect;
			}
		}
		return null;
	}

	public static void paintBackGroundUnderLayer(mGraphics2 g, int x, int y, int layer)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			if (((Effect2_)vEff.elementAt(i)).layer == -layer)
			{
				((Effect2_)vEff.elementAt(i)).paintUnderBackground(g, x, y);
			}
		}
	}

	public static void paintLayer1(mGraphics2 g)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			if (((Effect2_)vEff.elementAt(i)).layer == 1)
			{
				((Effect2_)vEff.elementAt(i)).paint(g);
			}
		}
	}

	public static void paintLayer2(mGraphics2 g)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			if (((Effect2_)vEff.elementAt(i)).layer == 2)
			{
				((Effect2_)vEff.elementAt(i)).paint(g);
			}
		}
	}

	public static void paintLayer3(mGraphics2 g)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			if (((Effect2_)vEff.elementAt(i)).layer == 3)
			{
				((Effect2_)vEff.elementAt(i)).paint(g);
			}
		}
	}

	public static void paintLayer4(mGraphics2 g)
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			if (((Effect2_)vEff.elementAt(i)).layer == 4)
			{
				((Effect2_)vEff.elementAt(i)).paint(g);
			}
		}
	}

	public static void update()
	{
		for (int i = 0; i < vEff.size(); i++)
		{
			((Effect2_)vEff.elementAt(i)).update();
		}
	}
}
