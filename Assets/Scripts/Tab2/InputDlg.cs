public class InputDlg2 : Dialog2
{
	protected string[] info;

	public TField2 tfInput;

	private int padLeft;

	public InputDlg2()
	{
		padLeft = 40;
		if (GameCanvas2.w <= 176)
		{
			padLeft = 10;
		}
		tfInput = new TField2();
		tfInput.x = padLeft + 10;
		tfInput.y = GameCanvas2.h - mScreen2.ITEM_HEIGHT - 43;
		tfInput.width = GameCanvas2.w - 2 * (padLeft + 10);
		tfInput.height = mScreen2.ITEM_HEIGHT + 2;
		tfInput.isFocus = true;
		right = tfInput.cmdClear;
	}

	public void show(string info, Command2 ok, int type)
	{
		tfInput.setText(string.Empty);
		tfInput.setIputType(type);
		this.info = mFont2.tahoma_8b.splitFontArray(info, GameCanvas2.w - padLeft * 2);
		left = new Command2(mResources2.CLOSE, GameCanvas2.gI(), 8882, null);
		center = ok;
		show();
	}

	public override void paint(mGraphics2 g)
	{
		GameCanvas2.paintz.paintInputDlg(g, padLeft, GameCanvas2.h - 77 - mScreen2.cmdH, GameCanvas2.w - padLeft * 2, 69, info);
		tfInput.paint(g);
		base.paint(g);
	}

	public override void keyPress(int keyCode)
	{
		tfInput.keyPressed(keyCode);
		base.keyPress(keyCode);
	}

	public override void update()
	{
		tfInput.update();
		base.update();
	}

	public override void show()
	{
		GameCanvas2.currentDialog = this;
	}

	public void hide()
	{
		GameCanvas2.endDlg();
	}
}
