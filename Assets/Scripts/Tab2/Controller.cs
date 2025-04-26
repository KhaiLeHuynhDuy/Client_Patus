using System;
using Mod2.XMAP;
using UnityEngine;

public class Controller2_ : IMessageHandler2
{
    protected static Controller2_ me;

    protected static Controller2_ me2;

    public Message2 messWait;

    public static bool isLoadingData = false;

    public static bool isConnectOK;

    public static bool isConnectionFail;

    public static bool isDisconnected;

    public static bool isMain;

    private int move;

    private int total;

    public static bool isStopReadMessage;

    public static MyHashTable2 frameHT_NEWBOSS = new MyHashTable2();

    public const sbyte PHUBAN_TYPE_CHIENTRUONGNAMEK = 0;

    public const sbyte PHUBAN_START = 0;

    public const sbyte PHUBAN_UPDATE_POINT = 1;

    public const sbyte PHUBAN_END = 2;

    public const sbyte PHUBAN_LIFE = 4;

    public const sbyte PHUBAN_INFO = 5;

    public static Controller2_ gI()
    {
        if (me == null)
        {
            me = new Controller2_();
        }
        return me;
    }

    public static Controller2_ gI2()
    {
        if (me2 == null)
        {
            me2 = new Controller2_();
        }
        return me2;
    }

    public void onConnectOK(bool isMain1)
    {
        isMain = isMain1;
        mSystem2.onConnectOK();
    }

    public void onConnectionFail(bool isMain1)
    {
        isMain = isMain1;
        mSystem2.onConnectionFail();
    }

    public void onDisconnected(bool isMain1)
    {
        isMain = isMain1;
        mSystem2.onDisconnected();
    }

    public void requestItemPlayer(Message2 msg)
    {
        try
        {
            int num = msg.reader().readUnsignedByte();
            Item2 item = GameScr2.currentCharViewInfo.arrItemBody[num];
            item.saleCoinLock = msg.reader().readInt();
            item.sys = msg.reader().readByte();
            item.options = new MyVector2();
            try
            {
                while (true)
                {
                    item.options.addElement(new ItemOption2(msg.reader().readUnsignedByte(), msg.reader().readUnsignedShort()));
                }
            }
            catch (Exception)
            {
            }
        }
        catch (Exception)
        {
        }
    }

    public void onMessage(Message2 msg)
    {
        GameCanvas2.debugSession.removeAllElements();
        GameCanvas2.debug("SA1", 2);
        try
        {
            if (msg.command != -74)
            {
            }
            Char2 @char = null;
            Mob2 mob = null;
            MyVector2 myVector = new MyVector2();
            int num = 0;
            GameCanvas2.timeLoading = 15;
            Controller2_2.readMessage(msg);
            switch (msg.command)
            {
                case 0:
                    readLogin(msg);
                    break;
                case 24:
                    read_opt(msg);
                    break;
                case 20:
                    phuban_Info(msg);
                    break;
                case 66:
                    readGetImgByName(msg);
                    break;
                case 65:
                    {
                        sbyte b67 = msg.reader().readSByte();
                        string text6 = msg.reader().readUTF();
                        short num162 = msg.reader().readShort();
                        if (ItemTime2.isExistMessage(b67))
                        {
                            if (num162 != 0)
                            {
                                ItemTime2.getMessageById(b67).initTimeText(b67, text6, num162);
                            }
                            else
                            {
                                GameScr2.textTime.removeElement(ItemTime2.getMessageById(b67));
                            }
                        }
                        else
                        {
                            ItemTime2 itemTime = new ItemTime2();
                            itemTime.initTimeText(b67, text6, num162);
                            GameScr2.textTime.addElement(itemTime);
                        }
                        break;
                    }
                case 112:
                    {
                        sbyte type = msg.reader().readByte();
                        if (type == 0)
                        {
                            Panel2.spearcialImage = msg.reader().readShort();
                            Panel2.specialInfo = msg.reader().readUTF(); // name
                            MainMod2.GI().CheckAutoIntrinsic(Panel2.specialInfo);
                        }
                        else
                        {
                            if (type != 1)
                            {
                                break;
                            }
                            sbyte tabSize = msg.reader().readByte();
                            Char2.myCharz().infoSpeacialSkill = new string[tabSize][];
                            Char2.myCharz().imgSpeacialSkill = new short[tabSize][];
                            GameCanvas2.panel.speacialTabName = new string[tabSize][];
                            for (int j = 0; j < tabSize; j++)
                            {
                                GameCanvas2.panel.speacialTabName[j] = new string[2];
                                string[] array10 = Res2.split(msg.reader().readUTF(), "\n", 0);
                                if (array10.Length == 2)
                                {
                                    GameCanvas2.panel.speacialTabName[j] = array10;
                                }
                                if (array10.Length == 1)
                                {
                                    GameCanvas2.panel.speacialTabName[j][0] = array10[0];
                                    GameCanvas2.panel.speacialTabName[j][1] = string.Empty;
                                }
                                int size = msg.reader().readByte();
                                Char2.myCharz().infoSpeacialSkill[j] = new string[size];
                                Char2.myCharz().imgSpeacialSkill[j] = new short[size];
                                for (int i = 0; i < size; i++)
                                {
                                    Char2.myCharz().imgSpeacialSkill[j][i] = msg.reader().readShort();
                                    Char2.myCharz().infoSpeacialSkill[j][i] = msg.reader().readUTF();
                                }
                            }
                            GameCanvas2.panel.tabName[25] = GameCanvas2.panel.speacialTabName;
                            GameCanvas2.panel.setTypeSpeacialSkill();
                            GameCanvas2.panel.show();
                        }
                        break;
                    }
                case -98:
                    {
                        sbyte b39 = msg.reader().readByte();
                        GameCanvas2.menu.showMenu = false;
                        if (b39 == 0)
                        {
                            GameCanvas2.startYesNoDlg(msg.reader().readUTF(), new Command2(mResources2.YES, GameCanvas2.instance, 888397, msg.reader().readUTF()), new Command2(mResources2.NO, GameCanvas2.instance, 888396, null));
                        }
                        break;
                    }
                case -97:
                    Char2.myCharz().cNangdong = msg.reader().readInt();
                    break;
                case -96:
                    {
                        sbyte typeTop = msg.reader().readByte();
                        GameCanvas2.panel.vTop.removeAllElements();
                        string topName = msg.reader().readUTF();
                        sbyte size = msg.reader().readByte();
                        for (int n = 0; n < size; n++)
                        {
                            int rank = msg.reader().readInt();
                            int pId = msg.reader().readInt();
                            short headID = msg.reader().readShort();
                            short headICON = msg.reader().readShort();
                            short body = msg.reader().readShort();
                            short leg = msg.reader().readShort();
                            string name = msg.reader().readUTF();
                            string info2 = msg.reader().readUTF();
                            TopInfo2 topInfo = new()
                            {
                                rank = rank,
                                headID = headID,
                                headICON = headICON,
                                body = body,
                                leg = leg,
                                name = name,
                                info = info2,
                                info2 = msg.reader().readUTF(),
                                pId = pId
                            };
                            GameCanvas2.panel.vTop.addElement(topInfo);
                        }
                        GameCanvas2.panel.topName = topName;
                        GameCanvas2.panel.setTypeTop(typeTop);
                        GameCanvas2.panel.show();
                        break;
                    }
                case -94:
                    while (msg.reader().available() > 0)
                    {
                        short num136 = msg.reader().readShort();
                        int num137 = msg.reader().readInt();
                        for (int num138 = 0; num138 < Char2.myCharz().vSkill.size(); num138++)
                        {
                            Skill2 skill = (Skill2)Char2.myCharz().vSkill.elementAt(num138);
                            if (skill != null && skill.skillId == num136)
                            {
                                if (num137 < skill.coolDown)
                                {
                                    skill.lastTimeUseThisSkill = mSystem2.currentTimeMillis() - (skill.coolDown - num137);
                                }
                            }
                        }
                    }
                    break;
                case -95:
                    {
                        sbyte type = msg.reader().readByte();
                        if (type == 0)
                        {
                            int num139 = msg.reader().readInt();
                            short templateId = msg.reader().readShort();
                            long hp = msg.readLong();
                            SoundMn2.gI().explode_1();
                            if (num139 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().mobMe = new Mob2(num139, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, templateId, 1, hp, 0, hp, (short)(Char2.myCharz().cx + ((Char2.myCharz().cdir != 1) ? (-40) : 40)), (short)Char2.myCharz().cy, 4, 0)
                                {
                                    isMobMe = true
                                };
                                EffecMn2.addEff(new Effect2_(18, Char2.myCharz().mobMe.x, Char2.myCharz().mobMe.y, 2, 10, -1));
                                Char2.myCharz().tMobMeBorn = 30;
                                GameScr2.vMob.addElement(Char2.myCharz().mobMe);
                            }
                            else
                            {
                                @char = GameScr2.findCharInMap(num139);
                                if (@char != null)
                                {
                                    Mob2 mob6 = new(num139, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, templateId, 1, hp, 0, hp, (short)@char.cx, (short)@char.cy, 4, 0);
                                    mob6.isMobMe = true;
                                    @char.mobMe = mob6;
                                    GameScr2.vMob.addElement(@char.mobMe);
                                }
                                else
                                {
                                    Mob2 mob7 = GameScr2.findMobInMap(num139);
                                    if (mob7 == null)
                                    {
                                        mob7 = new Mob2(num139, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, templateId, 1, hp, 0, hp, -100, -100, 4, 0)
                                        {
                                            isMobMe = true
                                        };
                                        GameScr2.vMob.addElement(mob7);
                                    }
                                }
                            }
                        }
                        if (type == 1)
                        {
                            int num141 = msg.reader().readInt();
                            int mobId = msg.reader().readByte();
                            if (num141 == Char2.myCharz().charID)
                            {
                                if (GameScr2.findMobInMap(mobId) != null)
                                {
                                    Char2.myCharz().mobMe.attackOtherMob(GameScr2.findMobInMap(mobId));
                                }
                            }
                            else
                            {
                                @char = GameScr2.findCharInMap(num141);
                                if (@char != null && GameScr2.findMobInMap(mobId) != null)
                                {
                                    @char.mobMe.attackOtherMob(GameScr2.findMobInMap(mobId));
                                }
                            }
                        }
                        if (type == 2)
                        {
                            int num142 = msg.reader().readInt();
                            int num143 = msg.reader().readInt();
                            long dameHit = msg.readLong();
                            long cHPNew = msg.readLong();
                            if (num142 == Char2.myCharz().charID)
                            {
                                @char = GameScr2.findCharInMap(num143);
                                if (@char != null)
                                {
                                    @char.cHPNew = cHPNew;
                                    if (Char2.myCharz().mobMe.isBusyAttackSomeOne)
                                    {
                                        @char.doInjure(dameHit, 0, isCrit: false, isMob: true);
                                    }
                                    else
                                    {
                                        Char2.myCharz().mobMe.dame = dameHit;
                                        Char2.myCharz().mobMe.setAttack(@char);
                                    }
                                }
                            }
                            else
                            {
                                mob = GameScr2.findMobInMap(num142);
                                if (mob != null)
                                {
                                    if (num143 == Char2.myCharz().charID)
                                    {
                                        Char2.myCharz().cHPNew = cHPNew;
                                        if (mob.isBusyAttackSomeOne)
                                        {
                                            Char2.myCharz().doInjure(dameHit, 0, isCrit: false, isMob: true);
                                        }
                                        else
                                        {
                                            mob.dame = dameHit;
                                            mob.setAttack(Char2.myCharz());
                                        }
                                    }
                                    else
                                    {
                                        @char = GameScr2.findCharInMap(num143);
                                        if (@char != null)
                                        {
                                            @char.cHPNew = cHPNew;
                                            if (mob.isBusyAttackSomeOne)
                                            {
                                                @char.doInjure(dameHit, 0, isCrit: false, isMob: true);
                                            }
                                            else
                                            {
                                                mob.dame = dameHit;
                                                mob.setAttack(@char);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (type == 3)
                        {
                            int num145 = msg.reader().readInt();
                            int mobId2 = msg.reader().readInt();
                            long hp = msg.readLong();
                            long dame = msg.readLong();
                            @char = null;
                            @char = ((Char2.myCharz().charID != num145) ? GameScr2.findCharInMap(num145) : Char2.myCharz());
                            if (@char != null)
                            {
                                mob = GameScr2.findMobInMap(mobId2);
                                if (@char.mobMe != null)
                                {
                                    @char.mobMe.attackOtherMob(mob);
                                }
                                if (mob != null)
                                {
                                    mob.hp = hp;
                                    mob.updateHp_bar();
                                    if (dame == 0)
                                    {
                                        mob.x = mob.xFirst;
                                        mob.y = mob.yFirst;
                                        GameScr2.startFlyText(mResources2.miss, mob.x, mob.y - mob.h, 0, -2, mFont2.MISS);
                                    }
                                    else
                                    {
                                        GameScr2.startFlyText("-" + dame, mob.x, mob.y - mob.h, 0, -2, mFont2.ORANGE);
                                    }
                                }
                            }
                        }
                        if (type == 4)
                        {
                            int charId = msg.reader().readInt();
                            if (charId == Char2.myCharz().charID)
                            {
                                EffecMn2.addEff(new Effect2_(18, Char2.myCharz().mobMe.x, Char2.myCharz().mobMe.y, 2, 10, -1));
                            }
                            else
                            {
                                @char = GameScr2.findCharInMap(charId);
                                EffecMn2.addEff(new Effect2_(18, @char.cx, @char.cy, 2, 10, -1));
                            }
                            SoundMn2.gI().explode_1();
                        }
                        if (type == 5)
                        {
                            int num147 = msg.reader().readInt();
                            sbyte b61 = msg.reader().readByte();
                            int mobId3 = msg.reader().readInt();
                            int num148 = msg.readInt3Byte();
                            int hp2 = msg.readInt3Byte();
                            @char = null;
                            @char = ((num147 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num147) : Char2.myCharz());
                            if (@char == null)
                            {
                                return;
                            }
                            if ((TileMap2.tileTypeAtPixel(@char.cx, @char.cy) & 2) == 2)
                            {
                                @char.setSkillPaint(GameScr2.sks[b61], 0);
                            }
                            else
                            {
                                @char.setSkillPaint(GameScr2.sks[b61], 1);
                            }
                            Mob2 mob8 = GameScr2.findMobInMap(mobId3);
                            if (@char.cx <= mob8.x)
                            {
                                @char.cdir = 1;
                            }
                            else
                            {
                                @char.cdir = -1;
                            }
                            @char.mobFocus = mob8;
                            mob8.hp = hp2;
                            mob8.updateHp_bar();
                            if (num148 == 0)
                            {
                                mob8.x = mob8.xFirst;
                                mob8.y = mob8.yFirst;
                                GameScr2.startFlyText(mResources2.miss, mob8.x, mob8.y - mob8.h, 0, -2, mFont2.MISS);
                            }
                            else
                            {
                                GameScr2.startFlyText("-" + num148, mob8.x, mob8.y - mob8.h, 0, -2, mFont2.ORANGE);
                            }
                        }
                        if (type == 6)
                        {
                            int num149 = msg.reader().readInt();
                            if (num149 == Char2.myCharz().charID)
                            {
                                Char2.myCharz().mobMe.startDie();
                            }
                            else
                            {
                                GameScr2.findCharInMap(num149)?.mobMe.startDie();
                            }
                        }
                        if (type != 7)
                        {
                            break;
                        }
                        int num150 = msg.reader().readInt();
                        if (num150 == Char2.myCharz().charID)
                        {
                            Char2.myCharz().mobMe = null;
                            for (int num151 = 0; num151 < GameScr2.vMob.size(); num151++)
                            {
                                if (((Mob2)GameScr2.vMob.elementAt(num151)).mobId == num150)
                                {
                                    GameScr2.vMob.removeElementAt(num151);
                                }
                            }
                            break;
                        }
                        @char = GameScr2.findCharInMap(num150);
                        for (int num152 = 0; num152 < GameScr2.vMob.size(); num152++)
                        {
                            if (((Mob2)GameScr2.vMob.elementAt(num152)).mobId == num150)
                            {
                                GameScr2.vMob.removeElementAt(num152);
                            }
                        }
                        if (@char != null)
                        {
                            @char.mobMe = null;
                        }
                        break;
                    }
                case -92:
                    Main2.typeClient = msg.reader().readByte();
                    if (Rms2.loadRMSString("ResVersion") == null)
                    {
                        Rms2.clearAll();
                    }
                    Rms2.saveRMSInt("clienttype", Main2.typeClient);
                    Rms2.saveRMSInt("lastZoomlevel", mGraphics2.zoomLevel);
                    if (Rms2.loadRMSString("ResVersion") == null)
                    {
                        GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
                    }
                    break;
                case -91:
                    {
                        sbyte b37 = msg.reader().readByte();
                        GameCanvas2.panel.mapNames = new string[b37];
                        GameCanvas2.panel.planetNames = new string[b37];
                        for (int num84 = 0; num84 < b37; num84++)
                        {
                            GameCanvas2.panel.mapNames[num84] = msg.reader().readUTF();
                            GameCanvas2.panel.planetNames[num84] = msg.reader().readUTF();
                        }
                        AutoXmap2.ShowPanelMapTrans();
                        break;
                    }
                case -90:
                    {
                        sbyte b35 = msg.reader().readByte();
                        int num79 = msg.reader().readInt();
                        @char = ((Char2.myCharz().charID != num79) ? GameScr2.findCharInMap(num79) : Char2.myCharz());
                        if (b35 != -1)
                        {
                            short num80 = msg.reader().readShort();
                            short num81 = msg.reader().readShort();
                            short num82 = msg.reader().readShort();
                            sbyte isMonkey = msg.reader().readByte();
                            if (@char != null)
                            {
                                if (@char.charID == num79)
                                {
                                    @char.isMask = true;
                                    @char.isMonkey = isMonkey;
                                    @char.isWaitMonkey = false;
                                    @char.isLockMove = false;
                                    // if (@char.isMonkey != 0)
                                    // {
                                    //     @char.isWaitMonkey = false;
                                    //     @char.isLockMove = false;
                                    // }
                                }
                                else if (@char != null)
                                {
                                    @char.isMask = true;
                                    @char.isMonkey = isMonkey;
                                }
                                if (num80 != -1)
                                {
                                    @char.head = num80;
                                }
                                if (num81 != -1)
                                {
                                    @char.body = num81;
                                }
                                if (num82 != -1)
                                {
                                    @char.leg = num82;
                                }
                            }
                        }
                        if (b35 == -1 && @char != null)
                        {
                            @char.isMask = false;
                            @char.isMonkey = 0;
                        }
                        if (@char == null)
                        {
                        }
                        break;
                    }
                case -88:
                    GameCanvas2.endDlg();
                    GameCanvas2.serverScreen.switchToMe();
                    break;
                case -87:
                    {
                        msg.reader().mark(100000);
                        createData(msg.reader(), isSaveRMS: true);
                        msg.reader().reset();
                        sbyte[] data3 = new sbyte[msg.reader().available()];
                        msg.reader().readFully(ref data3);
                        sbyte[] data4 = new sbyte[1] { GameScr2.vcData };
                        Rms2.saveRMS("NRdataVersion", data4);
                        LoginScr2.isUpdateData = false;
                        if (GameScr2.vsData == GameScr2.vcData && GameScr2.vsMap == GameScr2.vcMap && GameScr2.vsSkill == GameScr2.vcSkill && GameScr2.vsItem == GameScr2.vcItem)
                        {
                            GameScr2.gI().readDart();
                            GameScr2.gI().readEfect();
                            GameScr2.gI().readArrow();
                            GameScr2.gI().readSkill();
                            Service2.gI().clientOk();
                            return;
                        }
                        break;
                    }
                case -86:
                    {
                        sbyte b42 = msg.reader().readByte();
                        if (b42 == 0)
                        {
                            int playerID = msg.reader().readInt();
                            GameScr2.gI().giaodich(playerID);
                        }
                        if (b42 == 1)
                        {
                            int num97 = msg.reader().readInt();
                            Char2 char7 = GameScr2.findCharInMap(num97);
                            if (char7 == null)
                            {
                                return;
                            }
                            GameCanvas2.panel.setTypeGiaoDich(char7);
                            GameCanvas2.panel.show();
                            Service2.gI().getPlayerMenu(num97);
                        }
                        if (b42 == 2)
                        {
                            sbyte b43 = msg.reader().readByte();
                            for (int num98 = 0; num98 < GameCanvas2.panel.vMyGD.size(); num98++)
                            {
                                Item2 item2 = (Item2)GameCanvas2.panel.vMyGD.elementAt(num98);
                                if (item2.indexUI == b43)
                                {
                                    GameCanvas2.panel.vMyGD.removeElement(item2);
                                    break;
                                }
                            }
                        }
                        if (b42 == 6)
                        {
                            GameCanvas2.panel.isFriendLock = true;
                            if (GameCanvas2.panel2 != null)
                            {
                                GameCanvas2.panel2.isFriendLock = true;
                            }
                            GameCanvas2.panel.vFriendGD.removeAllElements();
                            if (GameCanvas2.panel2 != null)
                            {
                                GameCanvas2.panel2.vFriendGD.removeAllElements();
                            }
                            int friendMoneyGD = msg.reader().readInt();
                            sbyte b44 = msg.reader().readByte();
                            for (int num99 = 0; num99 < b44; num99++)
                            {
                                Item2 item3 = new Item2();
                                item3.template = ItemTemplates2.get(msg.reader().readShort());
                                item3.quantity = msg.reader().readInt();
                                int num100 = msg.reader().readUnsignedByte();
                                if (num100 != 0)
                                {
                                    item3.itemOption = new ItemOption2[num100];
                                    for (int num101 = 0; num101 < item3.itemOption.Length; num101++)
                                    {
                                        int num102 = msg.reader().readUnsignedByte();
                                        int param5 = msg.reader().readUnsignedShort();
                                        if (num102 != -1)
                                        {
                                            item3.itemOption[num101] = new ItemOption2(num102, param5);
                                            item3.compare = GameCanvas2.panel.getCompare(item3);
                                        }
                                    }
                                }
                                if (GameCanvas2.panel2 != null)
                                {
                                    GameCanvas2.panel2.vFriendGD.addElement(item3);
                                }
                                else
                                {
                                    GameCanvas2.panel.vFriendGD.addElement(item3);
                                }
                            }
                            if (GameCanvas2.panel2 != null)
                            {
                                GameCanvas2.panel2.setTabGiaoDich(isMe: false);
                                GameCanvas2.panel2.friendMoneyGD = friendMoneyGD;
                            }
                            else
                            {
                                GameCanvas2.panel.friendMoneyGD = friendMoneyGD;
                                if (GameCanvas2.panel.currentTabIndex == 2)
                                {
                                    GameCanvas2.panel.setTabGiaoDich(isMe: false);
                                }
                            }
                        }
                        if (b42 == 7)
                        {
                            InfoDlg2.hide();
                            if (GameCanvas2.panel.isShow)
                            {
                                GameCanvas2.panel.hide();
                            }
                        }
                        break;
                    }
                case -85:
                    {
                        sbyte b47 = msg.reader().readByte();
                        if (b47 == 0)
                        {
                            int num106 = msg.reader().readUnsignedShort();
                            sbyte[] data2 = new sbyte[num106];
                            msg.reader().read(ref data2, 0, num106);
                            GameScr2.imgCapcha = Image2.createImage(data2, 0, num106);
                            GameScr2.gI().keyInput = "-----";
                            GameScr2.gI().strCapcha = msg.reader().readUTF();
                            GameScr2.gI().keyCapcha = new int[GameScr2.gI().strCapcha.Length];
                            GameScr2.gI().mobCapcha = new Mob2();
                            GameScr2.gI().right = null;
                        }
                        if (b47 == 1)
                        {
                            MobCapcha2.isAttack = true;
                        }
                        if (b47 == 2)
                        {
                            MobCapcha2.explode = true;
                            GameScr2.gI().right = GameScr2.gI().cmdFocus;
                        }
                        break;
                    }
                case -112:
                    {
                        sbyte b40 = msg.reader().readByte();
                        if (b40 == 0)
                        {
                            sbyte mobIndex = msg.reader().readByte();
                            GameScr2.findMobInMap(mobIndex).clearBody();
                        }
                        if (b40 == 1)
                        {
                            sbyte mobIndex2 = msg.reader().readByte();
                            GameScr2.findMobInMap(mobIndex2).setBody(msg.reader().readShort());
                        }
                        break;
                    }
                case -84:
                    {
                        int index2 = msg.reader().readUnsignedByte();
                        Mob2 mob4 = null;
                        try
                        {
                            mob4 = (Mob2)GameScr2.vMob.elementAt(index2);
                        }
                        catch (Exception)
                        {
                        }
                        if (mob4 != null)
                        {
                            mob4.maxHp = msg.reader().readInt();
                        }
                        break;
                    }
                case -83:
                    {
                        sbyte b30 = msg.reader().readByte();
                        if (b30 == 0)
                        {
                            int num66 = msg.reader().readShort();
                            int bgRID = msg.reader().readShort();
                            int num67 = msg.reader().readUnsignedByte();
                            int num68 = msg.reader().readInt();
                            string text2 = msg.reader().readUTF();
                            int num69 = msg.reader().readShort();
                            int num70 = msg.reader().readShort();
                            sbyte b31 = msg.reader().readByte();
                            if (b31 == 1)
                            {
                                GameScr2.gI().isRongNamek = true;
                            }
                            else
                            {
                                GameScr2.gI().isRongNamek = false;
                            }
                            GameScr2.gI().xR = num69;
                            GameScr2.gI().yR = num70;
                            if (Char2.myCharz().charID == num68)
                            {
                                GameCanvas2.panel.hideNow();
                                GameScr2.gI().activeRongThanEff(isMe: true);
                            }
                            else if (TileMap2.mapID == num66 && TileMap2.zoneID == num67)
                            {
                                GameScr2.gI().activeRongThanEff(isMe: false);
                            }
                            else if (mGraphics2.zoomLevel > 1)
                            {
                                GameScr2.gI().doiMauTroi();
                            }
                            GameScr2.gI().mapRID = num66;
                            GameScr2.gI().bgRID = bgRID;
                            GameScr2.gI().zoneRID = num67;
                        }
                        if (b30 == 1)
                        {
                            if (TileMap2.mapID == GameScr2.gI().mapRID && TileMap2.zoneID == GameScr2.gI().zoneRID)
                            {
                                GameScr2.gI().hideRongThanEff();
                            }
                            else
                            {
                                GameScr2.gI().isRongThanXuatHien = false;
                                if (GameScr2.gI().isRongNamek)
                                {
                                    GameScr2.gI().isRongNamek = false;
                                }
                            }
                        }
                        if (b30 != 2)
                        {
                        }
                        break;
                    }
                case -82:
                    {
                        sbyte size = msg.reader().readByte();
                        TileMap2.tileIndex = new int[size][][];
                        TileMap2.tileType = new int[size][];
                        for (int i = 0; i < size; i++)
                        {
                            sbyte b15 = msg.reader().readByte();
                            TileMap2.tileType[i] = new int[b15];
                            TileMap2.tileIndex[i] = new int[b15][];
                            for (int j = 0; j < b15; j++)
                            {
                                TileMap2.tileType[i][j] = msg.reader().readInt();
                                sbyte b16 = msg.reader().readByte();
                                TileMap2.tileIndex[i][j] = new int[b16];
                                for (int k = 0; k < b16; k++)
                                {
                                    TileMap2.tileIndex[i][j][k] = msg.reader().readByte();
                                }
                            }
                        }
                        break;
                    }
                case -81:
                    {
                        sbyte b24 = msg.reader().readByte();
                        if (b24 == 0)
                        {
                            string src = msg.reader().readUTF();
                            string src2 = msg.reader().readUTF();
                            GameCanvas2.panel.setTypeCombine();
                            GameCanvas2.panel.combineInfo = mFont2.tahoma_7b_blue.splitFontArray(src, Panel2.WIDTH_PANEL);
                            GameCanvas2.panel.combineTopInfo = mFont2.tahoma_7.splitFontArray(src2, Panel2.WIDTH_PANEL);
                            GameCanvas2.panel.show();
                        }
                        if (b24 == 1)
                        {
                            GameCanvas2.panel.vItemCombine.removeAllElements();
                            sbyte b25 = msg.reader().readByte();
                            for (int num51 = 0; num51 < b25; num51++)
                            {
                                sbyte b26 = msg.reader().readByte();
                                for (int num52 = 0; num52 < Char2.myCharz().arrItemBag.Length; num52++)
                                {
                                    Item2 item = Char2.myCharz().arrItemBag[num52];
                                    if (item != null && item.indexUI == b26)
                                    {
                                        item.isSelect = true;
                                        GameCanvas2.panel.vItemCombine.addElement(item);
                                    }
                                }
                            }
                            if (GameCanvas2.panel.isShow)
                            {
                                GameCanvas2.panel.setTabCombine();
                            }
                        }
                        if (b24 == 2)
                        {
                            GameCanvas2.panel.combineSuccess = 0;
                            GameCanvas2.panel.setCombineEff(0);
                        }
                        if (b24 == 3)
                        {
                            GameCanvas2.panel.combineSuccess = 1;
                            GameCanvas2.panel.setCombineEff(0);
                        }
                        if (b24 == 4)
                        {
                            short iconID = msg.reader().readShort();
                            GameCanvas2.panel.iconID3 = iconID;
                            GameCanvas2.panel.combineSuccess = 0;
                            GameCanvas2.panel.setCombineEff(1);
                        }
                        if (b24 == 5)
                        {
                            short iconID2 = msg.reader().readShort();
                            GameCanvas2.panel.iconID3 = iconID2;
                            GameCanvas2.panel.combineSuccess = 0;
                            GameCanvas2.panel.setCombineEff(2);
                        }
                        if (b24 == 6)
                        {
                            short iconID3 = msg.reader().readShort();
                            short iconID4 = msg.reader().readShort();
                            GameCanvas2.panel.combineSuccess = 0;
                            GameCanvas2.panel.setCombineEff(3);
                            GameCanvas2.panel.iconID1 = iconID3;
                            GameCanvas2.panel.iconID3 = iconID4;
                        }
                        if (b24 == 7)
                        {
                            short iconID5 = msg.reader().readShort();
                            GameCanvas2.panel.iconID3 = iconID5;
                            GameCanvas2.panel.combineSuccess = 0;
                            GameCanvas2.panel.setCombineEff(4);
                        }
                        if (b24 == 8)
                        {
                            GameCanvas2.panel.iconID3 = -1;
                            GameCanvas2.panel.combineSuccess = 1;
                            GameCanvas2.panel.setCombineEff(4);
                        }
                        short num53 = 21;
                        int num54 = 0;
                        int num55 = 0;
                        try
                        {
                            num53 = msg.reader().readShort();
                            num54 = msg.reader().readShort();
                            num55 = msg.reader().readShort();
                            GameCanvas2.panel.xS = num54 - GameScr2.cmx;
                            GameCanvas2.panel.yS = num55 - GameScr2.cmy;
                        }
                        catch (Exception)
                        {
                        }
                        for (int num56 = 0; num56 < GameScr2.vNpc.size(); num56++)
                        {
                            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(num56);
                            if (npc.template.npcTemplateId == num53)
                            {
                                GameCanvas2.panel.xS = npc.cx - GameScr2.cmx;
                                GameCanvas2.panel.yS = npc.cy - GameScr2.cmy;
                                GameCanvas2.panel.idNPC = num53;
                                break;
                            }
                        }
                        break;
                    }
                case -80:
                    {
                        sbyte b48 = msg.reader().readByte();
                        InfoDlg2.hide();
                        if (b48 == 0)
                        {
                            GameCanvas2.panel.vFriend.removeAllElements();
                            int num108 = msg.reader().readUnsignedByte();
                            for (int num109 = 0; num109 < num108; num109++)
                            {
                                Char2 char9 = new Char2();
                                char9.charID = msg.reader().readInt();
                                char9.head = msg.reader().readShort();
                                char9.headICON = msg.reader().readShort();
                                char9.body = msg.reader().readShort();
                                char9.leg = msg.reader().readShort();
                                char9.bag = msg.reader().readUnsignedByte();
                                char9.cName = msg.reader().readUTF();
                                bool isOnline = msg.reader().readBoolean();
                                InfoItem2 infoItem2 = new InfoItem2(mResources2.power + ": " + msg.reader().readUTF());
                                infoItem2.charInfo = char9;
                                infoItem2.isOnline = isOnline;
                                GameCanvas2.panel.vFriend.addElement(infoItem2);
                            }
                            GameCanvas2.panel.setTypeFriend();
                            GameCanvas2.panel.show();
                        }
                        if (b48 == 3)
                        {
                            MyVector2 vFriend = GameCanvas2.panel.vFriend;
                            int num110 = msg.reader().readInt();
                            for (int num111 = 0; num111 < vFriend.size(); num111++)
                            {
                                InfoItem2 infoItem3 = (InfoItem2)vFriend.elementAt(num111);
                                if (infoItem3.charInfo != null && infoItem3.charInfo.charID == num110)
                                {
                                    infoItem3.isOnline = msg.reader().readBoolean();
                                    break;
                                }
                            }
                        }
                        if (b48 != 2)
                        {
                            break;
                        }
                        MyVector2 vFriend2 = GameCanvas2.panel.vFriend;
                        int num112 = msg.reader().readInt();
                        for (int num113 = 0; num113 < vFriend2.size(); num113++)
                        {
                            InfoItem2 infoItem4 = (InfoItem2)vFriend2.elementAt(num113);
                            if (infoItem4.charInfo != null && infoItem4.charInfo.charID == num112)
                            {
                                vFriend2.removeElement(infoItem4);
                                break;
                            }
                        }
                        if (GameCanvas2.panel.isShow)
                        {
                            GameCanvas2.panel.setTabFriend();
                        }
                        break;
                    }
                case -99:
                    {
                        InfoDlg2.hide();
                        sbyte type;
                        try
                        {
                            type = msg.reader().readByte();
                        }
                        catch
                        {
                            type = -1;
                        }
                        if (type == 0)
                        {
                            GameCanvas2.panel.vEnemy.removeAllElements();
                            int num95 = msg.reader().readUnsignedByte();
                            for (int num96 = 0; num96 < num95; num96++)
                            {
                                Char2 char6 = new Char2();
                                char6.charID = msg.reader().readInt();
                                char6.head = msg.reader().readShort();
                                char6.headICON = msg.reader().readShort();
                                char6.body = msg.reader().readShort();
                                char6.leg = msg.reader().readShort();
                                char6.bag = msg.reader().readShort();
                                char6.cName = msg.reader().readUTF();
                                InfoItem2 infoItem = new InfoItem2(msg.reader().readUTF());
                                bool flag8 = msg.reader().readBoolean();
                                infoItem.charInfo = char6;
                                infoItem.isOnline = flag8;
                                GameCanvas2.panel.vEnemy.addElement(infoItem);
                            }
                            GameCanvas2.panel.setTypeEnemy();
                            GameCanvas2.panel.show();
                        }
                        break;
                    }
                case -79:
                    {
                        InfoDlg2.hide();
                        int num104 = msg.reader().readInt();
                        Char2 charMenu = GameCanvas2.panel.charMenu;
                        if (charMenu == null)
                        {
                            return;
                        }
                        charMenu.cPower = msg.reader().readLong();
                        charMenu.currStrLevel = msg.reader().readUTF();
                        break;
                    }
                case -93:
                    {
                        short num15 = msg.reader().readShort();
                        BgItem2.newSmallVersion = new sbyte[num15];
                        for (int l = 0; l < num15; l++)
                        {
                            BgItem2.newSmallVersion[l] = msg.reader().readByte();
                        }
                        break;
                    }
                case -77:
                    {
                        short num93 = msg.reader().readShort();
                        SmallImage2.newSmallVersion = new sbyte[num93];
                        SmallImage2.maxSmall = num93;
                        SmallImage2.imgNew = new Small2[num93];
                        for (int num94 = 0; num94 < num93; num94++)
                        {
                            SmallImage2.newSmallVersion[num94] = msg.reader().readByte();
                        }
                        break;
                    }
                case -76:
                    {
                        sbyte type = msg.reader().readByte();
                        if (type == 0)
                        {
                            sbyte sz = msg.reader().readByte();
                            if (sz <= 0)
                            {
                                return;
                            }
                            Char2.myCharz().arrArchive = new Archivement2[sz];
                            for (int m = 0; m < sz; m++)
                            {
                                Char2.myCharz().arrArchive[m] = new Archivement2
                                {
                                    info1 = m + 1 + ". " + msg.reader().readUTF(),
                                    info2 = msg.reader().readUTF(),
                                    money = msg.reader().readShort(),
                                    isFinish = msg.reader().readBoolean(),
                                    isRecieve = msg.reader().readBoolean()
                                };
                            }
                            GameCanvas2.panel.setTypeArchivement();
                            GameCanvas2.panel.show();
                        }
                        else if (type == 1)
                        {
                            int idArchive = msg.reader().readUnsignedByte();
                            if (Char2.myCharz().arrArchive[idArchive] != null)
                            {
                                Char2.myCharz().arrArchive[idArchive].isRecieve = true;
                            }
                        }
                        break;
                    }
                case -74:
                    {
                        if (ServerListScreen2.stopDownload)
                        {
                            return;
                        }
                        if (!GameCanvas2.isGetResourceFromServer())
                        {
                            Service2.gI().getResource(3, null);
                            SmallImage2.loadBigRMS();
                            if (Rms2.loadRMSString("acc") != null || Rms2.loadRMSString("userAo" + ServerListScreen2.ipSelect) != null)
                            {
                                LoginScr2.isContinueToLogin = true;
                            }
                            GameCanvas2.loginScr = new LoginScr2();
                            GameCanvas2.loginScr.switchToMe();
                            return;
                        }
                        sbyte b38 = msg.reader().readByte();
                        if (b38 == 0)
                        {
                            int num89 = msg.reader().readInt();
                            string text3 = Rms2.loadRMSString("ResVersion");
                            int num90 = ((text3 == null || !(text3 != string.Empty)) ? (-1) : int.Parse(text3));
                            if (Session_ME2_.gI().isCompareIPConnect())
                            {
                                if (num90 == -1 || num90 != num89)
                                {
                                    GameCanvas2.serverScreen.show2();
                                }
                                else
                                {
                                    SmallImage2.loadBigRMS();
                                    ServerListScreen2.loadScreen = true;
                                    if (GameCanvas2.currentScreen != GameCanvas2.loginScr)
                                    {
                                        GameCanvas2.serverScreen.switchToMe();
                                    }
                                }
                            }
                            else
                            {
                                Session_ME2_.gI().close();
                                ServerListScreen2.loadScreen = true;
                                ServerListScreen2.isAutoConect = false;
                                ServerListScreen2.countDieConnect = 1000;
                                GameCanvas2.serverScreen.switchToMe();
                            }
                        }
                        if (b38 == 1)
                        {
                            ServerListScreen2.strWait = mResources2.downloading_data;
                            short nBig = msg.reader().readShort();
                            ServerListScreen2.nBig = nBig;
                            Service2.gI().getResource(2, null);
                        }
                        if (b38 == 2)
                        {
                            try
                            {
                                isLoadingData = true;
                                GameCanvas2.endDlg();
                                ServerListScreen2.demPercent++;
                                ServerListScreen2.percent = ServerListScreen2.demPercent * 100 / ServerListScreen2.nBig;
                                string original = msg.reader().readUTF();
                                string[] array8 = Res2.split(original, "/", 0);
                                string filename = "x" + mGraphics2.zoomLevel + array8[^1];
                                int num91 = msg.reader().readInt();
                                sbyte[] data = new sbyte[num91];
                                msg.reader().read(ref data, 0, num91);
                                Rms2.saveRMS(filename, data);
                            }
                            catch (Exception)
                            {
                                GameCanvas2.startOK(mResources2.pls_restart_game_error, 8885, null);
                            }
                        }
                        if (b38 == 3)
                        {
                            isLoadingData = false;
                            int num92 = msg.reader().readInt();
                            Rms2.saveRMSString("ResVersion", num92 + string.Empty);
                            Service2.gI().getResource(3, null);
                            GameCanvas2.endDlg();
                            SmallImage2.loadBigRMS();
                            mSystem2.gcc();
                            ServerListScreen2.bigOk = true;
                            ServerListScreen2.loadScreen = true;
                            GameScr2.gI().loadGameScr();
                            if (GameCanvas2.currentScreen != GameCanvas2.loginScr)
                            {
                                GameCanvas2.serverScreen.switchToMe();
                            }
                        }
                        break;
                    }
                case -43:
                    {
                        sbyte itemAction = msg.reader().readByte();
                        sbyte where = msg.reader().readByte();
                        sbyte index = msg.reader().readByte();
                        string info = msg.reader().readUTF();
                        GameCanvas2.panel.itemRequest(itemAction, info, where, index);
                        break;
                    }
                case -59:
                    {
                        sbyte typePK = msg.reader().readByte();
                        GameScr2.gI().player_vs_player(msg.reader().readInt(), msg.reader().readInt(), msg.reader().readUTF(), typePK);
                        break;
                    }
                case -62:
                    {
                        byte id = msg.reader().readUnsignedByte();
                        sbyte size = msg.reader().readByte();
                        int[] idImage = new int[size];

                        if (size > 0)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                idImage[i] = msg.reader().readShort();
                                if (idImage[i] > 0)
                                {
                                    SmallImage2.vKeys.addElement(idImage[i] + string.Empty);
                                }
                            }
                        }

                        short idNew;
                        try
                        {
                            idNew = msg.reader().readShort();
                        }
                        catch
                        {
                            idNew = id;
                        }

                        if (size > 0)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                try
                                {
                                    idImage[i] = msg.reader().readInt();
                                }
                                catch
                                {
                                }
                                if (idImage[i] > 0)
                                {
                                    SmallImage2.vKeys.addElement(idImage[i] + string.Empty);
                                }
                            }
                        }

                        ClanImage2 clanImage = ClanImage2.getClanImage(idNew);
                        if (clanImage == null)
                        {
                            break;
                        }
                        clanImage.idImage = idImage;
                        break;
                    }
                case -65:
                    {
                        InfoDlg2.hide();
                        int num83 = msg.reader().readInt();
                        sbyte b36 = msg.reader().readByte();
                        if (b36 == 0)
                        {
                            break;
                        }
                        if (Char2.myCharz().charID == num83)
                        {
                            isStopReadMessage = true;
                            GameScr2.lockTick = 500;
                            GameScr2.gI().center = null;
                            if (b36 == 0 || b36 == 1 || b36 == 3)
                            {
                                Teleport2 p = new Teleport2(Char2.myCharz().cx, Char2.myCharz().cy, Char2.myCharz().head, Char2.myCharz().cdir, 0, isMe: true, (b36 != 1) ? b36 : Char2.myCharz().cgender);
                                Teleport2.addTeleport(p);
                            }
                            if (b36 == 2)
                            {
                                GameScr2.lockTick = 50;
                                Char2.myCharz().hide();
                            }
                        }
                        else
                        {
                            Char2 char5 = GameScr2.findCharInMap(num83);
                            if ((b36 == 0 || b36 == 1 || b36 == 3) && char5 != null)
                            {
                                char5.isUsePlane = true;
                                Teleport2 teleport = new Teleport2(char5.cx, char5.cy, char5.head, char5.cdir, 0, isMe: false, (b36 != 1) ? b36 : char5.cgender);
                                teleport.id = num83;
                                Teleport2.addTeleport(teleport);
                            }
                            if (b36 == 2)
                            {
                                char5.hide();
                            }
                        }
                        break;
                    }
                case -64:
                    {
                        int num19 = msg.reader().readInt();
                        int num20 = msg.reader().readUnsignedByte();
                        @char = null;
                        @char = ((num19 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num19) : Char2.myCharz());
                        if (@char == null)
                        {
                            return;
                        }
                        @char.bag = num20;
                        for (int num21 = 0; num21 < 54; num21++)
                        {
                            @char.removeEffChar(0, 201 + num21);
                        }
                        if (@char.bag >= 201 && @char.bag < 255)
                        {
                            Effect2_ effect = new Effect2_(@char.bag, @char, 2, -1, 10, 1);
                            effect.typeEff = 5;
                            @char.addEffChar(effect);
                        }
                        break;
                    }
                case -63:
                    {
                        short id = msg.reader().readUnsignedByte();
                        sbyte size = msg.reader().readByte();
                        int[] idImages = new int[size];

                        if (size > 0)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                idImages[i] = msg.reader().readShort();
                            }
                        }

                        short idNew;
                        try
                        {
                            idNew = msg.reader().readShort();
                        }
                        catch
                        {
                            idNew = id;
                        }
                        if (size > 0)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                try
                                {
                                    idImages[i] = msg.reader().readInt();
                                }
                                catch
                                {
                                }
                            }
                        }

                        ClanImage2 clanImage3 = new()
                        {
                            ID = idNew,
                            idImage = idImages
                        };
                        if (size > 0)
                        {
                            ClanImage2.idImages.put(id + string.Empty, clanImage3);
                        }
                        break;
                    }
                case -57:
                    {
                        string strInvite = msg.reader().readUTF();
                        int clanID = msg.reader().readInt();
                        int code = msg.reader().readInt();
                        GameScr2.gI().clanInvite(strInvite, clanID, code);
                        break;
                    }
                case -51:
                    InfoDlg2.hide();
                    readClanMsg(msg, 0);
                    if (GameCanvas2.panel.isMessage && GameCanvas2.panel.type == 5)
                    {
                        GameCanvas2.panel.initTabClans();
                    }
                    break;
                case -53:
                    {
                        InfoDlg2.hide();
                        bool flag6 = false;
                        int num74 = msg.reader().readInt();
                        if (num74 == -1)
                        {
                            flag6 = true;
                            Char2.myCharz().clan = null;
                            ClanMessage2.vMessage.removeAllElements();
                            if (GameCanvas2.panel.member != null)
                            {
                                GameCanvas2.panel.member.removeAllElements();
                            }
                            if (GameCanvas2.panel.myMember != null)
                            {
                                GameCanvas2.panel.myMember.removeAllElements();
                            }
                            if (GameCanvas2.currentScreen == GameScr2.gI())
                            {
                                GameCanvas2.panel.setTabClans();
                            }
                            return;
                        }
                        GameCanvas2.panel.tabIcon = null;
                        if (Char2.myCharz().clan == null)
                        {
                            Char2.myCharz().clan = new Clan2();
                        }
                        Char2.myCharz().clan.ID = num74;
                        Char2.myCharz().clan.name = msg.reader().readUTF();
                        Char2.myCharz().clan.slogan = msg.reader().readUTF();
                        Char2.myCharz().clan.imgID = msg.reader().readUnsignedByte();
                        Char2.myCharz().clan.powerPoint = msg.reader().readUTF();
                        Char2.myCharz().clan.leaderName = msg.reader().readUTF();
                        Char2.myCharz().clan.currMember = msg.reader().readUnsignedByte();
                        Char2.myCharz().clan.maxMember = msg.reader().readUnsignedByte();
                        Char2.myCharz().role = msg.reader().readByte();
                        Char2.myCharz().clan.clanPoint = msg.reader().readInt();
                        Char2.myCharz().clan.level = msg.reader().readByte();
                        GameCanvas2.panel.myMember = new MyVector2();
                        for (int num75 = 0; num75 < Char2.myCharz().clan.currMember; num75++)
                        {
                            Member2 member2 = new Member2();
                            member2.ID = msg.reader().readInt();
                            member2.head = msg.reader().readShort();
                            member2.headICON = msg.reader().readShort();
                            member2.leg = msg.reader().readShort();
                            member2.body = msg.reader().readShort();
                            member2.name = msg.reader().readUTF();
                            member2.role = msg.reader().readByte();
                            member2.powerPoint = msg.reader().readUTF();
                            member2.donate = msg.reader().readInt();
                            member2.receive_donate = msg.reader().readInt();
                            member2.clanPoint = msg.reader().readInt();
                            member2.curClanPoint = msg.reader().readInt();
                            member2.joinTime = NinjaUtil2.getDate(msg.reader().readInt());
                            GameCanvas2.panel.myMember.addElement(member2);
                        }
                        int num76 = msg.reader().readUnsignedByte();
                        for (int num77 = 0; num77 < num76; num77++)
                        {
                            readClanMsg(msg, -1);
                        }
                        if (GameCanvas2.panel.isSearchClan || GameCanvas2.panel.isViewMember || GameCanvas2.panel.isMessage)
                        {
                            GameCanvas2.panel.setTabClans();
                        }
                        if (flag6)
                        {
                            GameCanvas2.panel.setTabClans();
                        }
                        break;
                    }
                case -52:
                    {
                        sbyte b34 = msg.reader().readByte();
                        if (b34 == 0)
                        {
                            Member2 member3 = new Member2();
                            member3.ID = msg.reader().readInt();
                            member3.head = msg.reader().readShort();
                            member3.headICON = msg.reader().readShort();
                            member3.leg = msg.reader().readShort();
                            member3.body = msg.reader().readShort();
                            member3.name = msg.reader().readUTF();
                            member3.role = msg.reader().readByte();
                            member3.powerPoint = msg.reader().readUTF();
                            member3.donate = msg.reader().readInt();
                            member3.receive_donate = msg.reader().readInt();
                            member3.clanPoint = msg.reader().readInt();
                            member3.joinTime = NinjaUtil2.getDate(msg.reader().readInt());
                            if (GameCanvas2.panel.myMember == null)
                            {
                                GameCanvas2.panel.myMember = new MyVector2();
                            }
                            GameCanvas2.panel.myMember.addElement(member3);
                            GameCanvas2.panel.initTabClans();
                        }
                        if (b34 == 1)
                        {
                            GameCanvas2.panel.myMember.removeElementAt(msg.reader().readByte());
                            GameCanvas2.panel.currentListLength--;
                            GameCanvas2.panel.initTabClans();
                        }
                        if (b34 == 2)
                        {
                            Member2 member4 = new Member2();
                            member4.ID = msg.reader().readInt();
                            member4.head = msg.reader().readShort();
                            member4.headICON = msg.reader().readShort();
                            member4.leg = msg.reader().readShort();
                            member4.body = msg.reader().readShort();
                            member4.name = msg.reader().readUTF();
                            member4.role = msg.reader().readByte();
                            member4.powerPoint = msg.reader().readUTF();
                            member4.donate = msg.reader().readInt();
                            member4.receive_donate = msg.reader().readInt();
                            member4.clanPoint = msg.reader().readInt();
                            member4.joinTime = NinjaUtil2.getDate(msg.reader().readInt());
                            for (int num78 = 0; num78 < GameCanvas2.panel.myMember.size(); num78++)
                            {
                                Member2 member5 = (Member2)GameCanvas2.panel.myMember.elementAt(num78);
                                if (member5.ID == member4.ID)
                                {
                                    if (Char2.myCharz().charID == member4.ID)
                                    {
                                        Char2.myCharz().role = member4.role;
                                    }
                                    Member2 o = member4;
                                    GameCanvas2.panel.myMember.removeElement(member5);
                                    GameCanvas2.panel.myMember.insertElementAt(o, num78);
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case -50:
                    {
                        InfoDlg2.hide();
                        GameCanvas2.panel.member = new MyVector2();
                        sbyte b22 = msg.reader().readByte();
                        for (int num49 = 0; num49 < b22; num49++)
                        {
                            Member2 member = new Member2();
                            member.ID = msg.reader().readInt();
                            member.head = msg.reader().readShort();
                            member.headICON = msg.reader().readShort();
                            member.leg = msg.reader().readShort();
                            member.body = msg.reader().readShort();
                            member.name = msg.reader().readUTF();
                            member.role = msg.reader().readByte();
                            member.powerPoint = msg.reader().readUTF();
                            member.donate = msg.reader().readInt();
                            member.receive_donate = msg.reader().readInt();
                            member.clanPoint = msg.reader().readInt();
                            member.joinTime = NinjaUtil2.getDate(msg.reader().readInt());
                            GameCanvas2.panel.member.addElement(member);
                        }
                        GameCanvas2.panel.isViewMember = true;
                        GameCanvas2.panel.isSearchClan = false;
                        GameCanvas2.panel.isMessage = false;
                        GameCanvas2.panel.currentListLength = GameCanvas2.panel.member.size() + 2;
                        GameCanvas2.panel.initTabClans();
                        break;
                    }
                case -47:
                    {
                        InfoDlg2.hide();
                        sbyte b69 = msg.reader().readByte();
                        if (b69 == 0)
                        {
                            GameCanvas2.panel.clanReport = mResources2.cannot_find_clan;
                            GameCanvas2.panel.clans = null;
                        }
                        else
                        {
                            GameCanvas2.panel.clans = new Clan2[b69];
                            for (int num169 = 0; num169 < GameCanvas2.panel.clans.Length; num169++)
                            {
                                GameCanvas2.panel.clans[num169] = new Clan2();
                                GameCanvas2.panel.clans[num169].ID = msg.reader().readInt();
                                GameCanvas2.panel.clans[num169].name = msg.reader().readUTF();
                                GameCanvas2.panel.clans[num169].slogan = msg.reader().readUTF();
                                GameCanvas2.panel.clans[num169].imgID = msg.reader().readUnsignedByte();
                                GameCanvas2.panel.clans[num169].powerPoint = msg.reader().readUTF();
                                GameCanvas2.panel.clans[num169].leaderName = msg.reader().readUTF();
                                GameCanvas2.panel.clans[num169].currMember = msg.reader().readUnsignedByte();
                                GameCanvas2.panel.clans[num169].maxMember = msg.reader().readUnsignedByte();
                                GameCanvas2.panel.clans[num169].date = msg.reader().readInt();
                            }
                        }
                        GameCanvas2.panel.isSearchClan = true;
                        GameCanvas2.panel.isViewMember = false;
                        GameCanvas2.panel.isMessage = false;
                        if (GameCanvas2.panel.isSearchClan)
                        {
                            GameCanvas2.panel.initTabClans();
                        }
                        break;
                    }
                case -46:
                    {
                        InfoDlg2.hide();
                        sbyte type = msg.reader().readByte();
                        if (type == 1 || type == 3)
                        {
                            GameCanvas2.endDlg();
                            ClanImage2.vClanImage.removeAllElements();
                            int size = msg.reader().readUnsignedByte();
                            for (int i = 0; i < size; i++)
                            {
                                byte id = msg.reader().readUnsignedByte();
                                string name = msg.reader().readUTF();
                                int xu = msg.reader().readInt();
                                int luong = msg.reader().readInt();

                                ClanImage2 clanImage2 = new()
                                {
                                    ID = id,
                                    name = name,
                                    xu = xu,
                                    luong = luong
                                };

                                if (!ClanImage2.isExistClanImage(clanImage2.ID))
                                {
                                    ClanImage2.addClanImage(clanImage2);
                                    continue;
                                }
                                ClanImage2.getClanImage((short)clanImage2.ID).name = clanImage2.name;
                                ClanImage2.getClanImage((short)clanImage2.ID).xu = clanImage2.xu;
                                ClanImage2.getClanImage((short)clanImage2.ID).luong = clanImage2.luong;
                            }
                            if (Char2.myCharz().clan != null)
                            {
                                GameCanvas2.panel.changeIcon();
                            }
                        }
                        if (type == 4)
                        {
                            Char2.myCharz().clan.imgID = msg.reader().readUnsignedByte();
                            Char2.myCharz().clan.slogan = msg.reader().readUTF();
                        }
                        break;
                    }
                case -61:
                    {
                        int num105 = msg.reader().readInt();
                        if (num105 != Char2.myCharz().charID)
                        {
                            if (GameScr2.findCharInMap(num105) != null)
                            {
                                GameScr2.findCharInMap(num105).clanID = msg.reader().readInt();
                                if (GameScr2.findCharInMap(num105).clanID == -2)
                                {
                                    GameScr2.findCharInMap(num105).isCopy = true;
                                }
                            }
                        }
                        else if (Char2.myCharz().clan != null)
                        {
                            Char2.myCharz().clan.ID = msg.reader().readInt();
                        }
                        break;
                    }
                case -42:
                    Char2.myCharz().cHPGoc = msg.readLong();
                    Char2.myCharz().cMPGoc = msg.readLong();
                    Char2.myCharz().cDamGoc = msg.readLong();
                    Char2.myCharz().cHPFull = msg.readLong();
                    Char2.myCharz().cMPFull = msg.readLong();
                    Char2.myCharz().cHP = msg.readLong();
                    Char2.myCharz().cMP = msg.readLong();
                    Char2.myCharz().cspeed = msg.reader().readByte();
                    Char2.myCharz().hpFrom1000TiemNang = msg.reader().readByte();
                    Char2.myCharz().mpFrom1000TiemNang = msg.reader().readByte();
                    Char2.myCharz().damFrom1000TiemNang = msg.reader().readByte();
                    Char2.myCharz().cDamFull = msg.readLong();
                    Char2.myCharz().cDefull = msg.reader().readInt();
                    Char2.myCharz().cCriticalFull = msg.reader().readByte();
                    Char2.myCharz().cTiemNang = msg.reader().readLong();
                    Char2.myCharz().expForOneAdd = msg.reader().readShort();
                    Char2.myCharz().cDefGoc = msg.reader().readShort();
                    Char2.myCharz().cCriticalGoc = msg.reader().readByte();

                    try
                    {
                        Char2.myCharz().tlDef = msg.readInt3Byte();
                        Char2.myCharz().tlPst = msg.readInt3Byte();
                        Char2.myCharz().tlNeDon = msg.readInt3Byte();
                        Char2.myCharz().tlHutHp = msg.readInt3Byte();
                        Char2.myCharz().tlHutMp = msg.readInt3Byte();

                        Char2.myCharz().tileGiamTDHS = msg.readInt3Byte();
                        Char2.myCharz().timeGiamTDHS = msg.readInt3Byte();
                        Char2.myCharz().khangTDHS = msg.reader().readBool();
                        Char2.myCharz().isKhongLanh = msg.reader().readBool();
                        Char2.myCharz().wearingVoHinh = msg.reader().readBool();
                        Char2.myCharz().teleport = msg.reader().readBool();
                    }
                    catch
                    {
                        Char2.myCharz().tlDef = 0;
                        Char2.myCharz().tlPst = 0;
                        Char2.myCharz().tlNeDon = 0;
                        Char2.myCharz().tlHutHp = 0;
                        Char2.myCharz().tlHutMp = 0;

                        Char2.myCharz().tileGiamTDHS = 0;
                        Char2.myCharz().timeGiamTDHS = 0;
                        Char2.myCharz().khangTDHS = false;
                        Char2.myCharz().isKhongLanh = false;
                        Char2.myCharz().wearingVoHinh = false;
                        Char2.myCharz().teleport = false;
                    }

                    InfoDlg2.hide();
                    break;
                case 1:
                    {
                        bool flag9 = msg.reader().readBool();
                        Res2.outz("isRes= " + flag9);
                        if (!flag9)
                        {
                            GameCanvas2.startOKDlg(msg.reader().readUTF());
                            break;
                        }
                        GameCanvas2.loginScr.isLogin2 = false;
                        Rms2.saveRMSString("userAo" + ServerListScreen2.ipSelect, string.Empty);
                        GameCanvas2.endDlg();
                        GameCanvas2.loginScr.doLogin();
                        break;
                    }
                case 2:
                    Char2.isLoadingMap = false;
                    LoginScr2.isLoggingIn = false;
                    if (!GameScr2.isLoadAllData)
                    {
                        GameScr2.gI().initSelectChar();
                    }
                    // BgItem2.clearHashTable();
                    GameCanvas2.endDlg();
                    CreateCharScr2.isCreateChar = true;
                    CreateCharScr2.gI().switchToMe();
                    break;
                case -107:
                    {
                        sbyte b21 = msg.reader().readByte();
                        if (b21 == 0)
                        {
                            Char2.myCharz().havePet = false;
                        }
                        if (b21 == 1)
                        {
                            Char2.myCharz().havePet = true;
                        }
                        if (b21 != 2)
                        {
                            break;
                        }
                        InfoDlg2.hide();
                        Char2.myPetz().head = msg.reader().readShort();
                        Char2.myPetz().setDefaultPart();
                        int num40 = msg.reader().readUnsignedByte();
                        Char2.myPetz().arrItemBody = new Item2[num40];
                        for (int num41 = 0; num41 < num40; num41++)
                        {
                            short num42 = msg.reader().readShort();
                            if (num42 == -1)
                            {
                                continue;
                            }
                            Char2.myPetz().arrItemBody[num41] = new Item2
                            {
                                template = ItemTemplates2.get(num42)
                            };
                            int num43 = Char2.myPetz().arrItemBody[num41].template.type;
                            Char2.myPetz().arrItemBody[num41].quantity = msg.reader().readInt();
                            Char2.myPetz().arrItemBody[num41].info = msg.reader().readUTF();
                            Char2.myPetz().arrItemBody[num41].content = msg.reader().readUTF();
                            int num44 = msg.reader().readUnsignedByte();
                            if (num44 != 0)
                            {
                                Char2.myPetz().arrItemBody[num41].itemOption = new ItemOption2[num44];
                                for (int num45 = 0; num45 < Char2.myPetz().arrItemBody[num41].itemOption.Length; num45++)
                                {
                                    int num46 = msg.reader().readUnsignedByte();
                                    int param3 = msg.reader().readUnsignedShort();
                                    if (num46 != -1)
                                    {
                                        Char2.myPetz().arrItemBody[num41].itemOption[num45] = new ItemOption2(num46, param3);
                                    }
                                }
                            }
                            switch (num43)
                            {
                                case 0:
                                    Char2.myPetz().body = Char2.myPetz().arrItemBody[num41].template.part;
                                    break;
                                case 1:
                                    Char2.myPetz().leg = Char2.myPetz().arrItemBody[num41].template.part;
                                    break;
                            }
                        }
                        Char2.myPetz().cHP = msg.readLong();
                        Char2.myPetz().cHPFull = msg.readLong();
                        Char2.myPetz().cMP = msg.readLong();
                        Char2.myPetz().cMPFull = msg.readLong();
                        Char2.myPetz().cDamFull = msg.readLong();
                        Char2.myPetz().cName = msg.reader().readUTF();
                        Char2.myPetz().currStrLevel = msg.reader().readUTF();
                        Char2.myPetz().cPower = msg.reader().readLong();
                        Char2.myPetz().cTiemNang = msg.reader().readLong();
                        Char2.myPetz().petStatus = msg.reader().readByte();
                        Char2.myPetz().cStamina = msg.reader().readShort();
                        Char2.myPetz().cMaxStamina = msg.reader().readShort();
                        Char2.myPetz().cCriticalFull = msg.reader().readByte();
                        Char2.myPetz().cDefull = msg.reader().readShort();
                        Char2.myPetz().arrPetSkill = new Skill2[msg.reader().readByte()];
                        for (int num47 = 0; num47 < Char2.myPetz().arrPetSkill.Length; num47++)
                        {
                            short num48 = msg.reader().readShort();
                            if (num48 != -1)
                            {
                                Char2.myPetz().arrPetSkill[num47] = Skills2.get(num48);
                                continue;
                            }
                            Char2.myPetz().arrPetSkill[num47] = new Skill2();
                            Char2.myPetz().arrPetSkill[num47].template = null;
                            Char2.myPetz().arrPetSkill[num47].moreInfo = msg.reader().readUTF();
                        }
                        if (!MainMod2.userOpenPet)
                        {
                            return;
                        }
                        if (GameCanvas2.w > 2 * Panel2.WIDTH_PANEL)
                        {
                            GameCanvas2.panel2 = new Panel2();
                            GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                            GameCanvas2.panel2.setTypeBodyOnly();
                            GameCanvas2.panel2.show();
                            GameCanvas2.panel.setTypePetMain();
                            GameCanvas2.panel.show();
                            MainMod2.userOpenPet = false;
                        }
                        else
                        {
                            GameCanvas2.panel.tabName[21] = mResources2.petMainTab;
                            GameCanvas2.panel.setTypePetMain();
                            GameCanvas2.panel.show();
                            MainMod2.userOpenPet = false;
                        }
                        break;
                    }
                case 3:
                    {
                        sbyte type = msg.reader().readByte();
                        if (type == 0)
                        {
                            Char2.myCharz().havePet2 = false;
                        }
                        if (type == 1)
                        {
                            Char2.myCharz().havePet2 = true;
                        }
                        if (type != 2)
                        {
                            break;
                        }
                        InfoDlg2.hide();

                        long hpg = msg.readLong();
                        long mpg = msg.readLong();
                        long dameg = msg.readLong();
                        int defg = msg.reader().readInt();
                        int critg = msg.reader().readInt();

                        Char2.MyPet2z().cHPGoc = hpg;
                        Char2.MyPet2z().cMPGoc = mpg;
                        Char2.MyPet2z().cDamGoc = dameg;
                        Char2.MyPet2z().cDefGoc = defg;
                        Char2.MyPet2z().cCriticalGoc = critg;

                        Char2.MyPet2z().head = msg.reader().readShort();
                        Char2.MyPet2z().setDefaultPart();
                        int arrBodySz = msg.reader().readUnsignedByte();
                        Char2.MyPet2z().arrItemBody = new Item2[arrBodySz];
                        for (int i = 0; i < arrBodySz; i++)
                        {
                            short tempId = msg.reader().readShort();
                            if (tempId == -1)
                            {
                                continue;
                            }
                            Char2.MyPet2z().arrItemBody[i] = new Item2
                            {
                                template = ItemTemplates2.get(tempId)
                            };
                            int num43 = Char2.MyPet2z().arrItemBody[i].template.type;
                            Char2.MyPet2z().arrItemBody[i].quantity = msg.reader().readInt();
                            Char2.MyPet2z().arrItemBody[i].info = msg.reader().readUTF();
                            Char2.MyPet2z().arrItemBody[i].content = msg.reader().readUTF();
                            int num44 = msg.reader().readUnsignedByte();
                            if (num44 != 0)
                            {
                                Char2.MyPet2z().arrItemBody[i].itemOption = new ItemOption2[num44];
                                for (int num45 = 0; num45 < Char2.MyPet2z().arrItemBody[i].itemOption.Length; num45++)
                                {
                                    int num46 = msg.reader().readUnsignedByte();
                                    int param3 = msg.reader().readUnsignedShort();
                                    if (num46 != -1)
                                    {
                                        Char2.MyPet2z().arrItemBody[i].itemOption[num45] = new ItemOption2(num46, param3);
                                    }
                                }
                            }
                            switch (num43)
                            {
                                case 0:
                                    Char2.MyPet2z().body = Char2.MyPet2z().arrItemBody[i].template.part;
                                    break;
                                case 1:
                                    Char2.MyPet2z().leg = Char2.MyPet2z().arrItemBody[i].template.part;
                                    break;
                            }
                        }
                        Char2.MyPet2z().cHP = msg.readLong();
                        Char2.MyPet2z().cHPFull = msg.readLong();
                        Char2.MyPet2z().cMP = msg.readLong();
                        Char2.MyPet2z().cMPFull = msg.readLong();
                        Char2.MyPet2z().cDamFull = msg.readLong();
                        Char2.MyPet2z().cName = msg.reader().readUTF();
                        Char2.MyPet2z().currStrLevel = msg.reader().readUTF();
                        Char2.MyPet2z().cPower = msg.reader().readLong();
                        Char2.MyPet2z().cTiemNang = msg.reader().readLong();
                        Char2.MyPet2z().petStatus = msg.reader().readByte();
                        Char2.MyPet2z().cStamina = msg.reader().readShort();
                        Char2.MyPet2z().cMaxStamina = msg.reader().readShort();
                        Char2.MyPet2z().cCriticalFull = msg.reader().readByte();
                        Char2.MyPet2z().cDefull = msg.reader().readShort();
                        Char2.MyPet2z().arrPetSkill = new Skill2[msg.reader().readByte()];
                        for (int num47 = 0; num47 < Char2.MyPet2z().arrPetSkill.Length; num47++)
                        {
                            short num48 = msg.reader().readShort();
                            if (num48 != -1)
                            {
                                Char2.MyPet2z().arrPetSkill[num47] = Skills2.get(num48);
                                continue;
                            }
                            Char2.MyPet2z().arrPetSkill[num47] = new Skill2
                            {
                                template = null,
                                moreInfo = msg.reader().readUTF()
                            };
                        }
                        if (!MainMod2.userOpenPet)
                        {
                            return;
                        }
                        if (GameCanvas2.w > 2 * Panel2.WIDTH_PANEL)
                        {
                            GameCanvas2.panel2 = new Panel2();
                            GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                            GameCanvas2.panel2.setTypeBodyOnly();
                            GameCanvas2.panel2.show();
                            GameCanvas2.panel.setTypePet2Main();
                            GameCanvas2.panel.show();
                            MainMod2.userOpenPet = false;
                        }
                        else
                        {
                            GameCanvas2.panel.tabName[21] = mResources2.petMainTab;
                            GameCanvas2.panel.setTypePet2Main();
                            GameCanvas2.panel.show();
                            MainMod2.userOpenPet = false;
                        }
                        break;
                    }
                case -109:
                    Char2.myPetz().cHPGoc = msg.readLong();
                    Char2.myPetz().cMPGoc = msg.readLong();
                    Char2.myPetz().cDamGoc = msg.readLong();
                    Char2.myPetz().cDefGoc = msg.reader().readInt();
                    Char2.myPetz().cCriticalGoc = msg.reader().readInt();
                    break;
                case -37:
                    {
                        sbyte b20 = msg.reader().readByte();
                        if (b20 != 0)
                        {
                            break;
                        }
                        Char2.myCharz().head = msg.reader().readShort();
                        Char2.myCharz().setDefaultPart();
                        int num33 = msg.reader().readUnsignedByte();
                        Res2.outz("num body = " + num33);
                        Char2.myCharz().arrItemBody = new Item2[num33];
                        for (int num34 = 0; num34 < num33; num34++)
                        {
                            short num35 = msg.reader().readShort();
                            if (num35 == -1)
                            {
                                continue;
                            }
                            Char2.myCharz().arrItemBody[num34] = new Item2();
                            Char2.myCharz().arrItemBody[num34].template = ItemTemplates2.get(num35);
                            int num36 = Char2.myCharz().arrItemBody[num34].template.type;
                            Char2.myCharz().arrItemBody[num34].quantity = msg.reader().readInt();
                            Char2.myCharz().arrItemBody[num34].info = msg.reader().readUTF();
                            Char2.myCharz().arrItemBody[num34].content = msg.reader().readUTF();
                            int num37 = msg.reader().readUnsignedByte();
                            if (num37 != 0)
                            {
                                Char2.myCharz().arrItemBody[num34].itemOption = new ItemOption2[num37];
                                for (int num38 = 0; num38 < Char2.myCharz().arrItemBody[num34].itemOption.Length; num38++)
                                {
                                    int num39 = msg.reader().readUnsignedByte();
                                    int param2 = msg.reader().readUnsignedShort();
                                    if (num39 != -1)
                                    {
                                        Char2.myCharz().arrItemBody[num34].itemOption[num38] = new ItemOption2(num39, param2);
                                    }
                                }
                            }
                            switch (num36)
                            {
                                case 0:
                                    Char2.myCharz().body = Char2.myCharz().arrItemBody[num34].template.part;
                                    break;
                                case 1:
                                    Char2.myCharz().leg = Char2.myCharz().arrItemBody[num34].template.part;
                                    break;
                            }
                        }
                        break;
                    }
                case -36:
                    {
                        sbyte b7 = msg.reader().readByte();
                        Res2.outz("cAction= " + b7);
                        if (b7 == 0)
                        {
                            int num11 = msg.reader().readUnsignedByte();
                            Char2.myCharz().arrItemBag = new Item2[num11];
                            GameScr2.hpPotion = 0;
                            Res2.outz("numC=" + num11);
                            for (int j = 0; j < num11; j++)
                            {
                                short num12 = msg.reader().readShort();
                                if (num12 == -1)
                                {
                                    continue;
                                }
                                Char2.myCharz().arrItemBag[j] = new Item2
                                {
                                    template = ItemTemplates2.get(num12),
                                    quantity = msg.reader().readInt(),
                                    info = msg.reader().readUTF(),
                                    content = msg.reader().readUTF(),
                                    indexUI = j
                                };
                                if (num12 == 457)
                                {
                                    Char2.myCharz().thoiVang = Char2.myCharz().arrItemBag[j].quantity;
                                }
                                int num13 = msg.reader().readUnsignedByte();
                                if (num13 != 0)
                                {
                                    Char2.myCharz().arrItemBag[j].itemOption = new ItemOption2[num13];
                                    for (int k = 0; k < Char2.myCharz().arrItemBag[j].itemOption.Length; k++)
                                    {
                                        int num14 = msg.reader().readUnsignedByte();
                                        int param = msg.reader().readUnsignedShort();
                                        if (num14 != -1)
                                        {
                                            Char2.myCharz().arrItemBag[j].itemOption[k] = new ItemOption2(num14, param);
                                        }
                                    }
                                    Char2.myCharz().arrItemBag[j].compare = GameCanvas2.panel.getCompare(Char2.myCharz().arrItemBag[j]);
                                }
                                if (Char2.myCharz().arrItemBag[j].template.type == 11)
                                {
                                }
                                if (Char2.myCharz().arrItemBag[j].template.type == 6)
                                {
                                    GameScr2.hpPotion += Char2.myCharz().arrItemBag[j].quantity;
                                }
                            }
                        }
                        if (b7 == 2)
                        {
                            sbyte b8 = msg.reader().readByte();
                            int quantity = msg.reader().readInt();
                            int quantity2 = Char2.myCharz().arrItemBag[b8].quantity;
                            Char2.myCharz().arrItemBag[b8].quantity = quantity;
                            if (Char2.myCharz().arrItemBag[b8].quantity < quantity2 && Char2.myCharz().arrItemBag[b8].template.type == 6)
                            {
                                GameScr2.hpPotion -= quantity2 - Char2.myCharz().arrItemBag[b8].quantity;
                            }
                            if (Char2.myCharz().arrItemBag[b8].quantity == 0)
                            {
                                Char2.myCharz().arrItemBag[b8] = null;
                            }
                        }
                        break;
                    }
                case -35:
                    {
                        sbyte b63 = msg.reader().readByte();
                        Res2.outz("cAction= " + b63);
                        if (b63 == 0)
                        {
                            int num154 = msg.reader().readUnsignedByte();
                            Char2.myCharz().arrItemBox = new Item2[num154];
                            GameCanvas2.panel.hasUse = 0;
                            for (int num155 = 0; num155 < num154; num155++)
                            {
                                short num156 = msg.reader().readShort();
                                if (num156 == -1)
                                {
                                    continue;
                                }
                                Char2.myCharz().arrItemBox[num155] = new Item2();
                                Char2.myCharz().arrItemBox[num155].template = ItemTemplates2.get(num156);
                                Char2.myCharz().arrItemBox[num155].quantity = msg.reader().readInt();
                                Char2.myCharz().arrItemBox[num155].info = msg.reader().readUTF();
                                Char2.myCharz().arrItemBox[num155].content = msg.reader().readUTF();
                                int num157 = msg.reader().readUnsignedByte();
                                if (num157 != 0)
                                {
                                    Char2.myCharz().arrItemBox[num155].itemOption = new ItemOption2[num157];
                                    for (int num158 = 0; num158 < Char2.myCharz().arrItemBox[num155].itemOption.Length; num158++)
                                    {
                                        int num159 = msg.reader().readUnsignedByte();
                                        int param6 = msg.reader().readUnsignedShort();
                                        if (num159 != -1)
                                        {
                                            Char2.myCharz().arrItemBox[num155].itemOption[num158] = new ItemOption2(num159, param6);
                                        }
                                    }
                                }
                                GameCanvas2.panel.hasUse++;
                            }
                        }
                        if (b63 == 1)
                        {
                            bool isBoxClan = false;
                            try
                            {
                                sbyte b64 = msg.reader().readByte();
                                if (b64 == 1)
                                {
                                    isBoxClan = true;
                                }
                            }
                            catch (Exception)
                            {
                            }
                            GameCanvas2.panel.setTypeBox();
                            GameCanvas2.panel.isBoxClan = isBoxClan;
                            GameCanvas2.panel.show();
                        }
                        if (b63 == 2)
                        {
                            sbyte b65 = msg.reader().readByte();
                            int quantity3 = msg.reader().readInt();
                            Char2.myCharz().arrItemBox[b65].quantity = quantity3;
                            if (Char2.myCharz().arrItemBox[b65].quantity == 0)
                            {
                                Char2.myCharz().arrItemBox[b65] = null;
                            }
                        }
                        break;
                    }
                case -45:
                    {
                        sbyte type = msg.reader().readByte();
                        int playerId = msg.reader().readInt();
                        short skillId = msg.reader().readShort();
                        if (type == 20)
                        {
                            sbyte typeFrame = msg.reader().readByte();
                            sbyte dir = msg.reader().readByte();
                            short timeGong = msg.reader().readShort();
                            bool isFly = msg.reader().readByte() != 0;
                            sbyte typePaint = msg.reader().readByte();
                            sbyte typeItem = -1;
                            try
                            {
                                typeItem = msg.reader().readByte();
                            }
                            catch (Exception)
                            {
                            }
                            sbyte level = -1;
                            try
                            {
                                level = msg.reader().readByte();
                            }
                            catch (Exception)
                            {
                            }
                            @char = (Char2.myCharz().charID != playerId) ? GameScr2.findCharInMap(playerId) : Char2.myCharz();
                            @char.SetSkillPaint_NEW(skillId, isFly, typeFrame, typePaint, dir, timeGong, typeItem, level);
                        }
                        if (type == 21)
                        {
                            Point2 point = new()
                            {
                                x = msg.reader().readShort(),
                                y = msg.reader().readShort()
                            };
                            short timeDame = msg.reader().readShort();
                            short rangeDame = msg.reader().readShort();
                            sbyte typePaint2 = 0;
                            sbyte typeItem2 = -1;
                            Point2[] targets = null;
                            @char = (Char2.myCharz().charID != playerId) ? GameScr2.findCharInMap(playerId) : Char2.myCharz();
                            try
                            {
                                typePaint2 = msg.reader().readByte();
                                sbyte targetSz = msg.reader().readByte();
                                targets = new Point2[targetSz];
                                for (int i = 0; i < targets.Length; i++)
                                {
                                    targets[i] = new Point2
                                    {
                                        type = msg.reader().readByte()
                                    };
                                    if (targets[i].type == 0)
                                    {
                                        targets[i].id = msg.reader().readByte();
                                    }
                                    else
                                    {
                                        targets[i].id = msg.reader().readInt();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                typeItem2 = msg.reader().readByte();
                            }
                            catch (Exception)
                            {
                            }
                            sbyte level = -1;
                            try
                            {
                                level = msg.reader().readByte();
                            }
                            catch (Exception)
                            {
                            }
                            @char.SetSkillPaint_STT(1, skillId, point, timeDame, rangeDame, typePaint2, targets, typeItem2, level);
                        }
                        if (type == 0)
                        {
                            Res2.outz("id use= " + playerId);
                            if (Char2.myCharz().charID != playerId)
                            {
                                @char = GameScr2.findCharInMap(playerId);
                                if ((TileMap2.tileTypeAtPixel(@char.cx, @char.cy) & 2) == 2)
                                {
                                    @char.setSkillPaint(GameScr2.sks[skillId], 0);
                                }
                                else
                                {
                                    @char.setSkillPaint(GameScr2.sks[skillId], 1);
                                    @char.delayFall = 20;
                                }
                            }
                            else
                            {
                                Char2.myCharz().saveLoadPreviousSkill();
                                Res2.outz("LOAD LAST SKILL");
                            }
                            sbyte b52 = msg.reader().readByte();
                            Res2.outz("npc size= " + b52);
                            for (int num120 = 0; num120 < b52; num120++)
                            {
                                sbyte b53 = msg.reader().readByte();
                                sbyte b54 = msg.reader().readByte();
                                Res2.outz("index= " + b53);
                                if (skillId >= 42 && skillId <= 48)
                                {
                                    ((Mob2)GameScr2.vMob.elementAt(b53)).isFreez = true;
                                    ((Mob2)GameScr2.vMob.elementAt(b53)).seconds = b54;
                                    ((Mob2)GameScr2.vMob.elementAt(b53)).last = (((Mob2)GameScr2.vMob.elementAt(b53)).cur = mSystem2.currentTimeMillis());
                                }
                            }
                            sbyte b55 = msg.reader().readByte();
                            for (int num121 = 0; num121 < b55; num121++)
                            {
                                int num122 = msg.reader().readInt();
                                sbyte b56 = msg.reader().readByte();
                                Res2.outz("player ID= " + num122 + " my ID= " + Char2.myCharz().charID);
                                if (skillId < 42 || skillId > 48)
                                {
                                    continue;
                                }
                                if (num122 == Char2.myCharz().charID)
                                {
                                    if (!Char2.myCharz().isFlyAndCharge && !Char2.myCharz().isStandAndCharge)
                                    {
                                        GameScr2.gI().isFreez = true;
                                        Char2.myCharz().isFreez = true;
                                        Char2.myCharz().freezSeconds = b56;
                                        Char2.myCharz().lastFreez = (Char2.myCharz().currFreez = mSystem2.currentTimeMillis());
                                        Char2.myCharz().isLockMove = true;
                                    }
                                }
                                else
                                {
                                    @char = GameScr2.findCharInMap(num122);
                                    if (@char != null && !@char.isFlyAndCharge && !@char.isStandAndCharge)
                                    {
                                        @char.isFreez = true;
                                        @char.seconds = b56;
                                        @char.freezSeconds = b56;
                                        @char.lastFreez = (GameScr2.findCharInMap(num122).currFreez = mSystem2.currentTimeMillis());
                                    }
                                }
                            }
                        }
                        if (type == 1 && playerId != Char2.myCharz().charID)
                        {
                            GameScr2.findCharInMap(playerId).isCharge = true;
                        }
                        if (type == 3)
                        {
                            if (playerId == Char2.myCharz().charID)
                            {
                                Char2.myCharz().isCharge = false;
                                SoundMn2.gI().taitaoPause();
                                Char2.myCharz().saveLoadPreviousSkill();
                            }
                            else
                            {
                                GameScr2.findCharInMap(playerId).isCharge = false;
                            }
                        }
                        if (type == 4)
                        {
                            if (playerId == Char2.myCharz().charID)
                            {
                                Char2.myCharz().seconds = msg.reader().readShort() - 1000;
                                Char2.myCharz().last = mSystem2.currentTimeMillis();
                                Res2.outz("second= " + Char2.myCharz().seconds + " last= " + Char2.myCharz().last);
                            }
                            else if (GameScr2.findCharInMap(playerId) != null)
                            {
                                switch (GameScr2.findCharInMap(playerId).cgender)
                                {
                                    case 0:
                                        GameScr2.findCharInMap(playerId).useChargeSkill(isGround: false);
                                        break;
                                    case 1:
                                        GameScr2.findCharInMap(playerId).useChargeSkill(isGround: true);
                                        break;
                                }
                                GameScr2.findCharInMap(playerId).skillTemplateId = skillId;
                                GameScr2.findCharInMap(playerId).isUseSkillAfterCharge = true;
                                GameScr2.findCharInMap(playerId).seconds = msg.reader().readShort();
                                GameScr2.findCharInMap(playerId).last = mSystem2.currentTimeMillis();
                            }
                        }
                        if (type == 5)
                        {
                            if (playerId == Char2.myCharz().charID)
                            {
                                Char2.myCharz().stopUseChargeSkill();
                            }
                            else if (GameScr2.findCharInMap(playerId) != null)
                            {
                                GameScr2.findCharInMap(playerId).stopUseChargeSkill();
                            }
                        }
                        if (type == 6)
                        {
                            if (playerId == Char2.myCharz().charID)
                            {
                                Char2.myCharz().setAutoSkillPaint(GameScr2.sks[skillId], 0);
                            }
                            else
                            {
                                GameScr2.findCharInMap(playerId)?.setAutoSkillPaint(GameScr2.sks[skillId], 0);
                            }
                            SoundMn2.gI().gong();
                        }
                        if (type == 7)
                        {
                            if (playerId == Char2.myCharz().charID)
                            {
                                Char2.myCharz().seconds = msg.reader().readShort();
                                Res2.outz("second = " + Char2.myCharz().seconds);
                                Char2.myCharz().last = mSystem2.currentTimeMillis();
                            }
                            else if (GameScr2.findCharInMap(playerId) != null)
                            {
                                GameScr2.findCharInMap(playerId).useChargeSkill(isGround: true);
                                GameScr2.findCharInMap(playerId).seconds = msg.reader().readShort();
                                GameScr2.findCharInMap(playerId).last = mSystem2.currentTimeMillis();
                                SoundMn2.gI().gong();
                            }
                        }
                        if (type == 8 && playerId != Char2.myCharz().charID && GameScr2.findCharInMap(playerId) != null)
                        {
                            GameScr2.findCharInMap(playerId).setAutoSkillPaint(GameScr2.sks[skillId], 0);
                        }
                        break;
                    }
                case -44:
                    {
                        bool flag5 = false;
                        if (GameCanvas2.w > 2 * Panel2.WIDTH_PANEL)
                        {
                            flag5 = true;
                        }
                        sbyte type_shop = msg.reader().readByte();
                        int tabSz = msg.reader().readUnsignedByte();
                        Char2.myCharz().arrItemShop = new Item2[tabSz][];
                        GameCanvas2.panel.shopTabName = new string[tabSz + ((!flag5) ? 1 : 0)][];
                        for (int num58 = 0; num58 < GameCanvas2.panel.shopTabName.Length; num58++)
                        {
                            GameCanvas2.panel.shopTabName[num58] = new string[2];
                        }
                        if (type_shop == 2)
                        {
                            GameCanvas2.panel.maxPageShop = new int[tabSz];
                            GameCanvas2.panel.currPageShop = new int[tabSz];
                        }
                        if (!flag5)
                        {
                            GameCanvas2.panel.shopTabName[tabSz] = mResources2.inventory;
                        }
                        for (int i = 0; i < tabSz; i++)
                        {
                            string[] name = Res2.split(msg.reader().readUTF(), "\n", 0);
                            if (type_shop == 2)
                            {
                                GameCanvas2.panel.maxPageShop[i] = msg.reader().readUnsignedByte();
                            }
                            if (name.Length == 2)
                            {
                                GameCanvas2.panel.shopTabName[i] = name;
                            }
                            if (name.Length == 1)
                            {
                                GameCanvas2.panel.shopTabName[i][0] = name[0];
                                GameCanvas2.panel.shopTabName[i][1] = string.Empty;
                            }
                            int itemSz = msg.reader().readUnsignedByte();
                            Char2.myCharz().arrItemShop[i] = new Item2[itemSz];
                            Panel2.strWantToBuy = mResources2.say_wat_do_u_want_to_buy;
                            if (type_shop == 1)
                            {
                                Panel2.strWantToBuy = mResources2.say_wat_do_u_want_to_buy2;
                            }
                            for (int num61 = 0; num61 < itemSz; num61++)
                            {
                                short itemId = msg.reader().readShort();
                                if (itemId == -1)
                                {
                                    continue;
                                }
                                Char2.myCharz().arrItemShop[i][num61] = new Item2();
                                Char2.myCharz().arrItemShop[i][num61].template = ItemTemplates2.get(itemId);
                                Res2.outz("name " + i + " = " + Char2.myCharz().arrItemShop[i][num61].template.name + " id templat= " + Char2.myCharz().arrItemShop[i][num61].template.id);
                                if (type_shop == 8)
                                {
                                    Char2.myCharz().arrItemShop[i][num61].buyCoin = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].buyGold = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].quantity = msg.reader().readInt();
                                }
                                else if (type_shop == 4) // Reward
                                {
                                    Char2.myCharz().arrItemShop[i][num61].reason = msg.reader().readUTF();
                                }
                                else if (type_shop == 0) // Normal
                                {
                                    Char2.myCharz().arrItemShop[i][num61].buyCoin = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].buyGold = msg.reader().readInt();

                                }
                                else if (type_shop == 1)
                                {
                                    Char2.myCharz().arrItemShop[i][num61].powerRequire = msg.reader().readLong();
                                }
                                else if (type_shop == 2) // Ky gui
                                {
                                    Char2.myCharz().arrItemShop[i][num61].itemId = msg.reader().readShort();
                                    Char2.myCharz().arrItemShop[i][num61].buyCoin = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].buyGold = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].buyType = msg.reader().readByte();
                                    Char2.myCharz().arrItemShop[i][num61].quantity = msg.reader().readInt();
                                    Char2.myCharz().arrItemShop[i][num61].isMe = msg.reader().readByte();
                                }
                                else if (type_shop == 3) // Special
                                {
                                    Char2.myCharz().arrItemShop[i][num61].isBuySpec = true;
                                    Char2.myCharz().arrItemShop[i][num61].iconSpec = msg.reader().readShort();
                                    Char2.myCharz().arrItemShop[i][num61].buySpec = msg.reader().readInt();
                                }
                                int optSz = msg.reader().readUnsignedByte();
                                if (optSz != 0)
                                {
                                    Char2.myCharz().arrItemShop[i][num61].itemOption = new ItemOption2[optSz];
                                    for (int j = 0; j < Char2.myCharz().arrItemShop[i][num61].itemOption.Length; j++)
                                    {
                                        int optId = msg.reader().readUnsignedByte();
                                        int param = msg.reader().readUnsignedShort();
                                        if (optId != -1)
                                        {
                                            Char2.myCharz().arrItemShop[i][num61].itemOption[j] = new ItemOption2(optId, param);
                                            Char2.myCharz().arrItemShop[i][num61].compare = GameCanvas2.panel.getCompare(Char2.myCharz().arrItemShop[i][num61]);
                                        }
                                    }
                                }
                                sbyte isNew = msg.reader().readByte();
                                Char2.myCharz().arrItemShop[i][num61].newItem = isNew != 0;
                                sbyte isCT = msg.reader().readByte();
                                if (isCT == 1)
                                {
                                    int headTemp = msg.reader().readShort();
                                    int bodyTemp = msg.reader().readShort();
                                    int legTemp = msg.reader().readShort();
                                    int bagTemp = msg.reader().readShort();
                                    Char2.myCharz().arrItemShop[i][num61].setPartTemp(headTemp, bodyTemp, legTemp, bagTemp);
                                }
                                if (MainMod.readNameKiGui && type_shop == 2)
                                {
                                    Char2.myCharz().arrItemShop[i][num61].nameNguoiKyGui = msg.reader().readUTF();
                                }
                            }
                        }
                        if (flag5)
                        {
                            if (type_shop != 2)
                            {
                                GameCanvas2.panel2 = new Panel2();
                                GameCanvas2.panel2.tabName[7] = new string[1][] { new string[1] { string.Empty } };
                                GameCanvas2.panel2.setTypeBodyOnly();
                                GameCanvas2.panel2.show();
                            }
                            else
                            {
                                GameCanvas2.panel2 = new Panel2();
                                GameCanvas2.panel2.setTypeKiGuiOnly();
                                GameCanvas2.panel2.show();
                            }
                        }
                        GameCanvas2.panel.tabName[1] = GameCanvas2.panel.shopTabName;
                        if (type_shop == 2)
                        {
                            string[][] array5 = GameCanvas2.panel.tabName[1];
                            if (flag5)
                            {
                                GameCanvas2.panel.tabName[1] = new string[4][]
                                {
                            array5[0],
                            array5[1],
                            array5[2],
                            array5[3]
                                };
                            }
                            else
                            {
                                GameCanvas2.panel.tabName[1] = new string[5][]
                                {
                            array5[0],
                            array5[1],
                            array5[2],
                            array5[3],
                            array5[4]
                                };
                            }
                        }
                        GameCanvas2.panel.setTypeShop(type_shop);
                        GameCanvas2.panel.show();
                        break;
                    }
                case -41:
                    {
                        sbyte b23 = msg.reader().readByte();
                        Char2.myCharz().strLevel = new string[b23];
                        for (int i = 0; i < b23; i++)
                        {
                            string text = msg.reader().readUTF();
                            Char2.myCharz().strLevel[i] = text;
                        }
                        Res2.outz("---   xong  level caption cmd : " + msg.command);
                        break;
                    }
                case -34:
                    {
                        sbyte b12 = msg.reader().readByte();
                        Res2.outz("act= " + b12);
                        if (b12 == 0 && GameScr2.gI().magicTree != null)
                        {
                            Res2.outz("toi duoc day");
                            MagicTree2 magicTree = GameScr2.gI().magicTree;
                            magicTree.id = msg.reader().readShort();
                            magicTree.name = msg.reader().readUTF();
                            magicTree.name = Res2.changeString(magicTree.name);
                            magicTree.x = msg.reader().readShort();
                            magicTree.y = msg.reader().readShort();
                            magicTree.level = msg.reader().readByte();
                            magicTree.currPeas = msg.reader().readShort();
                            magicTree.maxPeas = msg.reader().readShort();
                            Res2.outz("curr Peas= " + magicTree.currPeas);
                            magicTree.strInfo = msg.reader().readUTF();
                            magicTree.seconds = msg.reader().readInt();
                            magicTree.timeToRecieve = magicTree.seconds;
                            sbyte b13 = msg.reader().readByte();
                            magicTree.peaPostionX = new int[b13];
                            magicTree.peaPostionY = new int[b13];
                            for (int num22 = 0; num22 < b13; num22++)
                            {
                                magicTree.peaPostionX[num22] = msg.reader().readByte();
                                magicTree.peaPostionY[num22] = msg.reader().readByte();
                            }
                            magicTree.isUpdate = msg.reader().readBool();
                            magicTree.last = (magicTree.cur = mSystem2.currentTimeMillis());
                            GameScr2.gI().magicTree.isUpdateTree = true;
                        }
                        if (b12 == 1)
                        {
                            myVector = new MyVector2();
                            try
                            {
                                while (msg.reader().available() > 0)
                                {
                                    string caption = msg.reader().readUTF();
                                    myVector.addElement(new Command2(caption, GameCanvas2.instance, 888392, null));
                                }
                            }
                            catch (Exception ex4)
                            {
                                Cout2.println("Loi MAGIC_TREE " + ex4.ToString());
                            }
                            GameCanvas2.menu.startAt(myVector, 3);
                        }
                        if (b12 == 2)
                        {
                            GameScr2.gI().magicTree.remainPeas = msg.reader().readShort();
                            GameScr2.gI().magicTree.seconds = msg.reader().readInt();
                            GameScr2.gI().magicTree.last = (GameScr2.gI().magicTree.cur = mSystem2.currentTimeMillis());
                            GameScr2.gI().magicTree.isUpdateTree = true;
                            GameScr2.gI().magicTree.isPeasEffect = true;
                        }
                        break;
                    }
                case 11:
                    {
                        GameCanvas2.debug("SA9", 2);
                        int num9 = msg.reader().readByte();
                        sbyte b6 = msg.reader().readByte();
                        if (b6 != 0)
                        {
                            Mob2.arrMobTemplate[num9].data.readDataNewBoss(NinjaUtil2.readByteArray(msg), b6);
                        }
                        else
                        {
                            Mob2.arrMobTemplate[num9].data.readData(NinjaUtil2.readByteArray(msg));
                        }
                        for (int i = 0; i < GameScr2.vMob.size(); i++)
                        {
                            mob = (Mob2)GameScr2.vMob.elementAt(i);
                            if (mob.templateId == num9)
                            {
                                mob.w = Mob2.arrMobTemplate[num9].data.width;
                                mob.h = Mob2.arrMobTemplate[num9].data.height;
                            }
                        }
                        sbyte[] array2 = NinjaUtil2.readByteArray(msg);
                        Image2 img = Image2.createImage(array2, 0, array2.Length);
                        Mob2.arrMobTemplate[num9].data.img = img;
                        int num10 = msg.reader().readByte();
                        Mob2.arrMobTemplate[num9].data.typeData = num10;
                        if (num10 == 1 || num10 == 2)
                        {
                            readFrameBoss(msg, num9);
                        }
                        break;
                    }
                case -69:
                    Char2.myCharz().cMaxStamina = msg.reader().readShort();
                    break;
                case -68:
                    Char2.myCharz().cStamina = msg.reader().readShort();
                    break;
                case -67:
                    {
                        int iconId = msg.reader().readInt();
                        sbyte[] data = null;
                        try
                        {
                            data = NinjaUtil2.readByteArray(msg);
                        }
                        catch (Exception)
                        {
                            data = null;
                            SmallImage2.imgNew[iconId].img = Image2.createRGBImage(new int[1], 1, 1, bl: true);
                        }
                        // if (data != null && mGraphics2.zoomLevel > 1)
                        if (data != null)
                        {
                            Rms2.saveRMS(mGraphics2.zoomLevel + "Small" + iconId, data);
                            sbyte[] newArr = MainMod2.DecryptBytes(data);
                            SmallImage2.imgNew[iconId].img = createImage(newArr);
                        }
                        break;
                    }
                case -66:
                    {
                        short id2 = msg.reader().readShort();
                        sbyte[] data5 = NinjaUtil2.readByteArray(msg);
                        EffectData2 effDataById = Effect2_.getEffDataById(id2);
                        sbyte b62 = msg.reader().readSByte();
                        if (b62 == 0)
                        {
                            effDataById.readData(data5);
                        }
                        else
                        {
                            effDataById.readDataNewBoss(data5, b62);
                        }
                        sbyte[] array15 = NinjaUtil2.readByteArray(msg);
                        sbyte[] newArr = MainMod2.DecryptBytes(array15);
                        effDataById.img = Image2.createImage(newArr, 0, newArr.Length);
                        break;
                    }
                case -32:
                    {
                        short num131 = msg.reader().readShort();
                        int num132 = msg.reader().readInt();
                        sbyte[] array11 = null;
                        Image2 image = null;
                        try
                        {
                            array11 = new sbyte[num132];
                            for (int num133 = 0; num133 < num132; num133++)
                            {
                                array11[num133] = msg.reader().readByte();
                            }
                            //image = Image.createImage(array11, 0, num132);
                            //BgItem.imgNew.put(num131 + string.Empty, image);
                        }
                        catch (Exception)
                        {
                            array11 = null;
                            BgItem2.imgNew.put(num131 + string.Empty, Image2.createRGBImage(new int[1], 1, 1, bl: true));
                        }
                        if (array11 != null)
                        {
                            // if (mGraphics2.zoomLevel > 1)
                            // {
                            //     Rms2.saveRMS(mGraphics2.zoomLevel + "bgItem" + num131, array11);
                            // }
                            Rms2.saveRMS(mGraphics2.zoomLevel + "bgItem" + num131, array11);
                            sbyte[] newArr = MainMod2.DecryptBytes(array11);
                            image = Image2.createImage(newArr, 0, num132);
                            BgItem2.imgNew.put(num131 + string.Empty, image);
                            BgItemMn2.blendcurrBg(num131, image);
                        }
                        break;
                    }
                case 92:
                    {
                        if (GameCanvas2.currentScreen == GameScr2.instance)
                        {
                            GameCanvas2.endDlg();
                        }
                        string text4 = msg.reader().readUTF();
                        string str2 = msg.reader().readUTF();
                        str2 = Res2.changeString(str2);
                        string empty = string.Empty;
                        Char2 char8 = null;
                        sbyte b46 = 0;
                        if (!text4.Equals(string.Empty))
                        {
                            char8 = new Char2();
                            char8.charID = msg.reader().readInt();
                            char8.head = msg.reader().readShort();
                            char8.headICON = msg.reader().readShort();
                            char8.body = msg.reader().readShort();
                            char8.bag = msg.reader().readShort();
                            char8.leg = msg.reader().readShort();
                            b46 = msg.reader().readByte();
                            char8.cName = text4;
                            try
                            {
                                char8.isTichXanh = msg.reader().readByte() == 1;
                                char8.isTichDo = msg.reader().readByte() == 1;
                            }
                            catch (Exception)
                            {
                                char8.isTichXanh = false;
                                char8.isTichDo = false;
                            }
                        }
                        empty += str2;
                        InfoDlg2.hide();
                        if (text4.Equals(string.Empty))
                        {
                            GameScr2.info1.addInfo(empty, 0);
                            break;
                        }
                        GameScr2.info2.addInfoWithChar(empty, char8, (b46 == 0) ? true : false);
                        if (GameCanvas2.panel.isShow && GameCanvas2.panel.type == 8)
                        {
                            GameCanvas2.panel.initLogMessage();
                        }
                        break;
                    }
                case -26:
                    ServerListScreen2.testConnect = 2;
                    string msgDlg = msg.reader().readUTF();
                    if (msgDlg == "Vui lòng mở giới hạn sức mạnh" || msgDlg == "")
                    {
                        MainMod2.indexAutoPoint = -1;
                        MainMod2.pointIncrease = 0;
                        MainMod2.typePointForPet = 16;
                        GameScr2.info1.addInfo("Chỉ số đã đạt tối đa", 0);
                    }
                    GameCanvas2.startOKDlg(msgDlg);
                    InfoDlg2.hide();
                    LoginScr2.isContinueToLogin = false;
                    Char2.isLoadingMap = false;
                    if (GameCanvas2.currentScreen == GameCanvas2.loginScr)
                    {
                        GameCanvas2.serverScreen.switchToMe();
                    }
                    if (MainMod2.autoLogin != null)
                    {
                        MainMod2.autoLogin.waitToNextLogin = false;
                    }
                    break;
                case -25:
                    GameScr2.info1.addInfo(msg.reader().readUTF(), 0);
                    break;
                case 94:
                    GameScr2.info1.addInfo(msg.reader().readUTF(), 0);
                    break;
                case 47:
                    GameScr2.gI().resetButton();
                    break;
                case 81:
                    {
                        Mob2 mob5 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        mob5.isDisable = msg.reader().readBool();
                        break;
                    }
                case 82:
                    {
                        Mob2 mob5 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        mob5.isDontMove = msg.reader().readBool();
                        break;
                    }
                case 85:
                    {
                        Mob2 mob5 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        mob5.isFire = msg.reader().readBool();
                        break;
                    }
                case 86:
                    {
                        Mob2 mob5 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        mob5.isIce = msg.reader().readBool();
                        if (!mob5.isIce)
                        {
                            ServerEffect2.addServerEffect(77, mob5.x, mob5.y - 9, 1);
                        }
                        break;
                    }
                case 87:
                    {
                        Mob2 mob5 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        mob5.isWind = msg.reader().readBool();
                        break;
                    }
                case 56:
                    {
                        @char = null;
                        int charID = msg.reader().readInt();
                        if (charID == Char2.myCharz().charID)
                        {
                            bool flag3 = false;
                            @char = Char2.myCharz();
                            @char.cHP = msg.readLong();
                            long dameHit = msg.readLong();
                            if (dameHit != 0)
                            {
                                @char.doInjure();
                            }
                            try
                            {
                                flag3 = msg.reader().readBoolean();
                                sbyte effId = msg.reader().readByte();
                                if (effId != -1)
                                {
                                    EffecMn2.addEff(new Effect2_(effId, @char.cx, @char.cy, 3, 1, -1));
                                }
                            }
                            catch (Exception)
                            {
                            }
                            if (Char2.myCharz().cTypePk != 4)
                            {
                                if (dameHit == 0)
                                {
                                    GameScr2.startFlyText(mResources2.miss, @char.cx, @char.cy - @char.ch, 0, -3, mFont2.MISS_ME);
                                }
                                else
                                {
                                    GameScr2.startFlyText("-" + dameHit, @char.cx, @char.cy - @char.ch, 0, -3, flag3 ? mFont2.FATAL : mFont2.RED);
                                }
                            }
                        }
                        else
                        {
                            @char = GameScr2.findCharInMap(charID);
                            if (@char == null)
                            {
                                return;
                            }
                            @char.cHP = msg.readLong();
                            bool flag4 = false;
                            long dameHit1 = msg.readLong();
                            if (dameHit1 != 0)
                            {
                                @char.doInjure();
                            }
                            int num32 = 0;
                            try
                            {
                                flag4 = msg.reader().readBoolean();
                                sbyte effId = msg.reader().readByte();
                                if (effId != -1)
                                {
                                    EffecMn2.addEff(new Effect2_(effId, @char.cx, @char.cy, 3, 1, -1));
                                }
                            }
                            catch (Exception)
                            {
                            }
                            dameHit1 += num32;
                            if (@char.cTypePk != 4)
                            {
                                if (dameHit1 == 0)
                                {
                                    GameScr2.startFlyText(mResources2.miss, @char.cx, @char.cy - @char.ch, 0, -3, mFont2.MISS);
                                }
                                else
                                {
                                    GameScr2.startFlyText("-" + dameHit1, @char.cx, @char.cy - @char.ch, 0, -3, flag4 ? mFont2.FATAL : mFont2.ORANGE);
                                }
                            }
                        }
                        break;
                    }
                case 83:
                    {
                        int num18 = msg.reader().readInt();
                        @char = ((num18 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num18) : Char2.myCharz());
                        if (@char == null)
                        {
                            return;
                        }
                        Mob2 mobToAttack = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        if (@char.mobMe != null)
                        {
                            @char.mobMe.attackOtherMob(mobToAttack);
                        }
                        break;
                    }
                case 84:
                    {
                        int num18 = msg.reader().readInt();
                        if (num18 == Char2.myCharz().charID)
                        {
                            @char = Char2.myCharz();
                        }
                        else
                        {
                            @char = GameScr2.findCharInMap(num18);
                            if (@char == null)
                            {
                                return;
                            }
                        }
                        @char.cHP = @char.cHPFull;
                        @char.cMP = @char.cMPFull;
                        @char.cx = msg.reader().readShort();
                        @char.cy = msg.reader().readShort();
                        @char.liveFromDead();
                        break;
                    }
                case 46:
                    GameCanvas2.debug("SA5", 2);
                    Cout2.LogWarning("Controler RESET_POINT  " + Char2.ischangingMap);
                    Char2.isLockKey = false;
                    Char2.myCharz().setResetPoint(msg.reader().readShort(), msg.reader().readShort());
                    break;
                case -29:
                    messageNotLogin(msg);
                    break;
                case -28:
                    messageNotMap(msg);
                    break;
                case -30:
                    messageSubCommand(msg);
                    break;
                case 62:
                    @char = GameScr2.findCharInMap(msg.reader().readInt());
                    if (@char != null)
                    {
                        @char.killCharId = Char2.myCharz().charID;
                        Char2.myCharz().npcFocus = null;
                        Char2.myCharz().mobFocus = null;
                        Char2.myCharz().itemFocus = null;
                        Char2.myCharz().charFocus = @char;
                        Char2.isManualFocus = true;
                        GameScr2.info1.addInfo(@char.cName + mResources2.CUU_SAT, 0);
                    }
                    break;
                case 63:
                    Char2.myCharz().killCharId = msg.reader().readInt();
                    Char2.myCharz().npcFocus = null;
                    Char2.myCharz().mobFocus = null;
                    Char2.myCharz().itemFocus = null;
                    Char2.myCharz().charFocus = GameScr2.findCharInMap(Char2.myCharz().killCharId);
                    Char2.isManualFocus = true;
                    break;
                case 64:
                    GameCanvas2.debug("SZ5", 2);
                    @char = Char2.myCharz();
                    try
                    {
                        @char = GameScr2.findCharInMap(msg.reader().readInt());
                    }
                    catch (Exception ex2)
                    {
                        Cout2.println("Loi CLEAR_CUU_SAT " + ex2.ToString());
                    }
                    @char.killCharId = -9999;
                    break;
                case 39:
                    GameCanvas2.debug("SA49", 2);
                    GameScr2.gI().typeTradeOrder = 2;
                    if (GameScr2.gI().typeTrade >= 2 && GameScr2.gI().typeTradeOrder >= 2)
                    {
                        InfoDlg2.showWait();
                    }
                    break;
                case 57:
                    {
                        GameCanvas2.debug("SZ6", 2);
                        MyVector2 myVector2 = new MyVector2();
                        myVector2.addElement(new Command2(msg.reader().readUTF(), GameCanvas2.instance, 88817, null));
                        GameCanvas2.menu.startAt(myVector2, 3);
                        break;
                    }
                case 58:
                    {
                        int charId = msg.reader().readInt();
                        Char2 char10 = (charId != Char2.myCharz().charID) ? GameScr2.findCharInMap(charId) : Char2.myCharz();
                        char10.moveFast = new short[3];
                        char10.moveFast[0] = 0;
                        short x = msg.reader().readShort();
                        short y = msg.reader().readShort();
                        char10.moveFast[1] = x;
                        char10.moveFast[2] = y;
                        try
                        {
                            charId = msg.reader().readInt();
                            Char2 char11 = (charId != Char2.myCharz().charID) ? GameScr2.findCharInMap(charId) : Char2.myCharz();
                            char11.cx = x;
                            char11.cy = y;
                        }
                        catch (Exception ex25)
                        {
                            Cout2.println("Loi MOVE_FAST " + ex25.ToString());
                        }
                        break;
                    }
                case 88:
                    {
                        string info4 = msg.reader().readUTF();
                        short num170 = msg.reader().readShort();
                        GameCanvas2.inputDlg.show(info4, new Command2(mResources2.ACCEPT, GameCanvas2.instance, 88818, num170), TField2.INPUT_TYPE_ANY);
                        break;
                    }
                case 27:
                    {
                        myVector = new MyVector2();
                        string text7 = msg.reader().readUTF();
                        int num164 = msg.reader().readByte();
                        for (int num165 = 0; num165 < num164; num165++)
                        {
                            string caption4 = msg.reader().readUTF();
                            short num166 = msg.reader().readShort();
                            myVector.addElement(new Command2(caption4, GameCanvas2.instance, 88819, num166));
                        }
                        GameCanvas2.menu.startWithoutCloseButton(myVector, 3);
                        break;
                    }
                case 33:
                    {
                        InfoDlg2.hide();
                        GameCanvas2.clearKeyHold();
                        GameCanvas2.clearKeyPressed();
                        myVector = new MyVector2();
                        try
                        {
                            while (true)
                            {
                                string caption3 = msg.reader().readUTF();
                                myVector.addElement(new Command2(caption3, GameCanvas2.instance, 88822, null));
                            }
                        }
                        catch (Exception ex22)
                        {
                            Cout2.println("Loi OPEN_UI_MENU " + ex22.ToString());
                        }
                        if (Char2.myCharz().npcFocus == null)
                        {
                            return;
                        }
                        for (int num153 = 0; num153 < Char2.myCharz().npcFocus.template.menu.Length; num153++)
                        {
                            string[] array16 = Char2.myCharz().npcFocus.template.menu[num153];
                            myVector.addElement(new Command2(array16[0], GameCanvas2.instance, 88820, array16));
                        }
                        GameCanvas2.menu.startAt(myVector, 3);
                        break;
                    }
                case 40:
                    {
                        GameCanvas2.debug("SA52", 2);
                        GameCanvas2.taskTick = 150;
                        short taskId = msg.reader().readShort();
                        sbyte index3 = msg.reader().readByte();
                        string str3 = msg.reader().readUTF();
                        str3 = Res2.changeString(str3);
                        string str4 = msg.reader().readUTF();
                        str4 = Res2.changeString(str4);
                        string[] array12 = new string[msg.reader().readByte()];
                        string[] array13 = new string[array12.Length];
                        GameScr2.tasks = new int[array12.Length];
                        GameScr2.mapTasks = new int[array12.Length];
                        short[] array14 = new short[array12.Length];
                        short count = -1;
                        for (int num134 = 0; num134 < array12.Length; num134++)
                        {
                            string str5 = msg.reader().readUTF();
                            str5 = Res2.changeString(str5);
                            GameScr2.tasks[num134] = msg.reader().readByte();
                            GameScr2.mapTasks[num134] = msg.reader().readShort();
                            string str6 = msg.reader().readUTF();
                            str6 = Res2.changeString(str6);
                            array14[num134] = -1;
                            if (!str5.Equals(string.Empty))
                            {
                                array12[num134] = str5;
                                array13[num134] = str6;
                            }
                        }
                        try
                        {
                            count = msg.reader().readShort();
                            for (int num135 = 0; num135 < array12.Length; num135++)
                            {
                                array14[num135] = msg.reader().readShort();
                            }
                        }
                        catch (Exception ex21)
                        {
                            Cout2.println("Loi TASK_GET " + ex21.ToString());
                        }
                        Char2.myCharz().taskMaint = new Task2(taskId, index3, str3, str4, array12, array14, count, array13);
                        if (Char2.myCharz().npcFocus != null)
                        {
                            Npc2.clearEffTask();
                        }
                        Char2.taskAction(isNextStep: false);
                        break;
                    }
                case 41:
                    GameCanvas2.debug("SA53", 2);
                    GameCanvas2.taskTick = 100;
                    Res2.outz("TASK NEXT");
                    Char2.myCharz().taskMaint.index++;
                    Char2.myCharz().taskMaint.count = 0;
                    Npc2.clearEffTask();
                    Char2.taskAction(isNextStep: true);
                    break;
                case 50:
                    {
                        sbyte b59 = msg.reader().readByte();
                        Panel2.vGameInfo.removeAllElements();
                        for (int num130 = 0; num130 < b59; num130++)
                        {
                            GameInfo2 gameInfo = new GameInfo2();
                            gameInfo.id = msg.reader().readShort();
                            gameInfo.main = msg.reader().readUTF();
                            gameInfo.content = msg.reader().readUTF();
                            Panel2.vGameInfo.addElement(gameInfo);
                            bool hasRead = Rms2.loadRMSInt(gameInfo.id + string.Empty) != -1;
                            gameInfo.hasRead = hasRead;
                        }
                        break;
                    }
                case 43:
                    GameCanvas2.taskTick = 50;
                    GameCanvas2.debug("SA55", 2);
                    Char2.myCharz().taskMaint.count = msg.reader().readShort();
                    if (Char2.myCharz().npcFocus != null)
                    {
                        Npc2.clearEffTask();
                    }
                    try
                    {
                        short num127 = msg.reader().readShort();
                        short num128 = msg.reader().readShort();
                        Char2.myCharz().x_hint = num127;
                        Char2.myCharz().y_hint = num128;
                        Res2.outz("CMD   TASK_UPDATE:43_mapID =    x|y " + num127 + "|" + num128);
                        for (int num129 = 0; num129 < TileMap2.vGo.size(); num129++)
                        {
                            Res2.outz("===> " + TileMap2.vGo.elementAt(num129));
                        }
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 90:
                    GameCanvas2.debug("SA577", 2);
                    requestItemPlayer(msg);
                    break;
                case 29:
                    GameCanvas2.debug("SA58", 2);
                    GameScr2.gI().openUIZone(msg);
                    break;
                case -21:
                    {
                        GameCanvas2.debug("SA60", 2);
                        short itemMapID = msg.reader().readShort();
                        for (int num123 = 0; num123 < GameScr2.vItemMap.size(); num123++)
                        {
                            if (((ItemMap2)GameScr2.vItemMap.elementAt(num123)).itemMapID == itemMapID)
                            {
                                GameScr2.vItemMap.removeElementAt(num123);
                                break;
                            }
                        }
                        break;
                    }
                case -20:
                    {
                        GameCanvas2.debug("SA61", 2);
                        Char2.myCharz().itemFocus = null;
                        short itemMapID = msg.reader().readShort();
                        for (int num116 = 0; num116 < GameScr2.vItemMap.size(); num116++)
                        {
                            ItemMap2 itemMap2 = (ItemMap2)GameScr2.vItemMap.elementAt(num116);
                            if (itemMap2.itemMapID != itemMapID)
                            {
                                continue;
                            }
                            itemMap2.setPoint(Char2.myCharz().cx, Char2.myCharz().cy - 10);
                            string text5 = msg.reader().readUTF();
                            num = 0;
                            try
                            {
                                num = msg.reader().readShort();
                                if (itemMap2.template.type == 9)
                                {
                                    num = msg.reader().readShort();
                                    Char2.myCharz().xu += num;
                                    Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                                }
                                else if (itemMap2.template.type == 10)
                                {
                                    num = msg.reader().readShort();
                                    Char2.myCharz().luong += num;
                                    Char2.myCharz().luongStr = mSystem2.numberTostring(Char2.myCharz().luong);
                                }
                                else if (itemMap2.template.type == 34)
                                {
                                    num = msg.reader().readShort();
                                    Char2.myCharz().luongKhoa += num;
                                    Char2.myCharz().luongKhoaStr = mSystem2.numberTostring(Char2.myCharz().luongKhoa);
                                }
                            }
                            catch (Exception)
                            {
                            }
                            if (text5.Equals(string.Empty))
                            {
                                if (itemMap2.template.type == 9)
                                {
                                    GameScr2.startFlyText(((num >= 0) ? "+" : string.Empty) + num, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch, 0, -2, mFont2.YELLOW);
                                    SoundMn2.gI().getItem();
                                }
                                else if (itemMap2.template.type == 10)
                                {
                                    GameScr2.startFlyText(((num >= 0) ? "+" : string.Empty) + num, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch, 0, -2, mFont2.GREEN);
                                    SoundMn2.gI().getItem();
                                }
                                else if (itemMap2.template.type == 34)
                                {
                                    GameScr2.startFlyText(((num >= 0) ? "+" : string.Empty) + num, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch, 0, -2, mFont2.RED);
                                    SoundMn2.gI().getItem();
                                }
                                else
                                {
                                    GameScr2.info1.addInfo(mResources2.you_receive + " " + ((num <= 0) ? string.Empty : (num + " ")) + itemMap2.template.name, 0);
                                    SoundMn2.gI().getItem();
                                }
                                if (num > 0 && Char2.myCharz().petFollow != null && Char2.myCharz().petFollow.smallID == 4683)
                                {
                                    ServerEffect2.addServerEffect(55, Char2.myCharz().petFollow.cmx, Char2.myCharz().petFollow.cmy, 1);
                                    ServerEffect2.addServerEffect(55, Char2.myCharz().cx, Char2.myCharz().cy, 1);
                                }
                            }
                            else if (text5.Length == 1)
                            {
                                Cout2.LogError3("strInf.Length =1:  " + text5);
                            }
                            else
                            {
                                GameScr2.info1.addInfo(text5, 0);
                            }
                            break;
                        }
                        break;
                    }
                case -19:
                    {
                        short itemMapID = msg.reader().readShort();
                        @char = GameScr2.findCharInMap(msg.reader().readInt());
                        for (int num115 = 0; num115 < GameScr2.vItemMap.size(); num115++)
                        {
                            ItemMap2 itemMap = (ItemMap2)GameScr2.vItemMap.elementAt(num115);
                            if (itemMap.itemMapID != itemMapID)
                            {
                                continue;
                            }
                            if (@char == null)
                            {
                                return;
                            }
                            itemMap.setPoint(@char.cx, @char.cy - 10);
                            if (itemMap.x < @char.cx)
                            {
                                @char.cdir = -1;
                            }
                            else if (itemMap.x > @char.cx)
                            {
                                @char.cdir = 1;
                            }
                            break;
                        }
                        break;
                    }
                case -18:
                    {
                        GameCanvas2.debug("SA63", 2);
                        int num114 = msg.reader().readByte();
                        GameScr2.vItemMap.addElement(new ItemMap2(msg.reader().readShort(), Char2.myCharz().arrItemBag[num114].template.id, Char2.myCharz().cx, Char2.myCharz().cy, msg.reader().readShort(), msg.reader().readShort()));
                        Char2.myCharz().arrItemBag[num114] = null;
                        break;
                    }
                case 68:
                    {
                        short itemMapID = msg.reader().readShort();
                        short itemTemplateID = msg.reader().readShort();
                        int x = msg.reader().readShort();
                        int y = msg.reader().readShort();
                        int num107 = msg.reader().readInt();
                        short r = 0;
                        if (num107 == -2)
                        {
                            r = msg.reader().readShort();
                        }
                        ItemMap2 o2 = new(num107, itemMapID, itemTemplateID, x, y, r);
                        GameScr2.vItemMap.addElement(o2);
                        break;
                    }
                case 69:
                    SoundMn2.IsDelAcc = ((msg.reader().readByte() != 0) ? true : false);
                    break;
                case -14:
                    @char = GameScr2.findCharInMap(msg.reader().readInt());
                    if (@char == null)
                    {
                        return;
                    }
                    GameScr2.vItemMap.addElement(new ItemMap2(msg.reader().readShort(), msg.reader().readShort(), @char.cx, @char.cy, msg.reader().readShort(), msg.reader().readShort()));
                    break;
                case -22:
                    Char2.isLockKey = true;
                    Char2.ischangingMap = true;
                    GameScr2.gI().timeStartMap = 0;
                    GameScr2.gI().timeLengthMap = 0;
                    Char2.myCharz().mobFocus = null;
                    Char2.myCharz().npcFocus = null;
                    Char2.myCharz().charFocus = null;
                    Char2.myCharz().itemFocus = null;
                    Char2.myCharz().focus.removeAllElements();
                    Char2.myCharz().testCharId = -9999;
                    Char2.myCharz().killCharId = -9999;
                    GameCanvas2.resetBg();
                    GameScr2.gI().resetButton();
                    GameScr2.gI().center = null;
                    break;
                case -70:
                    {
                        GameCanvas2.endDlg();
                        if (PickMob2.tanSat)
                        {
                            MainMod2.GI().perform(44, true);
                            return;
                        }
                        int avatar2 = msg.reader().readShort();
                        string chat3 = msg.reader().readUTF();
                        Npc2 npc6 = new(-1, 0, 0, 0, 0, 0)
                        {
                            avatar = avatar2
                        };
                        ChatPopup2.addBigMessage(chat3, 100000, npc6);
                        sbyte type = msg.reader().readByte();
                        if (type == 0)
                        {
                            ChatPopup2.serverChatPopUp.cmdMsg1 = new Command2(mResources2.CLOSE, ChatPopup2.serverChatPopUp, 1001, null)
                            {
                                x = GameCanvas2.w / 2 - 35,
                                y = GameCanvas2.h - 35
                            };
                        }
                        if (type == 1)
                        {
                            string p2 = msg.reader().readUTF();
                            string caption2 = msg.reader().readUTF();
                            ChatPopup2.serverChatPopUp.cmdMsg1 = new Command2(mResources2.CLOSE, ChatPopup2.serverChatPopUp, 1001, null)
                            {
                                x = GameCanvas2.w / 2 + 11,
                                y = GameCanvas2.h - 35
                            };
                            ChatPopup2.serverChatPopUp.cmdMsg2 = new Command2(caption2, ChatPopup2.serverChatPopUp, 1000, p2)
                            {
                                x = GameCanvas2.w / 2 - 75,
                                y = GameCanvas2.h - 35
                            };
                        }
                        break;
                    }
                case 38:
                    {
                        InfoDlg2.hide();
                        int num85 = msg.reader().readShort();
                        string str = msg.reader().readUTF();
                        str = Res2.changeString(str);
                        for (int num103 = 0; num103 < GameScr2.vNpc.size(); num103++)
                        {
                            Npc2 npc4 = (Npc2)GameScr2.vNpc.elementAt(num103);
                            if (npc4.template.npcTemplateId == num85)
                            {
                                ChatPopup2.addChatPopupMultiLine(str, 100000, npc4);
                                GameCanvas2.panel.hideNow();
                                return;
                            }
                        }
                        Npc2 npc5 = new Npc2(num85, 0, 0, 0, num85, GameScr2.info1.charId[Char2.myCharz().cgender][2]);
                        if (npc5.template.npcTemplateId == 5)
                        {
                            npc5.charID = 5;
                        }
                        try
                        {
                            npc5.avatar = msg.reader().readShort();
                        }
                        catch (Exception)
                        {
                        }
                        ChatPopup2.addChatPopupMultiLine(str, 100000, npc5);
                        GameCanvas2.panel.hideNow();
                        break;
                    }
                case 32:
                    {
                        int npcId = msg.reader().readShort();
                        for (int i = 0; i < GameScr2.vNpc.size(); i++)
                        {
                            Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
                            if (npc.template.npcTemplateId == npcId && npc.Equals(Char2.myCharz().npcFocus))
                            {
                                bool hasUpgradeMenu = false;
                                string chat = msg.reader().readUTF();
                                string[] menu = new string[msg.reader().readByte()];
                                for (int num87 = 0; num87 < menu.Length; num87++)
                                {
                                    menu[num87] = msg.reader().readUTF();
                                    if (menu[num87].Contains("Nâng cấp"))
                                    {
                                        hasUpgradeMenu = true;
                                    }
                                }
                                GameScr2.gI().createMenu(menu, npc);
                                ChatPopup2.addChatPopup(chat, 100000, npc);

                                if (npcId == 21 && hasUpgradeMenu && chat.Contains("tối đa") && chat.Contains("sao pha lê") && chat.Contains("đạt"))
                                {
                                    MainMod2.maxPhale = MainMod2.currPhale;
                                }

                                return;
                            }
                        }
                        Npc2 npc1 = new(npcId, 0, -100, 100, npcId, GameScr2.info1.charId[Char2.myCharz().cgender][2]);
                        string chat1 = msg.reader().readUTF();
                        string[] menu1 = new string[msg.reader().readByte()];
                        for (int j = 0; j < menu1.Length; j++)
                        {
                            menu1[j] = msg.reader().readUTF();
                        }
                        try
                        {
                            short avatar = msg.reader().readShort();
                            npc1.avatar = avatar;
                        }
                        catch (Exception)
                        {
                        }
                        GameScr2.gI().createMenu(menu1, npc1);
                        ChatPopup2.addChatPopup(chat1, 100000, npc1);
                        break;
                    }
                case 7:
                    {
                        sbyte type = msg.reader().readByte();
                        short id = msg.reader().readShort();
                        string info3 = msg.reader().readUTF();
                        GameCanvas2.panel.saleRequest(type, info3, id);
                        break;
                    }
                case 6:
                    Char2.myCharz().xu = msg.reader().readLong();
                    Char2.myCharz().luong = msg.reader().readInt();
                    Char2.myCharz().luongKhoa = msg.reader().readInt();
                    Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                    Char2.myCharz().luongStr = mSystem2.numberTostring(Char2.myCharz().luong);
                    Char2.myCharz().luongKhoaStr = mSystem2.numberTostring(Char2.myCharz().luongKhoa);
                    GameCanvas2.endDlg();
                    break;
                case -23:
                    LoadAuraNpcs(msg);
                    break;
                case -24:
                    if (GameCanvas2.currentScreen is GameScr2)
                    {
                        GameCanvas2.timeBreakLoading = mSystem2.currentTimeMillis() + 3000;
                    }
                    else
                    {
                        GameCanvas2.timeBreakLoading = mSystem2.currentTimeMillis() + 30000;
                    }
                    Char2.isLoadingMap = true;
                    GameScr2.gI().magicTree = null;
                    GameCanvas2.isLoading = true;
                    GameScr2.resetAllvector();
                    GameCanvas2.endDlg();
                    TileMap2.vGo.removeAllElements();
                    PopUp2.vPopups.removeAllElements();
                    mSystem2.gcc();
                    TileMap2.mapID = msg.reader().readUnsignedByte();
                    TileMap2.planetID = msg.reader().readByte();
                    TileMap2.tileID = msg.reader().readByte();
                    TileMap2.bgID = msg.reader().readByte();
                    TileMap2.typeMap = msg.reader().readByte();
                    TileMap2.mapName = msg.reader().readUTF();
                    TileMap2.zoneID = msg.reader().readByte();
                    try
                    {
                        TileMap2.loadMapFromResource(TileMap2.mapID);
                    }
                    catch (Exception)
                    {
                        Service2.gI().requestMaptemplate(TileMap2.mapID);
                        messWait = msg;
                        return;
                    }
                    loadInfoMap(msg);
                    try
                    {
                        sbyte b33 = msg.reader().readByte();
                        TileMap2.isMapDouble = ((b33 != 0) ? true : false);
                    }
                    catch (Exception)
                    {
                    }
                    GameScr2.cmx = GameScr2.cmtoX;
                    GameScr2.cmy = GameScr2.cmtoY;
                    break;
                case -31:
                    {
                        TileMap2.vItemBg.removeAllElements();
                        short num71 = msg.reader().readShort();
                        for (int num72 = 0; num72 < num71; num72++)
                        {
                            BgItem2 bgItem = new BgItem2();
                            bgItem.id = num72;
                            bgItem.idImage = msg.reader().readShort();
                            bgItem.layer = msg.reader().readByte();
                            bgItem.dx = msg.reader().readShort();
                            bgItem.dy = msg.reader().readShort();
                            sbyte b32 = msg.reader().readByte();
                            bgItem.tileX = new int[b32];
                            bgItem.tileY = new int[b32];
                            for (int num73 = 0; num73 < b32; num73++)
                            {
                                bgItem.tileX[num72] = msg.reader().readByte();
                                bgItem.tileY[num72] = msg.reader().readByte();
                            }
                            TileMap2.vItemBg.addElement(bgItem);
                        }
                        break;
                    }
                case -4:
                    {
                        GameCanvas2.debug("SA76", 2);
                        @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char == null)
                        {
                            return;
                        }
                        GameCanvas2.debug("SA76v1", 2);
                        if ((TileMap2.tileTypeAtPixel(@char.cx, @char.cy) & 2) == 2)
                        {
                            @char.setSkillPaint(GameScr2.sks[msg.reader().readUnsignedByte()], 0);
                        }
                        else
                        {
                            @char.setSkillPaint(GameScr2.sks[msg.reader().readUnsignedByte()], 1);
                        }
                        GameCanvas2.debug("SA76v2", 2);
                        @char.attMobs = new Mob2[msg.reader().readByte()];
                        for (int num26 = 0; num26 < @char.attMobs.Length; num26++)
                        {
                            Mob2 mob3 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readByte());
                            @char.attMobs[num26] = mob3;
                            if (num26 == 0)
                            {
                                if (@char.cx <= mob3.x)
                                {
                                    @char.cdir = 1;
                                }
                                else
                                {
                                    @char.cdir = -1;
                                }
                            }
                        }
                        GameCanvas2.debug("SA76v3", 2);
                        @char.charFocus = null;
                        @char.mobFocus = @char.attMobs[0];
                        Char2[] array = new Char2[10];
                        num = 0;
                        try
                        {
                            for (num = 0; num < array.Length; num++)
                            {
                                int num18 = msg.reader().readInt();
                                Char2 char4 = (array[num] = ((num18 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num18) : Char2.myCharz()));
                                if (num == 0)
                                {
                                    if (@char.cx <= char4.cx)
                                    {
                                        @char.cdir = 1;
                                    }
                                    else
                                    {
                                        @char.cdir = -1;
                                    }
                                }
                            }
                        }
                        catch (Exception ex5)
                        {
                            Cout2.println("Loi PLAYER_ATTACK_N_P " + ex5.ToString());
                        }
                        GameCanvas2.debug("SA76v4", 2);
                        if (num > 0)
                        {
                            @char.attChars = new Char2[num];
                            for (num = 0; num < @char.attChars.Length; num++)
                            {
                                @char.attChars[num] = array[num];
                            }
                            @char.charFocus = @char.attChars[0];
                            @char.mobFocus = null;
                        }
                        GameCanvas2.debug("SA76v5", 2);
                        break;
                    }
                case 54:
                    {
                        @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char == null)
                        {
                            return;
                        }
                        int num17 = msg.reader().readUnsignedByte();
                        if ((TileMap2.tileTypeAtPixel(@char.cx, @char.cy) & 2) == 2)
                        {
                            @char.setSkillPaint(GameScr2.sks[num17], 0);
                        }
                        else
                        {
                            @char.setSkillPaint(GameScr2.sks[num17], 1);
                        }
                        Mob2[] array3 = new Mob2[10];
                        num = 0;
                        try
                        {
                            for (num = 0; num < array3.Length; num++)
                            {
                                Mob2 mob2 = (array3[num] = (Mob2)GameScr2.vMob.elementAt(msg.reader().readByte()));
                                if (num == 0)
                                {
                                    if (@char.cx <= mob2.x)
                                    {
                                        @char.cdir = 1;
                                    }
                                    else
                                    {
                                        @char.cdir = -1;
                                    }
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        if (num > 0)
                        {
                            @char.attMobs = new Mob2[num];
                            for (num = 0; num < @char.attMobs.Length; num++)
                            {
                                @char.attMobs[num] = array3[num];
                            }
                            @char.charFocus = null;
                            @char.mobFocus = @char.attMobs[0];
                        }
                        break;
                    }
                case -60:
                    {
                        GameCanvas2.debug("SA7666", 2);
                        int num2 = msg.reader().readInt();
                        int num3 = -1;
                        if (num2 != Char2.myCharz().charID)
                        {
                            Char2 char2 = GameScr2.findCharInMap(num2);
                            if (char2 == null)
                            {
                                return;
                            }
                            if (char2.currentMovePoint != null)
                            {
                                char2.createShadow(char2.cx, char2.cy, 10);
                                char2.cx = char2.currentMovePoint.xEnd;
                                char2.cy = char2.currentMovePoint.yEnd;
                            }
                            int num4 = msg.reader().readUnsignedByte();
                            if ((TileMap2.tileTypeAtPixel(char2.cx, char2.cy) & 2) == 2)
                            {
                                char2.setSkillPaint(GameScr2.sks[num4], 0);
                            }
                            else
                            {
                                char2.setSkillPaint(GameScr2.sks[num4], 1);
                            }
                            sbyte b = msg.reader().readByte();
                            Char2[] array = new Char2[b];
                            for (num = 0; num < array.Length; num++)
                            {
                                num3 = msg.reader().readInt();
                                Char2 char3;
                                if (num3 == Char2.myCharz().charID)
                                {
                                    char3 = Char2.myCharz();
                                    if (!GameScr2.isChangeZone && GameScr2.isAutoPlay && GameScr2.canAutoPlay)
                                    {
                                        Service2.gI().requestChangeZone(-1, -1);
                                        GameScr2.isChangeZone = true;
                                    }
                                }
                                else
                                {
                                    char3 = GameScr2.findCharInMap(num3);
                                }
                                array[num] = char3;
                                if (num == 0)
                                {
                                    if (char2.cx <= char3.cx)
                                    {
                                        char2.cdir = 1;
                                    }
                                    else
                                    {
                                        char2.cdir = -1;
                                    }
                                }
                            }
                            if (num > 0)
                            {
                                char2.attChars = new Char2[num];
                                for (num = 0; num < char2.attChars.Length; num++)
                                {
                                    char2.attChars[num] = array[num];
                                }
                                char2.mobFocus = null;
                                char2.charFocus = char2.attChars[0];
                            }
                        }
                        else
                        {
                            sbyte b2 = msg.reader().readByte();
                            sbyte b3 = msg.reader().readByte();
                            num3 = msg.reader().readInt();
                        }
                        try
                        {
                            sbyte b4 = msg.reader().readByte();
                            if (b4 != 1)
                            {
                                break;
                            }
                            sbyte b5 = msg.reader().readByte();
                            if (num3 == Char2.myCharz().charID)
                            {
                                bool flag = false;
                                @char = Char2.myCharz();
                                long num5 = msg.readLong();
                                @char.isDie = msg.reader().readBoolean();
                                if (@char.isDie)
                                {
                                    Char2.isLockKey = true;
                                }
                                long num6 = 0;
                                flag = (@char.isCrit = msg.reader().readBoolean());
                                @char.isMob = false;
                                num5 = (@char.damHP = num5 + num6);
                                if (b5 == 0)
                                {
                                    @char.doInjure(num5, 0, flag, isMob: false);
                                }
                            }
                            else
                            {
                                @char = GameScr2.findCharInMap(num3);
                                if (@char == null)
                                {
                                    return;
                                }
                                bool flag2 = false;
                                long num7 = msg.readLong();
                                @char.isDie = msg.reader().readBoolean();
                                long num8 = 0;
                                flag2 = (@char.isCrit = msg.reader().readBoolean());
                                @char.isMob = false;
                                num7 = (@char.damHP = num7 + num8);
                                if (b5 == 0)
                                {
                                    @char.doInjure(num7, 0, flag2, isMob: false);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    }
            }
            switch (msg.command)
            {
                case -2:
                    {
                        GameCanvas2.debug("SA77", 22);
                        int num195 = msg.reader().readInt();
                        Char2.myCharz().yen += num195;
                        GameScr2.startFlyText((num195 <= 0) ? (string.Empty + num195) : ("+" + num195), Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 10, 0, -2, mFont2.YELLOW);
                        break;
                    }
                case 95:
                    {
                        GameCanvas2.debug("SA77", 22);
                        int num182 = msg.reader().readInt();
                        Char2.myCharz().xu += num182;
                        Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                        GameScr2.startFlyText((num182 <= 0) ? (string.Empty + num182) : ("+" + num182), Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 10, 0, -2, mFont2.YELLOW);
                        break;
                    }
                case 96:
                    GameCanvas2.debug("SA77a", 22);
                    Char2.myCharz().taskOrders.addElement(new TaskOrder2(msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readByte(), msg.reader().readByte()));
                    break;
                case 97:
                    {
                        sbyte b75 = msg.reader().readByte();
                        for (int num188 = 0; num188 < Char2.myCharz().taskOrders.size(); num188++)
                        {
                            TaskOrder2 taskOrder = (TaskOrder2)Char2.myCharz().taskOrders.elementAt(num188);
                            if (taskOrder.taskId == b75)
                            {
                                taskOrder.count = msg.reader().readShort();
                                break;
                            }
                        }
                        break;
                    }
                case -1:
                    {
                        GameCanvas2.debug("SA77", 222);
                        int num194 = msg.reader().readInt();
                        Char2.myCharz().xu += num194;
                        Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                        Char2.myCharz().yen -= num194;
                        GameScr2.startFlyText("+" + num194, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 10, 0, -2, mFont2.YELLOW);
                        break;
                    }
                case -3:
                    {
                        sbyte type = msg.reader().readByte();
                        long param = msg.readLong();
                        if (type == 0)
                        {
                            Char2.myCharz().cPower += param;
                        }
                        if (type == 1)
                        {
                            Char2.myCharz().cTiemNang += param;
                        }
                        if (type == 2)
                        {
                            Char2.myCharz().cPower += param;
                            Char2.myCharz().cTiemNang += param;
                        }
                        Char2.myCharz().applyCharLevelPercent();
                        if (Char2.myCharz().cTypePk != 3)
                        {
                            GameScr2.startFlyText(((param <= 0) ? string.Empty : "+") + param, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch, 0, -4, mFont2.GREEN);
                            if (param > 0 && Char2.myCharz().petFollow != null && Char2.myCharz().petFollow.smallID == 5002)
                            {
                                ServerEffect2.addServerEffect(55, Char2.myCharz().petFollow.cmx, Char2.myCharz().petFollow.cmy, 1);
                                ServerEffect2.addServerEffect(55, Char2.myCharz().cx, Char2.myCharz().cy, 1);
                            }
                        }
                        break;
                    }
                case -73:
                    {
                        sbyte npcId = msg.reader().readByte();
                        for (int i = 0; i < GameScr2.vNpc.size(); i++)
                        {
                            Npc2 npc7 = (Npc2)GameScr2.vNpc.elementAt(i);
                            if (npc7.template.npcTemplateId == npcId)
                            {
                                sbyte isHide = msg.reader().readByte();
                                if (isHide == 0)
                                {
                                    npc7.isHide = true;
                                }
                                else
                                {
                                    npc7.isHide = false;
                                }
                                break;
                            }
                        }
                        break;
                    }
                case -5:
                    {
                        int charID = msg.reader().readInt();
                        int num184 = msg.reader().readInt();
                        Char2 char15;
                        if (num184 != -100)
                        {
                            char15 = new Char2
                            {
                                charID = charID,
                                clanID = num184
                            };
                        }
                        else
                        {
                            char15 = new Mabu2
                            {
                                charID = charID,
                                clanID = num184
                            };
                        }
                        if (char15.clanID == -2)
                        {
                            char15.isCopy = true;
                        }
                        if (readCharInfo(char15, msg))
                        {
                            sbyte b73 = msg.reader().readByte();
                            if (char15.cy <= 10 && b73 != 0 && b73 != 2)
                            {
                                Teleport2 teleport2 = new Teleport2(char15.cx, char15.cy, char15.head, char15.cdir, 1, isMe: false, (b73 != 1) ? b73 : char15.cgender);
                                teleport2.id = char15.charID;
                                char15.isTeleport = true;
                                Teleport2.addTeleport(teleport2);
                            }
                            if (b73 == 2)
                            {
                                char15.show();
                            }
                            for (int num185 = 0; num185 < GameScr2.vMob.size(); num185++)
                            {
                                Mob2 mob10 = (Mob2)GameScr2.vMob.elementAt(num185);
                                if (mob10 != null && mob10.isMobMe && mob10.mobId == char15.charID)
                                {
                                    char15.mobMe = mob10;
                                    char15.mobMe.x = char15.cx;
                                    char15.mobMe.y = char15.cy - 40;
                                    break;
                                }
                            }
                            if (GameScr2.findCharInMap(char15.charID) == null)
                            {
                                GameScr2.vCharInMap.addElement(char15);
                            }
                            char15.isMonkey = msg.reader().readByte();
                            short num186 = msg.reader().readShort();
                            if (num186 != -1)
                            {
                                char15.isHaveMount = true;
                                switch (num186)
                                {
                                    case 346:
                                    case 347:
                                    case 348:
                                        char15.isMountVip = false;
                                        break;
                                    case 349:
                                    case 350:
                                    case 351:
                                        char15.isMountVip = true;
                                        break;
                                    case 396:
                                        char15.isEventMount = true;
                                        break;
                                    case 532:
                                        char15.isSpeacialMount = true;
                                        break;
                                    default:
                                        if (num186 >= Char2.ID_NEW_MOUNT)
                                        {
                                            char15.idMount = num186;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                char15.isHaveMount = false;
                            }
                        }
                        sbyte b74 = msg.reader().readByte();
                        char15.cFlag = b74;
                        char15.isNhapThe = msg.reader().readByte() == 1;
                        try
                        {
                            char15.idAuraEff = msg.reader().readShort();
                            char15.idEff_Set_Item = msg.reader().readSByte();
                            char15.idHat = msg.reader().readShort();
                            if (char15.bag >= 201 && char15.bag < 255)
                            {
                                Effect2_ effect2 = new Effect2_(char15.bag, char15, 2, -1, 10, 1);
                                effect2.typeEff = 5;
                                char15.addEffChar(effect2);
                            }
                            else
                            {
                                for (int num187 = 0; num187 < 54; num187++)
                                {
                                    char15.removeEffChar(0, 201 + num187);
                                }
                            }
                        }
                        catch (Exception ex37)
                        {
                            Res2.outz("cmd: -5 err: " + ex37.StackTrace);
                        }
                        try
                        {
                            char15.isTichXanh = msg.reader().readByte() == 1;
                            char15.isTichDo = msg.reader().readByte() == 1;
                        }
                        catch
                        {
                        }
                        GameScr2.gI().getFlagImage(char15.charID, char15.cFlag);
                        break;
                    }
                case -7:
                    {
                        int num177 = msg.reader().readInt();
                        for (int num180 = 0; num180 < GameScr2.vCharInMap.size(); num180++)
                        {
                            Char2 char14 = null;
                            try
                            {
                                char14 = (Char2)GameScr2.vCharInMap.elementAt(num180);
                            }
                            catch (Exception)
                            {
                            }
                            if (char14 == null)
                            {
                                break;
                            }
                            if (char14.charID == num177)
                            {
                                GameCanvas2.debug("SA8x2y" + num180, 2);
                                char14.moveTo(msg.reader().readShort(), msg.reader().readShort(), 0);
                                char14.lastUpdateTime = mSystem2.currentTimeMillis();
                                break;
                            }
                        }
                        GameCanvas2.debug("SA80x3", 2);
                        break;
                    }
                case -6:
                    {
                        GameCanvas2.debug("SA81", 2);
                        int num177 = msg.reader().readInt();
                        for (int num178 = 0; num178 < GameScr2.vCharInMap.size(); num178++)
                        {
                            Char2 char13 = (Char2)GameScr2.vCharInMap.elementAt(num178);
                            if (char13 != null && char13.charID == num177)
                            {
                                if (!char13.isInvisiblez && !char13.isUsePlane)
                                {
                                    ServerEffect2.addServerEffect(60, char13.cx, char13.cy, 1);
                                }
                                if (!char13.isUsePlane)
                                {
                                    GameScr2.vCharInMap.removeElementAt(num178);
                                }
                                return;
                            }
                        }
                        break;
                    }
                case -13:
                    {
                        int num189 = msg.reader().readUnsignedByte();
                        if (num189 > GameScr2.vMob.size() - 1 || num189 < 0)
                        {
                            return;
                        }
                        Mob2 mob9 = (Mob2)GameScr2.vMob.elementAt(num189);
                        if (mob9.status != 0 && mob9.status != 1)
                        {
                            return;
                        }
                        mob9.sys = msg.reader().readByte();
                        mob9.levelBoss = msg.reader().readByte();
                        if (mob9.levelBoss != 0)
                        {
                            mob9.typeSuperEff = Res2.random(0, 3);
                        }
                        mob9.x = mob9.xFirst;
                        mob9.y = mob9.yFirst;
                        mob9.status = 5;
                        mob9.injureThenDie = false;
                        mob9.hp = msg.readLong();
                        mob9.maxHp = mob9.hp;
                        mob9.updateHp_bar();
                        ServerEffect2.addServerEffect(60, mob9.x, mob9.y, 1);
                        break;
                    }
                case -75:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null)
                        {
                            mob9.levelBoss = msg.reader().readByte();
                            if (mob9.levelBoss > 0)
                            {
                                mob9.typeSuperEff = Res2.random(0, 3);
                            }
                        }
                        break;
                    }
                case -9:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null)
                        {
                            mob9.hp = msg.readLong();
                            mob9.updateHp_bar();
                            long dame = msg.readLong();
                            if (dame == 1)
                            {
                                return;
                            }
                            if (dame > 1)
                            {
                                mob9.setInjure();
                            }
                            bool flag10 = false;
                            try
                            {
                                flag10 = msg.reader().readBoolean();
                            }
                            catch (Exception)
                            {
                            }
                            sbyte b72 = msg.reader().readByte();
                            if (b72 != -1)
                            {
                                EffecMn2.addEff(new Effect2_(b72, mob9.x, mob9.getY(), 3, 1, -1));
                            }
                            if (flag10)
                            {
                                GameScr2.startFlyText("-" + dame, mob9.x, mob9.getY() - mob9.getH(), 0, -2, mFont2.FATAL);
                            }
                            else if (dame == 0)
                            {
                                mob9.x = mob9.xFirst;
                                mob9.y = mob9.yFirst;
                                GameScr2.startFlyText(mResources2.miss, mob9.x, mob9.getY() - mob9.getH(), 0, -2, mFont2.MISS);
                            }
                            else if (dame > 1)
                            {
                                GameScr2.startFlyText("-" + dame, mob9.x, mob9.getY() - mob9.getH(), 0, -2, mFont2.ORANGE);
                            }
                        }
                        break;
                    }
                case 45:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null)
                        {
                            mob9.hp = msg.reader().readInt();
                            mob9.updateHp_bar();
                            GameScr2.startFlyText(mResources2.miss, mob9.x, mob9.y - mob9.h, 0, -2, mFont2.MISS);
                        }
                        break;
                    }
                case -12:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 == null || mob9.status == 0 || mob9.status == 0)
                        {
                            break;
                        }
                        mob9.startDie();
                        try
                        {
                            long dameHit = msg.readLong();
                            if (msg.reader().readBool())
                            {
                                GameScr2.startFlyText("-" + dameHit, mob9.x, mob9.y - mob9.h, 0, -2, mFont2.FATAL);
                            }
                            else
                            {
                                GameScr2.startFlyText("-" + dameHit, mob9.x, mob9.y - mob9.h, 0, -2, mFont2.ORANGE);
                            }
                            sbyte b76 = msg.reader().readByte();
                            for (int num191 = 0; num191 < b76; num191++)
                            {
                                ItemMap2 itemMap4 = new ItemMap2(msg.reader().readShort(), msg.reader().readShort(), mob9.x, mob9.y, msg.reader().readShort(), msg.reader().readShort());
                                int num192 = (itemMap4.playerId = msg.reader().readInt());
                                GameScr2.vItemMap.addElement(itemMap4);
                                if (Res2.abs(itemMap4.y - Char2.myCharz().cy) < 24 && Res2.abs(itemMap4.x - Char2.myCharz().cx) < 24)
                                {
                                    Char2.myCharz().charFocus = null;
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    }
                case 74:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null && mob9.status != 0 && mob9.status != 0)
                        {
                            mob9.status = 0;
                            ServerEffect2.addServerEffect(60, mob9.x, mob9.y, 1);
                            ItemMap2 itemMap3 = new ItemMap2(msg.reader().readShort(), msg.reader().readShort(), mob9.x, mob9.y, msg.reader().readShort(), msg.reader().readShort());
                            GameScr2.vItemMap.addElement(itemMap3);
                            if (Res2.abs(itemMap3.y - Char2.myCharz().cy) < 24 && Res2.abs(itemMap3.x - Char2.myCharz().cx) < 24)
                            {
                                Char2.myCharz().charFocus = null;
                            }
                        }
                        break;
                    }
                case -11:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            int index4 = msg.reader().readUnsignedByte();
                            mob9 = (Mob2)GameScr2.vMob.elementAt(index4);
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null)
                        {
                            Char2.myCharz().isDie = false;
                            Char2.isLockKey = false;
                            long dame = msg.readLong();
                            int num175;
                            try
                            {
                                num175 = msg.readInt3Byte();
                            }
                            catch (Exception)
                            {
                                num175 = 0;
                            }
                            if (mob9.isBusyAttackSomeOne)
                            {
                                Char2.myCharz().doInjure(dame, num175, isCrit: false, isMob: true);
                                break;
                            }
                            mob9.dame = dame;
                            mob9.dameMp = num175;
                            mob9.setAttack(Char2.myCharz());
                        }
                        break;
                    }
                case -10:
                    {
                        Mob2 mob9 = null;
                        try
                        {
                            mob9 = (Mob2)GameScr2.vMob.elementAt(msg.reader().readUnsignedByte());
                        }
                        catch (Exception)
                        {
                        }
                        if (mob9 != null)
                        {
                            @char = GameScr2.findCharInMap(msg.reader().readInt());
                            if (@char == null)
                            {
                                return;
                            }
                            long cHP = msg.readLong();
                            mob9.dame = @char.cHP - cHP;
                            @char.cHPNew = cHP;
                            try
                            {
                                @char.cMP = msg.readInt3Byte();
                            }
                            catch (Exception)
                            {
                            }
                            if (mob9.isBusyAttackSomeOne)
                            {
                                @char.doInjure(mob9.dame, 0, isCrit: false, isMob: true);
                            }
                            else
                            {
                                mob9.setAttack(@char);
                            }
                        }
                        break;
                    }
                case -17:
                    Char2.myCharz().meDead = true;
                    Char2.myCharz().cPk = msg.reader().readByte();
                    Char2.myCharz().startDie(msg.reader().readShort(), msg.reader().readShort());
                    try
                    {
                        Char2.myCharz().cPower = msg.reader().readLong();
                        Char2.myCharz().applyCharLevelPercent();
                    }
                    catch (Exception)
                    {
                        Cout2.println("Loi tai ME_DIE " + msg.command);
                    }
                    Char2.myCharz().countKill = 0;
                    break;
                case 66:
                    break;
                case -8:
                    @char = GameScr2.findCharInMap(msg.reader().readInt());
                    if (@char == null)
                    {
                        return;
                    }
                    @char.cPk = msg.reader().readByte();
                    @char.waitToDie(msg.reader().readShort(), msg.reader().readShort());
                    break;
                case -16:
                    if (Char2.myCharz().wdx != 0 || Char2.myCharz().wdy != 0)
                    {
                        Char2.myCharz().cx = Char2.myCharz().wdx;
                        Char2.myCharz().cy = Char2.myCharz().wdy;
                        Char2.myCharz().wdx = (Char2.myCharz().wdy = 0);
                    }
                    Char2.myCharz().liveFromDead();
                    Char2.myCharz().isLockMove = false;
                    Char2.myCharz().meDead = false;
                    break;
                case 44:
                    {
                        int num176 = msg.reader().readInt();
                        string text8 = msg.reader().readUTF();
                        @char = ((Char2.myCharz().charID != num176) ? GameScr2.findCharInMap(num176) : Char2.myCharz());
                        if (@char == null)
                        {
                            return;
                        }
                        @char.addInfo(text8);
                        break;
                    }
                case 18:
                    {
                        sbyte b70 = msg.reader().readByte();
                        for (int num173 = 0; num173 < b70; num173++)
                        {
                            int charId = msg.reader().readInt();
                            int cx = msg.reader().readShort();
                            int cy = msg.reader().readShort();
                            int cHPShow = msg.readInt3Byte();
                            Char2 char12 = GameScr2.findCharInMap(charId);
                            if (char12 != null)
                            {
                                char12.cx = cx;
                                char12.cy = cy;
                                char12.cHP = (char12.cHPShow = cHPShow);
                                char12.lastUpdateTime = mSystem2.currentTimeMillis();
                            }
                        }
                        break;
                    }
                case 19:
                    Char2.myCharz().countKill = msg.reader().readUnsignedShort();
                    Char2.myCharz().countKillMax = msg.reader().readUnsignedShort();
                    break;
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            msg?.cleanup();
        }
    }

    private void readLogin(Message2 msg)
    {
        sbyte b = msg.reader().readByte();
        ChooseCharScr2.playerData = new PlayerData2[b];
        Res2.outz("[LEN] sl nguoi choi " + b);
        for (int i = 0; i < b; i++)
        {
            int playerID = msg.reader().readInt();
            string name = msg.reader().readUTF();
            short head = msg.reader().readShort();
            short body = msg.reader().readShort();
            short leg = msg.reader().readShort();
            long ppoint = msg.reader().readLong();
            ChooseCharScr2.playerData[i] = new PlayerData2(playerID, name, head, body, leg, ppoint);
        }
        GameCanvas2.chooseCharScr.switchToMe();
        GameCanvas2.chooseCharScr.updateChooseCharacter((byte)b);
    }

    private void createItem(myReader2 d)
    {
        GameScr2.vcItem = d.readByte();
        ItemTemplates2.itemTemplates.clear();
        GameScr2.gI().iOptionTemplates = new ItemOptionTemplate2[d.readUnsignedByte()];
        for (int i = 0; i < GameScr2.gI().iOptionTemplates.Length; i++)
        {
            GameScr2.gI().iOptionTemplates[i] = new ItemOptionTemplate2();
            GameScr2.gI().iOptionTemplates[i].id = i;
            GameScr2.gI().iOptionTemplates[i].name = d.readUTF();
            GameScr2.gI().iOptionTemplates[i].type = d.readByte();
        }
        int num = d.readShort();
        for (int j = 0; j < num; j++)
        {
            ItemTemplate2 it = new ItemTemplate2((short)j, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBool());
            ItemTemplates2.add(it);
        }
    }

    private void createSkill(myReader2 d)
    {
        GameScr2.vcSkill = d.readByte();
        GameScr2.gI().sOptionTemplates = new SkillOptionTemplate2[d.readByte()];
        for (int i = 0; i < GameScr2.gI().sOptionTemplates.Length; i++)
        {
            GameScr2.gI().sOptionTemplates[i] = new SkillOptionTemplate2();
            GameScr2.gI().sOptionTemplates[i].id = i;
            GameScr2.gI().sOptionTemplates[i].name = d.readUTF();
        }
        GameScr2.nClasss = new NClass2[d.readByte()];
        for (int j = 0; j < GameScr2.nClasss.Length; j++)
        {
            GameScr2.nClasss[j] = new NClass2();
            GameScr2.nClasss[j].classId = j;
            GameScr2.nClasss[j].name = d.readUTF();
            GameScr2.nClasss[j].skillTemplates = new SkillTemplate2[d.readByte()];
            for (int k = 0; k < GameScr2.nClasss[j].skillTemplates.Length; k++)
            {
                GameScr2.nClasss[j].skillTemplates[k] = new SkillTemplate2();
                GameScr2.nClasss[j].skillTemplates[k].id = d.readByte();
                GameScr2.nClasss[j].skillTemplates[k].name = d.readUTF();
                GameScr2.nClasss[j].skillTemplates[k].maxPoint = d.readByte();
                GameScr2.nClasss[j].skillTemplates[k].manaUseType = d.readByte();
                GameScr2.nClasss[j].skillTemplates[k].type = d.readByte();
                GameScr2.nClasss[j].skillTemplates[k].iconId = d.readShort();
                GameScr2.nClasss[j].skillTemplates[k].damInfo = d.readUTF();
                int lineWidth = 130;
                if (GameCanvas2.w == 128 || GameCanvas2.h <= 208)
                {
                    lineWidth = 100;
                }
                GameScr2.nClasss[j].skillTemplates[k].description = mFont2.tahoma_7_green2.splitFontArray(d.readUTF(), lineWidth);
                GameScr2.nClasss[j].skillTemplates[k].skills = new Skill2[d.readByte()];
                for (int l = 0; l < GameScr2.nClasss[j].skillTemplates[k].skills.Length; l++)
                {
                    GameScr2.nClasss[j].skillTemplates[k].skills[l] = new Skill2();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].skillId = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].template = GameScr2.nClasss[j].skillTemplates[k];
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].point = d.readByte();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].powRequire = d.readLong();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].manaUse = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].coolDown = d.readInt();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].dx = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].dy = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].maxFight = d.readByte();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].damage = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].price = d.readShort();
                    GameScr2.nClasss[j].skillTemplates[k].skills[l].moreInfo = d.readUTF();
                    Skills2.add(GameScr2.nClasss[j].skillTemplates[k].skills[l]);
                }
            }
        }
    }

    private void createMap(myReader2 d)
    {
        GameScr2.vcMap = d.readByte();
        TileMap2.mapNames = new string[d.readUnsignedByte()];
        for (int i = 0; i < TileMap2.mapNames.Length; i++)
        {
            TileMap2.mapNames[i] = d.readUTF();
        }
        Npc2.arrNpcTemplate = new NpcTemplate2[d.readByte()];
        for (sbyte b = 0; b < Npc2.arrNpcTemplate.Length; b++)
        {
            Npc2.arrNpcTemplate[b] = new NpcTemplate2();
            Npc2.arrNpcTemplate[b].npcTemplateId = b;
            Npc2.arrNpcTemplate[b].name = d.readUTF();
            Npc2.arrNpcTemplate[b].headId = d.readShort();
            Npc2.arrNpcTemplate[b].bodyId = d.readShort();
            Npc2.arrNpcTemplate[b].legId = d.readShort();
            Npc2.arrNpcTemplate[b].menu = new string[d.readByte()][];
            for (int j = 0; j < Npc2.arrNpcTemplate[b].menu.Length; j++)
            {
                Npc2.arrNpcTemplate[b].menu[j] = new string[d.readByte()];
                for (int k = 0; k < Npc2.arrNpcTemplate[b].menu[j].Length; k++)
                {
                    Npc2.arrNpcTemplate[b].menu[j][k] = d.readUTF();
                }
            }
        }
        Mob2.arrMobTemplate = new MobTemplate2[d.readByte()];
        for (sbyte b2 = 0; b2 < Mob2.arrMobTemplate.Length; b2++)
        {
            Mob2.arrMobTemplate[b2] = new MobTemplate2();
            Mob2.arrMobTemplate[b2].mobTemplateId = b2;
            Mob2.arrMobTemplate[b2].type = d.readByte();
            Mob2.arrMobTemplate[b2].name = d.readUTF();
            Mob2.arrMobTemplate[b2].hp = d.readInt();
            Mob2.arrMobTemplate[b2].rangeMove = d.readByte();
            Mob2.arrMobTemplate[b2].speed = d.readByte();
            Mob2.arrMobTemplate[b2].dartType = d.readByte();
        }
    }

    private void createData(myReader2 d, bool isSaveRMS)
    {
        GameScr2.vcData = d.readByte();
        if (isSaveRMS)
        {
            Rms2.saveRMS("NR_dart", NinjaUtil2.readByteArray(d));
            Rms2.saveRMS("NR_arrow", NinjaUtil2.readByteArray(d));
            Rms2.saveRMS("NR_effect", NinjaUtil2.readByteArray(d));
            Rms2.saveRMS("NR_image", NinjaUtil2.readByteArray(d));
            Rms2.saveRMS("NR_part", NinjaUtil2.readByteArray(d));
            Rms2.saveRMS("NR_skill", NinjaUtil2.readByteArray(d));
            Rms2.DeleteStorage("NRdata");
        }
    }

    private Image2 createImage(sbyte[] arr)
    {
        try
        {
            return Image2.createImage(arr, 0, arr.Length);
        }
        catch (Exception)
        {
        }
        return null;
    }

    public int[] arrayByte2Int(sbyte[] b)
    {
        int[] array = new int[b.Length];
        for (int i = 0; i < b.Length; i++)
        {
            int num = b[i];
            if (num < 0)
            {
                num += 256;
            }
            array[i] = num;
        }
        return array;
    }

    public void readClanMsg(Message2 msg, int index)
    {
        try
        {
            ClanMessage2 clanMessage = new ClanMessage2();
            sbyte b = msg.reader().readByte();
            clanMessage.type = b;
            clanMessage.id = msg.reader().readInt();
            clanMessage.playerId = msg.reader().readInt();
            clanMessage.playerName = msg.reader().readUTF();
            clanMessage.role = msg.reader().readByte();
            clanMessage.time = msg.reader().readInt() + 1000000000;
            bool flag = false;
            GameScr2.isNewClanMessage = false;
            if (b == 0)
            {
                string text = msg.reader().readUTF();
                GameScr2.isNewClanMessage = true;
                if (mFont2.tahoma_7.getWidth(text) > Panel2.WIDTH_PANEL - 60)
                {
                    clanMessage.chat = mFont2.tahoma_7.splitFontArray(text, Panel2.WIDTH_PANEL - 10);
                }
                else
                {
                    clanMessage.chat = new string[1];
                    clanMessage.chat[0] = text;
                }
                clanMessage.color = msg.reader().readByte();
            }
            else if (b == 1)
            {
                clanMessage.recieve = msg.reader().readByte();
                clanMessage.maxCap = msg.reader().readByte();
                flag = msg.reader().readByte() == 1;
                if (flag)
                {
                    GameScr2.isNewClanMessage = true;
                }
                if (clanMessage.playerId != Char2.myCharz().charID)
                {
                    if (clanMessage.recieve < clanMessage.maxCap)
                    {
                        clanMessage.option = new string[1] { mResources2.donate };
                    }
                    else
                    {
                        clanMessage.option = null;
                    }
                }
                if (GameCanvas2.panel.cp != null)
                {
                    GameCanvas2.panel.updateRequest(clanMessage.recieve, clanMessage.maxCap);
                }
            }
            else if (b == 2 && Char2.myCharz().role == 0)
            {
                GameScr2.isNewClanMessage = true;
                clanMessage.option = new string[2]
                {
                    mResources2.CANCEL,
                    mResources2.receive
                };
            }
            if (GameCanvas2.currentScreen != GameScr2.instance)
            {
                GameScr2.isNewClanMessage = false;
            }
            else if (GameCanvas2.panel.isShow && GameCanvas2.panel.type == 0 && GameCanvas2.panel.currentTabIndex == 3)
            {
                GameScr2.isNewClanMessage = false;
            }
            ClanMessage2.addMessage(clanMessage, index, flag);
        }
        catch (Exception)
        {
        }
    }

    public void loadCurrMap(sbyte teleport3)
    {
        GameScr2.gI().auto = 0;
        GameScr2.isChangeZone = false;
        CreateCharScr2.instance = null;
        GameScr2.info1.isUpdate = false;
        GameScr2.info2.isUpdate = false;
        GameScr2.lockTick = 0;
        GameCanvas2.panel.isShow = false;
        SoundMn2.gI().stopAll();
        if (!GameScr2.isLoadAllData && !CreateCharScr2.isCreateChar)
        {
            GameScr2.gI().initSelectChar();
        }
        GameScr2.loadCamera(fullmScreen: false, (teleport3 != 1) ? (-1) : Char2.myCharz().cx, (teleport3 == 0) ? (-1) : 0);
        TileMap2.loadMainTile();
        TileMap2.loadMap(TileMap2.tileID);
        Char2.myCharz().cvx = 0;
        Char2.myCharz().statusMe = 4;
        Char2.myCharz().currentMovePoint = null;
        Char2.myCharz().mobFocus = null;
        Char2.myCharz().charFocus = null;
        Char2.myCharz().npcFocus = null;
        Char2.myCharz().itemFocus = null;
        Char2.myCharz().skillPaint = null;
        Char2.myCharz().setMabuHold(m: false);
        Char2.myCharz().skillPaintRandomPaint = null;
        GameCanvas2.clearAllPointerEvent();
        if (Char2.myCharz().cy >= TileMap2.pxh - 100)
        {
            Char2.myCharz().isFlyUp = true;
            Char2.myCharz().cx += Res2.abs(Res2.random(0, 80));
            Service2.gI().charMove();
        }
        GameScr2.gI().loadGameScr();
        GameCanvas2.loadBG(TileMap2.bgID);
        Char2.isLockKey = false;
        for (int i = 0; i < Char2.myCharz().vEff.size(); i++)
        {
            EffectChar2 effectChar = (EffectChar2)Char2.myCharz().vEff.elementAt(i);
            if (effectChar.template.type == 10)
            {
                Char2.isLockKey = true;
                break;
            }
        }
        GameCanvas2.clearKeyHold();
        GameCanvas2.clearKeyPressed();
        GameScr2.gI().dHP = Char2.myCharz().cHP;
        GameScr2.gI().dMP = Char2.myCharz().cMP;
        Char2.ischangingMap = false;
        GameScr2.gI().switchToMe();
        if (Char2.myCharz().cy <= 10 && teleport3 != 0 && teleport3 != 2)
        {
            Teleport2 p = new Teleport2(Char2.myCharz().cx, Char2.myCharz().cy, Char2.myCharz().head, Char2.myCharz().cdir, 1, isMe: true, (teleport3 != 1) ? teleport3 : Char2.myCharz().cgender);
            Teleport2.addTeleport(p);
            Char2.myCharz().isTeleport = true;
        }
        if (teleport3 == 2)
        {
            Char2.myCharz().show();
        }
        if (GameScr2.gI().isRongThanXuatHien)
        {
            if (TileMap2.mapID == GameScr2.gI().mapRID && TileMap2.zoneID == GameScr2.gI().zoneRID)
            {
                GameScr2.gI().callRongThan(GameScr2.gI().xR, GameScr2.gI().yR);
            }
            if (mGraphics2.zoomLevel > 1)
            {
                GameScr2.gI().doiMauTroi();
            }
        }
        InfoDlg2.hide();
        InfoDlg2.show(TileMap2.mapName, mResources2.zone + " " + TileMap2.zoneID, 30);
        GameCanvas2.endDlg();
        GameCanvas2.isLoading = false;
        Hint2.clickMob();
        Hint2.clickNpc();
    }

    public void loadInfoMap(Message2 msg)
    {
        try
        {
            // if (mGraphics2.zoomLevel == 1)
            // {
            //     SmallImage2.clearHastable();
            // }
            Char2.myCharz().cx = Char2.myCharz().cxSend = (Char2.myCharz().cxFocus = msg.reader().readShort());
            Char2.myCharz().cy = Char2.myCharz().cySend = (Char2.myCharz().cyFocus = msg.reader().readShort());
            Char2.myCharz().xSd = Char2.myCharz().cx;
            Char2.myCharz().ySd = Char2.myCharz().cy;
            if (Char2.myCharz().cx >= 0 && Char2.myCharz().cx <= 100)
            {
                Char2.myCharz().cdir = 1;
            }
            else if (Char2.myCharz().cx >= TileMap2.tmw - 100 && Char2.myCharz().cx <= TileMap2.tmw)
            {
                Char2.myCharz().cdir = -1;
            }
            int num = msg.reader().readByte();
            if (!GameScr2.info1.isDone)
            {
                GameScr2.info1.cmx = Char2.myCharz().cx - GameScr2.cmx;
                GameScr2.info1.cmy = Char2.myCharz().cy - GameScr2.cmy;
            }
            for (int i = 0; i < num; i++)
            {
                Waypoint2 waypoint = new(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readUTF());
                if ((TileMap2.mapID != 21 && TileMap2.mapID != 22 && TileMap2.mapID != 23) || waypoint.minX < 0 || waypoint.minX <= 24)
                {
                }
            }
            Resources.UnloadUnusedAssets();
            GC.Collect();
            num = msg.reader().readByte();
            Mob2.newMob.removeAllElements();
            for (sbyte b = 0; b < num; b++)
            {
                Mob2 mob = new Mob2(b,
                    msg.reader().readBoolean(),
                    msg.reader().readBoolean(),
                    msg.reader().readBoolean(),
                    msg.reader().readBoolean(),
                    msg.reader().readBoolean(),
                    msg.reader().readByte(),
                    msg.reader().readByte(),
                    msg.readLong(), // HP
                    msg.reader().readByte(),
                    msg.readLong(), // MAX HP
                    msg.reader().readShort(),
                    msg.reader().readShort(),
                    msg.reader().readByte(),
                    msg.reader().readByte());
                mob.xSd = mob.x;
                mob.ySd = mob.y;
                mob.isBoss = msg.reader().readBoolean();
                if (Mob2.arrMobTemplate[mob.templateId].type != 0)
                {
                    if (b % 3 == 0)
                    {
                        mob.dir = -1;
                    }
                    else
                    {
                        mob.dir = 1;
                    }
                    mob.x += 10 - b % 20;
                }
                mob.isMobMe = false;
                BigBoss2_ bigBoss = null;
                BachTuoc2 bachTuoc = null;
                BigBoss2_2 bigBoss2 = null;
                NewBoss2 newBoss = null;
                if (mob.templateId == 70)
                {
                    bigBoss = new BigBoss2_(b, (short)mob.x, (short)mob.y, 70, mob.hp, mob.maxHp, mob.sys);
                }
                if (mob.templateId == 71)
                {
                    bachTuoc = new BachTuoc2(b, (short)mob.x, (short)mob.y, 71, mob.hp, mob.maxHp, mob.sys);
                }
                if (mob.templateId == 72)
                {
                    bigBoss2 = new BigBoss2_2(b, (short)mob.x, (short)mob.y, 72, mob.hp, mob.maxHp, 3);
                }
                if (mob.isBoss)
                {
                    newBoss = new NewBoss2(b, (short)mob.x, (short)mob.y, mob.templateId, mob.hp, mob.maxHp, mob.sys);
                }
                if (newBoss != null)
                {
                    GameScr2.vMob.addElement(newBoss);
                }
                else if (bigBoss != null)
                {
                    GameScr2.vMob.addElement(bigBoss);
                }
                else if (bachTuoc != null)
                {
                    GameScr2.vMob.addElement(bachTuoc);
                }
                else if (bigBoss2 != null)
                {
                    GameScr2.vMob.addElement(bigBoss2);
                }
                else
                {
                    GameScr2.vMob.addElement(mob);
                }
            }
            if (Char2.myCharz().mobMe != null && GameScr2.findMobInMap(Char2.myCharz().mobMe.mobId) == null)
            {
                Char2.myCharz().mobMe.getData();
                Char2.myCharz().mobMe.x = Char2.myCharz().cx;
                Char2.myCharz().mobMe.y = Char2.myCharz().cy - 40;
                GameScr2.vMob.addElement(Char2.myCharz().mobMe);
            }
            num = msg.reader().readByte();
            for (byte b2 = 0; b2 < num; b2++)
            {
            }
            num = msg.reader().readByte();
            for (int j = 0; j < num; j++)
            {
                sbyte b3 = msg.reader().readByte();
                short cx = msg.reader().readShort();
                short num2 = msg.reader().readShort();
                sbyte b4 = msg.reader().readByte();
                short num3 = msg.reader().readShort();
                if (b4 != 6 && ((Char2.myCharz().taskMaint.taskId >= 7 && (Char2.myCharz().taskMaint.taskId != 7 || Char2.myCharz().taskMaint.index > 1)) || (b4 != 7 && b4 != 8 && b4 != 9)) && (Char2.myCharz().taskMaint.taskId >= 6 || b4 != 16))
                {
                    if (b4 == 4)
                    {
                        GameScr2.gI().magicTree = new MagicTree2(j, b3, cx, num2, b4, num3);
                        Service2.gI().magicTree(2);
                        GameScr2.vNpc.addElement(GameScr2.gI().magicTree);
                    }
                    else
                    {
                        Npc2 o = new Npc2(j, b3, cx, num2 + 3, b4, num3);
                        GameScr2.vNpc.addElement(o);
                    }
                }
            }
            num = msg.reader().readByte();
            string empty = string.Empty;
            empty = empty + "item: " + num;
            for (int k = 0; k < num; k++)
            {
                short itemMapID = msg.reader().readShort();
                short num4 = msg.reader().readShort();
                int x = msg.reader().readShort();
                int y = msg.reader().readShort();
                int num5 = msg.reader().readInt();
                short r = 0;
                if (num5 == -2)
                {
                    r = msg.reader().readShort();
                }
                ItemMap2 itemMap = new ItemMap2(num5, itemMapID, num4, x, y, r);
                bool flag = false;
                for (int l = 0; l < GameScr2.vItemMap.size(); l++)
                {
                    ItemMap2 itemMap2 = (ItemMap2)GameScr2.vItemMap.elementAt(l);
                    if (itemMap2.itemMapID == itemMap.itemMapID)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    GameScr2.vItemMap.addElement(itemMap);
                }
                empty = empty + num4 + ",";
            }
            TileMap2.vCurrItem.removeAllElements();
            // if (mGraphics2.zoomLevel == 1)
            // {
            //     BgItem2.clearHashTable();
            // }
            BgItem2.vKeysNew.removeAllElements();
            if (!GameCanvas2.lowGraphic || (GameCanvas2.lowGraphic && TileMap2.isVoDaiMap()) || TileMap2.mapID == 45 || TileMap2.mapID == 46 || TileMap2.mapID == 47 || TileMap2.mapID == 48)
            {
                short num6 = msg.reader().readShort();
                empty = "item high graphic: ";
                for (int m = 0; m < num6; m++)
                {
                    short num7 = msg.reader().readShort();
                    short num8 = msg.reader().readShort();
                    short num9 = msg.reader().readShort();
                    if (TileMap2.getBIById(num7) != null)
                    {
                        BgItem2 bIById = TileMap2.getBIById(num7);
                        BgItem2 bgItem = new BgItem2();
                        bgItem.id = num7;
                        bgItem.idImage = bIById.idImage;
                        bgItem.dx = bIById.dx;
                        bgItem.dy = bIById.dy;
                        bgItem.x = num8 * TileMap2.size;
                        bgItem.y = num9 * TileMap2.size;
                        bgItem.layer = bIById.layer;
                        if (TileMap2.isExistMoreOne(bgItem.id))
                        {
                            bgItem.trans = ((m % 2 != 0) ? 2 : 0);
                            if (TileMap2.mapID == 45)
                            {
                                bgItem.trans = 0;
                            }
                        }
                        Image2 image = null;
                        if (!BgItem2.imgNew.containsKey(bgItem.idImage + string.Empty))
                        {
                            // if (mGraphics2.zoomLevel == 1)
                            // {
                            //     image = GameCanvas2.loadImage("/mapBackGround/" + bgItem.idImage + ".png");
                            //     if (image == null)
                            //     {
                            //         image = Image2.createRGBImage(new int[1], 1, 1, bl: true);
                            //         Service2.gI().getBgTemplate(bgItem.idImage);
                            //     }
                            //     BgItem2.imgNew.put(bgItem.idImage + string.Empty, image);
                            // }
                            // else
                            // {
                            bool flag2 = false;
                            sbyte[] array = Rms2.loadRMS(mGraphics2.zoomLevel + "bgItem" + bgItem.idImage);
                            if (array != null)
                            {
                                sbyte[] newArr = MainMod2.DecryptBytes(array);
                                if (BgItem2.newSmallVersion != null)
                                {
                                    if (newArr.Length % 127 != BgItem2.newSmallVersion[bgItem.idImage])
                                    {
                                        flag2 = true;
                                    }
                                }
                                if (!flag2)
                                {
                                    image = Image2.createImage(newArr, 0, newArr.Length);
                                    if (image != null)
                                    {
                                        BgItem2.imgNew.put(bgItem.idImage + string.Empty, image);
                                    }
                                    else
                                    {
                                        flag2 = true;
                                    }
                                }
                            }
                            else
                            {
                                flag2 = true;
                            }
                            if (flag2)
                            {
                                image = GameCanvas2.loadImage("/mapBackGround/" + bgItem.idImage + ".png");
                                if (image == null)
                                {
                                    image = Image2.createRGBImage(new int[1], 1, 1, bl: true);
                                    Service2.gI().getBgTemplate(bgItem.idImage);
                                }
                                BgItem2.imgNew.put(bgItem.idImage + string.Empty, image);
                            }
                            // }
                            BgItem2.vKeysLast.addElement(bgItem.idImage + string.Empty);
                        }
                        if (!BgItem2.isExistKeyNews(bgItem.idImage + string.Empty))
                        {
                            BgItem2.vKeysNew.addElement(bgItem.idImage + string.Empty);
                        }
                        bgItem.changeColor();
                        TileMap2.vCurrItem.addElement(bgItem);
                    }
                    empty = empty + num7 + ",";
                }
                for (int n = 0; n < BgItem2.vKeysLast.size(); n++)
                {
                    string text = (string)BgItem2.vKeysLast.elementAt(n);
                    if (!BgItem2.isExistKeyNews(text))
                    {
                        BgItem2.imgNew.remove(text);
                        if (BgItem2.imgNew.containsKey(text + "blend" + 1))
                        {
                            BgItem2.imgNew.remove(text + "blend" + 1);
                        }
                        if (BgItem2.imgNew.containsKey(text + "blend" + 3))
                        {
                            BgItem2.imgNew.remove(text + "blend" + 3);
                        }
                        BgItem2.vKeysLast.removeElementAt(n);
                        n--;
                    }
                }
                BackgroudEffect2.isFog = false;
                BackgroudEffect2.nCloud = 0;
                EffecMn2.vEff.removeAllElements();
                BackgroudEffect2.vBgEffect.removeAllElements();
                Effect2_.newEff.removeAllElements();
                short num10 = msg.reader().readShort();
                for (int num11 = 0; num11 < num10; num11++)
                {
                    string key = msg.reader().readUTF();
                    string value = msg.reader().readUTF();
                    keyValueAction(key, value);
                }
            }
            else
            {
                short num12 = msg.reader().readShort();
                for (int num13 = 0; num13 < num12; num13++)
                {
                    short num14 = msg.reader().readShort();
                    short num15 = msg.reader().readShort();
                    short num16 = msg.reader().readShort();
                }
                short num17 = msg.reader().readShort();
                for (int num18 = 0; num18 < num17; num18++)
                {
                    string text2 = msg.reader().readUTF();
                    string text3 = msg.reader().readUTF();
                }
            }
            TileMap2.bgType = msg.reader().readByte();
            sbyte teleport = msg.reader().readByte();
            loadCurrMap(teleport);
            Char2.isLoadingMap = false;
            Resources.UnloadUnusedAssets();
            GC.Collect();
            MainMod2.GI().canUpdate = true;
        }
        catch (Exception)
        {
            AutoXmap2.FixBlackScreen();
        }
    }

    public void LoadAuraNpcs(Message2 msg)
    {
        sbyte sz = msg.reader().readByte();
        for (sbyte i = 0; i < sz; i++)
        {
            sbyte npcId = msg.reader().readByte();
            short auraId = msg.reader().readShort();
            Npc2 npc = MainMod2.GetNpcByTempId(npcId);
            if (npc != null)
            {
                npc.idAura = auraId;
            }
        }
    }

    public void keyValueAction(string key, string value)
    {
        if (key.Equals("eff"))
        {
            if (Panel2.graphics > 0)
            {
                return;
            }
            string[] array = Res2.split(value, ".", 0);
            int id = int.Parse(array[0]);
            int layer = int.Parse(array[1]);
            int x = int.Parse(array[2]);
            int y = int.Parse(array[3]);
            int loop;
            int loopCount;
            if (array.Length <= 4)
            {
                loop = -1;
                loopCount = 1;
            }
            else
            {
                loop = int.Parse(array[4]);
                loopCount = int.Parse(array[5]);
            }
            Effect2_ effect = new Effect2_(id, x, y, layer, loop, loopCount);
            if (array.Length > 6)
            {
                effect.typeEff = int.Parse(array[6]);
                if (array.Length > 7)
                {
                    effect.indexFrom = int.Parse(array[7]);
                    effect.indexTo = int.Parse(array[8]);
                }
            }
            EffecMn2.addEff(effect);
        }
        else if (key.Equals("beff") && Panel2.graphics <= 1)
        {
            BackgroudEffect2.addEffect(int.Parse(value));
        }
    }

    public void messageNotMap(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            switch (b)
            {
                case 16:
                    MoneyCharge2.gI().switchToMe();
                    break;
                case 17:
                    Char2.myCharz().clearTask();
                    break;
                case 18:
                    {
                        GameCanvas2.isLoading = false;
                        GameCanvas2.endDlg();
                        int num2 = msg.reader().readInt();
                        GameCanvas2.inputDlg.show(mResources2.changeNameChar, new Command2(mResources2.OK, GameCanvas2.instance, 88829, num2), TField2.INPUT_TYPE_ANY);
                        break;
                    }
                case 20:
                    Char2.myCharz().cPk = msg.reader().readByte();
                    GameScr2.info1.addInfo(mResources2.PK_NOW + " " + Char2.myCharz().cPk, 0);
                    break;
                case 35:
                    GameCanvas2.endDlg();
                    GameScr2.gI().resetButton();
                    GameScr2.info1.addInfo(msg.reader().readUTF(), 0);
                    break;
                case 36:
                    GameScr2.typeActive = msg.reader().readByte();
                    break;
                case 4:
                    {
                        GameCanvas2.loginScr.savePass();
                        GameScr2.isAutoPlay = false;
                        GameScr2.canAutoPlay = false;
                        LoginScr2.isUpdateAll = true;
                        LoginScr2.isUpdateData = true;
                        LoginScr2.isUpdateMap = true;
                        LoginScr2.isUpdateSkill = true;
                        LoginScr2.isUpdateItem = true;
                        GameScr2.vsData = msg.reader().readByte();
                        GameScr2.vsMap = msg.reader().readByte();
                        GameScr2.vsSkill = msg.reader().readByte();
                        GameScr2.vsItem = msg.reader().readByte();
                        sbyte b3 = msg.reader().readByte();
                        if (GameCanvas2.loginScr.isLogin2)
                        {
                            Rms2.saveRMSString("acc", string.Empty);
                            Rms2.saveRMSString("pass", string.Empty);
                        }
                        else
                        {
                            Rms2.saveRMSString("userAo" + ServerListScreen2.ipSelect, string.Empty);
                        }
                        if (GameScr2.vsData != GameScr2.vcData)
                        {
                            GameScr2.isLoadAllData = false;
                            Service2.gI().updateData();
                        }
                        else
                        {
                            try
                            {
                                LoginScr2.isUpdateData = false;
                            }
                            catch (Exception)
                            {
                                GameScr2.vcData = -1;
                                Service2.gI().updateData();
                            }
                        }
                        if (GameScr2.vsMap != GameScr2.vcMap)
                        {
                            GameScr2.isLoadAllData = false;
                            Service2.gI().updateMap();
                        }
                        else
                        {
                            try
                            {
                                if (!GameScr2.isLoadAllData)
                                {
                                    DataInputStream2 dataInputStream = new DataInputStream2(Rms2.loadRMS("NRmap"));
                                    createMap(dataInputStream.r);
                                }
                                LoginScr2.isUpdateMap = false;
                            }
                            catch (Exception)
                            {
                                GameScr2.vcMap = -1;
                                Service2.gI().updateMap();
                            }
                        }
                        if (GameScr2.vsSkill != GameScr2.vcSkill)
                        {
                            GameScr2.isLoadAllData = false;
                            Service2.gI().updateSkill();
                        }
                        else
                        {
                            try
                            {
                                if (!GameScr2.isLoadAllData)
                                {
                                    DataInputStream2 dataInputStream2 = new(Rms2.loadRMS("NRskill"));
                                    createSkill(dataInputStream2.r);
                                }
                                LoginScr2.isUpdateSkill = false;
                            }
                            catch (Exception)
                            {
                                GameScr2.vcSkill = -1;
                                Service2.gI().updateSkill();
                            }
                        }
                        if (GameScr2.vsItem != GameScr2.vcItem)
                        {
                            GameScr2.isLoadAllData = false;
                            Service2.gI().updateItem();
                        }
                        else
                        {
                            try
                            {
                                DataInputStream2 dataInputStream3 = new(Rms2.loadRMS("NRitem0"));
                                loadItemNew(dataInputStream3.r, 0, isSave: false);
                                DataInputStream2 dataInputStream4 = new(Rms2.loadRMS("NRitem1"));
                                loadItemNew(dataInputStream4.r, 1, isSave: false);
                                DataInputStream2 dataInputStream5 = new(Rms2.loadRMS("NRitem2"));
                                loadItemNew(dataInputStream5.r, 2, isSave: false);
                                DataInputStream2 dataInputStream6 = new(Rms2.loadRMS("NRitem100"));
                                loadItemNew(dataInputStream6.r, 100, isSave: false);
                                LoginScr2.isUpdateItem = false;
                            }
                            catch (Exception)
                            {
                                GameScr2.vcItem = -1;
                                Service2.gI().updateItem();
                            }
                        }
                        if (GameScr2.vsData == GameScr2.vcData && GameScr2.vsMap == GameScr2.vcMap && GameScr2.vsSkill == GameScr2.vcSkill && GameScr2.vsItem == GameScr2.vcItem)
                        {
                            if (!GameScr2.isLoadAllData)
                            {
                                GameScr2.gI().readDart();
                                GameScr2.gI().readEfect();
                                GameScr2.gI().readArrow();
                                GameScr2.gI().readSkill();
                            }
                            Service2.gI().clientOk();
                        }
                        sbyte b4 = msg.reader().readByte();
                        GameScr2.exps = new long[b4];
                        for (int j = 0; j < GameScr2.exps.Length; j++)
                        {
                            GameScr2.exps[j] = msg.reader().readLong();
                        }
                        break;
                    }
                case 6:
                    {
                        msg.reader().mark(100000);
                        createMap(msg.reader());
                        msg.reader().reset();
                        sbyte[] data3 = new sbyte[msg.reader().available()];
                        msg.reader().readFully(ref data3);
                        Rms2.saveRMS("NRmap", data3);
                        sbyte[] data4 = new sbyte[1] { GameScr2.vcMap };
                        Rms2.saveRMS("NRmapVersion", data4);
                        LoginScr2.isUpdateMap = false;
                        if (GameScr2.vsData == GameScr2.vcData && GameScr2.vsMap == GameScr2.vcMap && GameScr2.vsSkill == GameScr2.vcSkill && GameScr2.vsItem == GameScr2.vcItem)
                        {
                            GameScr2.gI().readDart();
                            GameScr2.gI().readEfect();
                            GameScr2.gI().readArrow();
                            GameScr2.gI().readSkill();
                            Service2.gI().clientOk();
                        }
                        break;
                    }
                case 7:
                    {
                        msg.reader().mark(100000);
                        createSkill(msg.reader());
                        msg.reader().reset();
                        sbyte[] data = new sbyte[msg.reader().available()];
                        msg.reader().readFully(ref data);
                        Rms2.saveRMS("NRskill", data);
                        sbyte[] data2 = new sbyte[1] { GameScr2.vcSkill };
                        Rms2.saveRMS("NRskillVersion", data2);
                        LoginScr2.isUpdateSkill = false;
                        if (GameScr2.vsData == GameScr2.vcData && GameScr2.vsMap == GameScr2.vcMap && GameScr2.vsSkill == GameScr2.vcSkill && GameScr2.vsItem == GameScr2.vcItem)
                        {
                            GameScr2.gI().readDart();
                            GameScr2.gI().readEfect();
                            GameScr2.gI().readArrow();
                            GameScr2.gI().readSkill();
                            Service2.gI().clientOk();
                        }
                        break;
                    }
                case 8:
                    Res2.outz("GET UPDATE_ITEM " + msg.reader().available() + " bytes");
                    createItemNew(msg.reader());
                    break;
                case 10:
                    try
                    {
                        Char2.isLoadingMap = true;
                        Res2.outz("REQUEST MAP TEMPLATE");
                        GameCanvas2.isLoading = true;
                        TileMap2.maps = null;
                        TileMap2.types = null;
                        mSystem2.gcc();
                        GameCanvas2.debug("SA99", 2);
                        TileMap2.tmw = msg.reader().readByte();
                        TileMap2.tmh = msg.reader().readByte();
                        TileMap2.maps = new int[TileMap2.tmw * TileMap2.tmh];
                        Res2.err("   M apsize= " + TileMap2.tmw * TileMap2.tmh);
                        for (int i = 0; i < TileMap2.maps.Length; i++)
                        {
                            int num = msg.reader().readByte();
                            if (num < 0)
                            {
                                num += 256;
                            }
                            TileMap2.maps[i] = (ushort)num;
                        }
                        TileMap2.types = new int[TileMap2.maps.Length];
                        msg = messWait;
                        loadInfoMap(msg);
                        try
                        {
                            sbyte b2 = msg.reader().readByte();
                            TileMap2.isMapDouble = ((b2 != 0) ? true : false);
                        }
                        catch (Exception ex)
                        {
                            Res2.err(" 1 LOI TAI CASE REQUEST_MAPTEMPLATE " + ex.ToString());
                        }
                    }
                    catch (Exception ex2)
                    {
                        Res2.err("2 LOI TAI CASE REQUEST_MAPTEMPLATE " + ex2.ToString());
                    }
                    msg.cleanup();
                    messWait.cleanup();
                    msg = (messWait = null);
                    GameScr2.gI().switchToMe();
                    break;
                case 12:
                    GameCanvas2.debug("SA10", 2);
                    break;
                case 9:
                    GameCanvas2.debug("SA11", 2);
                    break;
            }
        }
        catch (Exception)
        {
            Cout2.LogError("LOI TAI messageNotMap + " + msg.command);
        }
        finally
        {
            msg?.cleanup();
        }
    }

    public void messageNotLogin(Message2 msg)
    {
        try
        {
            sbyte cmd = msg.reader().readByte();
            if (cmd == 2)
            {
                string linkDefault = msg.reader().readUTF();
                if (Rms2.loadRMSInt("AdminLink") == 1)
                {
                    return;
                }
                if (mSystem2.clientType == 1)
                {
                    ServerListScreen2.linkDefault = linkDefault;
                }
                else
                {
                    ServerListScreen2.linkDefault = linkDefault;
                }
                mSystem2.AddIpTest();
                ServerListScreen2.GetServerList(ServerListScreen2.linkDefault);
                try
                {
                    sbyte b2 = msg.reader().readByte();
                    Panel2.CanNapTien = b2 == 1;
                    sbyte b3 = msg.reader().readByte();
                    Rms2.saveRMSInt("AdminLink", b3);
                }
                catch (Exception)
                {
                }
            }
            else if (cmd == 4)
            {
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            msg?.cleanup();
        }
    }

    public void messageSubCommand(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            switch (b)
            {
                case 63:
                    {
                        sbyte b5 = msg.reader().readByte();
                        if (b5 > 0)
                        {
                            GameCanvas2.panel.vPlayerMenu_id.removeAllElements();
                            InfoDlg2.showWait();
                            MyVector2 vPlayerMenu = GameCanvas2.panel.vPlayerMenu;
                            for (int j = 0; j < b5; j++)
                            {
                                string caption = msg.reader().readUTF();
                                string caption2 = msg.reader().readUTF();
                                short num5 = msg.reader().readShort();
                                GameCanvas2.panel.vPlayerMenu_id.addElement(num5 + string.Empty);
                                Char2.myCharz().charFocus.menuSelect = num5;
                                Command2 command = new Command2(caption, 11115, Char2.myCharz().charFocus);
                                command.caption2 = caption2;
                                vPlayerMenu.addElement(command);
                            }
                            InfoDlg2.hide();
                            GameCanvas2.panel.setTabPlayerMenu();
                        }
                        break;
                    }
                case 1:
                    GameCanvas2.debug("SA13", 2);
                    Char2.myCharz().nClass = GameScr2.nClasss[msg.reader().readByte()];
                    Char2.myCharz().cTiemNang = msg.reader().readLong();
                    Char2.myCharz().vSkill.removeAllElements();
                    Char2.myCharz().vSkillFight.removeAllElements();
                    Char2.myCharz().myskill = null;
                    break;
                case 2:
                    {
                        GameCanvas2.debug("SA14", 2);
                        if (Char2.myCharz().statusMe != 14 && Char2.myCharz().statusMe != 5)
                        {
                            Char2.myCharz().cHP = Char2.myCharz().cHPFull;
                            Char2.myCharz().cMP = Char2.myCharz().cMPFull;
                            Cout2.LogError2(" ME_LOAD_SKILL");
                        }
                        Char2.myCharz().vSkill.removeAllElements();
                        Char2.myCharz().vSkillFight.removeAllElements();
                        sbyte b2 = msg.reader().readByte();
                        for (sbyte b3 = 0; b3 < b2; b3++)
                        {
                            short skillId = msg.reader().readShort();
                            Skill2 skill2 = Skills2.get(skillId);
                            useSkill(skill2);
                        }
                        GameScr2.gI().sortSkill();
                        if (GameScr2.isPaintInfoMe)
                        {
                            GameScr2.indexRow = -1;
                            GameScr2.gI().left = (GameScr2.gI().center = null);
                        }
                        break;
                    }
                case 19:
                    GameCanvas2.debug("SA17", 2);
                    Char2.myCharz().boxSort();
                    break;
                case 21:
                    {
                        int num3 = msg.reader().readInt();
                        Char2.myCharz().xuInBox -= num3;
                        Char2.myCharz().xu += num3;
                        Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                        break;
                    }
                case 0:
                    {
                        RadarScr2.list = new MyVector2();
                        Teleport2.vTeleport.removeAllElements();
                        GameScr2.vCharInMap.removeAllElements();
                        GameScr2.vItemMap.removeAllElements();
                        Char2.vItemTime.removeAllElements();
                        GameScr2.loadImg();
                        GameScr2.currentCharViewInfo = Char2.myCharz();
                        Char2.myCharz().charID = msg.reader().readInt();
                        Char2.myCharz().ctaskId = msg.reader().readByte();
                        Char2.myCharz().cgender = msg.reader().readByte();
                        Char2.myCharz().head = msg.reader().readShort();
                        Char2.myCharz().cName = msg.reader().readUTF();
                        Char2.myCharz().cPk = msg.reader().readByte();
                        Char2.myCharz().cTypePk = msg.reader().readByte();
                        Char2.myCharz().cPower = msg.reader().readLong();
                        Char2.myCharz().applyCharLevelPercent();
                        Char2.myCharz().eff5BuffHp = msg.reader().readShort();
                        Char2.myCharz().eff5BuffMp = msg.reader().readShort();
                        Char2.myCharz().nClass = GameScr2.nClasss[msg.reader().readByte()];
                        Char2.myCharz().vSkill.removeAllElements();
                        Char2.myCharz().vSkillFight.removeAllElements();
                        GameScr2.gI().dHP = Char2.myCharz().cHP;
                        GameScr2.gI().dMP = Char2.myCharz().cMP;
                        sbyte b2 = msg.reader().readByte();
                        for (sbyte b6 = 0; b6 < b2; b6++)
                        {
                            Skill2 skill3 = Skills2.get(msg.reader().readShort());
                            useSkill(skill3);
                        }
                        GameScr2.gI().sortSkill();
                        GameScr2.gI().loadSkillShortcut();
                        Char2.myCharz().xu = msg.reader().readLong();
                        Char2.myCharz().luongKhoa = msg.reader().readInt();
                        Char2.myCharz().luong = msg.reader().readInt();
                        Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                        Char2.myCharz().luongStr = mSystem2.numberTostring(Char2.myCharz().luong);
                        Char2.myCharz().luongKhoaStr = mSystem2.numberTostring(Char2.myCharz().luongKhoa);
                        Char2.myCharz().arrItemBody = new Item2[msg.reader().readByte()];
                        try
                        {
                            Char2.myCharz().setDefaultPart();
                            for (int k = 0; k < Char2.myCharz().arrItemBody.Length; k++)
                            {
                                short num6 = msg.reader().readShort();
                                if (num6 == -1)
                                {
                                    continue;
                                }
                                ItemTemplate2 itemTemplate = ItemTemplates2.get(num6);
                                int num7 = itemTemplate.type;
                                Char2.myCharz().arrItemBody[k] = new Item2();
                                Char2.myCharz().arrItemBody[k].template = itemTemplate;
                                Char2.myCharz().arrItemBody[k].quantity = msg.reader().readInt();
                                Char2.myCharz().arrItemBody[k].info = msg.reader().readUTF();
                                Char2.myCharz().arrItemBody[k].content = msg.reader().readUTF();
                                int num8 = msg.reader().readUnsignedByte();
                                if (num8 != 0)
                                {
                                    Char2.myCharz().arrItemBody[k].itemOption = new ItemOption2[num8];
                                    for (int l = 0; l < Char2.myCharz().arrItemBody[k].itemOption.Length; l++)
                                    {
                                        int num9 = msg.reader().readUnsignedByte();
                                        int param = msg.reader().readUnsignedShort();
                                        if (num9 != -1)
                                        {
                                            Char2.myCharz().arrItemBody[k].itemOption[l] = new ItemOption2(num9, param);
                                        }
                                    }
                                }
                                switch (num7)
                                {
                                    case 0:
                                        Char2.myCharz().body = Char2.myCharz().arrItemBody[k].template.part;
                                        break;
                                    case 1:
                                        Char2.myCharz().leg = Char2.myCharz().arrItemBody[k].template.part;
                                        break;
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        Char2.myCharz().arrItemBag = new Item2[msg.reader().readByte()];
                        GameScr2.hpPotion = 0;
                        for (int m = 0; m < Char2.myCharz().arrItemBag.Length; m++)
                        {
                            short num10 = msg.reader().readShort();
                            if (num10 == -1)
                            {
                                continue;
                            }
                            Char2.myCharz().arrItemBag[m] = new Item2();
                            Char2.myCharz().arrItemBag[m].template = ItemTemplates2.get(num10);
                            Char2.myCharz().arrItemBag[m].quantity = msg.reader().readInt();
                            Char2.myCharz().arrItemBag[m].info = msg.reader().readUTF();
                            Char2.myCharz().arrItemBag[m].content = msg.reader().readUTF();
                            Char2.myCharz().arrItemBag[m].indexUI = m;
                            sbyte b7 = msg.reader().readByte();
                            if (b7 != 0)
                            {
                                Char2.myCharz().arrItemBag[m].itemOption = new ItemOption2[b7];
                                for (int n = 0; n < Char2.myCharz().arrItemBag[m].itemOption.Length; n++)
                                {
                                    int num11 = msg.reader().readUnsignedByte();
                                    int param2 = msg.reader().readUnsignedShort();
                                    if (num11 != -1)
                                    {
                                        Char2.myCharz().arrItemBag[m].itemOption[n] = new ItemOption2(num11, param2);
                                        Char2.myCharz().arrItemBag[m].getCompare();
                                    }
                                }
                            }
                            if (Char2.myCharz().arrItemBag[m].template.type == 6)
                            {
                                GameScr2.hpPotion += Char2.myCharz().arrItemBag[m].quantity;
                            }
                        }
                        Char2.myCharz().arrItemBox = new Item2[msg.reader().readByte()];
                        GameCanvas2.panel.hasUse = 0;
                        for (int num12 = 0; num12 < Char2.myCharz().arrItemBox.Length; num12++)
                        {
                            short num13 = msg.reader().readShort();
                            if (num13 == -1)
                            {
                                continue;
                            }
                            Char2.myCharz().arrItemBox[num12] = new Item2();
                            Char2.myCharz().arrItemBox[num12].template = ItemTemplates2.get(num13);
                            Char2.myCharz().arrItemBox[num12].quantity = msg.reader().readInt();
                            Char2.myCharz().arrItemBox[num12].info = msg.reader().readUTF();
                            Char2.myCharz().arrItemBox[num12].content = msg.reader().readUTF();
                            Char2.myCharz().arrItemBox[num12].itemOption = new ItemOption2[msg.reader().readByte()];
                            for (int num14 = 0; num14 < Char2.myCharz().arrItemBox[num12].itemOption.Length; num14++)
                            {
                                int num15 = msg.reader().readUnsignedByte();
                                int param3 = msg.reader().readUnsignedShort();
                                if (num15 != -1)
                                {
                                    Char2.myCharz().arrItemBox[num12].itemOption[num14] = new ItemOption2(num15, param3);
                                    Char2.myCharz().arrItemBox[num12].getCompare();
                                }
                            }
                            GameCanvas2.panel.hasUse++;
                        }
                        Char2.myCharz().statusMe = 4;
                        int num16 = Rms2.loadRMSInt(Char2.myCharz().cName + "vci");
                        if (num16 < 1)
                        {
                            GameScr2.isViewClanInvite = false;
                        }
                        else
                        {
                            GameScr2.isViewClanInvite = true;
                        }
                        short num17 = msg.reader().readShort();
                        Char2.idHead = new short[num17];
                        Char2.idAvatar = new short[num17];
                        for (int num18 = 0; num18 < num17; num18++)
                        {
                            Char2.idHead[num18] = msg.reader().readShort();
                            Char2.idAvatar[num18] = msg.reader().readShort();
                        }
                        for (int num19 = 0; num19 < GameScr2.info1.charId.Length; num19++)
                        {
                            GameScr2.info1.charId[num19] = new int[3];
                        }
                        GameScr2.info1.charId[Char2.myCharz().cgender][0] = msg.reader().readShort();
                        GameScr2.info1.charId[Char2.myCharz().cgender][1] = msg.reader().readShort();
                        GameScr2.info1.charId[Char2.myCharz().cgender][2] = msg.reader().readShort();
                        Char2.myCharz().isNhapThe = msg.reader().readByte() == 1;
                        GameScr2.deltaTime = mSystem2.currentTimeMillis() - (long)msg.reader().readInt() * 1000L;
                        GameScr2.isNewMember = msg.reader().readByte();
                        Char2.myCharz().isTichXanh = GameScr2.isNewMember == 1;
                        Service2.gI().updateCaption((sbyte)Char2.myCharz().cgender);
                        Service2.gI().androidPack();
                        try
                        {
                            Char2.myCharz().idAuraEff = msg.reader().readShort();
                            Char2.myCharz().idEff_Set_Item = msg.reader().readSByte();
                            Char2.myCharz().idHat = msg.reader().readShort();
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            Char2.myCharz().isTichDo = msg.reader().readByte() == 1;
                        }
                        catch
                        {
                        }
                        break;
                    }
                case 4:
                    Char2.myCharz().xu = msg.reader().readLong();
                    Char2.myCharz().luong = msg.reader().readInt();
                    Char2.myCharz().cHP = msg.readLong();
                    Char2.myCharz().cMP = msg.readLong();
                    Char2.myCharz().luongKhoa = msg.reader().readInt();
                    Char2.myCharz().xuStr = mSystem2.numberTostring(Char2.myCharz().xu);
                    Char2.myCharz().luongStr = mSystem2.numberTostring(Char2.myCharz().luong);
                    Char2.myCharz().luongKhoaStr = mSystem2.numberTostring(Char2.myCharz().luongKhoa);
                    break;
                case 5:
                    {
                        long cHP = Char2.myCharz().cHP;
                        Char2.myCharz().cHP = msg.readLong();
                        if (Char2.myCharz().cHP > cHP && Char2.myCharz().cTypePk != 4)
                        {
                            GameScr2.startFlyText("+" + (Char2.myCharz().cHP - cHP) + " " + mResources2.HP, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 20, 0, -1, mFont2.HP);
                            SoundMn2.gI().HP_MPup();
                            if (Char2.myCharz().petFollow != null && Char2.myCharz().petFollow.smallID == 5003)
                            {
                                MonsterDart2.addMonsterDart(Char2.myCharz().petFollow.cmx + ((Char2.myCharz().petFollow.dir != 1) ? (-10) : 10), Char2.myCharz().petFollow.cmy + 10, isBoss: true, -1, -1, Char2.myCharz(), 29);
                            }
                        }
                        if (Char2.myCharz().cHP < cHP)
                        {
                            GameScr2.startFlyText("-" + (cHP - Char2.myCharz().cHP) + " " + mResources2.HP, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 20, 0, -1, mFont2.HP);
                        }
                        GameScr2.gI().dHP = Char2.myCharz().cHP;
                        if (GameScr2.isPaintInfoMe)
                        {
                        }
                        break;
                    }
                case 6:
                    {
                        if (Char2.myCharz().statusMe == 14 || Char2.myCharz().statusMe == 5)
                        {
                            break;
                        }
                        long cMP = Char2.myCharz().cMP;
                        Char2.myCharz().cMP = msg.readLong();
                        if (Char2.myCharz().cMP > cMP)
                        {
                            GameScr2.startFlyText("+" + (Char2.myCharz().cMP - cMP) + " " + mResources2.KI, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 23, 0, -2, mFont2.MP);
                            SoundMn2.gI().HP_MPup();
                            if (Char2.myCharz().petFollow != null && Char2.myCharz().petFollow.smallID == 5001)
                            {
                                MonsterDart2.addMonsterDart(Char2.myCharz().petFollow.cmx + ((Char2.myCharz().petFollow.dir != 1) ? (-10) : 10), Char2.myCharz().petFollow.cmy + 10, isBoss: true, -1, -1, Char2.myCharz(), 29);
                            }
                        }
                        if (Char2.myCharz().cMP < cMP)
                        {
                            GameScr2.startFlyText("-" + (cMP - Char2.myCharz().cMP) + " " + mResources2.KI, Char2.myCharz().cx, Char2.myCharz().cy - Char2.myCharz().ch - 23, 0, -2, mFont2.MP);
                        }
                        GameScr2.gI().dMP = Char2.myCharz().cMP;
                        if (GameScr2.isPaintInfoMe)
                        {
                        }
                        break;
                    }
                case 7:
                    {
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char == null)
                        {
                            break;
                        }
                        @char.clanID = msg.reader().readInt();
                        if (@char.clanID == -2)
                        {
                            @char.isCopy = true;
                        }
                        readCharInfo(@char, msg);
                        try
                        {
                            @char.idAuraEff = msg.reader().readShort();
                            @char.idEff_Set_Item = msg.reader().readSByte();
                            @char.idHat = msg.reader().readShort();
                            if (@char.bag >= 201)
                            {
                                Effect2_ effect = new Effect2_(@char.bag, @char, 2, -1, 10, 1);
                                effect.typeEff = 5;
                                @char.addEffChar(effect);
                            }
                            else
                            {
                                @char.removeEffChar(0, 201);
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                case 8:
                    {
                        GameCanvas2.debug("SA26", 2);
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cspeed = msg.reader().readByte();
                        }
                        break;
                    }
                case 9:
                    {
                        GameCanvas2.debug("SA27", 2);
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cHP = msg.readInt3Byte();
                            @char.cHPFull = msg.readInt3Byte();
                        }
                        break;
                    }
                case 10:
                    {
                        GameCanvas2.debug("SA28", 2);
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cHP = msg.readInt3Byte();
                            @char.cHPFull = msg.readInt3Byte();
                            @char.eff5BuffHp = msg.reader().readShort();
                            @char.eff5BuffMp = msg.reader().readShort();
                            @char.wp = msg.reader().readShort();
                            if (@char.wp == -1)
                            {
                                @char.setDefaultWeapon();
                            }
                        }
                        break;
                    }
                case 11:
                    {
                        GameCanvas2.debug("SA29", 2);
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cHP = msg.readInt3Byte();
                            @char.cHPFull = msg.readInt3Byte();
                            @char.eff5BuffHp = msg.reader().readShort();
                            @char.eff5BuffMp = msg.reader().readShort();
                            @char.body = msg.reader().readShort();
                            if (@char.body == -1)
                            {
                                @char.setDefaultBody();
                            }
                        }
                        break;
                    }
                case 12:
                    {
                        GameCanvas2.debug("SA30", 2);
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cHP = msg.readInt3Byte();
                            @char.cHPFull = msg.readInt3Byte();
                            @char.eff5BuffHp = msg.reader().readShort();
                            @char.eff5BuffMp = msg.reader().readShort();
                            @char.leg = msg.reader().readShort();
                            if (@char.leg == -1)
                            {
                                @char.setDefaultLeg();
                            }
                        }
                        break;
                    }
                case 13:
                    {
                        GameCanvas2.debug("SA31", 2);
                        int num2 = msg.reader().readInt();
                        Char2 @char = ((num2 != Char2.myCharz().charID) ? GameScr2.findCharInMap(num2) : Char2.myCharz());
                        if (@char != null)
                        {
                            @char.cHP = msg.readInt3Byte();
                            @char.cHPFull = msg.readInt3Byte();
                            @char.eff5BuffHp = msg.reader().readShort();
                            @char.eff5BuffMp = msg.reader().readShort();
                        }
                        break;
                    }
                case 14:
                    {
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char == null)
                        {
                            break;
                        }
                        @char.cHP = msg.readLong();
                        sbyte b4 = msg.reader().readByte();
                        if (b4 == 1)
                        {
                            ServerEffect2.addServerEffect(11, @char, 5);
                            ServerEffect2.addServerEffect(104, @char, 4);
                        }
                        if (b4 == 2)
                        {
                            @char.doInjure();
                        }
                        try
                        {
                            @char.cHPFull = msg.readLong();
                            break;
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                case 15:
                    {
                        Char2 @char = GameScr2.findCharInMap(msg.reader().readInt());
                        if (@char != null)
                        {
                            @char.cHP = msg.readLong();
                            @char.cHPFull = msg.readLong();
                            @char.cx = msg.reader().readShort();
                            @char.cy = msg.reader().readShort();
                            @char.statusMe = 1;
                            @char.cp3 = 3;
                            ServerEffect2.addServerEffect(109, @char, 2);
                        }
                        break;
                    }
                case 35:
                    {
                        GameCanvas2.debug("SY3", 2);
                        int num4 = msg.reader().readInt();
                        Res2.outz("CID = " + num4);
                        if (TileMap2.mapID == 130)
                        {
                            GameScr2.gI().starVS();
                        }
                        if (num4 == Char2.myCharz().charID)
                        {
                            Char2.myCharz().cTypePk = msg.reader().readByte();
                            if (GameScr2.gI().isVS() && Char2.myCharz().cTypePk != 0)
                            {
                                GameScr2.gI().starVS();
                            }
                            Res2.outz("type pk= " + Char2.myCharz().cTypePk);
                            Char2.myCharz().npcFocus = null;
                            if (!GameScr2.gI().isMeCanAttackMob(Char2.myCharz().mobFocus))
                            {
                                Char2.myCharz().mobFocus = null;
                            }
                            Char2.myCharz().itemFocus = null;
                        }
                        else
                        {
                            Char2 @char = GameScr2.findCharInMap(num4);
                            if (@char != null)
                            {
                                Res2.outz("type pk= " + @char.cTypePk);
                                @char.cTypePk = msg.reader().readByte();
                                if (@char.isAttacPlayerStatus())
                                {
                                    Char2.myCharz().charFocus = @char;
                                }
                            }
                        }
                        for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
                        {
                            Char2 char2 = GameScr2.findCharInMap(i);
                            if (char2 != null && char2.cTypePk != 0 && char2.cTypePk == Char2.myCharz().cTypePk)
                            {
                                if (!Char2.myCharz().mobFocus.isMobMe)
                                {
                                    Char2.myCharz().mobFocus = null;
                                }
                                Char2.myCharz().npcFocus = null;
                                Char2.myCharz().itemFocus = null;
                                break;
                            }
                        }
                        Res2.outz("update type pk= ");
                        break;
                    }
                case 61:
                    {
                        string text = msg.reader().readUTF();
                        sbyte[] data = new sbyte[msg.reader().readInt()];
                        msg.reader().read(ref data);
                        if (data.Length == 0)
                        {
                            data = null;
                        }
                        if (text.Equals("KSkill"))
                        {
                            GameScr2.gI().onKSkill(data);
                        }
                        else if (text.Equals("OSkill"))
                        {
                            GameScr2.gI().onOSkill(data);
                        }
                        else if (text.Equals("CSkill"))
                        {
                            GameScr2.gI().onCSkill(data);
                        }
                        break;
                    }
                case 23:
                    {
                        short num = msg.reader().readShort();
                        Skill2 skill = Skills2.get(num);
                        useSkill(skill);
                        if (num != 0 && num != 14 && num != 28)
                        {
                            GameScr2.info1.addInfo(mResources2.LEARN_SKILL + " " + skill.template.name, 0);
                        }
                        break;
                    }
                case 62:
                    Res2.outz("ME UPDATE SKILL");
                    read_UpdateSkill(msg);
                    break;
            }
        }
        catch (Exception ex5)
        {
            Cout2.println("Loi tai Sub : " + ex5.ToString());
        }
        finally
        {
            msg?.cleanup();
        }
    }

    private void useSkill(Skill2 skill)
    {
        if (Char2.myCharz().myskill == null)
        {
            Char2.myCharz().myskill = skill;
        }
        else if (skill.template.Equals(Char2.myCharz().myskill.template))
        {
            Char2.myCharz().myskill = skill;
        }
        Char2.myCharz().vSkill.addElement(skill);
        if ((skill.template.type == 1
            || skill.template.type == 4
            || skill.template.type == 2
            || skill.template.type == 3) && (skill.template.maxPoint == 0 || (skill.template.maxPoint > 0 && skill.point > 0)))
        {
            if (skill.template.id == Char2.myCharz().skillTemplateId)
            {
                Service2.gI().selectSkill(Char2.myCharz().skillTemplateId);
            }
            Char2.myCharz().vSkillFight.addElement(skill);
        }
    }

    public bool readCharInfo(Char2 c, Message2 msg)
    {
        try
        {
            c.clevel = msg.reader().readByte();
            c.isInvisiblez = msg.reader().readBoolean();
            c.cTypePk = msg.reader().readByte();
            c.nClass = GameScr2.nClasss[msg.reader().readByte()];
            c.cgender = msg.reader().readByte();
            c.head = msg.reader().readShort();
            c.cName = msg.reader().readUTF();
            c.cHP = msg.readLong();
            c.dHP = c.cHP;
            if (c.cHP == 0)
            {
                c.statusMe = 14;
            }
            c.cHPFull = msg.readLong();
            if (c.cy >= TileMap2.pxh - 100)
            {
                c.isFlyUp = true;
            }
            c.body = msg.reader().readShort();
            c.leg = msg.reader().readShort();
            c.bag = msg.reader().readUnsignedByte();
            c.isShadown = true;
            sbyte b = msg.reader().readByte();
            if (c.wp == -1)
            {
                c.setDefaultWeapon();
            }
            if (c.body == -1)
            {
                c.setDefaultBody();
            }
            if (c.leg == -1)
            {
                c.setDefaultLeg();
            }
            c.cx = msg.reader().readShort();
            c.cy = msg.reader().readShort();
            c.xSd = c.cx;
            c.ySd = c.cy;
            c.eff5BuffHp = msg.reader().readShort();
            c.eff5BuffMp = msg.reader().readShort();
            int num = msg.reader().readByte();
            for (int i = 0; i < num; i++)
            {
                EffectChar2 effectChar = new EffectChar2(msg.reader().readByte(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort());
                c.vEff.addElement(effectChar);
                if (effectChar.template.type == 12 || effectChar.template.type == 11)
                {
                    c.isInvisiblez = true;
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        return false;
    }

    private void readGetImgByName(Message2 msg)
    {
        try
        {
            string text = msg.reader().readUTF();
            sbyte nFrame = msg.reader().readByte();
            sbyte[] array = null;
            array = NinjaUtil2.readByteArray(msg);
            sbyte[] newArr = MainMod2.DecryptBytes(array);
            Image2 img = createImage(newArr);
            ImgByName2.SetImage(text, img, nFrame);
            if (array != null)
            {
                ImgByName2.saveRMS(text, nFrame, array);
            }
        }
        catch (Exception)
        {
        }
    }

    private void createItemNew(myReader2 d)
    {
        try
        {
            loadItemNew(d, -1, isSave: true);
        }
        catch (Exception)
        {
        }
    }

    private void loadItemNew(myReader2 d, sbyte type, bool isSave)
    {
        try
        {
            d.mark(100000);
            GameScr2.vcItem = d.readByte();
            type = d.readByte();
            if (type == 0)
            {
                GameScr2.gI().iOptionTemplates = new ItemOptionTemplate2[d.readUnsignedByte()];
                for (int i = 0; i < GameScr2.gI().iOptionTemplates.Length; i++)
                {
                    GameScr2.gI().iOptionTemplates[i] = new ItemOptionTemplate2();
                    GameScr2.gI().iOptionTemplates[i].id = i;
                    GameScr2.gI().iOptionTemplates[i].name = d.readUTF();
                    GameScr2.gI().iOptionTemplates[i].type = d.readByte();
                }
                if (isSave)
                {
                    d.reset();
                    sbyte[] data = new sbyte[d.available()];
                    d.readFully(ref data);
                    Rms2.saveRMS("NRitem0", data);
                }
            }
            else if (type == 1)
            {
                ItemTemplates2.itemTemplates.clear();
                int num = d.readShort();
                for (int j = 0; j < num; j++)
                {
                    ItemTemplate2 it = new ItemTemplate2((short)j, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBoolean());
                    ItemTemplates2.add(it);
                }
                if (isSave)
                {
                    d.reset();
                    sbyte[] data2 = new sbyte[d.available()];
                    d.readFully(ref data2);
                    Rms2.saveRMS("NRitem1", data2);
                }
            }
            else if (type == 2)
            {
                int num2 = d.readShort();
                int num3 = d.readShort();
                for (int k = num2; k < num3; k++)
                {
                    ItemTemplate2 it2 = new ItemTemplate2((short)k, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readInt(), d.readShort(), d.readShort(), d.readBoolean());
                    ItemTemplates2.add(it2);
                }
                if (isSave)
                {
                    d.reset();
                    sbyte[] data3 = new sbyte[d.available()];
                    d.readFully(ref data3);
                    Rms2.saveRMS("NRitem2", data3);
                    sbyte[] data4 = new sbyte[1] { GameScr2.vcItem };
                    Rms2.saveRMS("NRitemVersion", data4);
                    LoginScr2.isUpdateItem = false;
                    if (GameScr2.vsData == GameScr2.vcData && GameScr2.vsMap == GameScr2.vcMap && GameScr2.vsSkill == GameScr2.vcSkill && GameScr2.vsItem == GameScr2.vcItem)
                    {
                        GameScr2.gI().readDart();
                        GameScr2.gI().readEfect();
                        GameScr2.gI().readArrow();
                        GameScr2.gI().readSkill();
                        Service2.gI().clientOk();
                    }
                }
            }
            else if (type == 100)
            {
                Char2.Arr_Head_2Fr = readArrHead(d);
                if (isSave)
                {
                    d.reset();
                    sbyte[] data5 = new sbyte[d.available()];
                    d.readFully(ref data5);
                    Rms2.saveRMS("NRitem100", data5);
                }
            }
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    private void readFrameBoss(Message2 msg, int mobTemplateId)
    {
        try
        {
            int num = msg.reader().readByte();
            int[][] array = new int[num][];
            for (int i = 0; i < num; i++)
            {
                int num2 = msg.reader().readByte();
                array[i] = new int[num2];
                for (int j = 0; j < num2; j++)
                {
                    array[i][j] = msg.reader().readByte();
                }
            }
            frameHT_NEWBOSS.put(mobTemplateId + string.Empty, array);
        }
        catch (Exception)
        {
        }
    }

    private int[][] readArrHead(myReader2 d)
    {
        int[][] array = new int[1][] { new int[2] { 542, 543 } };
        try
        {
            int num = d.readShort();
            array = new int[num][];
            for (int i = 0; i < array.Length; i++)
            {
                int num2 = d.readByte();
                array[i] = new int[num2];
                for (int j = 0; j < num2; j++)
                {
                    array[i][j] = d.readShort();
                }
            }
        }
        catch (Exception)
        {
        }
        return array;
    }

    public void phuban_Info(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                readPhuBan_CHIENTRUONGNAMEK(msg, b);
            }
        }
        catch (Exception)
        {
        }
    }

    private void readPhuBan_CHIENTRUONGNAMEK(Message2 msg, int type_PB)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                short idmapPaint = msg.reader().readShort();
                string nameTeam = msg.reader().readUTF();
                string nameTeam2 = msg.reader().readUTF();
                int maxPoint = msg.reader().readInt();
                short timeSecond = msg.reader().readShort();
                int maxLife = msg.reader().readByte();
                GameScr2.phuban_Info = new InfoPhuBan2(type_PB, idmapPaint, nameTeam, nameTeam2, maxPoint, timeSecond);
                GameScr2.phuban_Info.maxLife = maxLife;
                GameScr2.phuban_Info.updateLife(type_PB, 0, 0);
            }
            else if (b == 1)
            {
                int pointTeam = msg.reader().readInt();
                int pointTeam2 = msg.reader().readInt();
                if (GameScr2.phuban_Info != null)
                {
                    GameScr2.phuban_Info.updatePoint(type_PB, pointTeam, pointTeam2);
                }
            }
            else if (b == 2)
            {
                sbyte b2 = msg.reader().readByte();
                short type = 0;
                short num = -1;
                if (b2 == 1)
                {
                    type = 1;
                    num = 3;
                }
                else if (b2 == 2)
                {
                    type = 2;
                }
                num = -1;
                GameScr2.phuban_Info = null;
                GameScr2.addEffectEnd(type, num, 0, GameCanvas2.hw, GameCanvas2.hh, 0, 0, -1, null);
            }
            else if (b == 5)
            {
                short timeSecond2 = msg.reader().readShort();
                if (GameScr2.phuban_Info != null)
                {
                    GameScr2.phuban_Info.updateTime(type_PB, timeSecond2);
                }
            }
            else if (b == 4)
            {
                int lifeTeam = msg.reader().readByte();
                int lifeTeam2 = msg.reader().readByte();
                if (GameScr2.phuban_Info != null)
                {
                    GameScr2.phuban_Info.updateLife(type_PB, lifeTeam, lifeTeam2);
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public void read_opt(Message2 msg)
    {
        try
        {
            sbyte b = msg.reader().readByte();
            if (b == 0)
            {
                short idHat = msg.reader().readShort();
                Char2.myCharz().idHat = idHat;
                SoundMn2.gI().getStrOption();
            }
            else if (b == 2)
            {
                int num = msg.reader().readInt();
                sbyte b2 = msg.reader().readByte();
                short num2 = msg.reader().readShort();
                string v = num2 + "," + b2;
                MainImage2 imagePath = ImgByName2.getImagePath("banner_" + num2, ImgByName2.hashImagePath);
                GameCanvas2.danhHieu.put(num + string.Empty, v);
            }
            else if (b == 3)
            {
                short num3 = msg.reader().readShort();
                SmallImage2.createImage(num3);
                BackgroudEffect2.id_water1 = num3;
            }
            else if (b == 4)
            {
                string o = msg.reader().readUTF();
                GameCanvas2.messageServer.addElement(o);
            }
        }
        catch (Exception)
        {
        }
    }

    public void read_UpdateSkill(Message2 msg)
    {
        try
        {
            short skillId = msg.reader().readShort();
            sbyte type = -1;
            try
            {
                type = msg.reader().readSByte();
            }
            catch (Exception)
            {
            }
            if (type == 0)
            {
                short curExp = msg.reader().readShort();
                for (int i = 0; i < Char2.myCharz().vSkill.size(); i++)
                {
                    Skill2 skill = (Skill2)Char2.myCharz().vSkill.elementAt(i);
                    if (skill.skillId == skillId)
                    {
                        skill.curExp = curExp;
                        break;
                    }
                }
            }
            else if (type == 1)
            {
                sbyte gender = msg.reader().readByte();
                for (int i = 0; i < Char2.myCharz().vSkill.size(); i++)
                {
                    Skill2 skill2 = (Skill2)Char2.myCharz().vSkill.elementAt(i);
                    if (skill2.skillId == skillId)
                    {
                        for (int k = 0; k < 20; k++)
                        {
                            string nameImg = "Skills_" + skill2.template.id + "_" + gender + "_" + k;
                            MainImage2 imagePath = ImgByName2.getImagePath(nameImg, ImgByName2.hashImagePath);
                        }
                        break;
                    }
                }
            }
            else
            {
                if (type != -1)
                {
                    return;
                }
                Skill2 skill3 = Skills2.get(skillId);
                for (int l = 0; l < Char2.myCharz().vSkill.size(); l++)
                {
                    Skill2 skill4 = (Skill2)Char2.myCharz().vSkill.elementAt(l);
                    if (skill4.template.id == skill3.template.id)
                    {
                        Char2.myCharz().vSkill.setElementAt(skill3, l);
                        break;
                    }
                }
                for (int m = 0; m < Char2.myCharz().vSkillFight.size(); m++)
                {
                    Skill2 skill5 = (Skill2)Char2.myCharz().vSkillFight.elementAt(m);
                    if (skill5.template.id == skill3.template.id)
                    {
                        Char2.myCharz().vSkillFight.setElementAt(skill3, m);
                        break;
                    }
                }
                for (int n = 0; n < GameScr2.onScreenSkill.Length; n++)
                {
                    if (GameScr2.onScreenSkill[n] != null && GameScr2.onScreenSkill[n].template.id == skill3.template.id)
                    {
                        GameScr2.onScreenSkill[n] = skill3;
                        break;
                    }
                }
                for (int num2 = 0; num2 < GameScr2.keySkill.Length; num2++)
                {
                    if (GameScr2.keySkill[num2] != null && GameScr2.keySkill[num2].template.id == skill3.template.id)
                    {
                        GameScr2.keySkill[num2] = skill3;
                        break;
                    }
                }
                if (Char2.myCharz().myskill.template.id == skill3.template.id)
                {
                    Char2.myCharz().myskill = skill3;
                }
                GameScr2.info1.addInfo(mResources2.hasJustUpgrade1 + skill3.template.name + mResources2.hasJustUpgrade2 + skill3.point, 0);
            }
        }
        catch (Exception)
        {
        }
    }
}
