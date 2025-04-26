public class Npc2 : Char2
{
    public const sbyte BINH_KHI = 0;

    public const sbyte PHONG_CU = 1;

    public const sbyte TRANG_SUC = 2;

    public const sbyte DUOC_PHAM = 3;

    public const sbyte TAP_HOA = 4;

    public const sbyte THU_KHO = 5;

    public const sbyte DA_LUYEN = 6;

    public NpcTemplate2 template;

    public int npcId;

    public bool isFocus = true;

    public static NpcTemplate2[] arrNpcTemplate;

    public int sys;

    public new bool isHide;

    private int duaHauIndex;

    private int dyEff;

    public static bool mabuEff;

    public static int tMabuEff;

    private static int[] shock_x = new int[4] { 1, -1, 1, -1 };

    private static int[] shock_y = new int[4] { 1, -1, -1, 1 };

    public static int shock_scr;

    public int[] duahau;

    public new int seconds;

    public new long last;

    public new long cur;

    public int idItem;

    public short idAura = -1;

    public Npc2(int npcId, int status, int cx, int cy, int templateId, int avatar)
    {
        isShadown = true;
        this.npcId = npcId;
        base.avatar = avatar;
        base.cx = cx;
        base.cy = cy;
        xSd = cx;
        ySd = cy;
        statusMe = status;
        if (npcId != -1)
        {
            template = arrNpcTemplate[templateId];
        }
        if (templateId == 23 || templateId == 42)
        {
            ch = 45;
        }
        if (templateId == 51)
        {
            isShadown = false;
            duaHauIndex = status;
        }
        if (template != null)
        {
            if (template.name == null)
            {
                template.name = string.Empty;
            }
            template.name = Res2.changeString(template.name);
        }
    }

    public void setStatus(sbyte s, int sc)
    {
        duaHauIndex = s;
        last = (cur = mSystem2.currentTimeMillis());
        seconds = sc;
    }

    public static void clearEffTask()
    {
        for (int i = 0; i < GameScr2.vNpc.size(); i++)
        {
            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
            npc.effTask = null;
            npc.indexEffTask = -1;
        }
    }

    public override void update()
    {
        if (template.npcTemplateId == 51)
        {
            cur = mSystem2.currentTimeMillis();
            if (cur - last >= 1000)
            {
                seconds--;
                last = cur;
                if (seconds < 0)
                {
                    seconds = 0;
                }
            }
        }
        if (isShadown)
        {
            updateShadown();
        }
        if (effTask == null)
        {
            sbyte[] array = new sbyte[7] { -1, 9, 9, 10, 10, 11, 11 };
            if (Char2.myCharz().ctaskId >= 9 && Char2.myCharz().ctaskId <= 10 && Char2.myCharz().nClass.classId > 0 && array[Char2.myCharz().nClass.classId] == template.npcTemplateId)
            {
                if (Char2.myCharz().taskMaint == null)
                {
                    effTask = GameScr2.efs[57];
                    indexEffTask = 0;
                }
                else if (Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.index + 1 == Char2.myCharz().taskMaint.subNames.Length)
                {
                    effTask = GameScr2.efs[62];
                    indexEffTask = 0;
                }
            }
            else
            {
                sbyte taskNpcId = GameScr2.getTaskNpcId();
                if (Char2.myCharz().taskMaint == null && taskNpcId == template.npcTemplateId)
                {
                    indexEffTask = 0;
                }
                else if (Char2.myCharz().taskMaint != null && taskNpcId == template.npcTemplateId)
                {
                    if (Char2.myCharz().taskMaint.index + 1 == Char2.myCharz().taskMaint.subNames.Length)
                    {
                        effTask = GameScr2.efs[98];
                    }
                    else
                    {
                        effTask = GameScr2.efs[98];
                    }
                    indexEffTask = 0;
                }
            }
        }
        base.update();
        if (TileMap2.mapID != 51)
        {
            return;
        }
        if (cx > Char2.myCharz().cx)
        {
            cdir = -1;
        }
        else
        {
            cdir = 1;
        }
        if (template.npcTemplateId % 2 == 0)
        {
            if (cf == 1)
            {
                cf = 0;
            }
            else
            {
                cf = 1;
            }
        }
    }

    public void paintHead(mGraphics2 g, int xStart, int yStart)
    {
        Part2 part = GameScr2.parts[template.headId];
        if (cdir == 1)
        {
            SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, GameCanvas2.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 0, 0);
        }
        else
        {
            SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, GameCanvas2.w - 31 - g.getTranslateX(), 2 - g.getTranslateY(), 2, 24);
        }
    }

    public void PaintAuraBehind(mGraphics2 g)
    {
        if (GameCanvas.lowGraphic || !isPaintAura && idAura > -1 && !GameCanvas2.panel.isShow)
        {
            string nameImg = "aura_" + idAura + "_0";
            FrameImage2 fraImage = mSystem2.getFraImage(nameImg);
            fraImage?.drawFrame(GameCanvas2.gameTick / 4 % fraImage.nFrame, cx, cy, (cdir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER, g);
        }
    }

    public void PaintAuraFront(mGraphics2 g)
    {
        if (GameCanvas.lowGraphic || !isPaintAura || idAura <= -1)
        {
            return;
        }
        if (!GameCanvas2.panel.isShow && !GameCanvas2.lowGraphic)
        {
            string nameImg = "aura_" + idAura + "_1";
            FrameImage2 fraImage = mSystem2.getFraImage(nameImg);
            fraImage?.drawFrame(GameCanvas2.gameTick / 4 % fraImage.nFrame, cx, cy + 2, (cdir != 1) ? 2 : 0, mGraphics2.BOTTOM | mGraphics2.HCENTER, g);
        }
    }

    public override void paint(mGraphics2 g)
    {
        if (Char2.isLoadingMap || isHide || !isPaint() || statusMe == 15)
        {
            return;
        }
        if (cTypePk != 0)
        {
            base.paint(g);
        }
        else
        {
            if (template == null)
            {
                return;
            }
            if (template.npcTemplateId != 4 && template.npcTemplateId != 51 && template.npcTemplateId != 50)
            {
                g.drawImage(TileMap2.bong, cx, cy, 3);
            }
            if (template.npcTemplateId == 3)
            {
                SmallImage2.drawSmallImage(g, 265, cx, cy, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this) && ChatPopup2.currChatPopup == null)
                {
                    g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, cx, cy - ch + 4, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                }
                dyEff = 60;
            }
            else if (template.npcTemplateId != 4)
            {
                if (template.npcTemplateId == 50 || template.npcTemplateId == 51)
                {
                    if (duahau != null)
                    {
                        if (template.npcTemplateId == 50 && mabuEff)
                        {
                            tMabuEff++;
                            if (GameCanvas2.gameTick % 3 == 0)
                            {
                                Effect2_ effect = new Effect2_(19, cx + Res2.random(-50, 50), cy, 2, 1, -1);
                                EffecMn2.addEff(effect);
                            }
                            if (GameCanvas2.gameTick % 15 == 0)
                            {
                                Effect2_ effect2 = new Effect2_(18, cx + Res2.random(-5, 5), cy + Res2.random(-90, 0), 2, 1, -1);
                                EffecMn2.addEff(effect2);
                            }
                            if (tMabuEff == 100)
                            {
                                GameScr2.gI().activeSuperPower(cx, cy);
                            }
                            if (tMabuEff == 110)
                            {
                                mabuEff = false;
                                template.npcTemplateId = 4;
                            }
                        }
                        int num = 0;
                        if (SmallImage2.imgNew[duahau[duaHauIndex]] != null && SmallImage2.imgNew[duahau[duaHauIndex]].img != null)
                        {
                            num = mGraphics2.getImageHeight(SmallImage2.imgNew[duahau[duaHauIndex]].img);
                        }
                        SmallImage2.drawSmallImage(g, duahau[duaHauIndex], cx + Res2.random(-1, 1), cy, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                        if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
                        {
                            if (ChatPopup2.currChatPopup == null)
                            {
                                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, cx, cy - ch - 9 + 16 - num, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                            }
                            mFont2.tahoma_7b_white.drawString(g, NinjaUtil2.getTime(seconds), cx, cy - ch - 16 - mFont2.tahoma_7.getHeight() - 20 - num + 16, mFont2.CENTER, mFont2.tahoma_7b_dark);
                        }
                        else
                        {
                            mFont2.tahoma_7b_white.drawString(g, NinjaUtil2.getTime(seconds), cx, cy - ch - 8 - mFont2.tahoma_7.getHeight() - 20 - num + 16, mFont2.CENTER, mFont2.tahoma_7b_dark);
                        }
                    }
                }
                else if (template.npcTemplateId == 6)
                {
                    SmallImage2.drawSmallImage(g, 545, cx, cy + 5, 0, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                    if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this) && ChatPopup2.currChatPopup == null)
                    {
                        g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, cx, cy - ch - 9, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                    }
                    mFont2.tahoma_7b_white.drawString(g, TileMap2.zoneID + string.Empty, cx, cy - ch + 19 - mFont2.tahoma_7.getHeight(), mFont2.CENTER);
                }
                else
                {
                    PaintAuraBehind(g);
                    PaintAuraFront(g);

                    int headId = template.headId;
                    int legId = template.legId;
                    int bodyId = template.bodyId;
                    Part2 part = GameScr2.parts[headId];
                    Part2 part2 = GameScr2.parts[legId];
                    Part2 part3 = GameScr2.parts[bodyId];
                    if (cdir == 1)
                    {
                        SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, cx + Char2.CharInfo[cf][0][1] + part.pi[Char2.CharInfo[cf][0][0]].dx, cy - Char2.CharInfo[cf][0][2] + part.pi[Char2.CharInfo[cf][0][0]].dy, 0, 0);
                        SmallImage2.drawSmallImage(g, part2.pi[Char2.CharInfo[cf][1][0]].id, cx + Char2.CharInfo[cf][1][1] + part2.pi[Char2.CharInfo[cf][1][0]].dx, cy - Char2.CharInfo[cf][1][2] + part2.pi[Char2.CharInfo[cf][1][0]].dy, 0, 0);
                        SmallImage2.drawSmallImage(g, part3.pi[Char2.CharInfo[cf][2][0]].id, cx + Char2.CharInfo[cf][2][1] + part3.pi[Char2.CharInfo[cf][2][0]].dx, cy - Char2.CharInfo[cf][2][2] + part3.pi[Char2.CharInfo[cf][2][0]].dy, 0, 0);
                    }
                    else
                    {
                        SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, cx - Char2.CharInfo[cf][0][1] - part.pi[Char2.CharInfo[cf][0][0]].dx, cy - Char2.CharInfo[cf][0][2] + part.pi[Char2.CharInfo[cf][0][0]].dy, 2, 24);
                        SmallImage2.drawSmallImage(g, part2.pi[Char2.CharInfo[cf][1][0]].id, cx - Char2.CharInfo[cf][1][1] - part2.pi[Char2.CharInfo[cf][1][0]].dx, cy - Char2.CharInfo[cf][1][2] + part2.pi[Char2.CharInfo[cf][1][0]].dy, 2, 24);
                        SmallImage2.drawSmallImage(g, part3.pi[Char2.CharInfo[cf][2][0]].id, cx - Char2.CharInfo[cf][2][1] - part3.pi[Char2.CharInfo[cf][2][0]].dx, cy - Char2.CharInfo[cf][2][2] + part3.pi[Char2.CharInfo[cf][2][0]].dy, 2, 24);
                    }
                    if (TileMap2.mapID != 51)
                    {
                        int num2 = 15;
                        if (template.npcTemplateId == 47)
                        {
                            num2 = 47;
                        }
                        if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
                        {
                            if (ChatPopup2.currChatPopup == null)
                            {
                                int num3 = 0;
                                int num4 = 0;
                                if (Char2.myCharz().npcFocus.template.npcTemplateId == 28 || Char2.myCharz().npcFocus.template.npcTemplateId == 41)
                                {
                                    num3 = 3;
                                    num4 = -12;
                                }
                                g.drawRegion(Mob2.imgHP, 0, 0, 9, 6, 0, cx + num3, cy - ch - (num2 - 8) + num4, mGraphics2.BOTTOM | mGraphics2.HCENTER);
                            }
                        }
                    }
                    dyEff = 65;
                }
            }
            if (indexEffTask < 0 || effTask == null || cTypePk != 0)
            {
                return;
            }
            SmallImage2.drawSmallImage(g, effTask.arrEfInfo[indexEffTask].idImg, cx + effTask.arrEfInfo[indexEffTask].dx, cy + effTask.arrEfInfo[indexEffTask].dy - dyEff, 0, mGraphics2.VCENTER | mGraphics2.HCENTER);
            if (GameCanvas2.gameTick % 2 == 0)
            {
                indexEffTask++;
                if (indexEffTask >= effTask.arrEfInfo.Length)
                {
                    indexEffTask = 0;
                }
            }
        }
    }

    public new void paintName(mGraphics2 g)
    {
        if (Char2.isLoadingMap || isHide || !isPaint() || statusMe == 15 || template == null)
        {
            return;
        }
        if (template.npcTemplateId == 3)
        {
            if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
            {
                mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - mFont2.tahoma_7.getHeight() - 5, mFont2.CENTER, mFont2.tahoma_7_grey);
            }
            else
            {
                mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - 3 - mFont2.tahoma_7.getHeight(), mFont2.CENTER, mFont2.tahoma_7_grey);
            }
            dyEff = 60;
        }
        else
        {
            if (template.npcTemplateId == 4)
            {
                return;
            }
            if (template.npcTemplateId == 50 || template.npcTemplateId == 51)
            {
                if (duahau != null)
                {
                    int num = 0;
                    if (SmallImage2.imgNew[duahau[duaHauIndex]] != null && SmallImage2.imgNew[duahau[duaHauIndex]].img != null)
                    {
                        num = mGraphics2.getImageHeight(SmallImage2.imgNew[duahau[duaHauIndex]].img);
                    }
                    if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
                    {
                        mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - mFont2.tahoma_7.getHeight() - num, mFont2.CENTER, mFont2.tahoma_7_grey);
                    }
                    else
                    {
                        mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - 8 - mFont2.tahoma_7.getHeight() - num + 16, mFont2.CENTER, mFont2.tahoma_7_grey);
                    }
                }
                return;
            }
            if (template.npcTemplateId == 6)
            {
                if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
                {
                    mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - mFont2.tahoma_7.getHeight() - 16, mFont2.CENTER, mFont2.tahoma_7_grey);
                }
                else
                {
                    mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx, cy - ch - 8 - mFont2.tahoma_7.getHeight(), mFont2.CENTER, mFont2.tahoma_7_grey);
                }
                return;
            }
            if (TileMap2.mapID != 51)
            {
                int num2 = 15;
                if (template.npcTemplateId == 47)
                {
                    num2 = 47;
                }
                if (Char2.myCharz().npcFocus != null && Char2.myCharz().npcFocus.Equals(this))
                {
                    if (TileMap2.mapID != 113)
                    {
                        int num3 = 0;
                        int num4 = 0;
                        if (Char2.myCharz().npcFocus.template.npcTemplateId == 28 || Char2.myCharz().npcFocus.template.npcTemplateId == 41)
                        {
                            num3 = 3;
                            num4 = -12;
                        }
                        mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx + num3, cy - ch - mFont2.tahoma_7.getHeight() - num2 + num4, mFont2.CENTER, mFont2.tahoma_7_grey);
                    }
                }
                else
                {
                    num2 = 8;
                    if (template.npcTemplateId == 47)
                    {
                        num2 = 40;
                    }
                    if (TileMap2.mapID != 113)
                    {
                        int num5 = 0;
                        int num6 = 0;
                        if (template.npcTemplateId == 28 || template.npcTemplateId == 41)
                        {
                            num5 = 3;
                            num6 = -12;
                        }
                        mFont2.tahoma_7_yellow.drawString(g, "[" + template.npcTemplateId + "] " + template.name, cx + num5, cy - ch - num2 - mFont2.tahoma_7.getHeight() + num6, mFont2.CENTER, mFont2.tahoma_7_grey);
                    }
                }
            }
            dyEff = 65;
        }
    }

    public new void hide()
    {
        statusMe = 15;
        Char2.chatPopup = null;
    }
}
