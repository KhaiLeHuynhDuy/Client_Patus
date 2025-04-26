public class TabClanIcon2 : IActionListener2
{
    private int x;

    private int y;

    private int w;

    private int h;

    private Command2 left;

    private Command2 right;

    private Command2 center;

    private int WIDTH = 24;

    public int nItem;

    private int disStart = 50;

    public static Scroll2 scrMain;

    public int cmtoX;

    public int cmx;

    public int cmvx;

    public int cmdx;

    public bool isShow;

    public bool isGetName;

    public string text;

    private bool isRequest;

    public MyVector2 vItems = new MyVector2();

    private int msgID;

    private int select;

    private int lastSelect;

    private ScrollResult2 sr;

    public TabClanIcon2()
    {
        left = new Command2(mResources2.SELECT, this, 1, null);
        right = new Command2(mResources2.CLOSE, this, 2, null);
    }

    public void init()
    {
        if (isGetName)
        {
            w = 170;
            h = 118;
            x = GameCanvas2.w / 2 - w / 2;
            y = GameCanvas2.h / 2 - h / 2;
        }
        else
        {
            w = 170;
            h = 170;
            x = GameCanvas2.w / 2 - w / 2;
            y = GameCanvas2.h / 2 - h / 2;
            if (GameCanvas2.h < 240)
            {
                y -= 10;
            }
        }
        cmx = x;
        cmtoX = 0;
        if (!isRequest)
        {
            nItem = ClanImage2.vClanImage.size();
        }
        else
        {
            nItem = vItems.size();
        }
        if (GameCanvas2.isTouch)
        {
            left.x = x;
            left.y = y + h + 5;
            right.x = x + w - 68;
            right.y = y + h + 5;
        }
        scrMain = new Scroll2();
        scrMain.setStyle(nItem, WIDTH, x, y + disStart, w, h - disStart, styleUPDOWN: true, 1);
    }

    public void show(bool isGetName)
    {
        if (Char2.myCharz().clan != null)
        {
        }
        isShow = true;
        this.isGetName = isGetName;
        init();
    }

    public void showRequest(int msgID)
    {
        isShow = true;
        isRequest = true;
        this.msgID = msgID;
        init();
    }

    public void hide()
    {
        cmtoX = x + w;
        // SmallImage2.clearHastable();
    }

    public void paintPeans(mGraphics2 g)
    {
    }

    public void paintIcon(mGraphics2 g)
    {
        g.translate(-cmx, 0);
        PopUp2.paintPopUp(g, x, y - 17, w, h + 17, -1, isButton: true);
        mFont2.tahoma_7b_dark.drawString(g, mResources2.select_clan_icon, x + w / 2, y - 7, 2);
        if (lastSelect >= 0 && lastSelect <= ClanImage2.vClanImage.size() - 1)
        {
            ClanImage2 clanImage = (ClanImage2)ClanImage2.vClanImage.elementAt(lastSelect);
            if (clanImage.idImage != null)
            {
                Char2.myCharz().paintBag(g, clanImage.idImage, GameCanvas2.w / 2, y + 45, 1, isPaintChar: false);
            }
        }
        Char2.myCharz().paintCharBody(g, GameCanvas2.w / 2, y + 45, 1, Char2.myCharz().cf, isPaintBag: false);
        g.setClip(x, y + disStart, w, h - disStart - 10);
        if (scrMain != null)
        {
            g.translate(0, -scrMain.cmy);
        }
        for (int i = 0; i < nItem; i++)
        {
            int num = x + 10;
            int num2 = y + i * WIDTH + disStart;
            if (num2 + WIDTH - ((scrMain != null) ? scrMain.cmy : 0) >= y + disStart && num2 - ((scrMain != null) ? scrMain.cmy : 0) <= y + disStart + h)
            {
                ClanImage2 clanImage2 = (ClanImage2)ClanImage2.vClanImage.elementAt(i);
                mFont2 mFont2 = mFont2.tahoma_7_grey;
                if (i == lastSelect)
                {
                    mFont2 = mFont2.tahoma_7_blue;
                }
                if (clanImage2.name != null)
                {
                    mFont2.drawString(g, clanImage2.name, num + 20, num2, 0);
                }
                if (clanImage2.xu > 0)
                {
                    mFont2.drawString(g, clanImage2.xu + " " + mResources2.XU, num + w - 20, num2, mFont2.RIGHT);
                }
                else if (clanImage2.luong > 0)
                {
                    mFont2.drawString(g, clanImage2.luong + " " + mResources2.LUONG, num + w - 20, num2, mFont2.RIGHT);
                }
                if (clanImage2.idImage != null)
                {
                    SmallImage2.drawSmallImage(g, clanImage2.idImage[0], num, num2, 0, 0);
                }
            }
        }
        g.translate(0, -g.getTranslateY());
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        GameCanvas2.paintz.paintCmdBar(g, left, center, right);
    }

    public void paint(mGraphics2 g)
    {
        if (!isRequest)
        {
            paintIcon(g);
        }
        else
        {
            paintPeans(g);
        }
    }

    public void update()
    {
        if (scrMain != null)
        {
            scrMain.updatecm();
        }
        if (cmx != cmtoX)
        {
            cmvx = cmtoX - cmx << 2;
            cmdx += cmvx;
            cmx += cmdx >> 3;
            cmdx &= 15;
        }
        if (Math2.abs(cmtoX - cmx) < 10)
        {
            cmx = cmtoX;
        }
        if (cmx >= x + w - 10 && cmtoX >= x + w - 10)
        {
            isShow = false;
        }
    }

    public void updateKey()
    {
        if (left != null && (GameCanvas2.keyPressed[12] || mScreen2.getCmdPointerLast(left)))
        {
            left.performAction();
        }
        if (right != null && (GameCanvas2.keyPressed[13] || mScreen2.getCmdPointerLast(right)))
        {
            right.performAction();
        }
        if (center != null && (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25] || mScreen2.getCmdPointerLast(center)))
        {
            center.performAction();
        }
        if (!isGetName)
        {
            if (scrMain == null)
            {
                return;
            }
            if (GameCanvas2.isTouch)
            {
                scrMain.updateKey();
                select = scrMain.selectedItem;
            }
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
            {
                GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] = false;
                select--;
                if (select < 0)
                {
                    select = nItem - 1;
                }
                scrMain.moveTo(select * scrMain.ITEM_SIZE);
            }
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22])
            {
                GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] = false;
                select++;
                if (select > nItem - 1)
                {
                    select = 0;
                }
                scrMain.moveTo(select * scrMain.ITEM_SIZE);
            }
            if (select != -1)
            {
                lastSelect = select;
            }
        }
        GameCanvas2.clearKeyHold();
        GameCanvas2.clearKeyPressed();
    }

    public void perform(int idAction, object p)
    {
        if (idAction == 2)
        {
            hide();
        }
        if (idAction != 1 || isGetName)
        {
            return;
        }
        if (!isRequest)
        {
            if (lastSelect >= 0)
            {
                hide();
                if (Char2.myCharz().clan == null)
                {
                    Service2.gI().getClan(2, (sbyte)((ClanImage2)ClanImage2.vClanImage.elementAt(lastSelect)).ID, text);
                }
                else
                {
                    Service2.gI().getClan(4, (sbyte)((ClanImage2)ClanImage2.vClanImage.elementAt(lastSelect)).ID, string.Empty);
                }
            }
        }
        else if (lastSelect >= 0)
        {
            Item2 item = (Item2)vItems.elementAt(select);
        }
    }
}
