public class Menu2
{
    public bool showMenu;

    public MyVector2 menuItems;

    public int menuSelectedItem;

    public int menuX;

    public int menuY;

    public int menuW;

    public int menuH;

    public static int[] menuTemY;

    public static int cmtoX;

    public static int cmx;

    public static int cmdy;

    public static int cmvy;

    public static int cmxLim;

    public static int xc;

    private Command2 left = new Command2(mResources2.SELECT, 0);

    private Command2 right = new Command2(mResources2.CLOSE, 0, GameCanvas2.w - 71, GameCanvas2.h - mScreen2.cmdH + 1);

    private Command2 center;

    public static Image2 imgMenu1;

    public static Image2 imgMenu2;

    private bool disableClose;

    public int tDelay;

    public int w;

    private int pa;

    private bool trans;

    private int pointerDownTime;

    private int pointerDownFirstX;

    private int[] pointerDownLastX = new int[3];

    private bool pointerIsDowning;

    private bool isDownWhenRunning;

    private int waitToPerform;

    private int cmRun;

    private bool touch;

    private bool close;

    private int cmvx;

    private int cmdx;

    private bool isClose;

    public bool[] isNotClose;

    public static void loadBg()
    {
        imgMenu1 = GameCanvas2.loadImage("/mainImage/myTexture2dbtMenu1.png");
        imgMenu2 = GameCanvas2.loadImage("/mainImage/myTexture2dbtMenu2.png");
    }

    public void startWithoutCloseButton(MyVector2 menuItems, int pos)
    {
        startAt(menuItems, pos);
        disableClose = true;
    }

    public void startAt(MyVector2 menuItems, int x, int y)
    {
        startAt(menuItems, 0);
        menuX = x;
        menuY = y;
        while (menuY + menuH > GameCanvas2.h)
        {
            menuY -= 2;
        }
    }

    public void startAt(MyVector2 menuItems, int pos)
    {
        if (showMenu)
        {
            return;
        }
        isClose = false;
        touch = false;
        close = false;
        tDelay = 0;
        if (menuItems.size() == 1)
        {
            menuSelectedItem = 0;
            Command2 command = (Command2)menuItems.elementAt(0);
            if (command != null && command.caption.Equals(mResources2.saying))
            {
                command.performAction();
                showMenu = false;
                InfoDlg2.showWait();
                return;
            }
        }
        SoundMn2.gI().openMenu();
        isNotClose = new bool[menuItems.size()];
        for (int i = 0; i < isNotClose.Length; i++)
        {
            isNotClose[i] = false;
        }
        disableClose = false;
        ChatPopup2.currChatPopup = null;
        Effect2_2.vEffect2.removeAllElements();
        Effect2_2.vEffect2Outside.removeAllElements();
        InfoDlg2.hide();
        if (menuItems.size() != 0)
        {
            this.menuItems = menuItems;
            menuW = 60;
            menuH = 60;
            for (int j = 0; j < menuItems.size(); j++)
            {
                Command2 command2 = (Command2)menuItems.elementAt(j);
                command2.isPlaySoundButton = false;
                int width = mFont2.tahoma_7_yellow.getWidth(command2.caption);
                command2.subCaption = mFont2.tahoma_7_yellow.splitFontArray(command2.caption, menuW - 10);
            }
            menuTemY = new int[menuItems.size()];
            menuX = (GameCanvas2.w - menuItems.size() * menuW) / 2;
            if (menuX < 1)
            {
                menuX = 1;
            }
            menuY = GameCanvas2.h - menuH - (Paint2.hTab + 1) - 1;
            if (GameCanvas2.isTouch)
            {
                menuY -= 3;
            }
            menuY += 27;
            for (int k = 0; k < menuTemY.Length; k++)
            {
                menuTemY[k] = GameCanvas2.h;
            }
            showMenu = true;
            menuSelectedItem = 0;
            cmxLim = this.menuItems.size() * menuW - GameCanvas2.w;
            if (cmxLim < 0)
            {
                cmxLim = 0;
            }
            cmtoX = 0;
            cmx = 0;
            xc = 50;
            w = menuItems.size() * menuW - 1;
            if (w > GameCanvas2.w - 2)
            {
                w = GameCanvas2.w - 2;
            }
            if (GameCanvas2.isTouch && !Main2.isPC)
            {
                menuSelectedItem = -1;
            }
        }
    }

    public bool isScrolling()
    {
        if ((!isClose && menuTemY[menuTemY.Length - 1] > menuY) || (isClose && menuTemY[menuTemY.Length - 1] < GameCanvas2.h))
        {
            return true;
        }
        return false;
    }

    public void updateMenuKey()
    {
        if ((GameScr2.gI().activeRongThan && GameScr2.gI().isUseFreez) || !showMenu || isScrolling())
        {
            return;
        }
        bool flag = false;
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21] || GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
        {
            flag = true;
            menuSelectedItem--;
            if (menuSelectedItem < 0)
            {
                menuSelectedItem = menuItems.size() - 1;
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] || GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
        {
            flag = true;
            menuSelectedItem++;
            if (menuSelectedItem > menuItems.size() - 1)
            {
                menuSelectedItem = 0;
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 5 : 25])
        {
            if (center != null)
            {
                if (center.idAction > 0)
                {
                    if (center.actionListener == GameScr2.gI())
                    {
                        GameScr2.gI().actionPerform(center.idAction, center.p);
                    }
                    else
                    {
                        perform(center.idAction, center.p);
                    }
                }
            }
            else
            {
                waitToPerform = 2;
            }
        }
        else if (GameCanvas2.keyPressed[12] && !GameScr2.gI().isRongThanMenu())
        {
            if (isScrolling())
            {
                return;
            }
            if (left.idAction > 0)
            {
                perform(left.idAction, left.p);
            }
            else
            {
                waitToPerform = 2;
            }
            SoundMn2.gI().buttonClose();
        }
        else if (!GameScr2.gI().isRongThanMenu() && !disableClose && (GameCanvas2.keyPressed[13] || mScreen2.getCmdPointerLast(right)))
        {
            if (isScrolling())
            {
                return;
            }
            if (!close)
            {
                close = true;
            }
            isClose = true;
            SoundMn2.gI().buttonClose();
        }
        if (flag)
        {
            cmtoX = menuSelectedItem * menuW + menuW - GameCanvas2.w / 2;
            if (cmtoX > cmxLim)
            {
                cmtoX = cmxLim;
            }
            if (cmtoX < 0)
            {
                cmtoX = 0;
            }
            if (menuSelectedItem == menuItems.size() - 1 || menuSelectedItem == 0)
            {
                cmx = cmtoX;
            }
        }
        bool flag2 = true;
        if (GameCanvas2.panel.cp != null && GameCanvas2.panel.cp.isClip)
        {
            if (!GameCanvas2.isPointerHoldIn(GameCanvas2.panel.cp.cx, 0, GameCanvas2.panel.cp.sayWidth + 2, GameCanvas2.panel.cp.ch))
            {
                flag2 = true;
            }
            else
            {
                flag2 = false;
                GameCanvas2.panel.cp.updateKey();
            }
        }
        if (!disableClose && GameCanvas2.isPointerJustRelease && !GameCanvas2.isPointer(menuX, menuY, w, menuH) && !pointerIsDowning && !GameScr2.gI().isRongThanMenu() && flag2)
        {
            if (!isScrolling())
            {
                pointerDownTime = (pointerDownFirstX = 0);
                pointerIsDowning = false;
                GameCanvas2.clearAllPointerEvent();
                Res2.outz("menu select= " + menuSelectedItem);
                isClose = true;
                close = true;
                SoundMn2.gI().buttonClose();
            }
            return;
        }
        if (GameCanvas2.isPointerDown)
        {
            if (!pointerIsDowning && GameCanvas2.isPointer(menuX, menuY, w, menuH))
            {
                for (int i = 0; i < pointerDownLastX.Length; i++)
                {
                    pointerDownLastX[0] = GameCanvas2.px;
                }
                pointerDownFirstX = GameCanvas2.px;
                pointerIsDowning = true;
                isDownWhenRunning = cmRun != 0;
                cmRun = 0;
            }
            else if (pointerIsDowning)
            {
                pointerDownTime++;
                if (pointerDownTime > 5 && pointerDownFirstX == GameCanvas2.px && !isDownWhenRunning)
                {
                    pointerDownFirstX = -1000;
                    menuSelectedItem = (cmtoX + GameCanvas2.px - menuX) / menuW;
                }
                int num = GameCanvas2.px - pointerDownLastX[0];
                if (num != 0 && menuSelectedItem != -1)
                {
                    menuSelectedItem = -1;
                }
                for (int num2 = pointerDownLastX.Length - 1; num2 > 0; num2--)
                {
                    pointerDownLastX[num2] = pointerDownLastX[num2 - 1];
                }
                pointerDownLastX[0] = GameCanvas2.px;
                cmtoX -= num;
                if (cmtoX < 0)
                {
                    cmtoX = 0;
                }
                if (cmtoX > cmxLim)
                {
                    cmtoX = cmxLim;
                }
                if (cmx < 0 || cmx > cmxLim)
                {
                    num /= 2;
                }
                cmx -= num;
                if (cmx < -(GameCanvas2.h / 3))
                {
                }
                else
                {
                }
            }
        }
        if (GameCanvas2.isPointerJustRelease && pointerIsDowning)
        {
            int i2 = GameCanvas2.px - pointerDownLastX[0];
            GameCanvas2.isPointerJustRelease = false;
            if (Res2.abs(i2) < 20 && Res2.abs(GameCanvas2.px - pointerDownFirstX) < 20 && !isDownWhenRunning)
            {
                cmRun = 0;
                cmtoX = cmx;
                pointerDownFirstX = -1000;
                menuSelectedItem = (cmtoX + GameCanvas2.px - menuX) / menuW;
                pointerDownTime = 0;
                waitToPerform = 10;
            }
            else if (menuSelectedItem != -1 && pointerDownTime > 5)
            {
                pointerDownTime = 0;
                waitToPerform = 1;
            }
            else if (menuSelectedItem == -1 && !isDownWhenRunning)
            {
                if (cmx < 0)
                {
                    cmtoX = 0;
                }
                else if (cmx > cmxLim)
                {
                    cmtoX = cmxLim;
                }
                else
                {
                    int num3 = GameCanvas2.px - pointerDownLastX[0] + (pointerDownLastX[0] - pointerDownLastX[1]) + (pointerDownLastX[1] - pointerDownLastX[2]);
                    num3 = ((num3 > 10) ? 10 : ((num3 < -10) ? (-10) : 0));
                    cmRun = -num3 * 100;
                }
            }
            pointerIsDowning = false;
            pointerDownTime = 0;
            GameCanvas2.isPointerJustRelease = false;
        }
        GameCanvas2.clearKeyPressed();
        GameCanvas2.clearKeyHold();
    }

    public void moveCamera()
    {
        if (cmRun != 0 && !pointerIsDowning)
        {
            cmtoX += cmRun / 100;
            if (cmtoX < 0)
            {
                cmtoX = 0;
            }
            else if (cmtoX > cmxLim)
            {
                cmtoX = cmxLim;
            }
            else
            {
                cmx = cmtoX;
            }
            cmRun = cmRun * 9 / 10;
            if (cmRun < 100 && cmRun > -100)
            {
                cmRun = 0;
            }
        }
        if (cmx != cmtoX && !pointerIsDowning)
        {
            cmvx = cmtoX - cmx << 2;
            cmdx += cmvx;
            cmx += cmdx >> 4;
            cmdx &= 15;
        }
    }

    public void paintMenu(mGraphics2 g)
    {
        if (GameScr2.gI().activeRongThan && GameScr2.gI().isUseFreez)
        {
            return;
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());
        g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        g.translate(-cmx, 0);
        for (int i = 0; i < menuItems.size(); i++)
        {
            if (i == menuSelectedItem)
            {
                g.drawImage(imgMenu2, menuX + i * menuW + 1, menuTemY[i], 0);
            }
            else
            {
                g.drawImage(imgMenu1, menuX + i * menuW + 1, menuTemY[i], 0);
            }
            Command2 command = (Command2)menuItems.elementAt(i);
            string[] array = command.subCaption;
            if (array == null)
            {
                array = new string[1] { ((Command2)menuItems.elementAt(i)).caption };
            }
            int num = menuTemY[i] + (menuH - array.Length * 14) / 2 + 1;
            for (int j = 0; j < array.Length; j++)
            {
                if (i == menuSelectedItem)
                {
                    mFont2.tahoma_7b_green2.drawString(g, array[j], menuX + i * menuW + menuW / 2, num + j * 14, 2);
                }
                else if (command.isDisplay)
                {
                    mFont2.tahoma_7b_red.drawString(g, array[j], menuX + i * menuW + menuW / 2, num + j * 14, 2);
                }
                else
                {
                    mFont2.tahoma_7b_dark.drawString(g, array[j], menuX + i * menuW + menuW / 2, num + j * 14, 2);
                }
            }
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());
    }

    public void doCloseMenu()
    {
        isClose = false;
        showMenu = false;
        InfoDlg2.hide();
        if (close)
        {
            GameCanvas2.panel.cp = null;
            Char2.chatPopup = null;
            if (GameCanvas2.panel2 != null && GameCanvas2.panel2.cp != null)
            {
                GameCanvas2.panel2.cp = null;
            }
        }
        else
        {
            if (!touch)
            {
                return;
            }
            GameCanvas2.panel.cp = null;
            if (GameCanvas2.panel2 != null && GameCanvas2.panel2.cp != null)
            {
                GameCanvas2.panel2.cp = null;
            }
            if (menuSelectedItem >= 0)
            {
                Command2 command = (Command2)menuItems.elementAt(menuSelectedItem);
                if (command != null)
                {
                    SoundMn2.gI().buttonClose();
                    command.performAction();
                }
            }
        }
    }

    public void performSelect()
    {
        InfoDlg2.hide();
        if (menuSelectedItem >= 0)
        {
            ((Command2)menuItems.elementAt(menuSelectedItem))?.performAction();
        }
    }

    public void updateMenu()
    {
        moveCamera();
        if (!isClose)
        {
            tDelay++;
            for (int i = 0; i < menuTemY.Length; i++)
            {
                if (menuTemY[i] > menuY)
                {
                    int num = menuTemY[i] - menuY >> 1;
                    if (num < 1)
                    {
                        num = 1;
                    }
                    if (tDelay > i)
                    {
                        menuTemY[i] -= num;
                    }
                }
            }
            if (menuTemY[menuTemY.Length - 1] <= menuY)
            {
                tDelay = 0;
            }
        }
        else
        {
            tDelay++;
            for (int j = 0; j < menuTemY.Length; j++)
            {
                if (menuTemY[j] < GameCanvas2.h)
                {
                    int num2 = (GameCanvas2.h - menuTemY[j] >> 1) + 2;
                    if (num2 < 1)
                    {
                        num2 = 1;
                    }
                    if (tDelay > j)
                    {
                        menuTemY[j] += num2;
                    }
                }
            }
            if (menuTemY[menuTemY.Length - 1] >= GameCanvas2.h)
            {
                tDelay = 0;
                doCloseMenu();
            }
        }
        if (xc != 0)
        {
            xc >>= 1;
            if (xc < 0)
            {
                xc = 0;
            }
        }
        if (isScrolling() || waitToPerform <= 0)
        {
            return;
        }
        waitToPerform--;
        if (waitToPerform == 0)
        {
            if (menuSelectedItem >= 0 && !isNotClose[menuSelectedItem])
            {
                isClose = true;
                touch = true;
                GameCanvas2.panel.cp = null;
            }
            else
            {
                performSelect();
            }
        }
    }

    public void perform(int idAction, object p)
    {
    }
}
