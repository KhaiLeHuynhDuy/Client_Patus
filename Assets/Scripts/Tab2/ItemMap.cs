public class ItemMap2 : IMapObject2
{
	public int x;

	public int y;

	public int xEnd;

	public int yEnd;

	public int f;

	public int vx;

	public int vy;

	public int playerId;

	public int itemMapID;

	public int IdCharMove;

	public ItemTemplate2 template;

	public sbyte status;

	public bool isHintFocus;

	public int rO;

	public int xO;

	public int yO;

	public int angle;

	public int iAngle;

	public int iDot;

	public int[] xArg;

	public int[] yArg;

	public int[] xDot;

	public int[] yDot;

	public int count;

	public int countAura;

	public int countAutoPick = 0;

	public static Image2 imageFlare = GameCanvas2.loadImage("/mainImage/myTexture2dflare.png");

	public static Image2 imageAuraItem1 = GameCanvas2.loadImage("/mainImage/myTexture2ditemaura1.png");

	public static Image2 imageAuraItem2 = GameCanvas2.loadImage("/mainImage/myTexture2ditemaura2.png");

	public static Image2 imageAuraItem3 = GameCanvas2.loadImage("/mainImage/myTexture2ditemaura3.png");

	public ItemMap2(short itemMapID, short itemTemplateID, int x, int y, int xEnd, int yEnd)
	{
		this.itemMapID = itemMapID;
		template = ItemTemplates2.get(itemTemplateID);
		this.x = xEnd;
		this.y = y;
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		vx = xEnd - x >> 2;
		vy = 5;
		Res2.outz("playerid=  " + playerId + " myid= " + Char2.myCharz().charID);
	}

	public ItemMap2(int playerId, short itemMapID, short itemTemplateID, int x, int y, short r)
	{
		Res2.outz("item map item= " + itemMapID + " template= " + itemTemplateID + " x= " + x + " y= " + y);
		this.itemMapID = itemMapID;
		template = ItemTemplates2.get(itemTemplateID);
		Res2.outz("playerid=  " + playerId + " myid= " + Char2.myCharz().charID);
		this.x = (xEnd = x);
		this.y = (yEnd = y);
		status = 1;
		this.playerId = playerId;
		if (isAuraItem())
		{
			rO = r;
			setAuraItem();
		}
	}

	public void setPoint(int xEnd, int yEnd)
	{
		this.xEnd = xEnd;
		this.yEnd = yEnd;
		vx = xEnd - x >> 2;
		vy = yEnd - y >> 2;
		status = 2;
	}

	public void update()
	{
		if (status == 2 && x == xEnd && y == yEnd)
		{
			GameScr2.vItemMap.removeElement(this);
			if (Char2.myCharz().itemFocus != null && Char2.myCharz().itemFocus.Equals(this))
			{
				Char2.myCharz().itemFocus = null;
			}
			return;
		}
		if (status > 0)
		{
			if (vx == 0)
			{
				x = xEnd;
			}
			if (vy == 0)
			{
				y = yEnd;
			}
			if (x != xEnd)
			{
				x += vx;
				if ((vx > 0 && x > xEnd) || (vx < 0 && x < xEnd))
				{
					x = xEnd;
				}
			}
			if (y != yEnd)
			{
				y += vy;
				if ((vy > 0 && y > yEnd) || (vy < 0 && y < yEnd))
				{
					y = yEnd;
				}
			}
		}
		else
		{
			status -= 4;
			if (status < -12)
			{
				y -= 12;
				status = 1;
			}
		}
		if (isAuraItem())
		{
			updateAuraItemEff();
		}
	}

	public void paint(mGraphics2 g)
	{
		if (isAuraItem())
		{
			g.drawImage(TileMap2.bong, x + 3, y, mGraphics2.VCENTER | mGraphics2.HCENTER);
			if (status <= 0)
			{
				if (countAura < 10)
				{
					g.drawImage(imageAuraItem1, x, y + status + 3, mGraphics2.BOTTOM | mGraphics2.HCENTER);
				}
				else
				{
					g.drawImage(imageAuraItem2, x, y + status + 3, mGraphics2.BOTTOM | mGraphics2.HCENTER);
				}
			}
			else if (countAura < 10)
			{
				g.drawImage(imageAuraItem1, x, y + 3, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			}
			else
			{
				g.drawImage(imageAuraItem2, x, y + 3, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			}
		}
		else if (!isAuraItem())
		{
			if (GameCanvas2.gameTick % 4 == 0)
			{
				g.drawImage(imageFlare, x, y + status + 13, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			}
			if (status <= 0)
			{
				SmallImage2.drawSmallImage(g, template.iconID, x, y + status + 3, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			}
			else
			{
				SmallImage2.drawSmallImage(g, template.iconID, x, y + 3, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
			}
			if (Char2.myCharz().itemFocus != null && Char2.myCharz().itemFocus.Equals(this) && status != 2)
			{
				g.drawRegion(Mob2.imgHP, 0, 24, 9, 6, 0, x, y - 17, 3);
			}
		}
	}

	private bool isAuraItem()
	{
        if (template.type == 22)
		{
			return true;
		}
		return false;
	}

	private void setAuraItem()
	{
		xO = x;
		yO = y;
		iDot = 120;
		angle = 0;
		if (!GameCanvas2.lowGraphic)
		{
			iAngle = 360 / iDot;
			xArg = new int[iDot];
			yArg = new int[iDot];
			xDot = new int[iDot];
			yDot = new int[iDot];
			setDotPosition();
		}
	}

	private void updateAuraItemEff()
	{
		count++;
		countAura++;
		if (countAura >= 40)
		{
			countAura = 0;
		}
		if (count >= iDot)
		{
			count = 0;
		}
		if (count % 10 == 0 && !GameCanvas2.lowGraphic)
		{
			ServerEffect2.addServerEffect(114, x - 5, y - 30, 1);
		}
	}

	public void paintAuraItemEff(mGraphics2 g)
	{
		if (GameCanvas2.lowGraphic || !isAuraItem())
		{
			return;
		}
		for (int i = 0; i < yArg.Length; i++)
		{
			if (count == i)
			{
				if (countAura <= 20)
				{
					g.drawImage(imageAuraItem3, xDot[i], yDot[i] + 3, mGraphics2.BOTTOM | mGraphics2.HCENTER);
				}
				else
				{
					SmallImage2.drawSmallImage(g, template.iconID, xDot[i], yDot[i] + 3, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
				}
			}
		}
	}

	private void setDotPosition()
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

	public int getX()
	{
		return x;
	}

	public int getY()
	{
		return y;
	}

	public int getH()
	{
		return 20;
	}

	public int getW()
	{
		return 20;
	}

	public void stopMoving()
	{
	}

	public bool isInvisible()
	{
		return false;
	}
}
