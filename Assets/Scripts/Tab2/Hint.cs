using System;

public class Hint2
{
    public static int x;

    public static int y;

    public static int type;

    public static int t;

    public static int xF;

    public static int yF;

    public static bool isShow;

    public static bool activeClick;

    public static bool isViewMap;

    public static bool isCloseMap;

    public static bool isViewPotential;

    public static bool isPaint;

    public static bool isCamera;

    public static int trans;

    public static bool paintFlare;

    public static bool isPaintArrow;

    public static bool isOnTask(int tastId, int index)
    {
        if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId == tastId && Char2.myCharz().taskMaint.index == index)
        {
            return true;
        }
        return false;
    }

    public static bool isPaintz()
    {
        if (isOnTask(0, 3) && GameCanvas2.panel.currentTabIndex == 0 && (GameCanvas2.panel.cmy < 0 || GameCanvas2.panel.cmy > 30))
        {
            return false;
        }
        if (isOnTask(2, 0) && GameCanvas2.panel.isShow && GameCanvas2.panel.currentTabIndex != 0)
        {
            return false;
        }
        return true;
    }

    public static void clickNpc()
    {
        if (GameCanvas2.panel.isShow)
        {
            isPaint = false;
        }
        if (GameScr2.getNpcTask() != null)
        {
            x = GameScr2.getNpcTask().cx;
            y = GameScr2.getNpcTask().cy;
            trans = 0;
            isCamera = true;
            type = (GameCanvas2.isTouch ? 1 : 0);
        }
    }

    public static void nextMap(int index)
    {
        if (!GameCanvas2.panel.isShow && PopUp2.vPopups.size() - 1 >= index)
        {
            PopUp2 popUp = (PopUp2)PopUp2.vPopups.elementAt(index);
            x = popUp.cx + popUp.sayWidth / 2;
            y = popUp.cy + 30;
            if (popUp.isHide || !popUp.isPaint)
            {
                isPaint = false;
            }
            else
            {
                isPaint = true;
            }
            type = 0;
            isCamera = true;
            trans = 0;
            if (!GameCanvas2.isTouch)
            {
                isPaint = false;
            }
        }
    }

    public static void clickMob()
    {
        type = 1;
        if (GameCanvas2.panel.isShow)
        {
            isPaint = false;
        }
        bool flag = false;
        for (int i = 0; i < GameScr2.vMob.size(); i++)
        {
            Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
            if (mob.isHintFocus)
            {
                flag = true;
                break;
            }
        }
        for (int j = 0; j < GameScr2.vMob.size(); j++)
        {
            Mob2 mob2 = (Mob2)GameScr2.vMob.elementAt(j);
            if (mob2.isHintFocus)
            {
                x = mob2.x;
                y = mob2.y + 5;
                isCamera = true;
                if (mob2.status == 0)
                {
                    mob2.isHintFocus = false;
                }
                break;
            }
            if (!flag)
            {
                if (mob2.status != 0)
                {
                    mob2.isHintFocus = true;
                    break;
                }
                mob2.isHintFocus = false;
            }
        }
    }

    public static bool isHaveItem()
    {
        if (GameCanvas2.panel.isShow)
        {
            isPaint = false;
        }
        for (int i = 0; i < GameScr2.vItemMap.size(); i++)
        {
            ItemMap2 itemMap = (ItemMap2)GameScr2.vItemMap.elementAt(i);
            if (itemMap.playerId == Char2.myCharz().charID && itemMap.template.id == 73)
            {
                type = 1;
                x = itemMap.x;
                y = itemMap.y + 5;
                isCamera = true;
                return true;
            }
        }
        return false;
    }

    public static void paintArrowPointToHint(mGraphics2 g)
    {
        try
        {
            if (!isPaintArrow || (x > GameScr2.cmx && x < GameScr2.cmx + GameScr2.gW && y > GameScr2.cmy && y < GameScr2.cmy + GameScr2.gH) || GameCanvas2.gameTick % 10 < 5 || ChatPopup2.currChatPopup != null || ChatPopup2.serverChatPopUp != null || GameCanvas2.panel.isShow || !isCamera)
            {
                return;
            }
            int num = x - Char2.myCharz().cx;
            int num2 = y - Char2.myCharz().cy;
            int num3 = 0;
            int num4 = 0;
            int arg = 0;
            if (num > 0 && num2 >= 0)
            {
                if (Res2.abs(num) >= Res2.abs(num2))
                {
                    num3 = GameScr2.gW - 10;
                    num4 = GameScr2.gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        num4 = GameScr2.gH / 2 + 10;
                    }
                    arg = 0;
                }
                else
                {
                    num3 = GameScr2.gW / 2;
                    num4 = GameScr2.gH - 10;
                    arg = 5;
                }
            }
            else if (num >= 0 && num2 < 0)
            {
                if (Res2.abs(num) >= Res2.abs(num2))
                {
                    num3 = GameScr2.gW - 10;
                    num4 = GameScr2.gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        num4 = GameScr2.gH / 2 + 10;
                    }
                    arg = 0;
                }
                else
                {
                    num3 = GameScr2.gW / 2;
                    num4 = 10;
                    arg = 6;
                }
            }
            if (num < 0 && num2 >= 0)
            {
                if (Res2.abs(num) >= Res2.abs(num2))
                {
                    num3 = 10;
                    num4 = GameScr2.gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        num4 = GameScr2.gH / 2 + 10;
                    }
                    arg = 3;
                }
                else
                {
                    num3 = GameScr2.gW / 2;
                    num4 = GameScr2.gH - 10;
                    arg = 5;
                }
            }
            else if (num <= 0 && num2 < 0)
            {
                if (Res2.abs(num) >= Res2.abs(num2))
                {
                    num3 = 10;
                    num4 = GameScr2.gH / 2 + 30;
                    if (GameCanvas2.isTouch)
                    {
                        num4 = GameScr2.gH / 2 + 10;
                    }
                    arg = 3;
                }
                else
                {
                    num3 = GameScr2.gW / 2;
                    num4 = 10;
                    arg = 6;
                }
            }
            GameScr2.resetTranslate(g);
            g.drawRegion(GameScr2.arrow, 0, 0, 13, 16, arg, num3, num4, StaticObj2.VCENTER_HCENTER);
        }
        catch (Exception)
        {
        }
    }

    public static void paint(mGraphics2 g)
    {
        if (ChatPopup2.serverChatPopUp != null || Char2.myCharz().isUsePlane || Char2.myCharz().isTeleport)
        {
            return;
        }
        paintArrowPointToHint(g);
        if (GameCanvas2.menu.tDelay == 0 && isPaint && ChatPopup2.scr == null && !Char2.ischangingMap && GameCanvas2.currentScreen == GameScr2.gI() && (!GameCanvas2.panel.isShow || GameCanvas2.panel.cmx == 0))
        {
            if (isCamera)
            {
                g.translate(-GameScr2.cmx, -GameScr2.cmy);
            }
            if (trans == 0)
            {
                g.drawImage(Panel2.imgBantay, x - 15, y, 0);
            }
            if (trans == 1)
            {
                g.drawRegion(Panel2.imgBantay, 0, 0, 14, 16, 2, x + 15, y, StaticObj2.TOP_RIGHT);
            }
            if (paintFlare)
            {
                g.drawImage(ItemMap2.imageFlare, x, y, 3);
            }
        }
    }

    public static void hint()
    {
        if (Char2.myCharz().taskMaint != null && GameCanvas2.currentScreen == GameScr2.instance)
        {
            int taskId = Char2.myCharz().taskMaint.taskId;
            int index = Char2.myCharz().taskMaint.index;
            isCamera = false;
            trans = 0;
            type = 0;
            isPaint = true;
            isPaintArrow = true;
            if (GameCanvas2.menu.showMenu && taskId > 0)
            {
                isPaint = false;
            }
            switch (taskId)
            {
                case 0:
                    if (ChatPopup2.currChatPopup != null || Char2.myCharz().statusMe == 14)
                    {
                        x = GameCanvas2.w / 2;
                        y = GameCanvas2.h - 15;
                        return;
                    }
                    if (index == 0 && TileMap2.vGo.size() != 0)
                    {
                        x = ((Waypoint2)TileMap2.vGo.elementAt(0)).minX - 100;
                        y = ((Waypoint2)TileMap2.vGo.elementAt(0)).minY + 40;
                        isCamera = true;
                    }
                    if (index == 1)
                    {
                        nextMap(0);
                    }
                    if (index == 2)
                    {
                        clickNpc();
                    }
                    if (index == 3)
                    {
                        if (!GameCanvas2.panel.isShow)
                        {
                            clickNpc();
                        }
                        else if (GameCanvas2.panel.currentTabIndex == 0)
                        {
                            if (GameCanvas2.panel.cp == null)
                            {
                                x = GameCanvas2.panel.xScroll + GameCanvas2.panel.wScroll / 2;
                                y = GameCanvas2.panel.yScroll + 20;
                            }
                            else if (GameCanvas2.menu.tDelay != 0)
                            {
                                x = GameCanvas2.panel.xScroll + 25;
                                y = GameCanvas2.panel.yScroll + 60;
                            }
                        }
                        else if (GameCanvas2.panel.currentTabIndex == 1)
                        {
                            x = GameCanvas2.panel.startTabPos + 10;
                            y = 65;
                        }
                    }
                    if (index == 4)
                    {
                        if (GameCanvas2.panel.isShow)
                        {
                            x = GameCanvas2.panel.cmdClose.x + 5;
                            y = GameCanvas2.panel.cmdClose.y + 5;
                        }
                        else if (GameCanvas2.menu.showMenu)
                        {
                            x = GameCanvas2.w / 2;
                            y = GameCanvas2.h - 20;
                        }
                        else
                        {
                            clickNpc();
                        }
                    }
                    if (index == 5)
                    {
                        clickNpc();
                    }
                    return;
                case 1:
                    if (ChatPopup2.currChatPopup != null || Char2.myCharz().statusMe == 14)
                    {
                        x = GameCanvas2.w / 2;
                        y = GameCanvas2.h - 15;
                        return;
                    }
                    if (index == 0)
                    {
                        if (TileMap2.isOfflineMap())
                        {
                            nextMap(0);
                        }
                        else
                        {
                            clickMob();
                        }
                    }
                    if (index == 1)
                    {
                        if (!TileMap2.isOfflineMap())
                        {
                            nextMap(1);
                        }
                        else
                        {
                            clickNpc();
                        }
                    }
                    return;
                case 2:
                    if (ChatPopup2.currChatPopup != null || Char2.myCharz().statusMe == 14)
                    {
                        x = GameCanvas2.w / 2;
                        y = GameCanvas2.h - 15;
                        return;
                    }
                    if (index == 0)
                    {
                        if (!TileMap2.isOfflineMap())
                        {
                            isViewMap = true;
                        }
                        if (!GameCanvas2.panel.isShow)
                        {
                            if (!isViewMap)
                            {
                                x = GameScr2.gI().cmdMenu.x;
                                y = GameScr2.gI().cmdMenu.y + 13;
                                trans = 1;
                            }
                            else
                            {
                                if (GameScr2.getTaskMapId() == TileMap2.mapID)
                                {
                                    if (!isHaveItem())
                                    {
                                        clickMob();
                                    }
                                }
                                else
                                {
                                    nextMap(0);
                                }
                                if (isViewMap)
                                {
                                    isCloseMap = true;
                                }
                            }
                        }
                        else if (!isViewMap)
                        {
                            if (GameCanvas2.panel.currentTabIndex == 0)
                            {
                                int num = ((GameCanvas2.h <= 300) ? 10 : 15);
                                x = GameCanvas2.panel.xScroll + GameCanvas2.panel.wScroll / 2;
                                y = GameCanvas2.panel.yScroll + GameCanvas2.panel.hScroll - num;
                            }
                            else
                            {
                                x = GameCanvas2.panel.startTabPos + 10;
                                y = 65;
                            }
                        }
                        else if (!isCloseMap)
                        {
                            x = GameCanvas2.panel.cmdClose.x + 5;
                            y = GameCanvas2.panel.cmdClose.y + 5;
                        }
                        else
                        {
                            isPaint = false;
                        }
                        if (Char2.myCharz().cMP <= 0)
                        {
                            x = GameScr2.xHP + 5;
                            y = GameScr2.yHP + 13;
                            isCamera = false;
                        }
                    }
                    if (index == 1)
                    {
                        isPaint = false;
                        isPaintArrow = false;
                    }
                    return;
                case 3:
                    if (ChatPopup2.currChatPopup != null || Char2.myCharz().statusMe == 14)
                    {
                        x = GameCanvas2.w / 2;
                        y = GameCanvas2.h - 15;
                    }
                    else if (index == 0)
                    {
                        if (!GameCanvas2.panel.isShow)
                        {
                            if (!isViewPotential)
                            {
                                x = GameScr2.gI().cmdMenu.x;
                                y = GameScr2.gI().cmdMenu.y + 13;
                                trans = 1;
                            }
                            else
                            {
                                if (GameScr2.getTaskMapId() == TileMap2.mapID)
                                {
                                    if (!isHaveItem())
                                    {
                                        clickMob();
                                    }
                                }
                                else
                                {
                                    nextMap(0);
                                }
                                if (isViewMap)
                                {
                                    isCloseMap = true;
                                }
                            }
                        }
                        else if (!isViewPotential)
                        {
                            int num2 = ((GameCanvas2.h <= 300) ? 10 : 15);
                            x = GameCanvas2.panel.xScroll + 10 + 108 - 18;
                            y = 65;
                        }
                        else if (!isCloseMap)
                        {
                            x = GameCanvas2.panel.cmdClose.x + 5;
                            y = GameCanvas2.panel.cmdClose.y + 5;
                        }
                        else
                        {
                            isPaint = false;
                        }
                        if (Char2.myCharz().cMP <= 0)
                        {
                            x = GameScr2.xHP + 5;
                            y = GameScr2.yHP + 13;
                            isCamera = false;
                        }
                    }
                    else
                    {
                        isPaint = false;
                        isPaintArrow = false;
                    }
                    return;
            }
            if (Char2.myCharz().taskMaint.taskId == 9 && Char2.myCharz().taskMaint.index == 2)
            {
                for (int i = 0; i < PopUp2.vPopups.size(); i++)
                {
                    PopUp2 popUp = (PopUp2)PopUp2.vPopups.elementAt(i);
                    if (popUp.cy <= 24)
                    {
                        x = popUp.cx + popUp.sayWidth / 2;
                        y = popUp.cy + 30;
                        isCamera = true;
                        isPaint = false;
                        isPaintArrow = true;
                        return;
                    }
                }
            }
            isPaint = false;
            isPaintArrow = false;
        }
        else
        {
            isPaint = false;
            isPaintArrow = false;
        }
    }

    public static void update()
    {
        hint();
        int num = ((trans != 0) ? (-2) : 2);
        if (!activeClick)
        {
            paintFlare = false;
            t++;
            if (t == 50)
            {
                t = 0;
                activeClick = true;
            }
            return;
        }
        t++;
        if (type == 0)
        {
            if (t == 2)
            {
                x += 2 * num;
                y -= 4;
                paintFlare = true;
            }
            if (t == 4)
            {
                x -= 2 * num;
                y += 4;
                activeClick = false;
                paintFlare = false;
                t = 0;
            }
            if (t > 4)
            {
                activeClick = false;
            }
        }
        if (type != 1)
        {
            return;
        }
        if (t == 2)
        {
            if (GameCanvas2.isTouch)
            {
                GameScr2.startFlyText(mResources2.press_twice, x, y + 10, 0, 20, mFont2.MISS_ME);
            }
            paintFlare = true;
            x += 2 * num;
            y -= 4;
        }
        if (t == 4)
        {
            paintFlare = false;
            x -= num;
            y += 2;
        }
        if (t == 6)
        {
            paintFlare = true;
            x += num;
            y -= 2;
        }
        if (t == 8)
        {
            paintFlare = false;
            x -= num;
            y += 2;
        }
        if (t == 10)
        {
            x -= num;
            y += 2;
            activeClick = false;
            t = 0;
        }
    }
}
