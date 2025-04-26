using System;
using System.Threading;

public class CrackBallScr2 : mScreen2
{
	public static CrackBallScr2 instance;

	private BallInfo2[] listBall;

	private byte step;

	private byte typePrice;

	private int rO;

	private int xO;

	private int yO;

	private int angle;

	private int iAngle;

	private int iDot;

	private int yTo;

	private int indexSelect;

	private int indexSkillSelect;

	private int numTicket;

	private readonly int xP;

	private int yP;

	private readonly int wP;

	private readonly int hP;

	private int price;

	private int cost;

	private int countFr;

	private int countKame;

	private int frame;

	private int vp;

	private int[] xArg;

	private int[] yArg;

	private int[] xDot;

	private int[] yDot;

	private short[] idItem;

	private long timeStart;

	private long timeKame;

	private bool isKame;

	private bool isCanSkill;

	private bool isSendSv;

	private short idTicket;

	private static int ySkill;

	private static int[] xSkill;

	private static FrameImage2 fraImgKame;

	private static FrameImage2 fraImgKame_1;

	private static Image2 imgX;

	private static Image2 imgReplay;

	public static bool isAutoCrackBall;

	public static bool isCallStop;

	public static bool isContinue;

	private readonly byte[] fr = new byte[21]
	{
		19, 19, 19, 19, 19, 19, 19, 19, 19, 19,
		19, 19, 19, 19, 19, 19, 19, 19, 19, 19,
		20
	};

	private readonly byte[] nFrame = new byte[12]
	{
		0, 0, 0, 1, 1, 1, 2, 2, 2, 3,
		3, 3
	};

	public CrackBallScr2()
	{
		xSkill = new int[3];
		xSkill[0] = 16;
		ySkill = GameCanvas2.h - 41;
		xSkill[1] = GameCanvas2.w - 40;
		xSkill[2] = (xSkill[0] + xSkill[1]) / 2;
		Image2 img = GameCanvas2.loadImage("/e/e_1.png");
		fraImgKame = new FrameImage2(img, 30, 30);
		Image2 img2 = GameCanvas2.loadImage("/e/e_0.png");
		fraImgKame_1 = new FrameImage2(img2, 68, 65);
		imgReplay = GameCanvas2.loadImage("/e/nut2.png");
		imgX = GameCanvas2.loadImage("/e/nut3.png");
		wP = 230;
		xP = GameCanvas2.hw - wP / 2;
		hP = 40;
		yP = -hP;
	}

	public static CrackBallScr2 gI()
	{
		instance ??= new CrackBallScr2();
		return instance;
	}

	public void SetCrackBallScr(short[] idImage, byte typePrice, int price, short idTicket)
	{
		if (idImage != null && idImage.Length > 0)
		{
			yTo = Char2.myCharz().cy - 10;
			SetAuraItem();
			listBall = new BallInfo2[idImage.Length];
			for (int i = 0; i < listBall.Length; i++)
			{
				listBall[i] = new BallInfo2
				{
					idImg = idImage[i],
					count = i * 25,
					yTo = -999,
					vx = Res2.random(2, 5),
					dir = Res2.random(-1, 2)
				};
				listBall[i].SetChar();
			}
			isCanSkill = false;
			isKame = false;
			isSendSv = false;
			timeStart = GameCanvas2.timeNow + Res2.random(1000, 2000);
			step = 0;
			indexSelect = -1;
			indexSkillSelect = -1;
			this.typePrice = typePrice;
			this.price = price;
			cost = 0;
			Char2.myCharz().moveTo(470, 408, 1);
			Char2.myCharz().cdir = -1;
			Char2.myCharz().statusMe = 1;
			countFr = 0;
			countKame = 0;
			frame = 0;
			vp = 0;
			yP = -hP;
			this.idTicket = idTicket;
			numTicket = 0;
			CheckNumTicket();
			switchToMe();
			SoundMn2.gI().hoisinh();
		}
	}

	private void SetAuraItem()
	{
		rO = GameCanvas2.hh / 3 + 10;
		if (rO > 50)
		{
			rO = 50;
		}
		xO = 360;
		GameScr2.cmx = GameScr2.cmxLim / 2;
		yO = GameScr2.cmy + GameCanvas2.hh / 3 + 30;
		iDot = 175;
		angle = 0;
		iAngle = 360 / iDot;
		xArg = new int[iDot];
		yArg = new int[iDot];
		xDot = new int[iDot];
		yDot = new int[iDot];
		SetDotPosition();
	}

	private void SetDotPosition()
	{
		if (GameCanvas2.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < yArg.Length; i++)
		{
			yArg[i] = Res2.abs(rO * Res2.sin(angle) / 1024);
			xArg[i] = Res2.abs(rO * Res2.cos(angle) / 1024);
			if (angle < 90)
			{
				xDot[i] = xO + xArg[i];
				yDot[i] = yO - yArg[i];
			}
			else if (angle >= 90 && angle < 180)
			{
				xDot[i] = xO - xArg[i];
				yDot[i] = yO - yArg[i];
			}
			else if (angle >= 180 && angle < 270)
			{
				xDot[i] = xO - xArg[i];
				yDot[i] = yO + yArg[i];
			}
			else
			{
				xDot[i] = xO + xArg[i];
				yDot[i] = yO + yArg[i];
			}
			angle += iAngle;
		}
	}

	public override void update()
	{
		try
		{
			cost = price * CheckNum();
			CheckNumTicket();
			GameScr2.gI().update();
			if (timeStart - GameCanvas2.timeNow > 0)
			{
				for (int i = 0; i < listBall.Length; i++)
				{
					listBall[i].count += 2;
					if (listBall[i].count >= iDot)
					{
						listBall[i].count = 0;
					}
					listBall[i].x = xDot[listBall[i].count];
					listBall[i].y = yDot[listBall[i].count];
				}
				return;
			}
			if (step == 0)
			{
				step = 1;
			}
			if (step == 1)
			{
				for (int j = 0; j < listBall.Length; j++)
				{
					if (listBall[j].yTo == -999 || listBall[j].isDone)
					{
						continue;
					}
					if (listBall[j].y < listBall[j].yTo)
					{
						if (listBall[j].vy < 0)
						{
							listBall[j].vy = 0;
						}
						if (listBall[j].y + listBall[j].vy > listBall[j].yTo)
						{
							listBall[j].y = listBall[j].yTo;
						}
						else
						{
							listBall[j].y += listBall[j].vy;
						}
						listBall[j].vy++;
					}
					else
					{
						if (listBall[j].vy > 0)
						{
							listBall[j].vy = 0;
						}
						listBall[j].y += listBall[j].vy;
						listBall[j].vy--;
					}
					if (listBall[j].y == listBall[j].yTo)
					{
						Effect2_ me = new(19, listBall[j].x - 5, listBall[j].y + 25, 2, 1, -1);
						EffecMn2.addEff(me);
						SoundMn2.gI().charFall();
						listBall[j].isDone = true;
						if (!isCanSkill)
						{
							isCanSkill = true;
						}
					}
				}
			}
			if (step == 2)
			{
				for (int k = 0; k < listBall.Length; k++)
				{
					if (listBall[k].isDone)
					{
						continue;
					}
					if (listBall[k].y > -10)
					{
						if (listBall[k].vy > 0)
						{
							listBall[k].vy = 0;
						}
						listBall[k].y += listBall[k].vy;
						listBall[k].vy--;
						listBall[k].x += listBall[k].vx * listBall[k].dir;
						listBall[k].vx -= 3;
					}
					if (listBall[k].y == -10)
					{
						listBall[k].isPaint = false;
					}
				}
				countFr++;
				if (countFr > fr.Length - 1)
				{
					countFr = fr.Length - 1;
					isKame = true;
					SoundMn2.gI().newKame();
					if (!isSendSv && timeKame - GameCanvas2.timeNow < 0)
					{
						Service2.gI().SendCrackBall(2, (byte)(CheckTicket() + CheckNum()));
						isSendSv = true;
					}
				}
				Char2.myCharz().cf = fr[countFr];
				countKame++;
				if (countKame > 5)
				{
					countKame = 0;
				}
				frame = nFrame[countKame];
			}
			if (step == 3)
			{
				if (countKame <= 5)
				{
					countKame = 5;
				}
				countKame++;
				if (countKame > nFrame.Length - 1)
				{
					countKame = nFrame.Length - 1;
					step = 4;
					isKame = false;
					int num = 0;
					for (int l = 0; l < listBall.Length; l++)
					{
						if (listBall[l].isDone && !listBall[l].isSetImg)
						{
							listBall[l].idImg = idItem[num];
							listBall[l].isSetImg = true;
							num++;
						}
					}
				}
				frame = nFrame[countKame];
			}
			if (step == 4)
			{
				for (int m = 0; m < listBall.Length; m++)
				{
					if (listBall[m].isPaint)
					{
						listBall[m].xTo = Char2.myCharz().cx;
					}
				}
				step = 5;
			}
			if (step != 5)
			{
				return;
			}
			vp++;
			if (yP < GameCanvas2.hh / 3)
			{
				if (yP + vp > GameCanvas2.hh / 3)
				{
					yP = GameCanvas2.hh / 3;
				}
				else
				{
					yP += vp;
				}
			}
			for (int n = 0; n < listBall.Length; n++)
			{
				if (!listBall[n].isPaint)
				{
					continue;
				}
				if (listBall[n].x < listBall[n].xTo)
				{
					if (listBall[n].vx < 0)
					{
						listBall[n].vx = 0;
					}
					if (listBall[n].x + listBall[n].vx > listBall[n].xTo)
					{
						listBall[n].x = listBall[n].xTo;
					}
					else
					{
						listBall[n].x += listBall[n].vx;
					}
					listBall[n].vx++;
				}
				else
				{
					if (listBall[n].vx > 0)
					{
						listBall[n].vx = 0;
					}
					listBall[n].x += listBall[n].vx;
					listBall[n].vx--;
				}
				if (listBall[n].x == listBall[n].xTo)
				{
					listBall[n].isPaint = false;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public override void updateKey()
	{
		if (InfoDlg2.isLock)
		{
			return;
		}
		if (GameCanvas2.isTouch && !ChatTextField2.gI().isShow && !GameCanvas2.menu.showMenu)
		{
			UpdateKeyTouchControl();
		}
		if (isAutoCrackBall && !GameCanvas2.keyPressed[0])
		{
			GameCanvas2.clearKeyHold();
			GameCanvas2.clearKeyPressed();
		}
		if (GameCanvas2.keyPressed[0])
		{
			DoClickSkill(2);
		}
		for (int i = 1; i < 8; i++)
		{
			if (GameCanvas2.keyPressed[i])
			{
				GameCanvas2.keyPressed[i] = false;
				DoClickBall(i - 1);
			}
		}
		if (GameCanvas2.keyPressed[12])
		{
			GameCanvas2.keyPressed[12] = false;
			DoClickSkill(0);
		}
		if (GameCanvas2.keyPressed[13])
		{
			GameCanvas2.keyPressed[13] = false;
			DoClickSkill(1);
		}
		GameCanvas2.clearKeyPressed();
	}

	private void UpdateKeyTouchControl()
	{
		if (step == 1 && GameCanvas2.isPointerClick)
		{
			for (int i = 0; i < listBall.Length; i++)
			{
				if (GameCanvas2.isPointerHoldIn(listBall[i].x - 20 - GameScr2.cmx, listBall[i].y - 10 - GameScr2.cmy, 30, 30) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
				{
					DoClickBall(i);
				}
			}
		}
		if (!GameCanvas2.isPointerClick)
		{
			return;
		}
		for (int j = 0; j < xSkill.Length; j++)
		{
			if (GameCanvas2.isPointerHoldIn(xSkill[j], ySkill, 36, 36) && GameCanvas2.isPointerClick && GameCanvas2.isPointerJustRelease)
			{
				if (isAutoCrackBall && j != 2)
				{
					break;
				}
				DoClickSkill(j);
			}
		}
	}

	private void DoClickBall(int index)
	{
		if (!listBall[index].isDone)
		{
			SoundMn2.gI().getItem();
			long num = (typePrice != 0) ? Char2.myCharz().checkLuong() : Char2.myCharz().xu;
			if (CheckTicket() >= numTicket && num < cost + price)
			{
				string s = mResources2.not_enough_money_1 + " " + ((typePrice != 0) ? mResources2.LUONG : mResources2.XU);
				GameScr2.info1.addInfo(s, 0);
			}
			else
			{
				indexSelect = index;
				listBall[indexSelect].yTo = yTo + Res2.random(-3, 3);
			}
		}
	}

	private void DoClickSkill(int index)
	{
		if (MainMod2.isAutoVQMM && index == 2)
		{
			return;
		}
		indexSkillSelect = index;
		if (indexSkillSelect == 2)
		{
			isAutoCrackBall = !isAutoCrackBall;
			if (isAutoCrackBall)
			{
				StartAutoCrackBall();
			}
			else
			{
				isCallStop = true;
			}
		}
		else if (index == 0)
		{
			if (step < 2)
			{
				if (CheckTicket() + CheckNum() > 0)
				{
					step = 2;
					SoundMn2.gI().gong();
					Char2.myCharz().setSkillPaint(GameScr2.sks[13], 0);
					timeKame = GameCanvas2.timeNow + Res2.random(2000, 3000);
				}
			}
			else if (yP == GameCanvas2.hh / 3)
			{
				Service2.gI().SendCrackBall(typePrice, 0);
			}
		}
		else
		{
			if (isAutoCrackBall)
			{
				StopAutoCrackBall();
			}
			if (MainMod2.isAutoVQMM)
			{
				GameScr2.info1.addInfo("Đã tắt Auto VQMM (0)", 0);
				MainMod2.isAutoVQMM = false;
			}
			GameScr2.gI().isRongThanXuatHien = false;
			GameScr2.gI().switchToMe();
		}
	}

	public override void paint(mGraphics2 g)
	{
		try
		{
			GameScr2.gI().paint(g);
			g.translate(-GameScr2.cmx, -GameScr2.cmy);
			g.translate(0, GameCanvas2.transY);
			for (int i = 0; i < listBall.Length; i++)
			{
				if (listBall[i].isPaint && listBall[i].y > listBall[i].yTo - 20)
				{
					g.drawImage(TileMap2.bong, listBall[i].x, listBall[i].yTo + 7, mGraphics2.VCENTER | mGraphics2.HCENTER);
				}
			}
			for (int j = 0; j < listBall.Length; j++)
			{
				if (listBall[j].isPaint)
				{
					SmallImage2.drawSmallImage(g, listBall[j].idImg, listBall[j].x, listBall[j].y, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
				}
			}
			if (isKame)
			{
				if (fraImgKame != null)
				{
					int num = Char2.myCharz().cx - fraImgKame.frameWidth - 28;
					for (int k = 0; k < GameCanvas2.w / fraImgKame.frameWidth + 1; k++)
					{
						fraImgKame.drawFrame(frame, num - k * (fraImgKame.frameWidth - 1), Char2.myCharz().cy - fraImgKame.frameHeight / 2 - 12 + 2, 0, 0, g);
					}
				}
				if (fraImgKame_1 != null)
				{
					int num2 = Char2.myCharz().cx - fraImgKame_1.frameWidth - 10;
					fraImgKame_1.drawFrame(frame, num2 - 5, Char2.myCharz().cy - fraImgKame_1.frameHeight / 2 - 12, 0, 0, g);
				}
			}
			GameScr2.resetTranslate(g);
			int num3 = 240;
			int num4 = GameCanvas2.w - num3;
			int num5 = 15;
			g.setColor(13524492);
			g.fillRect(num4, num5 - 15, num3, 15);
			g.drawImage(Panel2.imgXu, num4 + 11, num5 - 7, 3);
			g.drawImage(Panel2.imgLuong, num4 + 90, num5 - 8, 3);
			mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().xuStr + string.Empty, num4 + 24, num5 - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
			mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().luongStr + string.Empty, num4 + 100, num5 - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
			g.drawImage(Panel2.imgLuongKhoa, num4 + 150, num5 - 7, 3);
			mFont2.tahoma_7_yellow.drawString(g, Char2.myCharz().luongKhoaStr + string.Empty, num4 + 160, num5 - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
			g.drawImage(Panel2.imgTicket, num4 + 200, num5 - 7, 3);
			mFont2.tahoma_7_yellow.drawString(g, numTicket + string.Empty, num4 + 210, num5 - 13, mFont2.LEFT, mFont2.tahoma_7_grey);
			if (step < 4)
			{
				int num6 = num3 / 2 + 20;
				int num7 = GameCanvas2.w - num6;
				g.setColor(11837316);
				g.fillRect(num7, num5, num6, 15);
				if (typePrice == 0)
				{
					g.drawImage(Panel2.imgXu, num7 + 21, num5 + 8, 3);
				}
				else
				{
					g.drawImage(Panel2.imgLuongKhoa, num7 + 21, num5 + 7, 3);
					g.drawImage(Panel2.imgLuong, num7 + 18, num5 + 7, 3);
				}
				mFont2.tahoma_7_red.drawString(g, " -" + cost, num7 + 30, num5 + 2, mFont2.LEFT, mFont2.tahoma_7_grey);
				g.drawImage(Panel2.imgTicket, num7 + 80, num5 + 7, 3);
				mFont2.tahoma_7_red.drawString(g, " -" + CheckTicket(), num7 + 90, num5 + 2, mFont2.LEFT, mFont2.tahoma_7_grey);
			}
			g.drawImage(GameScr2.imgSkill, xSkill[0], ySkill, 0);
			if (indexSkillSelect == 0)
			{
				g.drawImage(GameScr2.imgSkill2, xSkill[0], ySkill, 0);
			}
			if (step < 3)
			{
				SmallImage2.drawSmallImage(g, 540, xSkill[0] + 14, ySkill + 14, 0, StaticObj2.VCENTER_HCENTER);
			}
			else
			{
				g.drawImage(imgReplay, xSkill[0] + 14 - 10, ySkill + 14 - 10, 0);
			}
			g.drawImage(GameScr2.imgSkill, xSkill[1], ySkill, 0);
			if (indexSkillSelect == 1)
			{
				g.drawImage(GameScr2.imgSkill2, xSkill[1], ySkill, 0);
			}
			g.drawImage(imgX, xSkill[1] + 14 - 10, ySkill + 14 - 10, 0);
			if (step > 3)
			{
				GameCanvas2.paintz.paintFrameSimple(xP, yP, wP, hP, g);
				int num8 = GameCanvas2.hw - idItem.Length * 30 / 2;
				for (int l = 0; l < idItem.Length; l++)
				{
					SmallImage2.drawSmallImage(g, idItem[l], num8 + 5 + l * 30, yP + 10, 0, 0);
				}
			}
			if (!MainMod2.isAutoVQMM)
			{
				if (isAutoCrackBall)
				{
					g.drawImage(GameScr2.imgSkill2, (xSkill[0] + xSkill[1]) / 2, ySkill, 0);
				}
				else
				{
					g.drawImage(GameScr2.imgSkill, (xSkill[0] + xSkill[1]) / 2, ySkill, 0);
				}
				SmallImage2.drawSmallImage(g, 4387, (xSkill[0] + xSkill[1]) / 2 + 14, ySkill + 14, 0, StaticObj2.VCENTER_HCENTER);
			}
		}
		catch (Exception)
		{
		}
	}

	public void DoneCrackBallScr(short[] idImage)
	{
		step = 3;
		idItem = idImage;
	}

	public override void switchToMe()
	{
		GameScr2.isPaintOther = true;
		GameScr2.gI().isRongThanXuatHien = true;
		base.switchToMe();
	}

	private byte CheckTicket()
	{
		byte b = 0;
		for (int i = 0; i < listBall.Length; i++)
		{
			if (listBall[i].isDone)
			{
				b++;
			}
		}
		if (b > numTicket)
		{
			b = (byte)numTicket;
		}
		return b;
	}

	private byte CheckNum()
	{
		byte b = 0;
		for (int i = 0; i < listBall.Length; i++)
		{
			if (listBall[i].isDone)
			{
				b++;
			}
		}
		b -= CheckTicket();
		if (b <= 0)
		{
			b = 0;
		}
		return b;
	}

	private void CheckNumTicket()
	{
		for (int i = 0; i < Char2.myCharz().arrItemBag.Length; i++)
		{
			if (Char2.myCharz().arrItemBag[i] != null && Char2.myCharz().arrItemBag[i].template.id == idTicket)
			{
				numTicket = Char2.myCharz().arrItemBag[i].quantity;
				break;
			}
		}
	}

	private void UseSkillCrackBall()
	{
		if (step < 2)
		{
			if (CheckTicket() + CheckNum() > 0)
			{
				step = 2;
				SoundMn2.gI().gong();
				Char2.myCharz().setSkillPaint(GameScr2.sks[13], 0);
				timeKame = GameCanvas2.timeNow + Res2.random(2000, 3000);
			}
		}
		else if (yP == GameCanvas2.hh / 3)
		{
			Service2.gI().SendCrackBall(typePrice, 0);
		}
	}

	public void StartAutoCrackBall()
	{
		Thread thread = new(AutoCrackBall);
		thread.Start();
	}

	public void StopAutoCrackBall()
	{
		isAutoCrackBall = false;
		indexSkillSelect = -1;
		isCallStop = false;
		isContinue = false;
	}

	public void AutoCrackBall()
	{
		int num = 0;
		bool flag = false;
		try
		{
			while (isAutoCrackBall && GameCanvas2.currentScreen == instance)
			{
				indexSkillSelect = 2;
				while (num < 7 && step != 5)
				{
					DoClickBall(num);
					num++;
					Thread.Sleep(300);
				}
				if (num == 7)
				{
					Thread.Sleep(800);
					gI().UseSkillCrackBall();
					Thread.Sleep(4000);
					if (isCallStop)
					{
						StopAutoCrackBall();
						Thread.ResetAbort();
						break;
					}
					if (step == 5)
					{
						gI().UseSkillCrackBall();
						num = 0;
					}
					Thread.Sleep(1000);
				}
				if (step == 5 && num == 0 && !flag)
				{
					flag = true;
					gI().UseSkillCrackBall();
				}
			}
		}
		catch (Exception)
		{
		}
	}
}
