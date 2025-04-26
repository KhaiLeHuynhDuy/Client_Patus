using System;

public class NewBoss2 : Mob2, IMapObject2
{
    public static Image2 shadowBig = mSystem2.loadImage("/mainImage/shadowBig.png");

    public int xTo;

    public int yTo;

    public bool haftBody;

    public bool change;

    public new int xSd;

    public new int ySd;

    private int wCount;

    public new bool isShadown = true;

    private int tick;

    private int frame;

    public new static Image2 imgHP = mSystem2.loadImage("/mainImage/myTexture2dmobHP.png");

    private bool wy;

    private int wt;

    private int fy;

    private int ty;

    public new int typeSuperEff;

    private Char2 focus;

    private bool flyDown;

    private int dy;

    public bool changePos;

    private int tShock;

    public new bool isBusyAttackSomeOne = true;

    private int tA;

    private Char2[] charAttack;

    private int[] dameHP;

    private sbyte type;

    private int ff;

    private int offset;

    private int xTempRight = -1;

    private int xTempLeft = -1;

    private int yTemp = -1;

    private sbyte[] cou = new sbyte[2] { -1, 1 };

    public new Char2 injureBy;

    public new bool injureThenDie;

    public new Mob2 mobToAttack;

    public new int forceWait;

    public new bool blindEff;

    public new bool sleepEff;

    private int[][] frameArr = new int[17][]
    {
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
    };

    public new const sbyte stand = 0;

    public const sbyte moveFra = 1;

    public new const sbyte attack1 = 2;

    public new const sbyte attack2 = 3;

    public const sbyte attack3 = 4;

    public const sbyte attack4 = 5;

    public const sbyte attack5 = 6;

    public const sbyte attack6 = 7;

    public const sbyte attack7 = 8;

    public const sbyte attack8 = 9;

    public const sbyte attack9 = 10;

    public const sbyte attack10 = 11;

    public new const sbyte hurt = 12;

    public const sbyte die = 13;

    public const sbyte fly = 14;

    public const sbyte adddame = 15;

    public const sbyte typeEff = 16;

    public NewBoss2(int id, short px, short py, int templateID, int hp, int maxHp, int s)
    {
        mobId = id;
        x = (xFirst = px + 20);
        y = (yFirst = py);
        xTo = x;
        yTo = y;
        base.maxHp = maxHp;
        base.hp = hp;
        templateId = templateID;
        h_hp_bar = 6;
        w_hp_bar = 100;
        len = w_hp_bar;
        updateHp_bar();
        if (Mob2.arrMobTemplate[templateId].data == null)
        {
            Service2.gI().requestModTemplate(templateId);
        }
        status = 2;
        frameArr = null;
    }

    public NewBoss2(int id, short px, short py, int templateID, long hp, long maxHp, int s)
    {
        mobId = id;
        x = (xFirst = px + 20);
        y = (yFirst = py);
        xTo = x;
        yTo = y;
        base.maxHp = maxHp;
        base.hp = hp;
        templateId = templateID;
        h_hp_bar = 6;
        w_hp_bar = 100;
        len = w_hp_bar;
        updateHp_bar();
        if (Mob2.arrMobTemplate[templateId].data == null)
        {
            Service2.gI().requestModTemplate(templateId);
        }
        status = 2;
        frameArr = null;
    }

    public override void setBody(short id)
    {
        changBody = true;
        smallBody = id;
    }

    public override void clearBody()
    {
        changBody = false;
    }

    public new static bool isExistNewMob(string id)
    {
        for (int i = 0; i < Mob2.newMob.size(); i++)
        {
            string text = (string)Mob2.newMob.elementAt(i);
            if (text.Equals(id))
            {
                return true;
            }
        }
        return false;
    }

    public new void checkFrameTick(int[] array)
    {
        tick++;
        if (tick > array.Length - 1)
        {
            tick = 0;
        }
        frame = array[tick];
    }

    public void updateShadown()
    {
        int num = 0;
        xSd = x;
        if (TileMap2.tileTypeAt(x, y, 2))
        {
            ySd = y;
            return;
        }
        ySd = y;
        while (num < 30)
        {
            num++;
            ySd += 24;
            if (TileMap2.tileTypeAt(xSd, ySd, 2))
            {
                if (ySd % 24 != 0)
                {
                    ySd -= ySd % 24;
                }
                break;
            }
        }
    }

    private void paintShadow(mGraphics2 g)
    {
        int num = TileMap2.size;
        if ((TileMap2.mapID < 114 || TileMap2.mapID > 120) && TileMap2.mapID != 127 && TileMap2.mapID != 128)
        {
            if (TileMap2.tileTypeAt(xSd + num / 2, ySd + 1, 4))
            {
                g.setClip(xSd / num * num, (ySd - 30) / num * num, num, 100);
            }
            else if (TileMap2.tileTypeAt((xSd - num / 2) / num, (ySd + 1) / num) == 0)
            {
                g.setClip(xSd / num * num, (ySd - 30) / num * num, 100, 100);
            }
            else if (TileMap2.tileTypeAt((xSd + num / 2) / num, (ySd + 1) / num) == 0)
            {
                g.setClip(xSd / num * num, (ySd - 30) / num * num, num, 100);
            }
            else if (TileMap2.tileTypeAt(xSd - num / 2, ySd + 1, 8))
            {
                g.setClip(xSd / 24 * num, (ySd - 30) / num * num, num, 100);
            }
        }
        g.drawImage(shadowBig, xSd, ySd - 5, 3);
        g.setClip(GameScr2.cmx, GameScr2.cmy - GameCanvas2.transY, GameScr2.gW, GameScr2.gH + 2 * GameCanvas2.transY);
    }

    public new void updateSuperEff()
    {
    }

    public override void update()
    {
        if (frameArr == null && Mob2.arrMobTemplate[templateId].data != null)
        {
            GetFrame();
        }
        if (frameArr == null || !isUpdate())
        {
            return;
        }
        updateShadown();
        switch (status)
        {
            case 2:
                updateMobStandWait();
                break;
            case 3:
                updateMobAttack();
                break;
            case 5:
                timeStatus = 0;
                updateMobWalk();
                break;
            case 6:
                timeStatus = 0;
                p1++;
                y += p1;
                if (y >= yFirst)
                {
                    y = yFirst;
                    p1 = 0;
                    status = 5;
                }
                break;
            case 7:
                updateInjure();
                base.update();
                break;
            case 0:
            case 1:
                updateDead();
                break;
            case 4:
                updateMobFly();
                break;
        }
    }

    private void updateDead()
    {
        tick++;
        if (tick > frameArr[13].Length - 1)
        {
            tick = frameArr[13].Length - 1;
        }
        frame = frameArr[13][tick];
        if (x != xTo || y != yTo)
        {
            x += (xTo - x) / 4;
            y += (yTo - y) / 4;
        }
    }

    private void updateMobFly()
    {
    }

    public new void setAttack(Char2 cFocus)
    {
        isBusyAttackSomeOne = true;
        mobToAttack = null;
        base.cFocus = cFocus;
        p1 = 0;
        p2 = 0;
        status = 3;
        tick = 0;
        int cx = cFocus.cx;
        int cy = cFocus.cy;
        if (Res2.abs(cx - x) < w * 2 && Res2.abs(cy - y) < h * 2)
        {
            if (x < cx)
            {
                x = cx - w;
            }
            else
            {
                x = cx + w;
            }
            p3 = 0;
        }
        else
        {
            p3 = 1;
        }
    }

    private void updateInjure()
    {
    }

    private void updateMobStandWait()
    {
        checkFrameTick(frameArr[0]);
        if (x != xTo || y != yTo)
        {
            x += (xTo - x) / 4;
            y += (yTo - y) / 4;
        }
    }

    public void setFly()
    {
        status = 4;
    }

    public void setAttack(Char2[] cAttack, int[] dame, sbyte type, sbyte dir)
    {
        charAttack = cAttack;
        dameHP = dame;
        this.type = type;
        base.dir = dir;
        status = 3;
        if (x != xTo || y != yTo)
        {
            x += (xTo - x) / 4;
            y += (yTo - y) / 4;
        }
    }

    public new void updateMobAttack()
    {
        if (tick == frameArr[type + 1].Length - 1)
        {
            status = 2;
        }
        checkFrameTick(frameArr[type + 1]);
        if (tick == frameArr[15][type - 1])
        {
            for (int i = 0; i < charAttack.Length; i++)
            {
                charAttack[i].doInjure(dameHP[i], 0, isCrit: false, isMob: false);
                ServerEffect2.addServerEffect(frameArr[16][type - 1], charAttack[i].cx, charAttack[i].cy, 1);
            }
        }
    }

    public new void updateMobWalk()
    {
        checkFrameTick(frameArr[1]);
        sbyte speed = Mob2.arrMobTemplate[templateId].speed;
        int num = speed;
        if (Res2.abs(x - xTo) < speed)
        {
            num = Res2.abs(x - xTo);
        }
        x += ((x >= xTo) ? (-num) : num);
        y = yTo;
        if (x < xTo)
        {
            dir = 1;
        }
        else if (x > xTo)
        {
            dir = -1;
        }
        if (Res2.abs(x - xTo) <= 1)
        {
            x = xTo;
            status = 2;
        }
    }

    public new bool isPaint()
    {
        if (x < GameScr2.cmx)
        {
            return false;
        }
        if (x > GameScr2.cmx + GameScr2.gW)
        {
            return false;
        }
        if (y < GameScr2.cmy)
        {
            return false;
        }
        if (y > GameScr2.cmy + GameScr2.gH + 30)
        {
            return false;
        }
        if (status == 0)
        {
            return false;
        }
        return true;
    }

    public new bool isUpdate()
    {
        if (status == 0)
        {
            return false;
        }
        return true;
    }

    public override void paint(mGraphics2 g)
    {
        if (Mob2.arrMobTemplate[templateId].data == null || isHide)
        {
            return;
        }
        if (isMafuba)
        {
            if (!changBody)
            {
                Mob2.arrMobTemplate[templateId].data.paintFrame(g, frame, xMFB, yMFB, (dir != 1) ? 1 : 0, 2);
            }
            else
            {
                SmallImage2.drawSmallImage(g, smallBody, xMFB, yMFB, (dir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            }
            return;
        }
        if (isShadown)
        {
            paintShadow(g);
        }
        g.translate(0, GameCanvas2.transY);
        if (!changBody)
        {
            int num = 33;
            if (yTemp == -1)
            {
                yTemp = y;
            }
            if (TileMap2.tileTypeAt(x + num, y + fy, 4))
            {
                xTempLeft = TileMap2.tileXofPixel(x + num) - num;
                xTempRight = TileMap2.tileXofPixel(x + num);
                if (x > xTempLeft && x < xTempRight && xTempRight != -1)
                {
                    x = xTempLeft;
                }
            }
            if (y < yTemp && yTemp != -1)
            {
                yTemp = y;
                x += num;
            }
            if (y > yTemp)
            {
                yTemp = y;
                x -= num;
            }
            Mob2.arrMobTemplate[templateId].data.paintFrame(g, frame, x, y + fy, (dir != 1) ? 1 : 0, 2);
        }
        else
        {
            SmallImage2.drawSmallImage(g, smallBody, x, y + fy - 9, (dir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
        }
        g.translate(0, -GameCanvas2.transY);
        if (hp <= 0)
        {
            return;
        }
        int imageWidth = mGraphics2.getImageWidth(imgHPtem);
        int imageHeight = mGraphics2.getImageHeight(imgHPtem);
        int num2 = imageWidth;
        int num3 = imageWidth;
        int num4 = x - imageWidth;
        int num5 = y - h - 5;
        int num6 = imageWidth * 2 * per / 100;
        int num7 = num6;
        if (per_tem >= per)
        {
            num7 = imageWidth * (per_tem -= ((GameCanvas2.gameTick % 6 <= 3) ? offset : offset++)) / 100;
            if (per_tem <= 0)
            {
                per_tem = 0;
            }
            if (per_tem < per)
            {
                per_tem = per;
            }
            if (offset >= 3)
            {
                offset = 3;
            }
        }
        if (num6 > num2)
        {
            num3 = num6 - num2;
            if (num3 <= 0)
            {
                num3 = 0;
            }
        }
        else
        {
            num2 = num6;
            num3 = 0;
        }
        g.drawImage(GameScr2.imgHP_tm_xam, num4, num5, mGraphics2.TOP | mGraphics2.LEFT);
        g.drawImage(GameScr2.imgHP_tm_xam, num4 + imageWidth, num5, mGraphics2.TOP | mGraphics2.LEFT);
        g.setColor(16777215);
        g.fillRect(num4, num5, num7, 2);
        g.drawRegion(imgHPtem, 0, 0, num2, imageHeight, 0, num4, num5, mGraphics2.TOP | mGraphics2.LEFT);
        g.drawRegion(imgHPtem, 0, 0, num3, imageHeight, 0, num4 + imageWidth, num5, mGraphics2.TOP | mGraphics2.LEFT);
    }

    public new int getHPColor()
    {
        return 16711680;
    }

    public new void startDie()
    {
        hp = 0;
        injureThenDie = true;
        hp = 0;
        status = 1;
        p1 = -3;
        p2 = -dir;
        p3 = 0;
    }

    public new void attackOtherMob(Mob2 mobToAttack)
    {
        this.mobToAttack = mobToAttack;
        isBusyAttackSomeOne = true;
        cFocus = null;
        p1 = 0;
        p2 = 0;
        status = 3;
        tick = 0;
        int num = mobToAttack.x;
        int num2 = mobToAttack.y;
        if (Res2.abs(num - x) < w * 2 && Res2.abs(num2 - y) < h * 2)
        {
            if (x < num)
            {
                x = num - w;
            }
            else
            {
                x = num + w;
            }
            p3 = 0;
        }
        else
        {
            p3 = 1;
        }
    }

    public new int getX()
    {
        return x;
    }

    public new int getY()
    {
        return y;
    }

    public new int getH()
    {
        return h;
    }

    public new int getW()
    {
        return w;
    }

    public new void stopMoving()
    {
        if (status == 5)
        {
            status = 2;
            p1 = (p2 = (p3 = 0));
            forceWait = 50;
        }
    }

    public new bool isInvisible()
    {
        return status == 0 || status == 1;
    }

    public new void removeHoldEff()
    {
        if (holdEffID != 0)
        {
            holdEffID = 0;
        }
    }

    public new void removeBlindEff()
    {
        blindEff = false;
    }

    public new void removeSleepEff()
    {
        sleepEff = false;
    }

    public new void move(short xMoveTo, short yMoveTo)
    {
        if (yMoveTo != -1)
        {
            if (Res2.distance(x, y, xTo, yTo) > 100)
            {
                x = xMoveTo;
                y = yMoveTo;
                status = 2;
            }
            else
            {
                xTo = xMoveTo;
                yTo = yMoveTo;
                status = 5;
            }
        }
        else
        {
            xTo = xMoveTo;
            status = 5;
        }
    }

    public new void GetFrame()
    {
        try
        {
            frameArr = (int[][])Controller2_.frameHT_NEWBOSS.get(templateId + string.Empty);
            w = Mob2.arrMobTemplate[templateId].data.width;
            h = Mob2.arrMobTemplate[templateId].data.height;
        }
        catch (Exception)
        {
        }
    }

    public void setDie()
    {
        status = 0;
    }
}
