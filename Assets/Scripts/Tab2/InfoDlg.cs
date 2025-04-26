public class InfoDlg2
{
	public static bool isShow;

	private static string title;

	private static string subtitke;

	public static int delay;

	public static bool isLock;

	public static void show(string title, string subtitle, int delay)
	{
		if (title != null)
		{
			isShow = true;
			InfoDlg2.title = title;
			subtitke = subtitle;
			InfoDlg2.delay = delay;
		}
	}

	public static void showWait()
	{
		show(mResources2.PLEASEWAIT, null, 1000);
		isLock = true;
	}

	public static void showWait(string str)
	{
		show(str, null, 700);
		isLock = true;
	}

	public static void paint(mGraphics2 g)
	{
		if (isShow && (!isLock || delay <= 4990) && !GameScr2.isPaintAlert)
		{
			int num = 10;
			GameCanvas2.paintz.paintPopUp(GameCanvas2.hw - 75, num, 150, 55, g);
			if (isLock)
			{
				GameCanvas2.paintShukiren(GameCanvas2.hw - mFont2.tahoma_8b.getWidth(title) / 2 - 10, num + 28, g);
				mFont2.tahoma_8b.drawString(g, title, GameCanvas2.hw + 5, num + 21, 2);
			}
			else if (subtitke != null)
			{
				mFont2.tahoma_8b.drawString(g, title, GameCanvas2.hw, num + 13, 2);
				mFont2.tahoma_7_green2.drawString(g, subtitke, GameCanvas2.hw, num + 30, 2);
			}
			else
			{
				mFont2.tahoma_8b.drawString(g, title, GameCanvas2.hw, num + 21, 2);
			}
		}
	}

	public static void update()
	{
		if (delay > 0)
		{
			delay--;
			if (delay == 0)
			{
				hide();
			}
		}
	}

	public static void hide()
	{
		title = string.Empty;
		subtitke = null;
		isLock = false;
		delay = 0;
		isShow = false;
	}
}
