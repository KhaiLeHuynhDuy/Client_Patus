using System;

internal class Mabu2 : Char2
{
    public static EffectData2 data1;

    public static EffectData2 data2;

    private new int tick;

    private int lastDir;

    private bool addFoot;

    private Effect2_ effEat;

    private new Char2 focus;

    public int xTo;

    public int yTo;

    public bool haftBody;

    public bool change;

    private Char2[] charAttack;

    private int[] damageAttack;

    private int dx;

    public static int[] skill1 = new int[30]
    {
        0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
        5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
        5, 5, 5, 5, 5, 5, 5, 5, 5, 5
    };

    public static int[] skill2 = new int[15]
    {
        0, 0, 6, 6, 7, 7, 8, 8, 9, 9,
        9, 9, 9, 10, 10
    };

    public static int[] skill3 = new int[26]
    {
        0, 0, 1, 1, 2, 2, 3, 3, 4, 4,
        5, 5, 6, 6, 7, 7, 8, 8, 9, 9,
        10, 10, 11, 11, 12, 12
    };

    public static int[] skill4 = new int[8] { 13, 13, 14, 14, 15, 15, 16, 16 };

    public static int[][] skills = new int[4][] { skill1, skill2, skill3, skill4 };

    public sbyte skillID = -1;

    private int frame;

    private int pIndex;

    public Mabu2()
    {
        getData1();
        getData2();
    }

    public void eat(int id)
    {
        effEat = new Effect2_(105, cx, cy + 20, 2, 1, -1);
        EffecMn2.addEff(effEat);
        if (id == Char2.myCharz().charID)
        {
            focus = Char2.myCharz();
        }
        else
        {
            focus = GameScr2.findCharInMap(id);
        }
    }

    public new void checkFrameTick(int[] array)
    {
        if (skillID == 0)
        {
            if (tick == 11)
            {
                addFoot = true;
                Effect2_ effect = new Effect2_(19, cx, cy + 20, 2, 1, -1);
                EffecMn2.addEff(effect);
            }
            if (tick >= array.Length - 1)
            {
                skillID = 2;
                return;
            }
        }
        if (skillID == 1 && tick == array.Length - 1)
        {
            skillID = 3;
            cy -= 15;
            return;
        }
        tick++;
        if (tick > array.Length - 1)
        {
            tick = 0;
        }
        frame = array[tick];
    }

    public void getData1()
    {
        data1 = null;
        data1 = new EffectData2();
        string patch = "/x" + mGraphics2.zoomLevel + "/effectdata/" + 102 + "/data";
        try
        {
            data1.readData2(patch);
            data1.img = GameCanvas2.loadImage("/effectdata/" + 102 + "/img.png");
        }
        catch (Exception)
        {
        }
    }

    public void setSkill(sbyte id, short x, short y, Char2[] charHit, int[] damageHit)
    {
        skillID = id;
        xTo = x;
        yTo = y;
        lastDir = cdir;
        cdir = ((xTo > cx) ? 1 : (-1));
        charAttack = charHit;
        damageAttack = damageHit;
    }

    public void getData2()
    {
        data2 = null;
        data2 = new EffectData2();
        string patch = "/x" + mGraphics2.zoomLevel + "/effectdata/" + 103 + "/data";
        try
        {
            data2.readData2(patch);
            data2.img = GameCanvas2.loadImage("/effectdata/" + 103 + "/img.png");
            Res2.outz("read xong data");
        }
        catch (Exception)
        {
        }
    }

    public override void update()
    {
        if (focus != null)
        {
            if (effEat.t >= 30)
            {
                effEat.x += (cx - effEat.x) / 4;
                effEat.y += (cy - effEat.y) / 4;
                focus.cx = effEat.x;
                focus.cy = effEat.y;
                focus.isMabuHold = true;
            }
            else
            {
                effEat.trans = ((effEat.x > focus.cx) ? 1 : 0);
                effEat.x += (focus.cx - effEat.x) / 3;
                effEat.y += (focus.cy - effEat.y) / 3;
            }
        }
        if (skillID != -1)
        {
            if (skillID == 0 && addFoot && GameCanvas2.gameTick % 2 == 0)
            {
                dx += ((xTo <= cx) ? (-30) : 30);
                Effect2_ effect = new Effect2_(103, cx + dx, cy + 20, 2, 1, -1);
                effect.trans = ((xTo <= cx) ? 1 : 0);
                EffecMn2.addEff(effect);
                if ((cdir == 1 && cx + dx >= xTo) || (cdir == -1 && cx + dx <= xTo))
                {
                    addFoot = false;
                    skillID = -1;
                    dx = 0;
                    tick = 0;
                    cdir = lastDir;
                    for (int i = 0; i < charAttack.Length; i++)
                    {
                        charAttack[i].doInjure(damageAttack[i], 0, isCrit: false, isMob: false);
                    }
                }
            }
            if (skillID != 3)
            {
                return;
            }
            xTo = charAttack[pIndex].cx;
            yTo = charAttack[pIndex].cy;
            cx += (xTo - cx) / 3;
            cy += (yTo - cy) / 3;
            if (GameCanvas2.gameTick % 5 == 0)
            {
                Effect2_ effect2 = new Effect2_(19, cx, cy, 2, 1, -1);
                EffecMn2.addEff(effect2);
            }
            if (Res2.abs(cx - xTo) <= 20 && Res2.abs(cy - yTo) <= 20)
            {
                cx = xTo;
                cy = yTo;
                charAttack[pIndex].doInjure(damageAttack[pIndex], 0, isCrit: false, isMob: false);
                pIndex++;
                if (pIndex == charAttack.Length)
                {
                    skillID = -1;
                    pIndex = 0;
                }
            }
        }
        else
        {
            base.update();
        }
    }

    public override void paint(mGraphics2 g)
    {
        if (skillID != -1)
        {
            paintShadow(g);
            g.translate(0, GameCanvas2.transY);
            checkFrameTick(skills[skillID]);
            if (skillID == 0 || skillID == 1)
            {
                data1.paintFrame(g, frame, cx, cy + fy, (cdir != 1) ? 1 : 0, 2);
            }
            else
            {
                data2.paintFrame(g, frame, cx, cy + fy, (cdir != 1) ? 1 : 0, 2);
            }
            g.translate(0, -GameCanvas2.transY);
        }
        else
        {
            base.paint(g);
        }
    }
}

