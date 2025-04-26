using System;

public class Service2
{
    private ISession2 session = Session_ME2_.gI();

    protected static Service2 instance;

    public static long curCheckController;

    public static long curCheckMap;

    public static long logController;

    public static long logMap;

    public int demGui;

    public static bool reciveFromMainSession;

    public static Service2 gI()
    {
        if (instance == null)
        {
            instance = new Service2();
        }
        return instance;
    }

    public void gotoPlayer(int id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)18);
            message.writer().writeInt(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void androidPack()
    {
        if (mSystem2.android_pack == null)
        {
            return;
        }
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)126);
            message.writer().writeUTF(mSystem2.android_pack);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void charInfo(string day, string month, string year, string address, string cmnd, string dayCmnd, string noiCapCmnd, string sdt, string name)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)42);
            message.writer().writeUTF(day);
            message.writer().writeUTF(month);
            message.writer().writeUTF(year);
            message.writer().writeUTF(address);
            message.writer().writeUTF(cmnd);
            message.writer().writeUTF(dayCmnd);
            message.writer().writeUTF(noiCapCmnd);
            message.writer().writeUTF(sdt);
            message.writer().writeUTF(name);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void androidPack2()
    {
        if (mSystem2.android_pack == null)
        {
            return;
        }
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)126);
            message.writer().writeUTF(mSystem2.android_pack);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void checkAd(sbyte status)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-44));
            message.writer().writeByte(status);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void combine(sbyte action, MyVector2 id)
    {
        Res2.outz("combine");
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-81));
            message.writer().writeByte(action);
            if (action == 1)
            {
                message.writer().writeByte(id.size());
                for (int i = 0; i < id.size(); i++)
                {
                    message.writer().writeByte(((Item2)id.elementAt(i)).indexUI);
                    Res2.outz("gui id " + ((Item2)id.elementAt(i)).indexUI);
                }
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void giaodich(sbyte action, int playerID, sbyte index, int num)
    {
        Res2.outz2("giao dich action = " + action);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-86);
            message.writer().writeByte(action);
            if (action == 0 || action == 1)
            {
                Res2.outz2(">>>> len playerID =" + playerID);
                message.writer().writeInt(playerID);
            }
            if (action == 2)
            {
                Res2.outz2("gui len index =" + index + " num= " + num);
                message.writer().writeByte(index);
                message.writer().writeInt(num);
            }
            if (action == 4)
            {
                Res2.outz2(">>>> len index =" + index);
                message.writer().writeByte(index);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendClientInput(TField2[] t)
    {
        Message2 message = null;
        try
        {
            Res2.outz(" gui input ");
            message = new Message2((sbyte)(-125));
            Res2.outz("byte lent = " + t.Length);
            message.writer().writeByte(t.Length);
            for (int i = 0; i < t.Length; i++)
            {
                message.writer().writeUTF(t[i].getText());
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void speacialSkill(sbyte index)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)112);
            message.writer().writeByte(index);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void test2()
    {
        Res2.outz("gui test1");
        Message2 message = null;
        try
        {
            message = new Message2(1);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void testJoint()
    {
    }

    public void mobCapcha(char ch)
    {
        Res2.outz("cap char c= " + ch);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-85));
            message.writer().writeChar(ch);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void friend(sbyte action, int playerId)
    {
        Res2.outz("add friend");
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-80));
            message.writer().writeByte(action);
            if (playerId != -1)
            {
                message.writer().writeInt(playerId);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getArchivemnt(int index)
    {
        Res2.outz("get ngoc");
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-76));
            message.writer().writeByte(index);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getPlayerMenu(int playerID)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-79));
            message.writer().writeInt(playerID);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanImage(sbyte id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-62));
            message.writer().writeByte(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void skill_not_focus(sbyte status)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-45);
            message.writer().writeByte(status);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanDonate(int id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-54));
            message.writer().writeInt(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanMessage(int type, string text, int clanID)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-51));
            message.writer().writeByte(type);
            if (type == 0)
            {
                message.writer().writeUTF(text);
            }
            if (type == 2)
            {
                message.writer().writeInt(clanID);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void useItem(sbyte type, sbyte where, sbyte index, short template)
    {
        Cout2.println("USE ITEM! " + type);
        if (Char2.myCharz().statusMe == 14)
        {
            return;
        }
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-43));
            message.writer().writeByte(type);
            message.writer().writeByte(where);
            message.writer().writeByte(index);
            if (index == -1)
            {
                message.writer().writeShort(template);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void joinClan(int id, sbyte action)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-49));
            message.writer().writeInt(id);
            message.writer().writeByte(action);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanMember(int id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-50));
            message.writer().writeInt(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void searchClan(string text)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-47));
            message.writer().writeUTF(text);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestClan(short id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-53));
            message.writer().writeShort(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanRemote(int id, sbyte role)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-56));
            message.writer().writeInt(id);
            message.writer().writeByte(role);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void leaveClan()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-55));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clanInvite(sbyte action, int playerID, int clanID, int code)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-57));
            message.writer().writeByte(action);
            if (action == 0)
            {
                message.writer().writeInt(playerID);
            }
            if (action == 1 || action == 2)
            {
                message.writer().writeInt(clanID);
                message.writer().writeInt(code);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getClan(sbyte action, sbyte id, string text)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-46));
            message.writer().writeByte(action);
            if (action == 2 || action == 4)
            {
                message.writer().writeByte(id);
                message.writer().writeUTF(text);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateCaption(sbyte gender)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-41));
            message.writer().writeByte(gender);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getItem(sbyte type, sbyte id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-40);
            message.writer().writeByte(type);
            message.writer().writeByte(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getTask(int npcTemplateId, int menuId, int optionId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)40);
            message.writer().writeByte(npcTemplateId);
            message.writer().writeByte(menuId);
            if (optionId >= 0)
            {
                message.writer().writeByte(optionId);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public Message2 messageNotLogin(sbyte command)
    {
        Message2 message = new Message2((sbyte)(-29));
        if (MainMod.serverKey.Length > 0)
        {
            message.writer().writeUTF(MainMod.serverKey);
        }
        message.writer().writeByte(command);
        return message;
    }

    public Message2 messageNotMap(sbyte command)
    {
        Message2 message = new Message2((sbyte)(-28));
        message.writer().writeByte(command);
        return message;
    }

    public static Message2 messageSubCommand(sbyte command)
    {
        Message2 message = new Message2((sbyte)(-30));
        message.writer().writeByte(command);
        return message;
    }

    public void setClientType()
    {
        if (Rms2.loadRMSInt("clienttype") != -1)
        {
            Main2.typeClient = Rms2.loadRMSInt("clienttype");
        }
        try
        {
            Message2 message = messageNotLogin(2);
            message.writer().writeByte(Main2.typeClient);
            message.writer().writeByte(mGraphics2.zoomLevel);
            message.writer().writeBoolean(value: false);
            message.writer().writeInt(GameCanvas2.w);
            message.writer().writeInt(GameCanvas2.h);
            message.writer().writeBoolean(TField2.isQwerty);
            message.writer().writeBoolean(GameCanvas2.isTouch);
            message.writer().writeUTF(GameCanvas2.getPlatformName() + "|" + GameMidlet2.VERSION);
            DataInputStream2 dataInputStream = MyStream2.readFile("/info");
            if (dataInputStream != null)
            {
                sbyte[] data = new sbyte[dataInputStream.r.buffer.Length];
                dataInputStream.read(ref data);
                if (data != null)
                {
                    message.writer().writeShort(data.Length);
                    message.writer().write(data);
                    Res2.err("write " + data.Length + "|" + GameMidlet2.VERSION);
                }
            }
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
    }

    public void setClientType2()
    {
        Res2.outz("SET CLIENT TYPE");
        if (Rms2.loadRMSInt("clienttype") != -1)
        {
            mSystem2.clientType = Rms2.loadRMSInt("clienttype");
        }
        try
        {
            Res2.outz("setType");
            Message2 message = messageNotLogin(2);
            message.writer().writeByte(mSystem2.clientType);
            message.writer().writeByte(mGraphics2.zoomLevel);
            Res2.outz("gui zoomlevel = " + mGraphics2.zoomLevel);
            message.writer().writeBoolean(value: false);
            message.writer().writeInt(GameCanvas2.w);
            message.writer().writeInt(GameCanvas2.h);
            message.writer().writeBoolean(TField2.isQwerty);
            message.writer().writeBoolean(GameCanvas2.isTouch);
            message.writer().writeUTF(GameCanvas2.getPlatformName() + "|" + GameMidlet2.VERSION);
            DataInputStream2 dataInputStream = MyStream2.readFile("/info");
            if (dataInputStream != null)
            {
                sbyte[] data = new sbyte[dataInputStream.r.buffer.Length];
                dataInputStream.read(ref data);
                if (data != null)
                {
                    message.writer().writeShort(data.Length);
                    message.writer().write(data);
                    Res2.err("write " + data.Length + "|" + GameMidlet2.VERSION);
                }
            }
            session = Session_ME2_2.gI();
            session.sendMessage(message);
            session = Session_ME2_.gI();
            message.cleanup();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
    }

    public void sendCheckController()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-120));
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            curCheckController = mSystem2.currentTimeMillis();
            message.cleanup();
        }
    }

    public void sendCheckMap()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-121));
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            curCheckMap = mSystem2.currentTimeMillis();
            message.cleanup();
        }
    }

    public void login(string username, string pass, string version, sbyte type)
    {
        try
        {
            Message2 message = messageNotLogin(0);
            message.writer().writeUTF(username);
            message.writer().writeUTF(pass);
            message.writer().writeUTF(version);
            message.writer().writeByte(type);
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
    }

    public void requestRegister(string username, string pass, string usernameAo, string passAo, string version)
    {
        try
        {
            Message2 message = messageNotLogin(1);
            message.writer().writeUTF(username);
            message.writer().writeUTF(pass);
            if (usernameAo != null && !usernameAo.Equals(string.Empty))
            {
                message.writer().writeUTF(usernameAo);
                message.writer().writeUTF("a");
            }
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
    }

    public void requestChangeMap()
    {
        Message2 message = new Message2((sbyte)(-23));
        session.sendMessage(message);
        message.cleanup();
    }

    public void magicTree(sbyte type)
    {
        Message2 message = new Message2((sbyte)(-34));
        try
        {
            message.writer().writeByte(type);
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception)
        {
        }
    }

    public void requestChangeZone(int zoneId, int indexUI)
    {
        Message2 message = new Message2((sbyte)21);
        try
        {
            message.writer().writeByte(zoneId);
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception)
        {
        }
    }

    public void checkMMove(int second)
    {
        Message2 message = new Message2((sbyte)(-78));
        try
        {
            message.writer().writeInt(second);
            session.sendMessage(message);
            message.cleanup();
        }
        catch (Exception)
        {
        }
    }

    public void charMove()
    {
        int num = Char2.myCharz().cx - Char2.myCharz().cxSend;
        int num2 = Char2.myCharz().cy - Char2.myCharz().cySend;
        if (Char2.ischangingMap || (num == 0 && num2 == 0) || Controller2_.isStopReadMessage || Char2.myCharz().isTeleport || Char2.myCharz().cy <= 0 || Char2.myCharz().telePortSkill)
        {
            return;
        }
        try
        {
            Message2 message = new Message2((sbyte)(-7));
            Char2.myCharz().cxSend = Char2.myCharz().cx;
            Char2.myCharz().cySend = Char2.myCharz().cy;
            Char2.myCharz().cdirSend = Char2.myCharz().cdir;
            Char2.myCharz().cactFirst = Char2.myCharz().statusMe;
            if (TileMap2.tileTypeAt(Char2.myCharz().cx / TileMap2.size, Char2.myCharz().cy / TileMap2.size) == 0)
            {
                message.writer().writeByte((sbyte)1);
                if (Char2.myCharz().canFly)
                {
                    if (!Char2.myCharz().isHaveMount)
                    {
                        Char2.myCharz().cMP -= Char2.myCharz().cMPGoc / 100 * ((Char2.myCharz().isMonkey != 1) ? 1 : 2);
                    }
                    if (Char2.myCharz().cMP < 0)
                    {
                        Char2.myCharz().cMP = 0;
                    }
                    GameScr2.gI().isInjureMp = true;
                    GameScr2.gI().twMp = 0;
                }
            }
            else
            {
                message.writer().writeByte((sbyte)0);
            }
            message.writer().writeShort(Char2.myCharz().cx);
            if (num2 != 0)
            {
                message.writer().writeShort(Char2.myCharz().cy);
            }
            session.sendMessage(message);
            GameScr2.tickMove++;
            message.cleanup();
        }
        catch (Exception ex)
        {
            Cout2.LogError("LOI CHAR MOVE " + ex.ToString());
        }
    }

    public void selectCharToPlay(string charname)
    {
        Message2 message = new Message2((sbyte)(-28));
        try
        {
            message.writer().writeByte((sbyte)1);
            message.writer().writeUTF(charname);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        session.sendMessage(message);
    }

    public void selectZone(sbyte sub, int value)
    {
    }

    public void createChar(string name, int gender, int hair)
    {
        Message2 message = new Message2((sbyte)(-28));
        try
        {
            message.writer().writeByte((sbyte)2);
            message.writer().writeUTF(name);
            message.writer().writeByte(gender);
            message.writer().writeByte(hair);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        session.sendMessage(message);
    }

    public void requestModTemplate(int modTemplateId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)11);
            message.writer().writeByte(modTemplateId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestNpcTemplate(int npcTemplateId)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(12);
            message.writer().writeByte(npcTemplateId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestSkill(int skillId)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(9);
            message.writer().writeShort(skillId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestItemInfo(int typeUI, int indexUI)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)35);
            message.writer().writeByte(typeUI);
            message.writer().writeByte(indexUI);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestItemPlayer(int charId, int indexUI)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)90);
            message.writer().writeInt(charId);
            message.writer().writeByte(indexUI);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void upSkill(int skillTemplateId, int point)
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand(17);
            message.writer().writeShort(skillTemplateId);
            message.writer().writeByte(point);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void saleItem(sbyte action, sbyte type, short id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)7);
            message.writer().writeByte(action);
            message.writer().writeByte(type);
            message.writer().writeShort(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void buyItem(sbyte type, int id, int quantity)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)6);
            message.writer().writeByte(type);
            message.writer().writeShort(id);
            if (quantity > 1)
            {
                message.writer().writeShort(quantity);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void selectSkill(int skillTemplateId)
    {
        Cout2.println(Char2.myCharz().cName + " SELECT SKILL " + skillTemplateId);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)34);
            message.writer().writeShort(skillTemplateId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getEffData(short id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-66));
            message.writer().writeShort(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void openUIZone()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)29);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void confirmMenu(short npcID, sbyte select)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)32);
            message.writer().writeShort(npcID);
            message.writer().writeByte(select);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void openMenu(int npcId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)33);
            message.writer().writeShort(npcId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void menu(int npcId, int menuId, int optionId)
    {
        Cout2.println("menuid: " + menuId);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)22);
            message.writer().writeByte(npcId);
            message.writer().writeByte(menuId);
            message.writer().writeByte(optionId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void menuId(short menuId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)27);
            message.writer().writeShort(menuId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void textBoxId(short menuId, string str)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)88);
            message.writer().writeShort(menuId);
            message.writer().writeUTF(str);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestItem(int typeUI)
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand(22);
            message.writer().writeByte(typeUI);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void boxSort()
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand(19);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void boxCoinOut(int coinOut)
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand(21);
            message.writer().writeInt(coinOut);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void upgradeItem(Item2 item, Item2[] items, bool isGold)
    {
        GameCanvas2.msgdlg.pleasewait();
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)14);
            message.writer().writeBoolean(isGold);
            message.writer().writeByte(item.indexUI);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    message.writer().writeByte(items[i].indexUI);
                }
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void crystalCollectLock(Item2[] items)
    {
        GameCanvas2.msgdlg.pleasewait();
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)13);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    message.writer().writeByte(items[i].indexUI);
                }
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void acceptInviteTrade(int playerMapId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)37);
            message.writer().writeInt(playerMapId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void cancelInviteTrade()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)50);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void tradeAccept()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)39);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void tradeItemLock(int coin, Item2[] items)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)38);
            message.writer().writeInt(coin);
            int num = 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    num++;
                }
            }
            message.writer().writeByte(num);
            for (int j = 0; j < items.Length; j++)
            {
                if (items[j] != null)
                {
                    message.writer().writeByte(items[j].indexUI);
                }
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendPlayerAttack(MyVector2 vMob, MyVector2 vChar, int type)
    {
        try
        {
            Message2 message = null;
            if (type == 0)
            {
                return;
            }
            if (vMob.size() > 0 && vChar.size() > 0)
            {
                switch (type)
                {
                    case 1:
                        message = new Message2((sbyte)-4);
                        break;
                    case 2:
                        message = new Message2((sbyte)67);
                        break;
                }
                message.writer().writeByte(vMob.size());
                for (int i = 0; i < vMob.size(); i++)
                {
                    Mob2 mob = (Mob2)vMob.elementAt(i);
                    message.writer().writeByte(mob.mobId);
                }
                for (int j = 0; j < vChar.size(); j++)
                {
                    Char2 @char = (Char2)vChar.elementAt(j);
                    if (@char != null)
                    {
                        message.writer().writeInt(@char.charID);
                    }
                    else
                    {
                        message.writer().writeInt(-1);
                    }
                }
            }
            else if (vMob.size() > 0)
            {
                message = new Message2((sbyte)54);
                for (int k = 0; k < vMob.size(); k++)
                {
                    Mob2 mob2 = (Mob2)vMob.elementAt(k);
                    if (!mob2.isMobMe)
                    {
                        message.writer().writeByte(mob2.mobId);
                        continue;
                    }
                    message.writer().writeByte((sbyte)-1);
                    message.writer().writeInt(mob2.mobId);
                }
            }
            else if (vChar.size() > 0)
            {
                message = new Message2((sbyte)-60);
                for (int l = 0; l < vChar.size(); l++)
                {
                    Char2 char2 = (Char2)vChar.elementAt(l);
                    message.writer().writeInt(char2.charID);
                }
            }
            message.writer().writeSByte((sbyte)Char2.myCharz().cdir);
            if (message != null)
            {
                session.sendMessage(message);
            }
        }
        catch (Exception)
        {
        }
    }

    public void pickItem(int itemMapId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-20));
            message.writer().writeShort(itemMapId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void throwItem(int index)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-18));
            message.writer().writeByte(index);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void returnTownFromDead()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-15));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void wakeUpFromDead()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-16));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void chat(string text)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)44);
            message.writer().writeUTF(text);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateData()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-87);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateMap()
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(6);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateSkill()
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(7);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateItem()
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(8);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clientOk()
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(13);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void tradeInvite(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)36);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void addFriend(string name)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)53);
            message.writer().writeUTF(name);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void addPartyAccept(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)76);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void addPartyCancel(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)77);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void testInvite(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)59);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void addCuuSat(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)62);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void addParty(string name)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)75);
            message.writer().writeUTF(name);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void player_vs_player(sbyte action, sbyte type, int playerId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-59));
            message.writer().writeByte(action);
            message.writer().writeByte(type);
            message.writer().writeInt(playerId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestMaptemplate(int maptemplateId)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(10);
            message.writer().writeByte(maptemplateId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void outParty()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)79);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestPlayerInfo(MyVector2 chars)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)18);
            message.writer().writeByte(chars.size());
            for (int i = 0; i < chars.size(); i++)
            {
                Char2 @char = (Char2)chars.elementAt(i);
                message.writer().writeInt(@char.charID);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void pleaseInputParty(string str)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)16);
            message.writer().writeUTF(str);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void acceptPleaseParty(string str)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)17);
            message.writer().writeUTF(str);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void chatPlayer(string text, int id)
    {
        Res2.outz("chat player text = " + text);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-72));
            message.writer().writeInt(id);
            message.writer().writeUTF(text);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void chatGlobal(string text)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-71));
            message.writer().writeUTF(text);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void chatPrivate(string to, string text)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)91);
            message.writer().writeUTF(to);
            message.writer().writeUTF(text);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendCardInfo(string NAP, string PIN)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(16);
            message.writer().writeUTF(NAP);
            message.writer().writeUTF(PIN);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void saveRms(string key, sbyte[] data)
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand(60);
            message.writer().writeUTF(key);
            message.writer().writeInt(data.Length);
            message.writer().write(data);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void loadRMS(string key)
    {
        Cout2.println("REQUEST RMS");
        Message2 message = null;
        try
        {
            message = messageSubCommand(61);
            message.writer().writeUTF(key);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clearTask()
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(17);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void changeName(string name, int id)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(18);
            message.writer().writeInt(id);
            message.writer().writeUTF(name);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestIcon(int id)
    {
        GameCanvas2.connect();
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-67);
            message.writer().writeInt(id);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void doConvertUpgrade(int index1, int index2, int index3)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(33);
            message.writer().writeByte(index1);
            message.writer().writeByte(index2);
            message.writer().writeByte(index3);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void inviteClanDun(string name)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(34);
            message.writer().writeUTF(name);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void inputNumSplit(int indexItem, int numSplit)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(40);
            message.writer().writeByte(indexItem);
            message.writer().writeInt(numSplit);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void activeAccProtect(int pass)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(37);
            message.writer().writeInt(pass);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void clearAccProtect(int pass)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(41);
            message.writer().writeInt(pass);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void updateActive(int passOld, int passNew)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(38);
            message.writer().writeInt(passOld);
            message.writer().writeInt(passNew);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void openLockAccProtect(int pass2)
    {
        Message2 message = null;
        try
        {
            message = messageNotMap(39);
            message.writer().writeInt(pass2);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getBgTemplate(short id)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-32));
            message.writer().writeShort(id);
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getMapOffline()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-33));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void finishUpdate()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-38));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void finishUpdate(int playerID)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-38));
            message.writer().writeInt(playerID);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void finishLoadMap()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-39));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getChest(sbyte action)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-35));
            message.writer().writeByte(action);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestBagImage(sbyte ID)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-63));
            message.writer().writeByte(ID);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getBag(sbyte action)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-36));
            message.writer().writeByte(action);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getBody(sbyte action)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-37));
            message.writer().writeByte(action);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void login2(string user)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-101);
            if (MainMod.serverKey.Length > 0)
            {
                message.writer().writeUTF(MainMod.serverKey);
            }
            message.writer().writeUTF(user);
            message.writer().writeByte(1);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getMagicTree(sbyte action)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-34));
            message.writer().writeByte(action);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void upPotential(int type, int typePotential, int num)
    {
        Message2 message = null;
        try
        {
            message = messageSubCommand((sbyte)type);
            message.writer().writeByte(typePotential);
            message.writer().writeShort(num);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getResource(sbyte action, MyVector2 vResourceIndex)
    {
        Res2.outz("request resource action= " + action);
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-74));
            message.writer().writeByte(action);
            if (action == 2 && vResourceIndex != null)
            {
                message.writer().writeShort(vResourceIndex.size());
                for (int i = 0; i < vResourceIndex.size(); i++)
                {
                    message.writer().writeShort(short.Parse((string)vResourceIndex.elementAt(i)));
                }
            }
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                reciveFromMainSession = true;
                session = Session_ME2_.gI();
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestMapSelect(int selected)
    {
        Res2.outz("request magic tree");
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-91));
            message.writer().writeByte(selected);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void petInfo()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-107));
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void PetInfo2()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)3);
            message.writer().writeByte(0);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendTop(string topName, sbyte selected)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-96);
            message.writer().writeUTF(topName);
            message.writer().writeByte(selected);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void enemy(sbyte b, int charID)
    {
        Message2 message = null;
        Res2.outz("add enemy");
        try
        {
            message = new Message2((sbyte)(-99));
            message.writer().writeByte(b);
            if (b == 1 || b == 2)
            {
                message.writer().writeInt(charID);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void kigui(sbyte action, int itemId, sbyte moneyType, int money, int quaintly)
    {
        Message2 message = null;
        try
        {
            Res2.outz("ki gui action= " + action);
            message = new Message2((sbyte)(-100));
            message.writer().writeByte(action);
            if (action == 0)
            {
                message.writer().writeShort(itemId);
                message.writer().writeByte(moneyType);
                message.writer().writeInt(money);
                message.writer().writeInt(quaintly);
            }
            if (action == 1 || action == 2)
            {
                message.writer().writeShort(itemId);
            }
            if (action == 3)
            {
                message.writer().writeShort(itemId);
                message.writer().writeByte(moneyType);
                message.writer().writeInt(money);
            }
            if (action == 4)
            {
                message.writer().writeByte(moneyType);
                message.writer().writeByte(money);
                Res2.outz("currTab= " + moneyType + " page= " + money);
            }
            if (action == 5)
            {
                message.writer().writeShort(itemId);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getFlag(sbyte action, sbyte flagType)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-103));
            message.writer().writeByte(action);
            Res2.outz("------------service--  " + action + "   " + flagType);
            if (action != 0)
            {
                message.writer().writeByte(flagType);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void setLockInventory(int pass)
    {
        Message2 message = null;
        try
        {
            Res2.outz("------------setLockInventory:     " + pass);
            message = new Message2((sbyte)(-104));
            message.writer().writeInt(pass);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void petStatus(sbyte status)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-108));
            message.writer().writeByte(status);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void pet2Status(sbyte status)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)3);
            message.writer().writeByte(1);
            message.writer().writeByte(status);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void transportNow()
    {
        Message2 message = null;
        try
        {
            Res2.outz("------------transportNow  ");
            message = new Message2((sbyte)(-105));
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void funsion(sbyte type)
    {
        Message2 message = null;
        try
        {
            Res2.outz("FUNSION");
            message = new Message2((sbyte)125);
            message.writer().writeByte(type);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void imageSource(MyVector2 vID)
    {
        Message2 message = null;
        try
        {
            Res2.outz("IMAGE SOURCE size= " + vID.size());
            message = new Message2((sbyte)(-111));
            message.writer().writeShort(vID.size());
            if (vID.size() > 0)
            {
                for (int i = 0; i < vID.size(); i++)
                {
                    Res2.outz("gui len str " + ((ImageSource2)vID.elementAt(i)).id);
                    message.writer().writeUTF(((ImageSource2)vID.elementAt(i)).id);
                }
            }
            if (Session_ME2_2.gI().isConnected() && !Session_ME2_2.connecting)
            {
                session = Session_ME2_2.gI();
            }
            else
            {
                session = Session_ME2_.gI();
                reciveFromMainSession = true;
            }
            session.sendMessage(message);
            session = Session_ME2_.gI();
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getQuayso()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-126));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendServerData(sbyte action, int id, sbyte[] data)
    {
        Message2 message = null;
        try
        {
            Res2.outz("SERVER DATA");
            message = new Message2((sbyte)(-110));
            message.writer().writeByte(action);
            if (action == 1)
            {
                message.writer().writeInt(id);
                if (data != null)
                {
                    int num = data.Length;
                    message.writer().writeShort(num);
                    message.writer().write(ref data, 0, num);
                }
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void changeOnKeyScr(sbyte[] skill)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-113));
            for (int i = 0; i < GameScr2.onScreenSkill.Length; i++)
            {
                message.writer().writeByte(skill[i]);
            }
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void requestPean()
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-114));
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendThachDau(int id)
    {
        Res2.outz("GUI THACH DAU");
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-118));
            message.writer().writeInt(id);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void messagePlayerMenu(int charId)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-30));
            message.writer().writeByte((sbyte)63);
            message.writer().writeInt(charId);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void playerMenuAction(int charId, short select)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)(-30));
            message.writer().writeByte((sbyte)64);
            message.writer().writeInt(charId);
            message.writer().writeShort(select);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            ex.StackTrace.ToString();
        }
        finally
        {
            message.cleanup();
        }
    }

    public void getImgByName(string nameImg)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)66);
            message.writer().writeUTF(nameImg);
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void SendCrackBall(byte type, byte soluong)
    {
        Message2 message = new Message2((sbyte)(-127));
        try
        {
            message.writer().writeByte(type);
            if (soluong > 0)
            {
                message.writer().writeByte(soluong);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void SendRada(int i, int id)
    {
        Message2 message = new Message2(sbyte.MaxValue);
        try
        {
            message.writer().writeByte(i);
            if (id != -1)
            {
                message.writer().writeShort(id);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendOptHat(sbyte action)
    {
        Message2 message = new Message2((sbyte)24);
        try
        {
            if (action == 1)
            {
                sbyte[] array = Res2.TakeSnapShot();
                message.writer().writeByte(1);
                message.writer().writeShort(array.Length);
                message.writer().write(array);
            }
            else
            {
                message.writer().writeByte((Char2.myCharz().idHat != -1) ? (-1) : 0);
            }
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void sendDelAcc()
    {
        Message2 message = new Message2((sbyte)69);
        try
        {
            session.sendMessage(message);
        }
        catch (Exception)
        {
        }
        finally
        {
            message.cleanup();
        }
    }

    public void new_skill_not_focus(sbyte idTemplateSkill, sbyte dir, short x, short y)
    {
        Message2 message = null;
        try
        {
            message = new Message2((sbyte)-45);
            message.writer().writeSByte(20);
            message.writer().writeSByte(idTemplateSkill);
            message.writer().writeShort(Char2.myCharz().cx);
            message.writer().writeShort(Char2.myCharz().cy);
            message.writer().writeSByte(dir);
            message.writer().writeShort(x);
            message.writer().writeShort(y);
            session.sendMessage(message);
        }
        catch (Exception ex)
        {
            Cout2.println(ex.Message + ex.StackTrace);
        }
        finally
        {
            message.cleanup();
        }
    }
}
