using System;

public class Timer2
{
	public static IActionListener2 timeListener;

	public static int idAction;

	public static long timeExecute;

	public static bool isON;

	public static void setTimer(IActionListener2 actionListener, int action, long timeEllapse)
	{
		timeListener = actionListener;
		idAction = action;
		timeExecute = mSystem2.currentTimeMillis() + timeEllapse;
		isON = true;
	}

	public static void update()
	{
		long num = mSystem2.currentTimeMillis();
		if (!isON || num <= timeExecute)
		{
			return;
		}
		isON = false;
		try
		{
			if (idAction > 0)
			{
				GameScr2.gI().actionPerform(idAction, null);
			}
		}
		catch (Exception)
		{
		}
	}
}
