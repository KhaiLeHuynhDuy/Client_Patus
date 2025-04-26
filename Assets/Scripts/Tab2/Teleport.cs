public class Teleport2
{
    public static MyVector2 vTeleport = new MyVector2();

    public int x;

    public int y;

    public int headId;

    public int type;

    public bool isMe;

    public int y2;

    public int id;

    public int dir;

    public int planet;

    public static Image2[] maybay = new Image2[5];

    public static Image2 hole;

    public bool isUp;

    public bool isDown;

    private bool createShip;

    public bool paintFire;

    private bool painHead;

    private int tPrepare;

    private int vy = 1;

    private int tFire;

    private int tDelayHole;

    private bool tHole;

    private bool isShock;

    public Teleport2(int x, int y, int headId, int dir, int type, bool isMe, int planet)
    {
        this.x = x;
        this.y = 5;
        y2 = y;
        this.headId = headId;
        this.type = type;
        this.isMe = isMe;
        this.dir = dir;
        this.planet = planet;
        tPrepare = 0;
        int num = 0;
        while (num < 100)
        {
            num++;
            y2 += 12;
            if (TileMap2.tileTypeAt(x, y2, 2))
            {
                if (y2 % 24 != 0)
                {
                    y2 -= y2 % 24;
                }
                break;
            }
        }
        isDown = true;
        isUp = false;
        if (this.planet > 2)
        {
            y2 += 4;
            if (maybay[3] == null)
            {
                maybay[3] = GameCanvas2.loadImage("/mainImage/myTexture2dmaybay4a.png");
            }
            if (maybay[4] == null)
            {
                maybay[4] = GameCanvas2.loadImage("/mainImage/myTexture2dmaybay4b.png");
            }
            if (hole == null)
            {
                hole = GameCanvas2.loadImage("/mainImage/hole.png");
            }
        }
        else if (maybay[planet] == null)
        {
            maybay[planet] = GameCanvas2.loadImage("/mainImage/myTexture2dmaybay" + (planet + 1) + ".png");
        }
        if (x > GameScr2.cmx && x < GameScr2.cmx + GameCanvas2.w && y2 > 100 && !SoundMn2.gI().isPlayAirShip() && !SoundMn2.gI().isPlayRain())
        {
            createShip = true;
            SoundMn2.gI().airShip();
        }
    }

    public static void addTeleport(Teleport2 p)
    {
        vTeleport.addElement(p);
    }

    public void paintHole(mGraphics2 g)
    {
        if (planet > 2 && tHole)
        {
            g.drawImage(hole, x, y2 + 20, StaticObj2.BOTTOM_HCENTER);
        }
    }

    public void paint(mGraphics2 g)
    {
        if (Char2.isLoadingMap || x < GameScr2.cmx || x > GameScr2.cmx + GameCanvas2.w)
        {
            return;
        }
        Part2 part = GameScr2.parts[headId];
        int num = 0;
        int num2 = 0;
        if (planet == 0)
        {
            num = 15;
            num2 = 40;
        }
        if (planet == 1)
        {
            num = 7;
            num2 = 55;
        }
        if (planet == 2)
        {
            num = 18;
            num2 = 52;
        }
        if (painHead && planet < 3)
        {
            SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[0][0][0]].id, x + ((dir != 1) ? (-num) : num), y - num2, (dir != 1) ? 2 : 0, StaticObj2.TOP_CENTER);
        }
        if (planet < 3)
        {
            g.drawRegion(maybay[planet], 0, 0, mGraphics2.getImageWidth(maybay[planet]), mGraphics2.getImageHeight(maybay[planet]), (dir == 1) ? 2 : 0, x, y, StaticObj2.BOTTOM_HCENTER);
        }
        else if (isDown)
        {
            if (tPrepare > 10)
            {
                g.drawRegion(maybay[4], 0, 0, mGraphics2.getImageWidth(maybay[4]), mGraphics2.getImageHeight(maybay[4]), (dir == 1) ? 2 : 0, (dir != 1) ? (x + 11) : (x - 11), y + 2, StaticObj2.BOTTOM_HCENTER);
            }
            else
            {
                g.drawRegion(maybay[3], 0, 0, mGraphics2.getImageWidth(maybay[3]), mGraphics2.getImageHeight(maybay[3]), (dir == 1) ? 2 : 0, x, y, StaticObj2.BOTTOM_HCENTER);
            }
        }
        else if (tPrepare < 20)
        {
            g.drawRegion(maybay[4], 0, 0, mGraphics2.getImageWidth(maybay[4]), mGraphics2.getImageHeight(maybay[4]), (dir == 1) ? 2 : 0, (dir != 1) ? (x + 11) : (x - 11), y + 2, StaticObj2.BOTTOM_HCENTER);
        }
        else
        {
            g.drawRegion(maybay[3], 0, 0, mGraphics2.getImageWidth(maybay[3]), mGraphics2.getImageHeight(maybay[3]), (dir == 1) ? 2 : 0, x, y, StaticObj2.BOTTOM_HCENTER);
        }
    }

    public void update()
    {
        if (planet > 2 && paintFire && y != -80)
        {
            if (isDown && tPrepare == 0)
            {
                if (GameCanvas2.gameTick % 3 == 0)
                {
                    ServerEffect2.addServerEffect(1, x, y, 1, 0);
                }
            }
            else if (isUp && GameCanvas2.gameTick % 3 == 0)
            {
                ServerEffect2.addServerEffect(1, x, y + 16, 1, 1);
            }
        }
        tFire++;
        if (tFire > 3)
        {
            tFire = 0;
        }
        if (isDown)
        {
            paintFire = true;
            painHead = ((type != 0) ? true : false);
            if (planet < 3)
            {
                int num = y2 - y >> 3;
                if (num < 1)
                {
                    num = 1;
                    paintFire = false;
                }
                y += num;
            }
            else
            {
                if (GameCanvas2.gameTick % 2 == 0)
                {
                    vy++;
                }
                if (y2 - y < vy)
                {
                    y = y2;
                    paintFire = false;
                }
                else
                {
                    y += vy;
                }
            }
            if (isMe && type == 1 && Char2.myCharz().isTeleport)
            {
                Char2.myCharz().cx = x;
                Char2.myCharz().cy = y - 30;
                Char2.myCharz().statusMe = 4;
                GameScr2.cmtoX = x - GameScr2.gW2;
                GameScr2.cmtoY = y - GameScr2.gH23;
                GameScr2.info1.isUpdate = false;
            }
            if (GameScr2.findCharInMap(id) != null && !isMe && type == 1 && GameScr2.findCharInMap(id).isTeleport)
            {
                GameScr2.findCharInMap(id).cx = x;
                GameScr2.findCharInMap(id).cy = y - 30;
                GameScr2.findCharInMap(id).statusMe = 4;
            }
            if (Res2.abs(y - y2) < 50 && TileMap2.tileTypeAt(x, y, 2))
            {
                tHole = true;
                if (planet < 3)
                {
                    SoundMn2.gI().pauseAirShip();
                    if (y % 24 != 0)
                    {
                        y -= y % 24;
                    }
                    tPrepare++;
                    if (tPrepare > 10)
                    {
                        tPrepare = 0;
                        isDown = false;
                        isUp = true;
                        paintFire = false;
                    }
                    if (type == 1)
                    {
                        if (isMe)
                        {
                            Char2.myCharz().isTeleport = false;
                        }
                        else if (GameScr2.findCharInMap(id) != null)
                        {
                            GameScr2.findCharInMap(id).isTeleport = false;
                        }
                        painHead = false;
                    }
                }
                else
                {
                    y = y2;
                    if (!isShock)
                    {
                        ServerEffect2.addServerEffect(92, x + 4, y + 14, 1, 0);
                        GameScr2.shock_scr = 10;
                        isShock = true;
                    }
                    tPrepare++;
                    if (tPrepare > 30)
                    {
                        tPrepare = 0;
                        isDown = false;
                        isUp = true;
                        paintFire = false;
                    }
                    if (type == 1)
                    {
                        if (isMe)
                        {
                            Char2.myCharz().isTeleport = false;
                        }
                        else if (GameScr2.findCharInMap(id) != null)
                        {
                            GameScr2.findCharInMap(id).isTeleport = false;
                        }
                        painHead = false;
                    }
                }
            }
        }
        else if (isUp)
        {
            tPrepare++;
            if (tPrepare > 30)
            {
                int num2 = y2 + 24 - y >> 3;
                if (num2 > 30)
                {
                    num2 = 30;
                }
                y -= num2;
                paintFire = true;
            }
            else
            {
                if (tPrepare == 14 && createShip)
                {
                    SoundMn2.gI().resumeAirShip();
                }
                if (tPrepare > 0 && type == 0)
                {
                    if (isMe)
                    {
                        Char2.myCharz().isTeleport = false;
                        if (Char2.myCharz().statusMe != 14)
                        {
                            Char2.myCharz().statusMe = 3;
                        }
                        Char2.myCharz().cvy = -3;
                    }
                    else if (GameScr2.findCharInMap(id) != null)
                    {
                        GameScr2.findCharInMap(id).isTeleport = false;
                        if (GameScr2.findCharInMap(id).statusMe != 14)
                        {
                            GameScr2.findCharInMap(id).statusMe = 3;
                        }
                        GameScr2.findCharInMap(id).cvy = -3;
                    }
                    painHead = false;
                }
                if (tPrepare > 12 && type == 0)
                {
                    if (isMe)
                    {
                        Char2.myCharz().isTeleport = true;
                    }
                    else if (GameScr2.findCharInMap(id) != null)
                    {
                        GameScr2.findCharInMap(id).cx = x;
                        GameScr2.findCharInMap(id).cy = y;
                        GameScr2.findCharInMap(id).isTeleport = true;
                    }
                    painHead = true;
                }
            }
            if (isMe)
            {
                if (type == 0)
                {
                    GameScr2.cmtoX = x - GameScr2.gW2;
                    GameScr2.cmtoY = y - GameScr2.gH23;
                }
                if (type == 1)
                {
                    GameScr2.info1.isUpdate = true;
                }
            }
            if (y <= -80)
            {
                if (isMe && type == 0)
                {
                    Controller2_.isStopReadMessage = false;
                    Char2.ischangingMap = true;
                }
                if (!isMe && GameScr2.findCharInMap(id) != null && type == 0)
                {
                    GameScr2.vCharInMap.removeElement(GameScr2.findCharInMap(id));
                }
                if (planet < 3)
                {
                    vTeleport.removeElement(this);
                }
                else
                {
                    y = -80;
                    tDelayHole++;
                    if (tDelayHole > 80)
                    {
                        tDelayHole = 0;
                        vTeleport.removeElement(this);
                    }
                }
            }
        }
        if (paintFire && planet < 3 && Res2.abs(y - y2) <= 50 && GameCanvas2.gameTick % 5 == 0)
        {
            Effect2_ me = new Effect2_(19, x, y2 + 20, 2, 1, -1);
            EffecMn2.addEff(me);
        }
    }
}
