public class SplashScr2 : mScreen2
{
	public static int splashScrStat;

	private bool isCheckConnect;

	public static int nData = -1;

	public static int maxData = -1;

	public static SplashScr2 instance;

	public long TIMEOUT;

	public SplashScr2()
	{
		instance = this;
	}

	public static void loadSplashScr()
	{
		splashScrStat = 0;
	}

	public override void update()
	{
		if (splashScrStat == 30 && !isCheckConnect)
		{
			isCheckConnect = true;
			if (Rms2.loadRMSInt("serverchat") != -1)
			{
				GameScr2.isPaintChatVip = ((Rms2.loadRMSInt("serverchat") == 0) ? true : false);
			}
			if (Rms2.loadRMSInt("isPlaySound") != -1)
			{
				GameCanvas2.isPlaySound = Rms2.loadRMSInt("isPlaySound") == 1;
			}
			if (GameCanvas2.isPlaySound)
			{
				SoundMn2.gI().loadSound(TileMap2.mapID);
			}
			SoundMn2.gI().getStrOption();
			if (Rms2.loadRMSInt("svselect") == -1)
			{
				string linkDefault = ServerListScreen2.linkDefault;
				string[] array = Res2.split(linkDefault.Trim(), ",", 0);
				mResources2.loadLanguague(sbyte.Parse(array[array.Length - 2]));
				ServerListScreen2.nameServer = new string[array.Length - 2];
				ServerListScreen2.address = new string[array.Length - 2];
				ServerListScreen2.port = new short[array.Length - 2];
				ServerListScreen2.language = new sbyte[array.Length - 2];
				ServerListScreen2.hasConnected = new bool[2];
				for (int i = 0; i < array.Length - 2; i++)
				{
					string[] array2 = Res2.split(array[i].Trim(), ":", 0);
					ServerListScreen2.nameServer[i] = array2[0];
					ServerListScreen2.address[i] = array2[1];
					ServerListScreen2.port[i] = short.Parse(array2[2]);
					ServerListScreen2.language[i] = sbyte.Parse(array2[3].Trim());
				}
				GameCanvas2.serverScr.switchToMe();
			}
			else
			{
				ServerListScreen2.LoadIP();
			}
		}
		splashScrStat++;
		ServerListScreen2.updateDeleteData();
		if (splashScrStat >= 150)
		{
			if (Session_ME2_.gI().isConnected())
			{
				ServerListScreen2.loadScreen = true;
				GameCanvas2.serverScreen.switchToMe();
			}
			else
			{
				mSystem2.onDisconnected();
			}
		}
	}

	public static void loadIP()
	{

		if (Rms2.loadRMSInt("svselect") == -1)
		{
			int num = 0;
			if (mResources2.language > 0)
			{
				for (int i = 0; i < mResources2.language; i++)
				{
					num += ServerListScreen2.lengthServer[i];
				}
			}
			if (ServerListScreen2.serverPriority == -1)
			{
				ServerListScreen2.ipSelect = num + Res2.random(0, ServerListScreen2.lengthServer[mResources2.language]);
			}
			else
			{
				ServerListScreen2.ipSelect = ServerListScreen2.serverPriority;
			}
			Rms2.saveRMSInt("svselect", ServerListScreen2.ipSelect);
			GameMidlet2.IP = ServerListScreen2.address[ServerListScreen2.ipSelect];
			GameMidlet2.PORT = ServerListScreen2.port[ServerListScreen2.ipSelect];
			mResources2.loadLanguague(ServerListScreen2.language[ServerListScreen2.ipSelect]);
			LoginScr2.serverName = ServerListScreen2.nameServer[ServerListScreen2.ipSelect];
			GameCanvas2.connect();
		}
		else
		{
			ServerListScreen2.ipSelect = Rms2.loadRMSInt("svselect");
			if (ServerListScreen2.ipSelect > ServerListScreen2.nameServer.Length - 1)
			{
				ServerListScreen2.ipSelect = ServerListScreen2.serverPriority;
				Rms2.saveRMSInt("svselect", ServerListScreen2.ipSelect);
			}
			GameMidlet2.IP = ServerListScreen2.address[ServerListScreen2.ipSelect];
			GameMidlet2.PORT = ServerListScreen2.port[ServerListScreen2.ipSelect];
			mResources2.loadLanguague(ServerListScreen2.language[ServerListScreen2.ipSelect]);
			LoginScr2.serverName = ServerListScreen2.nameServer[ServerListScreen2.ipSelect];
			GameCanvas2.connect();
		}
	}

	public override void paint(mGraphics2 g)
	{
		if (MainMod2.imgLogoBig != null && splashScrStat < 30)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
			int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
			int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
			g.drawImageScale(MainMod2.imgLogoBig, (GameCanvas2.w - imgW) / 2, (GameCanvas2.h - imgH) / 2, imgW, imgH);
		}
		if (nData != -1)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
			//g.drawImage(imgLogo, GameCanvas.w / 2, GameCanvas.h / 2 - 24, StaticObj.BOTTOM_HCENTER);

			int imgW = MainMod2.imgLogoBig.getWidth() * mGraphics2.zoomLevel / 4;
			int imgH = MainMod2.imgLogoBig.getHeight() * mGraphics2.zoomLevel / 4;
			g.drawImageScale(MainMod2.imgLogoBig, (GameCanvas2.w - imgW) / 2, (GameCanvas2.h - imgH) / 2 - 24, imgW, imgH);

			GameCanvas2.paintShukiren(GameCanvas2.hw, GameCanvas2.h / 2 + 24, g);
			mFont2.tahoma_7b_white.drawString(g, mResources2.downloading_data + nData * 100 / maxData + "%", GameCanvas2.w / 2, GameCanvas2.h / 2, 2);
		}
		else if (splashScrStat >= 30)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas2.w, GameCanvas2.h);
			GameCanvas2.paintShukiren(GameCanvas2.hw, GameCanvas2.hh, g);
			if (ServerListScreen2.cmdDeleteRMS != null)
			{
				mFont2.tahoma_7_white.drawStringBorder(g, mResources2.xoadulieu, GameCanvas2.w - 2, GameCanvas2.h - 15, 1, mFont2.tahoma_7_grey);
			}
		}
	}

	public static void LoadImg()
	{
		MainMod2.LoadImages();
		MainMod2.LoadTickImages();
	}
}
