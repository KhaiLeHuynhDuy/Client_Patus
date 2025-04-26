public class MsgDlg2 : Dialog2
{
	public string[] info;

	public bool isWait;

	private int h;

	private int padLeft;

	private long time = -1L;

	public MsgDlg2()
	{
		padLeft = 35;
		if (GameCanvas2.w <= 176)
		{
			padLeft = 10;
		}
		if (GameCanvas2.w > 320)
		{
			padLeft = 80;
		}
	}

	public void pleasewait()
	{
		setInfo(mResources2.PLEASEWAIT, null, null, null);
		GameCanvas2.currentDialog = this;
		time = mSystem2.currentTimeMillis() + 5000;
	}

	public override void show()
	{
		GameCanvas2.currentDialog = this;
		time = -1L;
	}

	public void setInfo(string info)
	{
		this.info = mFont2.tahoma_8b.splitFontArray(info, GameCanvas2.w - (padLeft * 2 + 20));
		h = 80;
		if (this.info.Length >= 5)
		{
			h = this.info.Length * mFont2.tahoma_8b.getHeight() + 20;
		}
	}

	public void setInfo(string info, Command2 left, Command2 center, Command2 right)
	{
		this.info = mFont2.tahoma_8b.splitFontArray(info, GameCanvas2.w - (padLeft * 2 + 20));
		base.left = left;
		base.center = center;
		base.right = right;
		h = 80;
		if (this.info.Length >= 5)
		{
			h = this.info.Length * mFont2.tahoma_8b.getHeight() + 20;
		}
		if (GameCanvas2.isTouch)
		{
			if (left != null)
			{
				base.left.x = GameCanvas2.w / 2 - 68 - 5;
				base.left.y = GameCanvas2.h - 50;
			}
			if (right != null)
			{
				base.right.x = GameCanvas2.w / 2 + 5;
				base.right.y = GameCanvas2.h - 50;
			}
			if (center != null)
			{
				base.center.x = GameCanvas2.w / 2 - 35;
				base.center.y = GameCanvas2.h - 50;
			}
		}
		isWait = false;
		time = -1L;
	}

	public override void paint(mGraphics2 g)
	{
		g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
		if (!LoginScr2.isContinueToLogin)
		{
			int num = GameCanvas2.h - h - 38;
			int w = GameCanvas2.w - padLeft * 2;
			GameCanvas2.paintz.paintPopUp(padLeft, num, w, h, g);
			int num2 = num + (h - info.Length * mFont2.tahoma_8b.getHeight()) / 2 - 2;
			if (isWait)
			{
				num2 += 8;
				GameCanvas2.paintShukiren(GameCanvas2.hw, num2 - 12, g);
			}
			int num3 = 0;
			int num4 = num2;
			while (num3 < info.Length)
			{
				mFont2.tahoma_7b_dark.drawString(g, info[num3], GameCanvas2.hw, num4, 2);
				num3++;
				num4 += mFont2.tahoma_8b.getHeight();
			}
			base.paint(g);
		}
	}

	public override void update()
	{
		base.update();
		if (time != -1 && mSystem2.currentTimeMillis() > time)
		{
			GameCanvas2.endDlg();
		}
	}
}
