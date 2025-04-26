public class EffectManager2 : MyVector2
{
	public static EffectManager2 lowEffects = new EffectManager2();

	public static EffectManager2 mid_2Effects = new EffectManager2();

	public static EffectManager2 midEffects = new EffectManager2();

	public static EffectManager2 hiEffects = new EffectManager2();

	public void updateAll()
	{
		for (int num = size() - 1; num >= 0; num--)
		{
			Effect_End2 effect_End = (Effect_End2)elementAt(num);
			if (effect_End != null)
			{
				effect_End.update();
				if (effect_End.isRemove)
				{
					removeElementAt(num);
				}
			}
		}
	}

	public static void update()
	{
		hiEffects.updateAll();
		mid_2Effects.updateAll();
		midEffects.updateAll();
		lowEffects.updateAll();
	}

	public void paintAll(mGraphics2 g)
	{
		for (int i = 0; i < size(); i++)
		{
			Effect_End2 effect_End = (Effect_End2)elementAt(i);
			if (effect_End != null && !effect_End.isRemove)
			{
				((Effect_End2)elementAt(i)).paint(g);
			}
		}
	}

	public void removeAll()
	{
		for (int num = size() - 1; num >= 0; num--)
		{
			Effect_End2 effect_End = (Effect_End2)elementAt(num);
			if (effect_End != null)
			{
				effect_End.isRemove = true;
				removeElementAt(num);
			}
		}
	}

	public static void remove()
	{
		hiEffects.removeAll();
		lowEffects.removeAll();
		midEffects.removeAll();
		mid_2Effects.removeAll();
	}

	public static void addHiEffect(Effect_End2 eff)
	{
		hiEffects.addElement(eff);
	}

	public static void addMidEffects(Effect_End2 eff)
	{
		midEffects.addElement(eff);
	}

	public static void addMid_2Effects(Effect_End2 eff)
	{
		mid_2Effects.addElement(eff);
	}

	public static void addLowEffect(Effect_End2 eff)
	{
		lowEffects.addElement(eff);
	}
}
