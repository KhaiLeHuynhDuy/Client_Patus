public class PopUpYesNo2 : IActionListener2
{
	public Command2 cmdYes;

	public Command2 cmdNo;

	public string[] info;

	private int X;

	private int Y;

	private int W = 120;

	private int H;

	private int dem;

	private long last;

	private long curr;

	public void setPopUp(string info, Command2 cmdYes, Command2 cmdNo)
	{
		this.info = new string[1] { info };
		H = 29;
		this.cmdYes = cmdYes;
		this.cmdYes.caption = null;
		this.cmdNo = cmdNo;
		this.cmdYes.img = this.cmdNo.img = GameScr2.imgNut;
		this.cmdYes.imgFocus = this.cmdNo.imgFocus = GameScr2.imgNutF;
		this.cmdYes.w = mGraphics2.getImageWidth(cmdYes.img);
		this.cmdNo.w = mGraphics2.getImageWidth(cmdYes.img);
		this.cmdYes.h = mGraphics2.getImageHeight(cmdYes.img);
		this.cmdNo.h = mGraphics2.getImageHeight(cmdYes.img);
		last = mSystem2.currentTimeMillis();
		dem = this.info[0].Length / 3;
		if (dem < 15)
		{
			dem = 15;
		}
		TextInfo2.reset();
	}

	public void paint(mGraphics2 g)
	{
		PopUp2.paintPopUp(g, X, Y, W, H + ((!GameCanvas2.isTouch) ? 10 : 0), 16777215, isButton: false);
		if (info != null)
		{
			TextInfo2.paint(g, info[0], X + 5, Y + H / 2 - ((!GameCanvas2.isTouch) ? 6 : 4), W - 10, H, mFont2.tahoma_7);
			if (GameCanvas2.isTouch)
			{
				cmdYes.paint(g);
				mFont2.tahoma_7b_dark.drawString(g, mResources2.YES,
				cmdYes.x + cmdYes.img.getWidth() / 2 - mFont2.tahoma_7b_dark.getWidth(mResources2.YES) / 2,
				cmdYes.y + cmdYes.img.getHeight() / 2 - mFont2.tahoma_7b_dark.getHeight() / 2, 0);
				// mFont2.tahoma_7_yellow.drawString(g, dem + string.Empty, cmdYes.x + cmdYes.w / 2, cmdYes.y + cmdYes.h + 5, 2, mFont2.tahoma_7_grey);
			}
			else if (TField2.isQwerty)
			{
				mFont2.tahoma_7b_blue.drawString(g, mResources2.do_accept_qwerty + dem + ")", X + W / 2, Y + H - 6, 2);
			}
			else
			{
				mFont2.tahoma_7b_blue.drawString(g, mResources2.do_accept + dem + ")", X + W / 2, Y + H - 6, 2);
			}
		}
	}

	public void update()
	{
		if (info != null)
		{
			X = GameCanvas2.w - 28 - W;
			Y = 45;
			if (GameCanvas2.w - 50 > 155 + W)
			{
				X = GameCanvas2.w - 78 - W;
				Y = 5;
			}
			cmdYes.x = X + W + 2;
			cmdYes.y = Y - 1;
			curr = mSystem2.currentTimeMillis();
			Res2.outz("curr - last= " + (curr - last));
			if (curr - last >= 1000)
			{
				last = mSystem2.currentTimeMillis();
				dem--;
			}
			if (dem == 0)
			{
				GameScr2.gI().popUpYesNo = null;
			}
		}
	}

	public void perform(int idAction, object p)
	{
	}
}
