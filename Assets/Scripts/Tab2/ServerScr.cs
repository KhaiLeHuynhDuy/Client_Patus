public class ServerScr2 : mScreen2, IActionListener2
{
	private int mainSelect;

	private MyVector2 vecServer = new MyVector2();

	private Command2 cmdCheck;

	public const int icmd = 100;

	private int wc;

	private int hc;

	private int w2c;

	private int numw;

	private int numh;

	private Command2 cmdGlobal;

	private Command2 cmdVietNam;

	public ServerScr2()
	{
		TileMap2.bgID = (byte)(mSystem2.currentTimeMillis() % 9);
		if (TileMap2.bgID == 5 || TileMap2.bgID == 6)
		{
			TileMap2.bgID = 4;
		}
		GameScr2.loadCamera(fullmScreen: true, -1, -1);
		GameScr2.cmx = 100;
		GameScr2.cmy = 200;
	}

	public override void switchToMe()
	{
		//SoundMn2.gI().stopAll();
		base.switchToMe();
		cmdGlobal = new Command2("VIỆT NAM", this, 98, null);
		cmdGlobal.x = 0;
		cmdGlobal.y = 0;
		cmdVietNam = new Command2("GLOBAL", this, 97, null);
		cmdVietNam.x = 50;
		cmdVietNam.y = 0;
		vecServer = new MyVector2();
		vecServer.addElement(cmdGlobal);
		vecServer.addElement(cmdVietNam);
		sort();
		cmdGlobal.performAction();
	}

	private void sort()
	{
		mainSelect = ServerListScreen2.ipSelect;
		w2c = 5;
		wc = 76;
		hc = mScreen2.cmdH;
		numw = 2;
		if (GameCanvas2.w > 3 * (wc + w2c))
		{
			numw = 3;
		}
		if (vecServer.size() < 3)
		{
			numw = 2;
		}
		numh = vecServer.size() / numw + ((vecServer.size() % numw != 0) ? 1 : 0);
		for (int i = 0; i < vecServer.size(); i++)
		{
			Command2 command = (Command2)vecServer.elementAt(i);
			if (command != null)
			{
				int num = GameCanvas2.hw - numw * (wc + w2c) / 2;
				int x = num + i % numw * (wc + w2c);
				int num2 = GameCanvas2.hh - numh * (hc + w2c) / 2;
				int y = num2 + i / numw * (hc + w2c);
				command.x = x;
				command.y = y;
			}
		}
	}

	public override void update()
	{
		GameScr2.cmx++;
		if (GameScr2.cmx > GameCanvas2.w * 3 + 100)
		{
			GameScr2.cmx = 100;
		}
		for (int i = 0; i < vecServer.size(); i++)
		{
			Command2 command = (Command2)vecServer.elementAt(i);
			if (!GameCanvas2.isTouch)
			{
				if (i == mainSelect)
				{
					if (GameCanvas2.gameTick % 10 < 4)
					{
						command.isFocus = true;
					}
					else
					{
						command.isFocus = false;
					}
					cmdCheck = new Command2(mResources2.SELECT, this, command.idAction, null);
					center = cmdCheck;
				}
				else
				{
					command.isFocus = false;
				}
			}
			else if (command != null && command.isPointerPressInside())
			{
				command.performAction();
			}
		}
	}

	public override void paint(mGraphics2 g)
	{
		GameCanvas2.paintBGGameScr(g);
		for (int i = 0; i < vecServer.size(); i++)
		{
			if (vecServer.elementAt(i) != null)
			{
				((Command2)vecServer.elementAt(i)).paint(g);
			}
		}
		base.paint(g);
	}

	public override void updateKey()
	{
		base.updateKey();
		int num = mainSelect % numw;
		int num2 = mainSelect / numw;
		if (GameCanvas2.keyPressed[4])
		{
			if (num > 0)
			{
				mainSelect--;
			}
			GameCanvas2.keyPressed[4] = false;
		}
		else if (GameCanvas2.keyPressed[6])
		{
			if (num < numw - 1)
			{
				mainSelect++;
			}
			GameCanvas2.keyPressed[6] = false;
		}
		else if (GameCanvas2.keyPressed[2])
		{
			if (num2 > 0)
			{
				mainSelect -= numw;
			}
			GameCanvas2.keyPressed[2] = false;
		}
		else if (GameCanvas2.keyPressed[8])
		{
			if (num2 < numh - 1)
			{
				mainSelect += numw;
			}
			GameCanvas2.keyPressed[8] = false;
		}
		if (mainSelect < 0)
		{
			mainSelect = 0;
		}
		if (mainSelect >= vecServer.size())
		{
			mainSelect = vecServer.size() - 1;
		}
		if (GameCanvas2.keyPressed[5])
		{
			((Command2)vecServer.elementAt(num)).performAction();
			GameCanvas2.keyPressed[5] = false;
		}
		GameCanvas2.clearKeyPressed();
	}

	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 97:
		{
			vecServer.removeAllElements();
			for (int j = 0; j < ServerListScreen2.nameServer.Length; j++)
			{
				if (ServerListScreen2.language[j] != 0)
				{
					vecServer.addElement(new Command2(ServerListScreen2.nameServer[j], this, 100 + j, null));
				}
			}
			sort();
			break;
		}
		case 98:
		{
			vecServer.removeAllElements();
			for (int i = 0; i < ServerListScreen2.nameServer.Length; i++)
			{
				if (ServerListScreen2.language[i] == 0)
				{
					vecServer.addElement(new Command2(ServerListScreen2.nameServer[i], this, 100 + i, null));
				}
			}
			sort();
			break;
		}
		case 99:
			Session_ME2_.gI().clearSendingMessage();
			ServerListScreen2.ipSelect = mainSelect;
			GameCanvas2.serverScreen.selectServer();
			GameCanvas2.serverScreen.switchToMe();
			break;
		default:
			Session_ME2_.gI().clearSendingMessage();
			ServerListScreen2.ipSelect = idAction - 100;
			GameCanvas2.serverScreen.selectServer();
			GameCanvas2.serverScreen.switchToMe();
			break;
		}
	}
}
