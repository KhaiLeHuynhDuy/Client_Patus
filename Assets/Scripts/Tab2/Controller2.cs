using System;

internal class Controller2_2
{
    public static void readMessage(Message2 msg)
    {
        try
        {
            switch (msg.command)
            {
                case sbyte.MinValue:
                    readInfoEffChar(msg);
                    break;
                case sbyte.MaxValue:
                    readInfoRada(msg);
                    break;
                case 114:
                    try
                    {
                        string text2 = msg.reader().readUTF();
                        mSystem2.curINAPP = msg.reader().readByte();
                        mSystem2.maxINAPP = msg.reader().readByte();
                        break;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                case 113:
                    {
                        int loop = 0;
                        int layer = 0;
                        int id4 = 0;
                        short x2 = 0;
                        short y2 = 0;
                        short loopCount = -1;
                        try
                        {
                            loop = msg.reader().readByte();
                            layer = msg.reader().readByte();
                            id4 = msg.reader().readUnsignedByte();
                            x2 = msg.reader().readShort();
                            y2 = msg.reader().readShort();
                            loopCount = msg.reader().readShort();
                        }
                        catch (Exception)
                        {
                        }
                        EffecMn2.addEff(new Effect2_(id4, x2, y2, layer, loop, loopCount));
                        break;
                    }
                case 48:
                    {
                        sbyte b10 = msg.reader().readByte();
                        ServerListScreen2.ipSelect = b10;
                        GameCanvas2.instance.doResetToLoginScr(GameCanvas2.serverScreen);
                        Session_ME2_.gI().close();
                        GameCanvas2.endDlg();
                        ServerListScreen2.waitToLogin = true;
                        break;
                    }
                case 31:
                    {
                        int num15 = msg.reader().readInt();
                        sbyte b12 = msg.reader().readByte();
                        if (b12 == 1)
                        {
                            short smallID = msg.reader().readShort();
                            sbyte b13 = -1;
                            int[] array3 = null;
                            short wimg = 0;
                            short himg = 0;
                            try
                            {
                                b13 = msg.reader().readByte();
                                if (b13 > 0)
                                {
                                    sbyte b14 = msg.reader().readByte();
                                    array3 = new int[b14];
                                    for (int m = 0; m < b14; m++)
                                    {
                                        array3[m] = msg.reader().readByte();
                                    }
                                    wimg = msg.reader().readShort();
                                    himg = msg.reader().readShort();
                                }
                            }
                            catch (Exception)
                            {
                            }
                            if (num15 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().petFollow = new PetFollow2();
                                Char2.myCharz().petFollow.smallID = smallID;
                                if (b13 > 0)
                                {
                                    Char2.myCharz().petFollow.SetImg(b13, array3, wimg, himg);
                                }
                                break;
                            }
                            Char2 char3 = GameScr2.findCharInMap(num15);
                            char3.petFollow = new PetFollow2();
                            char3.petFollow.smallID = smallID;
                            if (b13 > 0)
                            {
                                char3.petFollow.SetImg(b13, array3, wimg, himg);
                            }
                        }
                        else if (num15 == Char2.myCharz().charID)
                        {
                            Char2.myCharz().petFollow.remove();
                            Char2.myCharz().petFollow = null;
                        }
                        else
                        {
                            Char2 char4 = GameScr2.findCharInMap(num15);
                            char4.petFollow.remove();
                            char4.petFollow = null;
                        }
                        break;
                    }
                case -89:
                    GameCanvas2.open3Hour = msg.reader().readByte() == 1;
                    break;
                case 42:
                    {
                        GameCanvas2.endDlg();
                        LoginScr2.isContinueToLogin = false;
                        Char2.isLoadingMap = false;
                        sbyte haveName = msg.reader().readByte();
                        if (GameCanvas2.registerScr == null)
                        {
                            GameCanvas2.registerScr = new RegisterScreen2();
                        }
                        GameCanvas2.registerScr.switchToMe();
                        break;
                    }
                case 52:
                    {
                        sbyte b8 = msg.reader().readByte();
                        if (b8 == 1)
                        {
                            int num11 = msg.reader().readInt();
                            if (num11 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().setMabuHold(m: true);
                                Char2.myCharz().cx = msg.reader().readShort();
                                Char2.myCharz().cy = msg.reader().readShort();
                            }
                            else
                            {
                                Char2 char2 = GameScr2.findCharInMap(num11);
                                if (char2 != null)
                                {
                                    char2.setMabuHold(m: true);
                                    char2.cx = msg.reader().readShort();
                                    char2.cy = msg.reader().readShort();
                                }
                            }
                        }
                        if (b8 == 0)
                        {
                            int num12 = msg.reader().readInt();
                            if (num12 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().setMabuHold(m: false);
                            }
                            else
                            {
                                GameScr2.findCharInMap(num12)?.setMabuHold(m: false);
                            }
                        }
                        if (b8 == 2)
                        {
                            int charId = msg.reader().readInt();
                            int id = msg.reader().readInt();
                            Mabu2 mabu = (Mabu2)GameScr2.findCharInMap(charId);
                            mabu.eat(id);
                        }
                        if (b8 == 3)
                        {
                            GameScr2.mabuPercent = msg.reader().readByte();
                        }
                        break;
                    }
                case 51:
                    {
                        int charId2 = msg.reader().readInt();
                        Mabu2 mabu2 = (Mabu2)GameScr2.findCharInMap(charId2);
                        sbyte id2 = msg.reader().readByte();
                        short x = msg.reader().readShort();
                        short y = msg.reader().readShort();
                        sbyte b9 = msg.reader().readByte();
                        Char2[] array = new Char2[b9];
                        int[] array2 = new int[b9];
                        for (int k = 0; k < b9; k++)
                        {
                            int num13 = msg.reader().readInt();
                            Res2.outz("char ID=" + num13);
                            array[k] = null;
                            if (num13 != Char2.myCharz().charID)
                            {
                                array[k] = GameScr2.findCharInMap(num13);
                            }
                            else
                            {
                                array[k] = Char2.myCharz();
                            }
                            array2[k] = msg.reader().readInt();
                        }
                        mabu2.setSkill(id2, x, y, array, array2);
                        break;
                    }
                case -127:
                    readLuckyRound(msg);
                    break;
                case -126:
                    {
                        sbyte type = msg.reader().readByte();
                        Res2.outz("type quay= " + type);
                        if (type == 1)
                        {
                            sbyte b27 = msg.reader().readByte();
                            string num38 = msg.reader().readUTF();
                            string finish = msg.reader().readUTF();
                            GameScr2.gI().showWinNumber(num38, finish);
                        }
                        if (type == 0)
                        {
                            GameScr2.gI().showYourNumber(msg.reader().readUTF());
                        }
                        break;
                    }
                case -122:
                    {
                        short id3 = msg.reader().readShort();
                        Npc2 npc = GameScr2.findNPCInMap(id3);
                        sbyte b20 = msg.reader().readByte();
                        npc.duahau = new int[b20];
                        for (int num25 = 0; num25 < b20; num25++)
                        {
                            npc.duahau[num25] = msg.reader().readShort();
                        }
                        npc.setStatus(msg.reader().readByte(), msg.reader().readInt());
                        break;
                    }
                case 102:
                    {
                        sbyte b21 = msg.reader().readByte();
                        if (b21 == 0 || b21 == 1 || b21 == 2 || b21 == 6)
                        {
                            BigBoss2_2 bigBoss = Mob2.getBigBoss2();
                            if (bigBoss == null)
                            {
                                break;
                            }
                            if (b21 == 6)
                            {
                                bigBoss.x = (bigBoss.y = (bigBoss.xTo = (bigBoss.yTo = (bigBoss.xFirst = (bigBoss.yFirst = -1000)))));
                                break;
                            }
                            sbyte b22 = msg.reader().readByte();
                            Char2[] array4 = new Char2[b22];
                            int[] array5 = new int[b22];
                            for (int num28 = 0; num28 < b22; num28++)
                            {
                                int num29 = msg.reader().readInt();
                                array4[num28] = null;
                                if (num29 != Char2.myCharz().charID)
                                {
                                    array4[num28] = GameScr2.findCharInMap(num29);
                                }
                                else
                                {
                                    array4[num28] = Char2.myCharz();
                                }
                                array5[num28] = msg.reader().readInt();
                            }
                            bigBoss.setAttack(array4, array5, b21);
                        }
                        if (b21 == 3 || b21 == 4 || b21 == 5 || b21 == 7)
                        {
                            BachTuoc2 bachTuoc = Mob2.getBachTuoc();
                            if (bachTuoc == null)
                            {
                                break;
                            }
                            if (b21 == 7)
                            {
                                bachTuoc.x = (bachTuoc.y = (bachTuoc.xTo = (bachTuoc.yTo = (bachTuoc.xFirst = (bachTuoc.yFirst = -1000)))));
                                break;
                            }
                            if (b21 == 3 || b21 == 4)
                            {
                                sbyte b23 = msg.reader().readByte();
                                Char2[] array6 = new Char2[b23];
                                int[] array7 = new int[b23];
                                for (int num30 = 0; num30 < b23; num30++)
                                {
                                    int num31 = msg.reader().readInt();
                                    array6[num30] = null;
                                    if (num31 != Char2.myCharz().charID)
                                    {
                                        array6[num30] = GameScr2.findCharInMap(num31);
                                    }
                                    else
                                    {
                                        array6[num30] = Char2.myCharz();
                                    }
                                    array7[num30] = msg.reader().readInt();
                                }
                                bachTuoc.setAttack(array6, array7, b21);
                            }
                            if (b21 == 5)
                            {
                                short xMoveTo = msg.reader().readShort();
                                bachTuoc.move(xMoveTo);
                            }
                        }
                        if (b21 > 9 && b21 < 30)
                        {
                            readActionBoss(msg, b21);
                        }
                        break;
                    }
                case 101:
                    {
                        Res2.outz("big boss--------------------------------------------------");
                        BigBoss2_ bigBoss2 = Mob2.getBigBoss();
                        if (bigBoss2 == null)
                        {
                            break;
                        }
                        sbyte b24 = msg.reader().readByte();
                        if (b24 == 0 || b24 == 1 || b24 == 2 || b24 == 4 || b24 == 3)
                        {
                            if (b24 == 3)
                            {
                                bigBoss2.xTo = (bigBoss2.xFirst = msg.reader().readShort());
                                bigBoss2.yTo = (bigBoss2.yFirst = msg.reader().readShort());
                                bigBoss2.setFly();
                            }
                            else
                            {
                                sbyte b25 = msg.reader().readByte();
                                Res2.outz("CHUONG nChar= " + b25);
                                Char2[] array8 = new Char2[b25];
                                int[] array9 = new int[b25];
                                for (int num32 = 0; num32 < b25; num32++)
                                {
                                    int num33 = msg.reader().readInt();
                                    Res2.outz("char ID=" + num33);
                                    array8[num32] = null;
                                    if (num33 != Char2.myCharz().charID)
                                    {
                                        array8[num32] = GameScr2.findCharInMap(num33);
                                    }
                                    else
                                    {
                                        array8[num32] = Char2.myCharz();
                                    }
                                    array9[num32] = msg.reader().readInt();
                                }
                                bigBoss2.setAttack(array8, array9, b24);
                            }
                        }
                        if (b24 == 5)
                        {
                            bigBoss2.haftBody = true;
                            bigBoss2.status = 2;
                        }
                        if (b24 == 6)
                        {
                            bigBoss2.getDataB2();
                            bigBoss2.x = msg.reader().readShort();
                            bigBoss2.y = msg.reader().readShort();
                        }
                        if (b24 == 7)
                        {
                            bigBoss2.setAttack(null, null, b24);
                        }
                        if (b24 == 8)
                        {
                            bigBoss2.xTo = (bigBoss2.xFirst = msg.reader().readShort());
                            bigBoss2.yTo = (bigBoss2.yFirst = msg.reader().readShort());
                            bigBoss2.status = 2;
                        }
                        if (b24 == 9)
                        {
                            bigBoss2.x = (bigBoss2.y = (bigBoss2.xTo = (bigBoss2.yTo = (bigBoss2.xFirst = (bigBoss2.yFirst = -1000)))));
                        }
                        break;
                    }
                case -120:
                    {
                        long num24 = mSystem2.currentTimeMillis();
                        Service2.logController = num24 - Service2.curCheckController;
                        Service2.gI().sendCheckController();
                        break;
                    }
                case -121:
                    {
                        long num27 = mSystem2.currentTimeMillis();
                        Service2.logMap = num27 - Service2.curCheckMap;
                        Service2.gI().sendCheckMap();
                        break;
                    }
                case 100:
                    {
                        sbyte b29 = msg.reader().readByte();
                        sbyte b30 = msg.reader().readByte();
                        Item2 item2 = null;
                        if (b29 == 0)
                        {
                            item2 = Char2.myCharz().arrItemBody[b30];
                        }
                        if (b29 == 1)
                        {
                            item2 = Char2.myCharz().arrItemBag[b30];
                        }
                        short num42 = msg.reader().readShort();
                        if (num42 == -1)
                        {
                            break;
                        }
                        item2.template = ItemTemplates2.get(num42);
                        item2.quantity = msg.reader().readInt();
                        item2.info = msg.reader().readUTF();
                        item2.content = msg.reader().readUTF();
                        sbyte b31 = msg.reader().readByte();
                        if (b31 == 0)
                        {
                            break;
                        }
                        item2.itemOption = new ItemOption2[b31];
                        for (int num43 = 0; num43 < item2.itemOption.Length; num43++)
                        {
                            int num44 = msg.reader().readUnsignedByte();
                            Res2.outz("id o= " + num44);
                            int param3 = msg.reader().readUnsignedShort();
                            if (num44 != -1)
                            {
                                item2.itemOption[num43] = new ItemOption2(num44, param3);
                            }
                        }
                        break;
                    }
                case -123:
                    {
                        int charId3 = msg.reader().readInt();
                        if (GameScr2.findCharInMap(charId3) != null)
                        {
                            GameScr2.findCharInMap(charId3).perCentMp = msg.reader().readByte();
                        }
                        break;
                    }
                case -119:
                    Char2.myCharz().rank = msg.reader().readInt();
                    break;
                case -117:
                    GameScr2.gI().tMabuEff = 0;
                    GameScr2.gI().percentMabu = msg.reader().readByte();
                    if (GameScr2.gI().percentMabu == 100)
                    {
                        GameScr2.gI().mabuEff = true;
                    }
                    if (GameScr2.gI().percentMabu == 101)
                    {
                        Npc2.mabuEff = true;
                    }
                    break;
                case -116:
                    GameScr2.canAutoPlay = msg.reader().readByte() == 1;
                    break;
                case -115:
                    Char2.myCharz().setPowerInfo(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
                    break;
                case -113:
                    {
                        sbyte[] array10 = new sbyte[10];
                        for (int num35 = 0; num35 < 10; num35++)
                        {
                            array10[num35] = msg.reader().readByte();
                            Res2.outz("vlue i= " + array10[num35]);
                        }
                        GameScr2.gI().onKSkill(array10);
                        GameScr2.gI().onOSkill(array10);
                        GameScr2.gI().onCSkill(array10);
                        break;
                    }
                case -111:
                    {
                        short num14 = msg.reader().readShort();
                        ImageSource2.vSource = new MyVector2();
                        for (int l = 0; l < num14; l++)
                        {
                            string iD = msg.reader().readUTF();
                            sbyte version = msg.reader().readByte();
                            ImageSource2.vSource.addElement(new ImageSource2(iD, version));
                        }
                        ImageSource2.checkRMS();
                        ImageSource2.saveRMS();
                        break;
                    }
                case 125:
                    {
                        sbyte fusion = msg.reader().readByte();
                        int num16 = msg.reader().readInt();
                        if (num16 == Char2.myCharz().charID)
                        {
                            Char2.myCharz().setFusion(fusion);
                        }
                        else if (GameScr2.findCharInMap(num16) != null)
                        {
                            GameScr2.findCharInMap(num16).setFusion(fusion);
                        }
                        break;
                    }
                case 124:
                    {
                        short num26 = msg.reader().readShort();
                        string text3 = msg.reader().readUTF();
                        Res2.outz("noi chuyen = " + text3 + "npc ID= " + num26);
                        GameScr2.findNPCInMap(num26)?.addInfo(text3);
                        break;
                    }
                case 123:
                    {
                        Res2.outz("SET POSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSss");
                        int num10 = msg.reader().readInt();
                        short xPos = msg.reader().readShort();
                        short yPos = msg.reader().readShort();
                        sbyte b7 = msg.reader().readByte();
                        Char2 @char = null;
                        if (num10 == Char2.myCharz().charID)
                        {
                            @char = Char2.myCharz();
                        }
                        else if (GameScr2.findCharInMap(num10) != null)
                        {
                            @char = GameScr2.findCharInMap(num10);
                        }
                        if (@char != null)
                        {
                            ServerEffect2.addServerEffect((b7 != 0) ? 173 : 60, @char, 1);
                            @char.setPos(xPos, yPos, b7);
                        }
                        break;
                    }
                case 122:
                    {
                        short num34 = msg.reader().readShort();
                        Res2.outz("second login = " + num34);
                        LoginScr2.timeLogin = num34;
                        LoginScr2.currTimeLogin = (LoginScr2.lastTimeLogin = mSystem2.currentTimeMillis());
                        GameCanvas2.endDlg();
                        break;
                    }
                case 121:
                    mSystem2.publicID = msg.reader().readUTF();
                    mSystem2.strAdmob = msg.reader().readUTF();
                    Res2.outz("SHOW AD public ID= " + mSystem2.publicID);
                    mSystem2.createAdmob();
                    break;
                case -124:
                    {
                        sbyte b4 = msg.reader().readByte();
                        sbyte b5 = msg.reader().readByte();
                        if (b5 == 0)
                        {
                            if (b4 == 2)
                            {
                                int num4 = msg.reader().readInt();
                                if (num4 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeEffect();
                                }
                                else if (GameScr2.findCharInMap(num4) != null)
                                {
                                    GameScr2.findCharInMap(num4).removeEffect();
                                }
                            }
                            int num5 = msg.reader().readUnsignedByte();
                            int num6 = msg.reader().readInt();
                            if (num5 == 32)
                            {
                                if (b4 == 1)
                                {
                                    int num7 = msg.reader().readInt();
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().holdEffID = num5;
                                        GameScr2.findCharInMap(num7).setHoldChar(Char2.myCharz());
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null && num7 != Char2.myCharz().charID)
                                    {
                                        GameScr2.findCharInMap(num6).holdEffID = num5;
                                        GameScr2.findCharInMap(num7).setHoldChar(GameScr2.findCharInMap(num6));
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null && num7 == Char2.myCharz().charID)
                                    {
                                        GameScr2.findCharInMap(num6).holdEffID = num5;
                                        Char2.myCharz().setHoldChar(GameScr2.findCharInMap(num6));
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeHoleEff();
                                }
                                else if (GameScr2.findCharInMap(num6) != null)
                                {
                                    GameScr2.findCharInMap(num6).removeHoleEff();
                                }
                            }
                            if (num5 == 33)
                            {
                                if (b4 == 1)
                                {
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().protectEff = true;
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null)
                                    {
                                        GameScr2.findCharInMap(num6).protectEff = true;
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeProtectEff();
                                }
                                else if (GameScr2.findCharInMap(num6) != null)
                                {
                                    GameScr2.findCharInMap(num6).removeProtectEff();
                                }
                            }
                            if (num5 == 39)
                            {
                                if (b4 == 1)
                                {
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().huytSao = true;
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null)
                                    {
                                        GameScr2.findCharInMap(num6).huytSao = true;
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeHuytSao();
                                }
                                else if (GameScr2.findCharInMap(num6) != null)
                                {
                                    GameScr2.findCharInMap(num6).removeHuytSao();
                                }
                            }
                            if (num5 == 40)
                            {
                                if (b4 == 1)
                                {
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().blindEff = true;
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null)
                                    {
                                        GameScr2.findCharInMap(num6).blindEff = true;
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeBlindEff();
                                }
                                else if (GameScr2.findCharInMap(num6) != null)
                                {
                                    GameScr2.findCharInMap(num6).removeBlindEff();
                                }
                            }
                            if (num5 == 41)
                            {
                                if (b4 == 1)
                                {
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().sleepEff = true;
                                    }
                                    else if (GameScr2.findCharInMap(num6) != null)
                                    {
                                        GameScr2.findCharInMap(num6).sleepEff = true;
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().removeSleepEff();
                                }
                                else if (GameScr2.findCharInMap(num6) != null)
                                {
                                    GameScr2.findCharInMap(num6).removeSleepEff();
                                }
                            }
                            if (num5 == 42)
                            {
                                if (b4 == 1)
                                {
                                    if (num6 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().stone = true;
                                    }
                                }
                                else if (num6 == Char2.myCharz().charID)
                                {
                                    Char2.myCharz().stone = false;
                                }
                            }
                        }
                        if (b5 != 1)
                        {
                            break;
                        }
                        int num8 = msg.reader().readUnsignedByte();
                        sbyte b6 = msg.reader().readByte();
                        Res2.outz("modbHoldID= " + b6 + " skillID= " + num8 + "eff ID= " + b4);
                        if (num8 == 32)
                        {
                            if (b4 == 1)
                            {
                                int num9 = msg.reader().readInt();
                                if (num9 == Char2.myCharz().charID)
                                {
                                    GameScr2.findMobInMap(b6).holdEffID = num8;
                                    Char2.myCharz().setHoldMob(GameScr2.findMobInMap(b6));
                                }
                                else if (GameScr2.findCharInMap(num9) != null)
                                {
                                    GameScr2.findMobInMap(b6).holdEffID = num8;
                                    GameScr2.findCharInMap(num9).setHoldMob(GameScr2.findMobInMap(b6));
                                }
                            }
                            else
                            {
                                GameScr2.findMobInMap(b6).removeHoldEff();
                            }
                        }
                        if (num8 == 40)
                        {
                            if (b4 == 1)
                            {
                                GameScr2.findMobInMap(b6).blindEff = true;
                            }
                            else
                            {
                                GameScr2.findMobInMap(b6).removeBlindEff();
                            }
                        }
                        if (num8 == 41)
                        {
                            if (b4 == 1)
                            {
                                GameScr2.findMobInMap(b6).sleepEff = true;
                            }
                            else
                            {
                                GameScr2.findMobInMap(b6).removeSleepEff();
                            }
                        }
                        break;
                    }
                case -125:
                    {
                        ChatTextField2.gI().isShow = false;
                        string text4 = msg.reader().readUTF();
                        Res2.outz("titile= " + text4);
                        sbyte b32 = msg.reader().readByte();
                        ClientInput2.gI().setInput(b32, text4);
                        for (int num45 = 0; num45 < b32; num45++)
                        {
                            ClientInput2.gI().tf[num45].name = msg.reader().readUTF();
                            sbyte b33 = msg.reader().readByte();
                            if (b33 == 0)
                            {
                                ClientInput2.gI().tf[num45].setIputType(TField2.INPUT_TYPE_NUMERIC);
                            }
                            if (b33 == 1)
                            {
                                ClientInput2.gI().tf[num45].setIputType(TField2.INPUT_TYPE_ANY);
                            }
                            if (b33 == 2)
                            {
                                ClientInput2.gI().tf[num45].setIputType(TField2.INPUT_TYPE_PASSWORD);
                            }
                        }
                        break;
                    }
                case -110:
                    {
                        sbyte b28 = msg.reader().readByte();
                        if (b28 == 1)
                        {
                            int num39 = msg.reader().readInt();
                            sbyte[] array11 = Rms2.loadRMS(num39 + string.Empty);
                            if (array11 == null)
                            {
                                Service2.gI().sendServerData(1, -1, null);
                            }
                            else
                            {
                                Service2.gI().sendServerData(1, num39, array11);
                            }
                        }
                        if (b28 == 0)
                        {
                            int num40 = msg.reader().readInt();
                            short num41 = msg.reader().readShort();
                            sbyte[] data = new sbyte[num41];
                            msg.reader().read(ref data, 0, num41);
                            Rms2.saveRMS(num40 + string.Empty, data);
                        }
                        break;
                    }
                case 93:
                    {
                        string str = msg.reader().readUTF();
                        str = Res2.changeString(str);
                        GameScr2.gI().chatVip(str);
                        break;
                    }
                case 98:
                    {
                        string str = msg.reader().readUTF();
                        MainMod2.GI().AddNotifTichXanh(str);
                        break;
                    }
                case -106:
                    {
                        short num36 = msg.reader().readShort();
                        int num37 = msg.reader().readShort();
                        if (ItemTime2.isExistItem(num36))
                        {
                            ItemTime2.getItemById(num36).initTime(num37);
                            break;
                        }
                        ItemTime2 o = new ItemTime2(num36, num37);
                        Char2.vItemTime.addElement(o);
                        break;
                    }
                case -105:
                    TransportScr2.gI().time = 0;
                    TransportScr2.gI().maxTime = msg.reader().readShort();
                    TransportScr2.gI().last = (TransportScr2.gI().curr = mSystem2.currentTimeMillis());
                    TransportScr2.gI().type = msg.reader().readByte();
                    TransportScr2.gI().switchToMe();
                    break;
                case -103:
                    {
                        sbyte b15 = msg.reader().readByte();
                        if (b15 == 0)
                        {
                            GameCanvas2.panel.vFlag.removeAllElements();
                            sbyte b16 = msg.reader().readByte();
                            for (int n = 0; n < b16; n++)
                            {
                                Item2 item = new Item2();
                                short num17 = msg.reader().readShort();
                                if (num17 != -1)
                                {
                                    item.template = ItemTemplates2.get(num17);
                                    sbyte b17 = msg.reader().readByte();
                                    if (b17 != -1)
                                    {
                                        item.itemOption = new ItemOption2[b17];
                                        for (int num18 = 0; num18 < item.itemOption.Length; num18++)
                                        {
                                            int num19 = msg.reader().readUnsignedByte();
                                            int param2 = msg.reader().readUnsignedShort();
                                            if (num19 != -1)
                                            {
                                                item.itemOption[num18] = new ItemOption2(num19, param2);
                                            }
                                        }
                                    }
                                }
                                GameCanvas2.panel.vFlag.addElement(item);
                            }
                            GameCanvas2.panel.setTypeFlag();
                            GameCanvas2.panel.show();
                        }
                        else if (b15 == 1)
                        {
                            int num20 = msg.reader().readInt();
                            sbyte b18 = msg.reader().readByte();
                            Res2.outz("---------------actionFlag1:  " + num20 + " : " + b18);
                            if (num20 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().cFlag = b18;
                            }
                            else if (GameScr2.findCharInMap(num20) != null)
                            {
                                GameScr2.findCharInMap(num20).cFlag = b18;
                            }
                            GameScr2.gI().getFlagImage(num20, b18);
                        }
                        else
                        {
                            if (b15 != 2)
                            {
                                break;
                            }
                            sbyte b19 = msg.reader().readByte();
                            int num21 = msg.reader().readShort();
                            PKFlag2 pKFlag = new PKFlag2();
                            pKFlag.cflag = b19;
                            pKFlag.IDimageFlag = num21;
                            GameScr2.vFlag.addElement(pKFlag);
                            for (int num22 = 0; num22 < GameScr2.vFlag.size(); num22++)
                            {
                                PKFlag2 pKFlag2 = (PKFlag2)GameScr2.vFlag.elementAt(num22);
                                Res2.outz("i: " + num22 + "  cflag: " + pKFlag2.cflag + "   IDimageFlag: " + pKFlag2.IDimageFlag);
                            }
                            for (int num23 = 0; num23 < GameScr2.vCharInMap.size(); num23++)
                            {
                                Char2 char5 = (Char2)GameScr2.vCharInMap.elementAt(num23);
                                if (char5 != null && char5.cFlag == b19)
                                {
                                    char5.flagImage = num21;
                                }
                            }
                            if (Char2.myCharz().cFlag == b19)
                            {
                                Char2.myCharz().flagImage = num21;
                            }
                        }
                        break;
                    }
                case -102:
                    {
                        sbyte b11 = msg.reader().readByte();
                        if (b11 != 0 && b11 == 1)
                        {
                            GameCanvas2.loginScr.isLogin2 = false;
                            Service2.gI().login(Rms2.loadRMSString("acc"), Rms2.loadRMSString("pass"), GameMidlet2.VERSION, 0);
                            LoginScr2.isLoggingIn = true;
                        }
                        break;
                    }
                case -101:
                    {
                        GameCanvas2.loginScr.isLogin2 = true;
                        GameCanvas2.connect();
                        string text = msg.reader().readUTF();
                        Rms2.saveRMSString("userAo" + ServerListScreen2.ipSelect, text);
                        Service2.gI().setClientType();
                        Service2.gI().login(text, string.Empty, GameMidlet2.VERSION, 1);
                        break;
                    }
                case -100:
                    {
                        InfoDlg2.hide();
                        bool flag = false;
                        if (GameCanvas2.w > 2 * Panel2.WIDTH_PANEL)
                        {
                            flag = true;
                        }
                        sbyte b = msg.reader().readByte();
                        Res2.outz("t Indxe= " + b);
                        GameCanvas2.panel.maxPageShop[b] = msg.reader().readByte();
                        GameCanvas2.panel.currPageShop[b] = msg.reader().readByte();
                        Res2.outz("max page= " + GameCanvas2.panel.maxPageShop[b] + " curr page= " + GameCanvas2.panel.currPageShop[b]);
                        int num = msg.reader().readUnsignedByte();
                        Char2.myCharz().arrItemShop[b] = new Item2[num];
                        for (int i = 0; i < num; i++)
                        {
                            short num2 = msg.reader().readShort();
                            if (num2 == -1)
                            {
                                continue;
                            }
                            Res2.outz("template id= " + num2);
                            Char2.myCharz().arrItemShop[b][i] = new Item2();
                            Char2.myCharz().arrItemShop[b][i].template = ItemTemplates2.get(num2);
                            Char2.myCharz().arrItemShop[b][i].itemId = msg.reader().readShort();
                            Char2.myCharz().arrItemShop[b][i].buyCoin = msg.reader().readInt();
                            Char2.myCharz().arrItemShop[b][i].buyGold = msg.reader().readInt();
                            Char2.myCharz().arrItemShop[b][i].buyType = msg.reader().readByte();
                            Char2.myCharz().arrItemShop[b][i].quantity = msg.reader().readInt();
                            Char2.myCharz().arrItemShop[b][i].isMe = msg.reader().readByte();
                            Panel2.strWantToBuy = mResources2.say_wat_do_u_want_to_buy;
                            sbyte b2 = msg.reader().readByte();
                            if (b2 != -1)
                            {
                                Char2.myCharz().arrItemShop[b][i].itemOption = new ItemOption2[b2];
                                for (int j = 0; j < Char2.myCharz().arrItemShop[b][i].itemOption.Length; j++)
                                {
                                    int num3 = msg.reader().readUnsignedByte();
                                    int param = msg.reader().readUnsignedShort();
                                    if (num3 != -1)
                                    {
                                        Char2.myCharz().arrItemShop[b][i].itemOption[j] = new ItemOption2(num3, param);
                                        Char2.myCharz().arrItemShop[b][i].compare = GameCanvas2.panel.getCompare(Char2.myCharz().arrItemShop[b][i]);
                                    }
                                }
                            }
                            sbyte b3 = msg.reader().readByte();
                            if (b3 == 1)
                            {
                                int headTemp = msg.reader().readShort();
                                int bodyTemp = msg.reader().readShort();
                                int legTemp = msg.reader().readShort();
                                int bagTemp = msg.reader().readShort();
                                Char2.myCharz().arrItemShop[b][i].setPartTemp(headTemp, bodyTemp, legTemp, bagTemp);
                            }
                            if (MainMod.readNameKiGui)
                            {
                                Char2.myCharz().arrItemShop[b][i].nameNguoiKyGui = msg.reader().readUTF();
                            }
                        }
                        if (flag)
                        {
                            GameCanvas2.panel2.setTabKiGui();
                        }
                        GameCanvas2.panel.setTabShop();
                        GameCanvas2.panel.cmy = (GameCanvas2.panel.cmtoY = 0);
                        break;
                    }
            }
        }
        catch (Exception ex4)
        {
            Res2.outz("=====> Controller2 " + ex4.StackTrace);
        }
    }

    private static void readLuckyRound(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                sbyte b2 = msg.reader().readByte();
                short[] array = new short[b2];
                for (int i = 0; i < b2; i++)
                {
                    array[i] = msg.reader().readShort();
                }
                sbyte b3 = msg.reader().readByte();
                int price = msg.reader().readInt();
                short idTicket = msg.reader().readShort();
                CrackBallScr2.gI().SetCrackBallScr(array, (byte)b3, price, idTicket);
            }
            else if (b == 1)
            {
                sbyte b4 = msg.reader().readByte();
                short[] array2 = new short[b4];
                for (int j = 0; j < b4; j++)
                {
                    array2[j] = msg.reader().readShort();
                }
                CrackBallScr2.gI().DoneCrackBallScr(array2);
            }
        }
        catch (Exception)
        {
        }
    }

    private static void readInfoRada(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                RadarScr2.gI();
                MyVector2 myVector = new MyVector2(string.Empty);
                short num = msg.reader().readShort();
                int num2 = 0;
                for (int i = 0; i < num; i++)
                {
                    Info_RadaScr2 info_RadaScr = new Info_RadaScr2();
                    int id = msg.reader().readShort();
                    int no = i + 1;
                    int idIcon = msg.reader().readShort();
                    sbyte rank = msg.reader().readByte();
                    sbyte amount = msg.reader().readByte();
                    sbyte max_amount = msg.reader().readByte();
                    short templateId = -1;
                    Char2 charInfo = null;
                    sbyte b2 = msg.reader().readByte();
                    if (b2 == 0)
                    {
                        templateId = msg.reader().readShort();
                    }
                    else
                    {
                        int head = msg.reader().readShort();
                        int body = msg.reader().readShort();
                        int leg = msg.reader().readShort();
                        int bag = msg.reader().readShort();
                        charInfo = Info_RadaScr2.SetCharInfo(head, body, leg, bag);
                    }
                    string name = msg.reader().readUTF();
                    string info = msg.reader().readUTF();
                    sbyte b3 = msg.reader().readByte();
                    sbyte use = msg.reader().readByte();
                    sbyte b4 = msg.reader().readByte();
                    ItemOption2[] array = null;
                    if (b4 != 0)
                    {
                        array = new ItemOption2[b4];
                        for (int j = 0; j < array.Length; j++)
                        {
                            int num3 = msg.reader().readUnsignedByte();
                            int param = msg.reader().readUnsignedShort();
                            sbyte activeCard = msg.reader().readByte();
                            if (num3 != -1)
                            {
                                array[j] = new ItemOption2(num3, param);
                                array[j].activeCard = activeCard;
                            }
                        }
                    }
                    info_RadaScr.SetInfo(id, no, idIcon, rank, b2, templateId, name, info, charInfo, array);
                    info_RadaScr.SetLevel(b3);
                    info_RadaScr.SetUse(use);
                    info_RadaScr.SetAmount(amount, max_amount);
                    myVector.addElement(info_RadaScr);
                    if (b3 > 0)
                    {
                        num2++;
                    }
                }
                RadarScr2.gI().SetRadarScr(myVector, num2, num);
                RadarScr2.gI().switchToMe();
            }
            else if (b == 1)
            {
                int id2 = msg.reader().readShort();
                sbyte use2 = msg.reader().readByte();
                if (Info_RadaScr2.GetInfo(RadarScr2.list, id2) != null)
                {
                    Info_RadaScr2.GetInfo(RadarScr2.list, id2).SetUse(use2);
                }
                RadarScr2.SetListUse();
            }
            else if (b == 2)
            {
                int num4 = msg.reader().readShort();
                sbyte level = msg.reader().readByte();
                int num5 = 0;
                for (int k = 0; k < RadarScr2.list.size(); k++)
                {
                    Info_RadaScr2 info_RadaScr2 = (Info_RadaScr2)RadarScr2.list.elementAt(k);
                    if (info_RadaScr2 != null)
                    {
                        if (info_RadaScr2.id == num4)
                        {
                            info_RadaScr2.SetLevel(level);
                        }
                        if (info_RadaScr2.level > 0)
                        {
                            num5++;
                        }
                    }
                }
                RadarScr2.SetNum(num5, RadarScr2.list.size());
                if (Info_RadaScr2.GetInfo(RadarScr2.listUse, num4) != null)
                {
                    Info_RadaScr2.GetInfo(RadarScr2.listUse, num4).SetLevel(level);
                }
            }
            else if (b == 3)
            {
                int id3 = msg.reader().readShort();
                sbyte amount2 = msg.reader().readByte();
                sbyte max_amount2 = msg.reader().readByte();
                if (Info_RadaScr2.GetInfo(RadarScr2.list, id3) != null)
                {
                    Info_RadaScr2.GetInfo(RadarScr2.list, id3).SetAmount(amount2, max_amount2);
                }
                if (Info_RadaScr2.GetInfo(RadarScr2.listUse, id3) != null)
                {
                    Info_RadaScr2.GetInfo(RadarScr2.listUse, id3).SetAmount(amount2, max_amount2);
                }
            }
            else if (b == 4)
            {
                int num6 = msg.reader().readInt();
                short idAuraEff = msg.reader().readShort();
                Char2 @char = null;
                @char = ((num6 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num6) : Char2.myCharz());
                if (@char != null)
                {
                    @char.idAuraEff = idAuraEff;
                    @char.idEff_Set_Item = msg.reader().readByte();
                }
            }
        }
        catch (Exception)
        {
        }
    }

    private static void readInfoEffChar(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte(); // on off
            int num = msg.reader().readInt(); // plId
            Char2 @char = null;
            @char = ((num != Char2.myCharz().charID) ? GameScr2.findCharInMap(num) : Char2.myCharz());
            if (b == 0) // bat
            {
                int id = msg.reader().readShort(); // id eff
                int layer = msg.reader().readByte(); // 
                int loop = msg.reader().readByte();
                short loopCount = msg.reader().readShort();
                sbyte isStand = msg.reader().readByte();
                int xC = 0;
                int yC = 0;
                try
                {
                    xC = msg.reader().readByte();
                    yC = msg.reader().readByte();
                }
                catch
                {

                }
                @char?.addEffChar(new Effect2_(id, @char, layer, loop, loopCount, isStand, xC, yC));
            }
            else if (b == 1) // tat
            {
                int id2 = msg.reader().readShort();
                @char?.removeEffChar(0, id2);
            }
            else if (b == 2)
            {
                @char?.removeEffChar(-1, 0);
            }
        }
        catch (Exception)
        {
        }
    }

    private static void readActionBoss(Message2 msg, int actionBoss)
    {
        try
        {
            sbyte idBoss = msg.reader().readByte();
            NewBoss2 newBoss = Mob2.getNewBoss(idBoss);
            if (newBoss == null)
            {
                return;
            }
            if (actionBoss == 10)
            {
                short xMoveTo = msg.reader().readShort();
                short yMoveTo = msg.reader().readShort();
                newBoss.move(xMoveTo, yMoveTo);
            }
            if (actionBoss >= 11 && actionBoss <= 20)
            {
                sbyte b = msg.reader().readByte();
                Char2[] array = new Char2[b];
                int[] array2 = new int[b];
                for (int i = 0; i < b; i++)
                {
                    int num = msg.reader().readInt();
                    array[i] = null;
                    if (num != Char2.myCharz().charID)
                    {
                        array[i] = GameScr2.findCharInMap(num);
                    }
                    else
                    {
                        array[i] = Char2.myCharz();
                    }
                    array2[i] = msg.reader().readInt();
                }
                sbyte dir = msg.reader().readByte();
                newBoss.setAttack(array, array2, (sbyte)(actionBoss - 10), dir);
            }
            if (actionBoss == 21)
            {
                newBoss.xTo = msg.reader().readShort();
                newBoss.yTo = msg.reader().readShort();
                newBoss.setFly();
            }
            if (actionBoss == 22)
            {
            }
            if (actionBoss == 23)
            {
                newBoss.setDie();
            }
        }
        catch (Exception)
        {
        }
    }
}
