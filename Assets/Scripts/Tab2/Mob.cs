using System;

public class Mob2 : IMapObject2
{
    public const sbyte TYPE_DUNG = 0;

    public const sbyte TYPE_DI = 1;

    public const sbyte TYPE_NHAY = 2;

    public const sbyte TYPE_LET = 3;

    public const sbyte TYPE_BAY = 4;

    public const sbyte TYPE_BAY_DAU = 5;

    public static MobTemplate2[] arrMobTemplate;

    public const sbyte MA_INHELL = 0;

    public const sbyte MA_DEADFLY = 1;

    public const sbyte MA_STANDWAIT = 2;

    public const sbyte MA_ATTACK = 3;

    public const sbyte MA_STANDFLY = 4;

    public const sbyte MA_WALK = 5;

    public const sbyte MA_FALL = 6;

    public const sbyte MA_INJURE = 7;

    public bool changBody;

    public short smallBody;

    public bool isHintFocus;

    public string flystring;

    public int flyx;

    public int flyy;

    public int flyIndex;

    public bool isFreez;

    public int seconds;

    public long last;

    public long cur;

    public int holdEffID;

    public long hp;

    public long maxHp;

    public int x;

    public int y;

    public int dir = 1;

    public int dirV = 1;

    public int status;

    public int p1;

    public int p2;

    public int p3;

    public int xFirst;

    public int yFirst;

    public int vy;

    public int exp;

    public int w;

    public int h;

    public long hpInjure;

    public int charIndex;

    public int timeStatus;

    public int mobId;

    public bool isx;

    public bool isy;

    public bool isDisable;

    public bool isDontMove;

    public bool isFire;

    public bool isIce;

    public bool isWind;

    public bool isDie;

    public long lastDie = 0L;

    public int countDie = 0;

    public MyVector2 vMobMove = new MyVector2();

    public bool isGo;

    public string mobName;

    public int templateId;

    public short pointx;

    public short pointy;

    public Char2 cFocus;

    public long dame;

    public int dameMp;

    public int sys;

    public sbyte levelBoss;

    public sbyte level;

    public bool isBoss;

    public bool isMobMe;

    public static MyVector2 lastMob = new MyVector2();

    public static MyVector2 newMob = new MyVector2();

    public bool isMafuba;

    public int xMFB;

    public int yMFB;

    public int xSd;

    public int ySd;

    private bool isOutMap;

    private int wCount;

    public bool isShadown = true;

    private int tick;

    private int frame;

    public static Image2 imgHP = GameCanvas2.loadImage("/mainImage/myTexture2dmobHP.png");

    private bool wy;

    private int wt;

    private int fy;

    private int ty;

    public int typeSuperEff;

    public bool isBusyAttackSomeOne = true;

    public int[] stand = new int[12]
    {
        0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
        1, 1
    };

    public int[] move = new int[15]
    {
        1, 1, 1, 1, 2, 2, 2, 2, 3, 3,
        3, 3, 2, 2, 2
    };

    public int[] moveFast = new int[7] { 1, 1, 2, 2, 3, 3, 2 };

    public int[] attack1 = new int[3] { 4, 5, 6 };

    public int[] attack2 = new int[3] { 7, 8, 9 };

    public int[] hurt = new int[1];

    public int len = 24;

    public int w_hp_bar = 24;

    public int per = 100;

    public int per_tem = 100;

    public byte h_hp_bar = 4;

    public Image2 imgHPtem;

    private int offset;

    public bool isHide;

    private sbyte[] cou = new sbyte[2] { -1, 1 };

    public Char2 injureBy;

    public bool injureThenDie;

    public Mob2 mobToAttack;

    public int forceWait;

    public bool blindEff;

    public bool sleepEff;

    private int[][] frameArr = new int[6][]
    {
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 },
        new int[8] { 0, 0, 0, 0, 1, 1, 1, 1 }
    };

    private bool isGetFr = true;

    public Mob2()
    {
    }

    public Mob2(int mobId, bool isDisable, bool isDontMove, bool isFire, bool isIce, bool isWind, int templateId, int sys, long hp, sbyte level, long maxp, short pointx, short pointy, sbyte status, sbyte levelBoss)
    {
        this.isDisable = isDisable;
        this.isDontMove = isDontMove;
        this.isFire = isFire;
        this.isIce = isIce;
        this.isWind = isWind;
        this.sys = sys;
        this.mobId = mobId;
        this.templateId = templateId;
        this.hp = hp;
        this.level = level;
        xFirst = (x = (this.pointx = pointx));
        yFirst = (y = (this.pointy = pointy));
        this.status = status;
        if (templateId != 70)
        {
            checkData();
            getData();
        }
        if (!isExistNewMob(templateId + string.Empty))
        {
            newMob.addElement(templateId + string.Empty);
        }
        maxHp = maxp;
        this.levelBoss = levelBoss;
        updateHp_bar();
        per_tem = (int)((long)hp * 100L / maxHp);
        isDie = false;
        xSd = pointx;
        ySd = pointy;
        if (isNewModStand())
        {
            stand = new int[17]
            {
                0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2
            };
            move = new int[17]
            {
                0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2
            };
            moveFast = new int[17]
            {
                0, 0, 0, 0, 0, 1, 1, 1, 1, 1,
                2, 2, 2, 2, 2, 2, 2
            };
            attack1 = new int[12]
            {
                3, 3, 3, 3, 4, 4, 4, 4, 5, 5,
                5, 5
            };
            attack2 = new int[12]
            {
                3, 3, 3, 3, 4, 4, 4, 4, 5, 5,
                5, 5
            };
        }
        else if (isNewMod())
        {
            stand = new int[12]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                1, 1
            };
            move = new int[16]
            {
                1, 1, 1, 1, 2, 2, 2, 2, 1, 1,
                1, 1, 3, 3, 3, 3
            };
            moveFast = new int[8] { 1, 1, 2, 2, 1, 1, 3, 3 };
            attack1 = new int[11]
            {
                4, 4, 4, 5, 5, 5, 6, 6, 6, 6,
                6
            };
            attack2 = new int[11]
            {
                7, 7, 7, 8, 8, 8, 9, 9, 9, 9,
                9
            };
        }
        else if (isSpecial())
        {
            stand = new int[12]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                1, 1
            };
            move = new int[16]
            {
                2, 2, 3, 3, 2, 2, 4, 4, 2, 2,
                3, 3, 2, 2, 4, 4
            };
            moveFast = new int[8] { 2, 2, 3, 3, 2, 2, 4, 4 };
            attack1 = new int[8] { 5, 6, 7, 8, 9, 10, 11, 12 };
            attack2 = new int[4] { 5, 12, 13, 14 };
        }
        else
        {
            stand = new int[12]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
                1, 1
            };
            move = new int[15]
            {
                1, 1, 1, 1, 2, 2, 2, 2, 3, 3,
                3, 3, 2, 2, 2
            };
            moveFast = new int[7] { 1, 1, 2, 2, 3, 3, 2 };
            attack1 = new int[3] { 4, 5, 6 };
            attack2 = new int[3] { 7, 8, 9 };
        }
    }

    public bool isBigBoss()
    {
        return this is BachTuoc2 || this is BigBoss2_2 || this is BigBoss2_ || this is NewBoss2;
    }

    public void getData()
    {
        if (arrMobTemplate[templateId].data == null)
        {
            arrMobTemplate[templateId].data = new EffectData2();
            string text = "/Mob/" + templateId;
            DataInputStream2 dataInputStream = MyStream2.readFile(text);
            if (dataInputStream != null)
            {
                arrMobTemplate[templateId].data.readData(text + "/data");
                arrMobTemplate[templateId].data.img = GameCanvas2.loadImage(text + "/img.png");
            }
            else
            {
                Service2.gI().requestModTemplate(templateId);
            }
            if (lastMob.size() > 15)
            {
                arrMobTemplate[int.Parse((string)lastMob.elementAt(0))].data = null;
                lastMob.removeElementAt(0);
            }
            lastMob.addElement(templateId + string.Empty);
        }
        else
        {
            w = arrMobTemplate[templateId].data.width;
            h = arrMobTemplate[templateId].data.height;
        }
    }

    public virtual void setBody(short id)
    {
        changBody = true;
        smallBody = id;
    }

    public virtual void clearBody()
    {
        changBody = false;
    }

    public static bool isExistNewMob(string id)
    {
        for (int i = 0; i < newMob.size(); i++)
        {
            string text = (string)newMob.elementAt(i);
            if (text.Equals(id))
            {
                return true;
            }
        }
        return false;
    }

    public void checkData()
    {
        int num = 0;
        for (int i = 0; i < arrMobTemplate.Length; i++)
        {
            if (arrMobTemplate[i].data != null)
            {
                num++;
            }
        }
        if (num < 10)
        {
            return;
        }
        for (int j = 0; j < arrMobTemplate.Length; j++)
        {
            if (arrMobTemplate[j].data != null && num > 5)
            {
                arrMobTemplate[j].data = null;
            }
        }
    }

    public void checkFrameTick(int[] array)
    {
        if (tick > array.Length - 1)
        {
            tick = 0;
        }
        frame = array[tick];
        tick++;
    }

    private void updateShadown()
    {
        int num = TileMap2.size;
        xSd = x;
        wCount = 0;
        if (ySd <= 0 || TileMap2.tileTypeAt(xSd, ySd, 2))
        {
            return;
        }
        if (TileMap2.tileTypeAt(xSd / num, ySd / num) == 0)
        {
            isOutMap = true;
        }
        else if (TileMap2.tileTypeAt(xSd / num, ySd / num) != 0 && !TileMap2.tileTypeAt(xSd, ySd, 2))
        {
            xSd = x;
            ySd = y;
            isOutMap = false;
        }
        while (isOutMap && wCount < 10)
        {
            wCount++;
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
        g.drawImage(TileMap2.bong, xSd, ySd, 3);
        g.setClip(GameScr2.cmx, GameScr2.cmy - GameCanvas2.transY, GameScr2.gW, GameScr2.gH + 2 * GameCanvas2.transY);
    }

    public void updateSuperEff()
    {
        if (typeSuperEff == 0 && GameCanvas2.gameTick % 25 == 0)
        {
            ServerEffect2.addServerEffect(114, this, 1);
        }
        if (typeSuperEff == 1 && GameCanvas2.gameTick % 4 == 0)
        {
            ServerEffect2.addServerEffect(132, this, 1);
        }
        if (typeSuperEff == 2 && GameCanvas2.gameTick % 7 == 0)
        {
            ServerEffect2.addServerEffect(131, this, 1);
        }
    }

    public virtual void update()
    {
        if (isMafuba)
        {
            return;
        }
        GetFrame();
        if (blindEff && GameCanvas2.gameTick % 5 == 0)
        {
            ServerEffect2.addServerEffect(113, x, y, 1);
        }
        if (sleepEff && GameCanvas2.gameTick % 10 == 0)
        {
            EffecMn2.addEff(new Effect2_(41, x, y, 3, 1, 1));
        }
        if (!GameCanvas2.lowGraphic && status != 1 && status != 0 && !GameCanvas2.lowGraphic && GameCanvas2.gameTick % (15 + mobId * 2) == 0)
        {
            for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
            {
                Char2 @char = (Char2)GameScr2.vCharInMap.elementAt(i);
                if (@char != null && @char.isFlyAndCharge && @char.cf == 32)
                {
                    Char2 char2 = new Char2();
                    char2.cx = @char.cx;
                    char2.cy = @char.cy - @char.ch;
                    if (@char.cgender == 0)
                    {
                        MonsterDart2.addMonsterDart(x + dir * w, y, checkIsBoss(), -100, -100, char2, 25);
                    }
                }
            }
            if (Char2.myCharz().isFlyAndCharge && Char2.myCharz().cf == 32)
            {
                Char2 char3 = new Char2();
                char3.cx = Char2.myCharz().cx;
                char3.cy = Char2.myCharz().cy - Char2.myCharz().ch;
                if (Char2.myCharz().cgender == 0)
                {
                    MonsterDart2.addMonsterDart(x + dir * w, y, checkIsBoss(), -100, -100, char3, 25);
                }
            }
        }
        if (holdEffID != 0 && GameCanvas2.gameTick % 5 == 0)
        {
            EffecMn2.addEff(new Effect2_(holdEffID, x, y + 24, 3, 5, 1));
        }
        if (isFreez)
        {
            if (GameCanvas2.gameTick % 5 == 0)
            {
                ServerEffect2.addServerEffect(113, x, y, 1);
            }
            long num = mSystem2.currentTimeMillis();
            if (num - last >= 1000)
            {
                seconds--;
                last = num;
                if (seconds < 0)
                {
                    isFreez = false;
                    seconds = 0;
                }
            }
            if (isTypeNewMod())
            {
                frame = hurt[GameCanvas2.gameTick % hurt.Length];
            }
            else if (isNewModStand())
            {
                frame = attack1[GameCanvas2.gameTick % attack1.Length];
            }
            else if (isNewMod())
            {
                if (GameCanvas2.gameTick % 20 > 5)
                {
                    frame = 11;
                }
                else
                {
                    frame = 10;
                }
            }
            else if (isSpecial())
            {
                if (GameCanvas2.gameTick % 20 > 5)
                {
                    frame = 1;
                }
                else
                {
                    frame = 15;
                }
            }
            else if (GameCanvas2.gameTick % 20 > 5)
            {
                frame = 11;
            }
            else
            {
                frame = 10;
            }
        }
        if (!isUpdate())
        {
            return;
        }
        if (isShadown)
        {
            updateShadown();
        }
        if (vMobMove == null && arrMobTemplate[templateId].rangeMove != 0)
        {
            return;
        }
        if (status != 3 && isBusyAttackSomeOne)
        {
            if (cFocus != null)
            {
                cFocus.doInjure(dame, dameMp, isCrit: false, isMob: true);
            }
            else if (mobToAttack != null)
            {
                mobToAttack.setInjure();
            }
            isBusyAttackSomeOne = false;
        }
        if (levelBoss > 0)
        {
            updateSuperEff();
        }
        switch (status)
        {
            case 1:
                isDisable = false;
                isDontMove = false;
                isFire = false;
                isIce = false;
                isWind = false;
                y += p1;
                if (GameCanvas2.gameTick % 2 == 0)
                {
                    if (p2 > 1)
                    {
                        p2--;
                    }
                    else if (p2 < -1)
                    {
                        p2++;
                    }
                }
                x += p2;
                if (isTypeNewMod())
                {
                    frame = hurt[GameCanvas2.gameTick % hurt.Length];
                }
                else if (isNewModStand())
                {
                    frame = attack1[GameCanvas2.gameTick % attack1.Length];
                }
                else if (isNewMod())
                {
                    frame = 11;
                }
                else if (isSpecial())
                {
                    frame = 15;
                }
                else
                {
                    frame = 11;
                }
                if (isDie)
                {
                    isDie = false;
                    if (isMobMe)
                    {
                        for (int j = 0; j < GameScr2.vMob.size(); j++)
                        {
                            if (((Mob2)GameScr2.vMob.elementAt(j)).mobId == mobId)
                            {
                                GameScr2.vMob.removeElementAt(j);
                            }
                        }
                    }
                    p1 = 0;
                    p2 = 0;
                    x = (y = 0);
                    hp = getTemplate().hp;
                    status = 0;
                    timeStatus = 0;
                    break;
                }
                if ((TileMap2.tileTypeAtPixel(x, y) & 2) == 2)
                {
                    p1 = ((p1 <= 4) ? (-p1) : (-4));
                    if (p3 == 0)
                    {
                        p3 = 16;
                    }
                }
                else
                {
                    p1++;
                }
                if (p3 > 0)
                {
                    p3--;
                    if (p3 == 0)
                    {
                        isDie = true;
                    }
                }
                break;
            case 2:
                if (holdEffID == 0 && !isFreez && !blindEff && !sleepEff)
                {
                    timeStatus = 0;
                    updateMobStandWait();
                }
                break;
            case 4:
                if (holdEffID == 0 && !blindEff && !sleepEff && !isFreez)
                {
                    timeStatus = 0;
                    p1++;
                    if (p1 > 40 + mobId % 5)
                    {
                        y -= 2;
                        status = 5;
                        p1 = 0;
                    }
                }
                break;
            case 3:
                if (holdEffID == 0 && !blindEff && !sleepEff && !isFreez)
                {
                    updateMobAttack();
                }
                break;
            case 5:
                if (holdEffID != 0 || blindEff || sleepEff)
                {
                    break;
                }
                if (isFreez)
                {
                    if (arrMobTemplate[templateId].type == 4)
                    {
                        ty++;
                        wt++;
                        fy += ((!wy) ? 1 : (-1));
                        if (wt == 10)
                        {
                            wt = 0;
                            wy = !wy;
                        }
                    }
                }
                else
                {
                    timeStatus = 0;
                    updateMobWalk();
                }
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
                break;
        }
    }

    public void setInjure()
    {
        if (hp > 0 && status != 3 && status != 7)
        {
            timeStatus = 4;
            status = 7;
            if (getTemplate().type != 0 && Res2.abs(x - xFirst) < 30)
            {
                x -= 10 * dir;
            }
        }
    }

    public static BigBoss2_ getBigBoss()
    {
        for (int i = 0; i < GameScr2.vMob.size(); i++)
        {
            Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
            if (mob is BigBoss2_)
            {
                return (BigBoss2_)mob;
            }
        }
        return null;
    }

    public static BigBoss2_2 getBigBoss2()
    {
        for (int i = 0; i < GameScr2.vMob.size(); i++)
        {
            Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
            if (mob is BigBoss2_2)
            {
                return (BigBoss2_2)mob;
            }
        }
        return null;
    }

    public static BachTuoc2 getBachTuoc()
    {
        for (int i = 0; i < GameScr2.vMob.size(); i++)
        {
            Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
            if (mob is BachTuoc2)
            {
                return (BachTuoc2)mob;
            }
        }
        return null;
    }

    public static NewBoss2 getNewBoss(sbyte idBoss)
    {
        Mob2 mob = (Mob2)GameScr2.vMob.elementAt(idBoss);
        if (mob is NewBoss2)
        {
            return (NewBoss2)mob;
        }
        return null;
    }

    public static void removeBigBoss()
    {
        for (int i = 0; i < GameScr2.vMob.size(); i++)
        {
            Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
            if (mob is BigBoss2_)
            {
                GameScr2.vMob.removeElement(mob);
                break;
            }
        }
    }

    public void setAttack(Char2 cFocus)
    {
        isBusyAttackSomeOne = true;
        mobToAttack = null;
        this.cFocus = cFocus;
        p1 = 0;
        p2 = 0;
        status = 3;
        tick = 0;
        dir = ((cFocus.cx > x) ? 1 : (-1));
        int cx = cFocus.cx;
        int cy = cFocus.cy;
        if (Res2.abs(cx - x) < w * 2 && Res2.abs(cy - y) < h * 2)
        {
            p3 = 0;
        }
        else
        {
            p3 = 1;
        }
    }

    private bool isSpecial()
    {
        if ((templateId >= 58 && templateId <= 65) || templateId == 67 || templateId == 68)
        {
            return true;
        }
        return false;
    }

    private bool isNewModStand()
    {
        return templateId == 76;
    }

    private bool isNewMod()
    {
        if (templateId >= 73 && !isNewModStand())
        {
            return true;
        }
        return false;
    }

    private void updateInjure()
    {
        if (!isBusyAttackSomeOne && GameCanvas2.gameTick % 4 == 0)
        {
            if (isTypeNewMod())
            {
                frame = hurt[GameCanvas2.gameTick % hurt.Length];
            }
            else if (isNewModStand())
            {
                frame = attack1[GameCanvas2.gameTick % attack1.Length];
            }
            else if (isNewMod())
            {
                if (frame != 10)
                {
                    frame = 10;
                }
                else
                {
                    frame = 11;
                }
            }
            else if (isSpecial())
            {
                if (frame != 1)
                {
                    frame = 1;
                }
                else
                {
                    frame = 15;
                }
            }
            else if (frame != 10)
            {
                frame = 10;
            }
            else
            {
                frame = 11;
            }
        }
        timeStatus--;
        if (timeStatus <= 0 && (isTypeNewMod() || isNewModStand() || (isNewMod() && frame == 11) || (isSpecial() && frame == 15) || (templateId < 58 && frame == 11)))
        {
            if ((injureBy != null && injureThenDie) || hp == 0)
            {
                status = 1;
                p2 = injureBy.cdir << 1;
                p1 = -3;
                p3 = 0;
            }
            else
            {
                status = 5;
                if (injureBy != null)
                {
                    dir = -injureBy.cdir;
                    if (Res2.abs(x - injureBy.cx) < 24)
                    {
                        status = 2;
                    }
                }
                p1 = (p2 = (p3 = 0));
                timeStatus = 0;
            }
            injureBy = null;
        }
        else if (arrMobTemplate[templateId].type != 0 && injureBy != null)
        {
            int num = -injureBy.cdir << 1;
            if (x > xFirst - arrMobTemplate[templateId].rangeMove && x < xFirst + arrMobTemplate[templateId].rangeMove)
            {
                x -= num;
            }
        }
    }

    private void updateMobStandWait()
    {
        checkFrameTick(stand);
        switch (arrMobTemplate[templateId].type)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                p1++;
                if (p1 > 10 + mobId % 10 && (cFocus == null || Res2.abs(cFocus.cx - x) > 80) && (mobToAttack == null || Res2.abs(mobToAttack.x - x) > 80))
                {
                    status = 5;
                }
                break;
            case 4:
            case 5:
                p1++;
                if (p1 > mobId % 3 && (cFocus == null || Res2.abs(cFocus.cx - x) > 80) && (mobToAttack == null || Res2.abs(mobToAttack.x - x) > 80))
                {
                    status = 5;
                }
                break;
        }
        if (cFocus != null && GameCanvas2.gameTick % (10 + p1 % 20) == 0)
        {
            if (cFocus.cx > x)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
        }
        else if (mobToAttack != null && GameCanvas2.gameTick % (10 + p1 % 20) == 0)
        {
            if (mobToAttack.x > x)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
        }
        if (forceWait > 0)
        {
            forceWait--;
            status = 2;
        }
    }

    public void updateMobAttack()
    {
        int[] array = ((p3 != 0) ? attack2 : attack1);
        if (tick < array.Length)
        {
            checkFrameTick(array);
            if (x >= GameScr2.cmx && x <= GameScr2.cmx + GameCanvas2.w && p3 == 0 && GameCanvas2.gameTick % 2 == 0)
            {
                SoundMn2.gI().charPunch(isKick: false, 0.05f);
            }
        }
        if (p1 == 0)
        {
            int num = 0;
            int num2 = 0;
            num = ((cFocus == null) ? mobToAttack.x : cFocus.cx);
            num2 = ((cFocus == null) ? mobToAttack.y : cFocus.cy);
            if (!isNewMod())
            {
                if (x > xFirst + arrMobTemplate[templateId].rangeMove)
                {
                    p1 = 1;
                }
                if (x < xFirst - arrMobTemplate[templateId].rangeMove)
                {
                    p1 = 1;
                }
            }
            if ((arrMobTemplate[templateId].type == 4 || arrMobTemplate[templateId].type == 5) && !isDontMove)
            {
                y += (num2 - y) / 20;
            }
            p2++;
            if (p2 > array.Length - 1 || p1 == 1)
            {
                p1 = 1;
                if (p3 == 0)
                {
                    if (cFocus != null)
                    {
                        cFocus.doInjure(dame, dameMp, isCrit: false, isMob: true);
                    }
                    else
                    {
                        mobToAttack.setInjure();
                    }
                    isBusyAttackSomeOne = false;
                }
                else
                {
                    if (cFocus != null)
                    {
                        MonsterDart2.addMonsterDart(x + dir * w, y, checkIsBoss(), (int)dame, dameMp, cFocus, getTemplate().dartType);
                    }
                    else
                    {
                        Char2 @char = new Char2();
                        @char.cx = mobToAttack.x;
                        @char.cy = mobToAttack.y;
                        @char.charID = -100;
                        MonsterDart2.addMonsterDart(x + dir * w, y, checkIsBoss(), (int)dame, dameMp, @char, getTemplate().dartType);
                    }
                    isBusyAttackSomeOne = false;
                }
            }
            dir = ((x < num) ? 1 : (-1));
        }
        else if (p1 == 1)
        {
            if (arrMobTemplate[templateId].type == 0 || isDontMove || isIce || !isWind)
            {
            }
            if (tick == array.Length)
            {
                status = 2;
                p1 = 0;
                p2 = 0;
                tick = 0;
            }
        }
        if (tick == 5 && cFocus != null && cFocus.charID == Char2.myCharz().charID)
        {
            if (templateId == 88 && p3 != 0)
            {
                GameScr2.shock_scr = 2;
            }
            if (templateId == 89)
            {
                GameScr2.shock_scr = 2;
            }
        }
    }

    public void updateMobWalk()
    {
        int num = 0;
        try
        {
            if (injureThenDie)
            {
                status = 1;
                p2 = injureBy.cdir << 3;
                p1 = -5;
                p3 = 0;
            }
            num = 1;
            if (isIce)
            {
                return;
            }
            if (isDontMove || isWind)
            {
                checkFrameTick(stand);
                return;
            }
            switch (arrMobTemplate[templateId].type)
            {
                case 0:
                    if (isNewModStand())
                    {
                        frame = stand[GameCanvas2.gameTick % stand.Length];
                    }
                    else
                    {
                        frame = 0;
                    }
                    num = 2;
                    break;
                case 1:
                case 2:
                case 3:
                    {
                        num = 3;
                        sbyte b = arrMobTemplate[templateId].speed;
                        if (b == 1)
                        {
                            if (GameCanvas2.gameTick % 2 == 1)
                            {
                                break;
                            }
                        }
                        else if (b > 2)
                        {
                            b += (sbyte)(mobId % 2);
                        }
                        else if (GameCanvas2.gameTick % 2 == 1)
                        {
                            b--;
                        }
                        x += b * dir;
                        if (x > xFirst + arrMobTemplate[templateId].rangeMove)
                        {
                            dir = -1;
                        }
                        else if (x < xFirst - arrMobTemplate[templateId].rangeMove)
                        {
                            dir = 1;
                        }
                        if (Res2.abs(x - Char2.myCharz().cx) < 40 && Res2.abs(x - xFirst) < arrMobTemplate[templateId].rangeMove)
                        {
                            dir = ((x <= Char2.myCharz().cx) ? 1 : (-1));
                            if (Res2.abs(x - Char2.myCharz().cx) < 20)
                            {
                                x -= dir * 10;
                            }
                            status = 2;
                            forceWait = 20;
                        }
                        checkFrameTick((w <= 30) ? moveFast : move);
                        break;
                    }
                case 4:
                    {
                        num = 4;
                        sbyte speed2 = arrMobTemplate[templateId].speed;
                        speed2 += (sbyte)(mobId % 2);
                        x += speed2 * dir;
                        if (GameCanvas2.gameTick % 10 > 2)
                        {
                            y += speed2 * dirV;
                        }
                        speed2 += (sbyte)((GameCanvas2.gameTick + mobId) % 2);
                        if (x > xFirst + arrMobTemplate[templateId].rangeMove)
                        {
                            dir = -1;
                            status = 2;
                            forceWait = GameCanvas2.gameTick % 20 + 20;
                            p1 = 0;
                        }
                        else if (x < xFirst - arrMobTemplate[templateId].rangeMove)
                        {
                            dir = 1;
                            status = 2;
                            forceWait = GameCanvas2.gameTick % 20 + 20;
                            p1 = 0;
                        }
                        if (y > yFirst + 24)
                        {
                            dirV = -1;
                        }
                        else if (y < yFirst - (20 + GameCanvas2.gameTick % 10))
                        {
                            dirV = 1;
                        }
                        checkFrameTick(move);
                        break;
                    }
                case 5:
                    {
                        num = 5;
                        sbyte speed = arrMobTemplate[templateId].speed;
                        speed += (sbyte)(mobId % 2);
                        x += speed * dir;
                        speed += (sbyte)((GameCanvas2.gameTick + mobId) % 2);
                        if (GameCanvas2.gameTick % 10 > 2)
                        {
                            y += speed * dirV;
                        }
                        if (x > xFirst + arrMobTemplate[templateId].rangeMove)
                        {
                            dir = -1;
                            status = 2;
                            forceWait = GameCanvas2.gameTick % 20 + 20;
                            p1 = 0;
                        }
                        else if (x < xFirst - arrMobTemplate[templateId].rangeMove)
                        {
                            dir = 1;
                            status = 2;
                            forceWait = GameCanvas2.gameTick % 20 + 20;
                            p1 = 0;
                        }
                        if (y > yFirst + 24)
                        {
                            dirV = -1;
                        }
                        else if (y < yFirst - (20 + GameCanvas2.gameTick % 10))
                        {
                            dirV = 1;
                        }
                        if (TileMap2.tileTypeAt(x, y, 2))
                        {
                            if (GameCanvas2.gameTick % 10 > 5)
                            {
                                y = TileMap2.tileYofPixel(y);
                                status = 4;
                                p1 = 0;
                                dirV = -1;
                            }
                            else
                            {
                                dirV = -1;
                            }
                        }
                        break;
                    }
            }
        }
        catch (Exception)
        {
            Cout2.println("lineee: " + num);
        }
    }

    public MobTemplate2 getTemplate()
    {
        return arrMobTemplate[templateId];
    }

    public bool isPaint()
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
        if (arrMobTemplate[templateId] == null)
        {
            return false;
        }
        if (arrMobTemplate[templateId].data == null)
        {
            return false;
        }
        if (arrMobTemplate[templateId].data.img == null)
        {
            return false;
        }
        if (status == 0)
        {
            return false;
        }
        return true;
    }

    public bool isUpdate()
    {
        if (arrMobTemplate[templateId] == null)
        {
            return false;
        }
        if (arrMobTemplate[templateId].data == null)
        {
            return false;
        }
        if (status == 0)
        {
            return false;
        }
        return true;
    }

    public bool checkIsBoss()
    {
        if (isBoss || levelBoss > 0)
        {
            return true;
        }
        return false;
    }

    public void updateHp_bar()
    {
        len = (int)(hp * 100L / maxHp * w_hp_bar) / 100;
        per = (int)(hp * 100L / maxHp);
        if (per == 100)
        {
            per_tem = per;
        }
        if (per >= 100)
        {
            per_tem = per;
        }
        offset = 0;
        if (per < 30)
        {
            imgHPtem = GameScr2.imgHP_tm_do;
        }
        else if (per < 60)
        {
            imgHPtem = GameScr2.imgHP_tm_vang;
        }
        else
        {
            imgHPtem = GameScr2.imgHP_tm_xanh;
        }
    }

    public virtual void paint(mGraphics2 g)
    {
        if (isHide)
        {
            return;
        }
        if (isMafuba)
        {
            if (!changBody)
            {
                arrMobTemplate[templateId].data.paintFrame(g, frame, xMFB, yMFB, (dir != 1) ? 1 : 0, 2);
            }
            else
            {
                SmallImage2.drawSmallImage(g, smallBody, xMFB, yMFB, (dir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
            }
            return;
        }
        if (isShadown && status != 0)
        {
            paintShadow(g);
        }
        if (!isPaint() || (status == 1 && p3 > 0 && GameCanvas2.gameTick % 3 == 0))
        {
            return;
        }
        g.translate(0, GameCanvas2.transY);
        if (!changBody)
        {
            arrMobTemplate[templateId].data.paintFrame(g, frame, x, y + fy, (dir != 1) ? 1 : 0, 2);
        }
        else
        {
            SmallImage2.drawSmallImage(g, smallBody, x, y + fy - 9, (dir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
        }
        g.translate(0, -GameCanvas2.transY);
        if (Char2.myCharz().mobFocus == null || !Char2.myCharz().mobFocus.Equals(this) || status == 1 || hp <= 0 || imgHPtem == null)
        {
            return;
        }
        int imageWidth = mGraphics2.getImageWidth(imgHPtem);
        int imageHeight = mGraphics2.getImageHeight(imgHPtem);
        int num = imageWidth * per / 100;
        int num2 = num;
        if (per_tem >= per)
        {
            num2 = imageWidth * (per_tem -= ((GameCanvas2.gameTick % 6 <= 3) ? offset : offset++)) / 100;
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
        g.drawImage(GameScr2.imgHP_tm_xam, x - (imageWidth >> 1), y - h - 5, mGraphics2.TOP | mGraphics2.LEFT);
        g.setColor(16777215);
        g.fillRect(x - (imageWidth >> 1), y - h - 5, num2, 2);
        g.drawRegion(imgHPtem, 0, 0, num, imageHeight, 0, x - (imageWidth >> 1), y - h - 5, mGraphics2.TOP | mGraphics2.LEFT);
    }

    public int getHPColor()
    {
        return 16711680;
    }

    public void startDie()
    {
        hp = 0;
        injureThenDie = true;
        hp = 0;
        status = 1;
        Res2.outz("MOB DIEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEe");
        p1 = -3;
        p2 = -dir;
        p3 = 0;
    }

    public void attackOtherMob(Mob2 mobToAttack)
    {
        this.mobToAttack = mobToAttack;
        isBusyAttackSomeOne = true;
        cFocus = null;
        p1 = 0;
        p2 = 0;
        status = 3;
        tick = 0;
        dir = ((mobToAttack.x > x) ? 1 : (-1));
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
        return h;
    }

    public int getW()
    {
        return w;
    }

    public void stopMoving()
    {
        if (status == 5)
        {
            status = 2;
            p1 = (p2 = (p3 = 0));
            forceWait = 50;
        }
    }

    public bool isInvisible()
    {
        return status == 0 || status == 1;
    }

    public void removeHoldEff()
    {
        if (holdEffID != 0)
        {
            holdEffID = 0;
        }
    }

    public void removeBlindEff()
    {
        blindEff = false;
    }

    public void removeSleepEff()
    {
        sleepEff = false;
    }

    public void GetFrame()
    {
        if (isGetFr && isTypeNewMod() && arrMobTemplate[templateId].data != null)
        {
            frameArr = (int[][])Controller2_.frameHT_NEWBOSS.get(templateId + string.Empty);
            stand = frameArr[0];
            move = frameArr[1];
            moveFast = frameArr[2];
            attack1 = frameArr[3];
            attack2 = frameArr[4];
            hurt = frameArr[5];
            isGetFr = false;
        }
    }

    private bool isTypeNewMod()
    {
        if (arrMobTemplate[templateId].data != null && arrMobTemplate[templateId].data.typeData == 2)
        {
            return true;
        }
        return false;
    }
}
