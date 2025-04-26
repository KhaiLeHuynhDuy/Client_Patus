using System;

public class ChooseCharScr2 : mScreen2, IActionListener2
{
	public Command2[] vc_players;

	public static PlayerData2[] playerData;

	private int cf;

	private int[] cx = new int[2]
	{
		GameCanvas2.w / 2 - 100,
		GameCanvas2.w / 2 - 100
	};

	private int focus;

	private int[] cy = new int[2];

	private int[] rectPanel = new int[4]
	{
		GameCanvas2.w / 2 - 150,
		GameCanvas2.h / 2 - 100,
		300,
		200
	};

	private int offsetY = -35;

	private int offsetX = -35;

	public override void switchToMe()
	{
		ServerListScreen2.isWait = false;
		Char2.isLoadingMap = false;
		LoginScr2.isContinueToLogin = false;
		ServerListScreen2.waitToLogin = false;
		GameScr2.gI().initSelectChar();
		base.switchToMe();
	}

	public override void update()
	{
		if (GameCanvas2.gameTick % 10 > 2)
		{
			cf = 1;
		}
		else
		{
			cf = 0;
		}
		for (int i = 0; i < vc_players.Length; i++)
		{
			if (vc_players[i].isPointerPressInside())
			{
				vc_players[i].performAction();
			}
		}
		for (int j = 0; j < cx.Length; j++)
		{
			if (GameCanvas2.isPointerHoldIn(cx[j] + offsetX, cy[j] + offsetY, rectPanel[2], 60))
			{
				if (GameCanvas2.isPointerDown)
				{
					focus = j;
					break;
				}
				if (GameCanvas2.isPointerJustRelease && !GameCanvas2.isPointerClick)
				{
				}
			}
		}
		base.update();
	}

	public override void paint(mGraphics2 g)
	{
		GameCanvas2.paintBGGameScr(g);
		try
		{
			PopUp2.paintPopUp(g, rectPanel[0] - 10, rectPanel[1], rectPanel[2] + 20, rectPanel[3], 16777215, isButton: true);
			if (vc_players != null)
			{
				for (int i = 0; i < vc_players.Length; i++)
				{
					vc_players[i].paint(g);
				}
			}
			if (playerData != null)
			{
				for (int j = 0; j < playerData.Length; j++)
				{
					PopUp2.paintPopUp(g, cx[j] - 20, cy[j] + offsetY, rectPanel[2], 60, 16777215, isButton: false);
					Part2 part = GameScr2.parts[playerData[j].head];
					Part2 part2 = GameScr2.parts[playerData[j].leg];
					Part2 part3 = GameScr2.parts[playerData[j].body];
					SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, cx[j] + Char2.CharInfo[cf][0][1] + part.pi[Char2.CharInfo[cf][0][0]].dx, cy[j] - Char2.CharInfo[cf][0][2] + part.pi[Char2.CharInfo[cf][0][0]].dy, 0, 0);
					SmallImage2.drawSmallImage(g, part2.pi[Char2.CharInfo[cf][1][0]].id, cx[j] + Char2.CharInfo[cf][1][1] + part2.pi[Char2.CharInfo[cf][1][0]].dx, cy[j] - Char2.CharInfo[cf][1][2] + part2.pi[Char2.CharInfo[cf][1][0]].dy, 0, 0);
					SmallImage2.drawSmallImage(g, part3.pi[Char2.CharInfo[cf][2][0]].id, cx[j] + Char2.CharInfo[cf][2][1] + part3.pi[Char2.CharInfo[cf][2][0]].dx, cy[j] - Char2.CharInfo[cf][2][2] + part3.pi[Char2.CharInfo[cf][2][0]].dy, 0, 0);
					if (focus == j)
					{
						mFont2.tahoma_7b_yellow.drawString(g, playerData[j].name, cx[j] + rectPanel[2] - 25, cy[j] + offsetY, 1);
						mFont2.tahoma_7b_yellow.drawString(g, mResources2.power_point + " " + Res2.formatNumber2(playerData[j].powpoint), cx[j] + rectPanel[2] - 25, cy[j] + offsetY + mFont2.tahoma_7b_yellow.getHeight(), 1);
					}
					else
					{
						mFont2.tahoma_7b_dark.drawString(g, playerData[j].name, cx[j] + rectPanel[2] - 25, cy[j] + offsetY, 1);
						mFont2.tahoma_7b_dark.drawString(g, mResources2.power_point + " " + Res2.formatNumber2(playerData[j].powpoint), cx[j] + rectPanel[2] - 25, cy[j] + offsetY + mFont2.tahoma_7b_dark.getHeight(), 1);
					}
				}
			}
		}
		catch (Exception)
        {
		}
		base.paint(g);
	}

	internal void updateChooseCharacter(byte len)
	{
		cx = new int[len];
		cy = new int[len];
		for (int i = 0; i < len; i++)
		{
			cx[i] = rectPanel[0] + 20;
			cy[i] = i * 70 + rectPanel[1] + 50;
		}
		vc_players = new Command2[2];
		vc_players[1] = new Command2("Vào game", this, 1, null, rectPanel[0] + rectPanel[2] - 80 - 80, rectPanel[1] + rectPanel[3] - 30);
		vc_players[0] = new Command2("Trờ ra", this, 2, null, rectPanel[0] + rectPanel[2] - 80, rectPanel[1] + rectPanel[3] - 30);
	}

	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 1:
			if (focus != -1)
			{
				GameCanvas2.startWaitDlg();
				Service2.gI().finishUpdate(playerData[focus].playerID);
			}
			break;
		case 2:
			GameCanvas2.instance.doResetToLoginScr(GameCanvas2.serverScreen);
			break;
		}
	}
}
