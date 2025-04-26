using System;

public class GamePad2
{
	private int xC;

	private int yC;

	private int xM;

	private int yM;

	private int xMLast;

	private int yMLast;

	private int R;

	private int r;

	private int d;

	private int xTemp;

	private int yTemp;

	private int deltaX;

	private int deltaY;

	private int delta;

	private int angle;

	public int xZone;

	public int yZone;

	public int wZone;

	public int hZone;

	private bool isGamePad;

	public bool isSmallGamePad;

	public bool isMediumGamePad;

	public bool isLargeGamePad;

	public GamePad2()
	{
		R = 28;
		if (GameCanvas2.w < 300)
		{
			isSmallGamePad = true;
			isMediumGamePad = false;
			isLargeGamePad = false;
		}
		if (GameCanvas2.w >= 300 && GameCanvas2.w <= 380)
		{
			isSmallGamePad = false;
			isMediumGamePad = true;
			isLargeGamePad = false;
		}
		if (GameCanvas2.w > 380)
		{
			isSmallGamePad = false;
			isMediumGamePad = false;
			isLargeGamePad = true;
		}
		if (!isLargeGamePad)
		{
			xZone = 0;
			wZone = GameCanvas2.hw;
			yZone = GameCanvas2.hh >> 1;
			hZone = GameCanvas2.h - 80;
		}
		else
		{
			xZone = 0;
			wZone = GameCanvas2.hw / 4 * 3 - 20;
			yZone = GameCanvas2.hh >> 1;
			hZone = GameCanvas2.h;
		}
	}

	public void update()
	{
		try
		{
			if (GameScr2.isAnalog == 0)
			{
				return;
			}
			if (GameCanvas2.isPointerDown && !GameCanvas2.isPointerJustRelease)
			{
				xTemp = GameCanvas2.pxFirst;
				yTemp = GameCanvas2.pyFirst;
				if (xTemp < xZone || xTemp > wZone || yTemp < yZone || yTemp > hZone)
				{
					return;
				}
				if (!isGamePad)
				{
					xC = (xM = xTemp);
					yC = (yM = yTemp);
				}
				isGamePad = true;
				deltaX = GameCanvas2.px - xC;
				deltaY = GameCanvas2.py - yC;
				delta = Math2.pow(deltaX, 2) + Math2.pow(deltaY, 2);
				d = Res2.sqrt(delta);
				if (Math2.abs(deltaX) <= 4 && Math2.abs(deltaY) <= 4)
				{
					return;
				}
				angle = Res2.angle(deltaX, deltaY);
				if (!GameCanvas2.isPointerHoldIn(xC - R, yC - R, 2 * R, 2 * R))
				{
					if (d != 0)
					{
						yM = deltaY * R / d;
						xM = deltaX * R / d;
						xM += xC;
						yM += yC;
						if (!Res2.inRect(xC - R, yC - R, 2 * R, 2 * R, xM, yM))
						{
							xM = xMLast;
							yM = yMLast;
						}
						else
						{
							xMLast = xM;
							yMLast = yM;
						}
					}
					else
					{
						xM = xMLast;
						yM = yMLast;
					}
				}
				else
				{
					xM = GameCanvas2.px;
					yM = GameCanvas2.py;
				}
				resetHold();
				if (checkPointerMove(2))
				{
					if ((angle <= 360 && angle >= 340) || (angle >= 0 && angle <= 20))
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] = true;
					}
					else if (angle > 40 && angle < 70)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] = true;
					}
					else if (angle >= 70 && angle <= 110)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 8 : 22] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = true;
					}
					else if (angle > 110 && angle < 120)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] = true;
					}
					else if (angle >= 120 && angle <= 200)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] = true;
					}
					else if (angle > 200 && angle < 250)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = true;
						GameCanvas2.keyHold[(!Main2.isPC) ? 4 : 23] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23] = true;
					}
					else if (angle >= 250 && angle <= 290)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = true;
					}
					else if (angle > 290 && angle < 340)
					{
						GameCanvas2.keyHold[(!Main2.isPC) ? 2 : 21] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = true;
						GameCanvas2.keyHold[(!Main2.isPC) ? 6 : 24] = true;
						GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24] = true;
					}
				}
				else
				{
					resetHold();
				}
			}
			else
			{
				xM = (xC = 45);
				if (!isLargeGamePad)
				{
					yM = (yC = GameCanvas2.h - 90);
				}
				else
				{
					yM = (yC = GameCanvas2.h - 45);
				}
				isGamePad = false;
				resetHold();
			}
		}
		catch (Exception)
		{
		}
	}

	private bool checkPointerMove(int distance)
	{
		if (GameScr2.isAnalog == 0)
		{
			return false;
		}
		if (Char2.myCharz().statusMe == 3)
		{
			return true;
		}
		try
		{
			for (int num = 2; num > 0; num--)
			{
				int i = GameCanvas2.arrPos[num].x - GameCanvas2.arrPos[num - 1].x;
				int i2 = GameCanvas2.arrPos[num].y - GameCanvas2.arrPos[num - 1].y;
				if (Res2.abs(i) > distance && Res2.abs(i2) > distance)
				{
					return false;
				}
			}
		}
		catch (Exception)
		{
		}
		return true;
	}

	private void resetHold()
	{
		GameCanvas2.clearKeyHold();
	}

	public void paint(mGraphics2 g)
	{
		g.drawImage(GameScr2.imgAnalog1, xC, yC, mGraphics2.HCENTER | mGraphics2.VCENTER);
		g.drawImage(GameScr2.imgAnalog2, xM, yM, mGraphics2.HCENTER | mGraphics2.VCENTER);
	}

	public bool disableCheckDrag()
	{
		if (GameScr2.isAnalog == 0)
		{
			return false;
		}
		return isGamePad;
	}

	public bool disableClickMove()
	{
		try
		{
			if (GameScr2.isAnalog == 0)
			{
				return false;
			}
			return ((GameCanvas2.px >= xZone && GameCanvas2.px <= wZone && GameCanvas2.py >= yZone && GameCanvas2.py <= hZone) || GameCanvas2.px >= GameCanvas2.w - 50);
		}
		catch (Exception)
		{
			return false;
		}
	}
}
