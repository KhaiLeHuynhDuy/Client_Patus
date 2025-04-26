public class MoneyCharge2 : mScreen2, IActionListener2
{
	public static MoneyCharge2 instance;

	public TField2 tfSerial;

	public TField2 tfCode;

	private int x;

	private int y;

	private int w;

	private int h;

	private string[] strPaint;

	private int focus;

	private int yt;

	private int freeAreaHeight;

	private int yy = GameCanvas2.hh - mScreen2.ITEM_HEIGHT - 5;

	private int yP;

	public MoneyCharge2()
	{
		w = GameCanvas2.w - 20;
		if (w > 320)
		{
			w = 320;
		}
		strPaint = mFont2.tahoma_7b_green2.splitFontArray(mResources2.pay_card, w - 20);
		x = (GameCanvas2.w - w) / 2;
		y = GameCanvas2.h - 150 - (strPaint.Length - 1) * 20;
		h = 110 + (strPaint.Length - 1) * 20;
		yP = y;
		tfSerial = new TField2();
		tfSerial.name = mResources2.SERI_NUM;
		tfSerial.x = x + 10;
		tfSerial.y = y + 35 + (strPaint.Length - 1) * 20;
		yt = tfSerial.y;
		tfSerial.width = w - 20;
		tfSerial.height = mScreen2.ITEM_HEIGHT + 2;
		if (GameCanvas2.isTouch)
		{
			tfSerial.isFocus = false;
		}
		else
		{
			tfSerial.isFocus = true;
		}
		tfSerial.setIputType(TField2.INPUT_TYPE_ANY);
		if (Main2.isWindowsPhone)
		{
			tfSerial.showSubTextField = false;
		}
		if (Main2.isIPhone)
		{
			tfSerial.isPaintMouse = false;
		}
		if (!GameCanvas2.isTouch)
		{
			right = tfSerial.cmdClear;
		}
		tfCode = new TField2();
		tfCode.name = mResources2.CARD_CODE;
		tfCode.x = x + 10;
		tfCode.y = tfSerial.y + 35;
		tfCode.width = w - 20;
		tfCode.height = mScreen2.ITEM_HEIGHT + 2;
		tfCode.isFocus = false;
		tfCode.setIputType(TField2.INPUT_TYPE_ANY);
		if (Main2.isWindowsPhone)
		{
			tfCode.showSubTextField = false;
		}
		if (Main2.isIPhone)
		{
			tfCode.isPaintMouse = false;
		}
		left = new Command2(mResources2.CLOSE, this, 1, null);
		center = new Command2(mResources2.pay_card2, this, 2, null);
		if (GameCanvas2.isTouch)
		{
			center.x = GameCanvas2.w / 2 + 18;
			left.x = GameCanvas2.w / 2 - 85;
			center.y = (left.y = y + h + 5);
		}
		freeAreaHeight = tfSerial.y - (4 * tfSerial.height - 10);
		yP = tfSerial.y;
	}

	public static MoneyCharge2 gI()
	{
		if (instance == null)
		{
			instance = new MoneyCharge2();
		}
		return instance;
	}

	public override void switchToMe()
	{
		focus = 0;
		base.switchToMe();
	}

	public void updateTfWhenOpenKb()
	{
	}

	public override void paint(mGraphics2 g)
	{
		GameScr2.gI().paint(g);
		PopUp2.paintPopUp(g, x, y, w, h, -1, isButton: true);
		for (int i = 0; i < strPaint.Length; i++)
		{
			mFont2.tahoma_7b_green2.drawString(g, strPaint[i], GameCanvas2.w / 2, y + 15 + i * 20, mFont2.CENTER);
		}
		tfSerial.paint(g);
		tfCode.paint(g);
		base.paint(g);
	}

	public override void update()
	{
		GameScr2.gI().update();
		tfSerial.update();
		tfCode.update();
		if (Main2.isWindowsPhone)
		{
			updateTfWhenOpenKb();
		}
	}

	public override void keyPress(int keyCode)
	{
		if (tfSerial.isFocus)
		{
			tfSerial.keyPressed(keyCode);
		}
		else if (tfCode.isFocus)
		{
			tfCode.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	public override void updateKey()
	{
		if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
		{
			focus--;
			if (focus < 0)
			{
				focus = 1;
			}
		}
		else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22])
		{
			focus++;
			if (focus > 1)
			{
				focus = 1;
			}
		}
		if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] || GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22])
		{
			GameCanvas2.clearKeyPressed();
			if (focus == 1)
			{
				tfSerial.isFocus = false;
				tfCode.isFocus = true;
				if (!GameCanvas2.isTouch)
				{
					right = tfCode.cmdClear;
				}
			}
			else if (focus == 0)
			{
				tfSerial.isFocus = true;
				tfCode.isFocus = false;
				if (!GameCanvas2.isTouch)
				{
					right = tfSerial.cmdClear;
				}
			}
			else
			{
				tfSerial.isFocus = false;
				tfCode.isFocus = false;
			}
		}
		if (GameCanvas2.isPointerJustRelease)
		{
			if (GameCanvas2.isPointerHoldIn(tfSerial.x, tfSerial.y, tfSerial.width, tfSerial.height))
			{
				focus = 0;
			}
			else if (GameCanvas2.isPointerHoldIn(tfCode.x, tfCode.y, tfCode.width, tfCode.height))
			{
				focus = 1;
			}
		}
		base.updateKey();
		GameCanvas2.clearKeyPressed();
	}

	public void clearScreen()
	{
		instance = null;
	}

	public void perform(int idAction, object p)
	{
		if (idAction == 1)
		{
			GameScr2.instance.switchToMe();
			clearScreen();
		}
		if (idAction == 2)
		{
			if (tfSerial.getText() == null || tfSerial.getText().Equals(string.Empty))
			{
				GameCanvas2.startOKDlg(mResources2.serial_blank);
				return;
			}
			if (tfCode.getText() == null || tfCode.getText().Equals(string.Empty))
			{
				GameCanvas2.startOKDlg(mResources2.card_code_blank);
				return;
			}
			Service2.gI().sendCardInfo(tfSerial.getText(), tfCode.getText());
			GameScr2.instance.switchToMe();
			clearScreen();
		}
	}
}
