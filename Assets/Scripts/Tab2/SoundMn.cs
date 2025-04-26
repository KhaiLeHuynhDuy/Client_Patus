using System;

public class SoundMn2
{
    public class MediaPlayer
    {
    }

    public class SoundPool
    {
    }

    public class AssetManager
    {
    }

    public static bool IsDelAcc;

    public static SoundMn2 gIz;

    public static bool isSound = true;

    public static float volume = 0.5f;

    public static MediaPlayer[] music;

    public static SoundPool[] sound;

    public static int[] soundID;

    public static int AIR_SHIP;

    public static int RAIN = 1;

    public static int TAITAONANGLUONG = 2;

    public static int GET_ITEM;

    public static int MOVE = 1;

    public static int LOW_PUNCH = 2;

    public static int LOW_KICK = 3;

    public static int FLY = 4;

    public static int JUMP = 5;

    public static int PANEL_OPEN = 6;

    public static int BUTTON_CLOSE = 7;

    public static int BUTTON_CLICK = 8;

    public static int MEDIUM_PUNCH = 9;

    public static int MEDIUM_KICK = 10;

    public static int PANEL_CLICK = 11;

    public static int EAT_PEAN = 12;

    public static int OPEN_DIALOG = 13;

    public static int NORMAL_KAME = 14;

    public static int NAMEK_KAME = 15;

    public static int XAYDA_KAME = 16;

    public static int EXPLODE_1 = 17;

    public static int EXPLODE_2 = 18;

    public static int TRAIDAT_KAME = 19;

    public static int HP_UP = 20;

    public static int THAIDUONGHASAN = 21;

    public static int HOISINH = 22;

    public static int GONG = 23;

    public static int KHICHAY = 24;

    public static int BIG_EXPLODE = 25;

    public static int NAMEK_LAZER = 26;

    public static int NAMEK_CHARGE = 27;

    public static int RADAR_CLICK = 28;

    public static int RADAR_ITEM = 29;

    public static int FIREWORK = 30;

    public static int KAMEX10_0 = 31;

    public static int KAMEX10_1 = 32;

    public static int DESTROY_0 = 33;

    public static int DESTROY_1 = 34;

    public static int MAFUBA_0 = 35;

    public static int MAFUBA_1 = 36;

    public static int MAFUBA_2 = 37;

    public static int DESTROY_2 = 38;

    public bool freePool;

    public int poolCount;

    public static int cout = 1;

    // public static void init(AssetManager ac)
    // {
    //     Sound2.setActivity(ac);
    // }

    public static SoundMn2 gI()
    {
        if (gIz == null)
        {
            gIz = new SoundMn2();
        }
        return gIz;
    }

    public void loadSound(int mapID)
    {
        SoundFunc.init(new int[3] { AIR_SHIP, RAIN, TAITAONANGLUONG }, new int[39]
        {
            GET_ITEM, MOVE, LOW_PUNCH, LOW_KICK, FLY, JUMP, PANEL_OPEN, BUTTON_CLOSE, BUTTON_CLICK, MEDIUM_PUNCH,
            MEDIUM_KICK, PANEL_OPEN, EAT_PEAN, OPEN_DIALOG, NORMAL_KAME, NAMEK_KAME, XAYDA_KAME, EXPLODE_1, EXPLODE_2, TRAIDAT_KAME,
            HP_UP, THAIDUONGHASAN, HOISINH, GONG, KHICHAY, BIG_EXPLODE, NAMEK_LAZER, NAMEK_CHARGE, RADAR_CLICK, RADAR_ITEM,
            FIREWORK, KAMEX10_0, KAMEX10_1, DESTROY_0, DESTROY_1, MAFUBA_0, MAFUBA_1, MAFUBA_2, DESTROY_2
        });
    }

    public void getSoundOption()
    {
        if (GameCanvas2.loginScr.isLogin2 && Char2.myCharz().taskMaint != null && Char2.myCharz().taskMaint.taskId >= 2)
        {
            if (Char2.myCharz().havePet && Char2.myCharz().havePet2)
            {
                Panel2.strTool = new string[13]
                {
                    mResources2.gameInfo,
                    mResources2.quayso,
                    MainMod2.strPlayerInfo,
                    mResources2.radaCard,
                    mResources2.pet,
                    MainMod2.strPet2,
                    mResources2.change_flag,
                    mResources2.change_zone,
                    mResources2.chat_world,
                    mResources2.account,
                    mResources2.option,
                    mResources2.change_account,
                    mResources2.REGISTOPROTECT
                };
            }
            else if (Char2.myCharz().havePet || Char2.myCharz().havePet2)
            {
                Panel2.strTool = new string[12]
                {
                    mResources2.gameInfo,
                    mResources2.quayso,
                    MainMod2.strPlayerInfo,
                    mResources2.radaCard,
                    Char2.myCharz().havePet ? mResources2.pet : MainMod2.strPet2,
                    mResources2.change_flag,
                    mResources2.change_zone,
                    mResources2.chat_world,
                    mResources2.account,
                    mResources2.option,
                    mResources2.change_account,
                    mResources2.REGISTOPROTECT
                };
            }
            else
            {
                Panel2.strTool = new string[11]
            {
                mResources2.gameInfo,
                mResources2.quayso,
                MainMod2.strPlayerInfo,
                mResources2.radaCard,
                mResources2.change_flag,
                mResources2.change_zone,
                mResources2.chat_world,
                mResources2.account,
                mResources2.option,
                mResources2.change_account,
                mResources2.REGISTOPROTECT
            };
            }
        }
        else
        {
            if (Char2.myCharz().havePet && Char2.myCharz().havePet2)
            {
                Panel2.strTool = new string[12]
                {
                    mResources2.gameInfo,
                    mResources2.quayso,
                    MainMod2.strPlayerInfo,
                    mResources2.radaCard,
                    mResources2.pet,
                    MainMod2.strPet2,
                    mResources2.change_flag,
                    mResources2.change_zone,
                    mResources2.chat_world,
                    mResources2.account,
                    mResources2.option,
                    mResources2.change_account
                };
            }
            else if (Char2.myCharz().havePet || Char2.myCharz().havePet2)
            {
                Panel2.strTool = new string[11]
                {
                    mResources2.gameInfo,
                    mResources2.quayso,
                    MainMod2.strPlayerInfo,
                    mResources2.radaCard,
                    Char2.myCharz().havePet ? mResources2.pet : MainMod2.strPet2,
                    mResources2.change_flag,
                    mResources2.change_zone,
                    mResources2.chat_world,
                    mResources2.account,
                    mResources2.option,
                    mResources2.change_account
                };
            }
            else
            {
                Panel2.strTool = new string[10]
            {
                mResources2.gameInfo,
                mResources2.quayso,
                MainMod2.strPlayerInfo,
                mResources2.radaCard,
                mResources2.change_flag,
                mResources2.change_zone,
                mResources2.chat_world,
                mResources2.account,
                mResources2.option,
                mResources2.change_account
            };
            }
        }
        if (IsDelAcc)
        {
            string[] array = new string[Panel2.strTool.Length + 1];
            for (int i = 0; i < Panel2.strTool.Length; i++)
            {
                array[i] = Panel2.strTool[i];
            }
            array[Panel2.strTool.Length] = mResources2.delacc;
            Panel2.strTool = array;
        }
    }

    public void getStrOption()
    {
        if (!GameCanvas2.isLoadRes) return;
        string text = "[x]   ";
        string text2 = "[  ]   ";
        if (!Main2.isIPhone)
        {
            Panel2.strCauhinh = new string[4]
            {
                (!Char2.isPaintAura) ? (text2 + mResources2.aura_off.Trim()) : (text + mResources2.aura_off.Trim()),
                (!Char2.isPaintAura2) ? (text2 + mResources2.aura_off_2.Trim()) : (text + mResources2.aura_off_2.Trim()),
                (!GameCanvas2.isPlaySound) ? (text2 + mResources2.turnOffSound.Trim()) : (text + mResources2.turnOffSound.Trim()),
                (mGraphics2.zoomLevel <= 1) ? (text2 + mResources2.x2Screen) : (text + mResources2.x1Screen)
            };
            return;
        }
        string text3 = ((GameScr2.isAnalog != 0) ? (text + mResources2.turnOffAnalog) : (text2 + mResources2.turnOnAnalog));
        if (!GameCanvas2.isTouch)
        {
            text3 = (GameScr2.isPaintChatVip ? (text + mResources2.serverchat_off) : (text2 + mResources2.serverchat_off));
        }
        Panel2.strCauhinh = new string[5]
        {
            (!Char2.isPaintAura) ? (text + mResources2.aura_off.Trim()) : (text2 + mResources2.aura_off.Trim()),
            (!Char2.isPaintAura2) ? (text + mResources2.aura_off_2.Trim()) : (text2 + mResources2.aura_off_2.Trim()),
            (!GameCanvas2.isPlaySound) ? (text2 + mResources2.turnOffSound.Trim()) : (text + mResources2.turnOffSound.Trim()),
            (!GameCanvas2.lowGraphic) ? (text2 + mResources2.cauhinhthap.Trim()) : (text + mResources2.cauhinhthap.Trim()),
            text3
        };
    }

    public void GetStrModFunc()
    {
        if (!GameCanvas2.isLoadRes) return;
        string text = "[x]   ";
        string text2 = "[  ]   ";
        Panel2.strModFunc = new string[10]
        {
            (MainMod2.isHighFps ? text : text2) + MainMod2.strHighFps,
            (MainMod2.GI().isUpdateZones ? text : text2) + MainMod2.strUpdateZones,
            (MainMod2.showCharsInMap ? text : text2) + MainMod2.strCharsInMap,
            (MainMod2.showInfoPet ? text : text2) + MainMod2.strInfoPet,
            (MainMod2.isAutoPhaLe ? text : text2) + MainMod2.strAutoPhaLe,
            (MainMod2.isAutoVQMM ? text : text2) + MainMod2.strAutoVQMM,
            (MainMod2.GI().autoWakeUp ? text : text2) + MainMod2.strAutoWakeUp,
            (MainMod2.isAutoLogin ? text : text2) + MainMod2.strAutoLogin,
            (MainMod2.isShowQuickButton ? text : text2) + MainMod2.strQuickButton,
            (MainMod2.isShowXMAPButton ? text : text2) + MainMod2.strXMAPButton
        };
    }

    public void HP_MPup()
    {
        SoundFunc.playSound(HP_UP, 0.5f, 1);
    }

    public void charPunch(bool isKick, float volumn)
    {
        if (!Char2.myCharz().me)
        {
            volume /= 2f;
        }
        if (volumn <= 0f)
        {
            volumn = 0.01f;
        }
        int num = Res2.random(0, 3);
        if (isKick)
        {
            SoundFunc.playSound((num != 0) ? MEDIUM_KICK : LOW_KICK, 0.1f, 1);
        }
        else
        {
            SoundFunc.playSound((num != 0) ? MEDIUM_PUNCH : LOW_PUNCH, 0.1f, 1);
        }
        poolCount++;
    }

    public void thaiduonghasan()
    {
        SoundFunc.playSound(THAIDUONGHASAN, 0.5f, 1);
        poolCount++;
    }

    public void rain()
    {
        SoundFunc.playMus(RAIN, 0.3f, loop: true, 1);
    }

    public void gongName()
    {
        SoundFunc.playSound(NAMEK_CHARGE, 0.3f, 1);
        poolCount++;
    }

    public void gong()
    {
        SoundFunc.playSound(GONG, 0.2f, 1);
        poolCount++;
    }

    public void getItem()
    {
        SoundFunc.playSound(GET_ITEM, 0.3f, 1);
        poolCount++;
    }

    public void soundToolOption()
    {
        GameCanvas2.isPlaySound = !GameCanvas2.isPlaySound;
        if (GameCanvas2.isPlaySound)
        {
            gI().loadSound(TileMap2.mapID);
            Rms2.saveRMSInt("isPlaySound", 1);
        }
        else
        {
            gI().closeSound();
            Rms2.saveRMSInt("isPlaySound", 0);
        }
        getStrOption();
    }

    public void chatVipToolOption()
    {
        GameScr2.isPaintChatVip = !GameScr2.isPaintChatVip;
        if (GameScr2.isPaintChatVip)
        {
            Rms2.saveRMSInt("serverchat", 0);
        }
        else
        {
            Rms2.saveRMSInt("serverchat", 1);
        }
        getStrOption();
    }

    public void analogToolOption()
    {
        if (GameScr2.isAnalog == 0)
        {
            GameScr2.isAnalog = 1;
            Rms2.saveRMSInt("analog", GameScr2.isAnalog);
            GameScr2.setSkillBarPosition();
        }
        else
        {
            GameScr2.isAnalog = 0;
            Rms2.saveRMSInt("analog", GameScr2.isAnalog);
            GameScr2.setSkillBarPosition();
        }
        getStrOption();
    }

    public void CaseAnalog()
    {
        if (Main2.isIPhone)
        {
            if (!GameCanvas2.isTouch)
            {
                chatVipToolOption();
            }
            else
            {
                analogToolOption();
            }
        }
    }

    public void CaseSizeScr()
    {
        if (GameCanvas2.lowGraphic)
        {
            Rms2.saveRMSInt("lowGraphic", 0);
            GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
        }
        else
        {
            Rms2.saveRMSInt("lowGraphic", 1);
            GameCanvas2.startOK(mResources2.plsRestartGame, 8885, null);
        }
        getStrOption();
    }

    public void AuraToolOption()
    {
        if (Char2.isPaintAura)
        {
            Rms2.saveRMSInt("isPaintAura", 0);
            Char2.isPaintAura = false;
        }
        else
        {
            Rms2.saveRMSInt("isPaintAura", 1);
            Char2.isPaintAura = true;
        }
        getStrOption();
    }

    public void AuraToolOption2()
    {
        if (Char2.isPaintAura2)
        {
            Rms2.saveRMSInt("isPaintAura2", 0);
            Char2.isPaintAura2 = false;
        }
        else
        {
            Rms2.saveRMSInt("isPaintAura2", 1);
            Char2.isPaintAura2 = true;
        }
        getStrOption();
    }

    public void HatToolOption()
    {
        Service2.gI().sendOptHat(0);
    }

    public void update()
    {
    }

    public void closeSound()
    {
        SoundFunc.stopAll = true;
        stopAll();
    }

    public void openSound()
    {
        if (SoundFunc.music == null)
        {
            loadSound(0);
        }
        SoundFunc.stopAll = false;
    }

    public void bigeExlode()
    {
        SoundFunc.playSound(BIG_EXPLODE, 0.5f, 1);
        poolCount++;
    }

    public void explode_1()
    {
        SoundFunc.playSound(EXPLODE_1, 0.5f, 1);
        poolCount++;
    }

    public void explode_2()
    {
        SoundFunc.playSound(EXPLODE_1, 0.5f, 1);
        poolCount++;
    }

    public void traidatKame()
    {
        SoundFunc.playSound(TRAIDAT_KAME, 1f, 1);
        poolCount++;
    }

    public void namekKame()
    {
        SoundFunc.playSound(NAMEK_KAME, 0.3f, 1);
        poolCount++;
    }

    public void nameLazer()
    {
        SoundFunc.playSound(NAMEK_LAZER, 0.3f, 1);
        poolCount++;
    }

    public void xaydaKame()
    {
        SoundFunc.playSound(XAYDA_KAME, 0.3f, 1);
        poolCount++;
    }

    public void mobKame(int type)
    {
        int id = XAYDA_KAME;
        if (type == 13)
        {
            id = NORMAL_KAME;
        }
        SoundFunc.playSound(id, 0.1f, 1);
        poolCount++;
    }

    public void charRun(float volumn)
    {
        if (!Char2.myCharz().me)
        {
            volume /= 2f;
            if (volumn <= 0f)
            {
                volumn = 0.01f;
            }
        }
        if (GameCanvas2.gameTick % 8 == 0)
        {
            SoundFunc.playSound(MOVE, volumn, 1);
            poolCount++;
        }
    }

    public void monkeyRun(float volumn)
    {
        if (GameCanvas2.gameTick % 8 == 0)
        {
            SoundFunc.playSound(KHICHAY, 0.2f, 1);
            poolCount++;
        }
    }

    public void charFall()
    {
        SoundFunc.playSound(MOVE, 0.1f, 1);
        poolCount++;
    }

    public void charJump()
    {
        SoundFunc.playSound(MOVE, 0.2f, 1);
        poolCount++;
    }

    public void panelOpen()
    {
        SoundFunc.playSound(PANEL_OPEN, 0.5f, 1);
        poolCount++;
    }

    public void buttonClose()
    {
        //Sound.playSound(BUTTON_CLOSE, 0.5f, 1);
        //poolCount++;
    }

    public void buttonClick()
    {
        SoundFunc.playSound(BUTTON_CLICK, 0.5f, 1);
        poolCount++;
    }

    public void stopMove()
    {
    }

    public void charFly()
    {
        SoundFunc.playSound(FLY, 0.2f, 1);
        poolCount++;
    }

    public void stopFly()
    {
    }

    public void openMenu()
    {
        SoundFunc.playSound(BUTTON_CLOSE, 0.5f, 1);
        poolCount++;
    }

    public void panelClick()
    {
        SoundFunc.playSound(PANEL_CLICK, 0.5f, 1);
        poolCount++;
    }

    public void eatPeans()
    {
        SoundFunc.playSound(EAT_PEAN, 0.5f, 1);
        poolCount++;
    }

    public void openDialog()
    {
        SoundFunc.playSound(OPEN_DIALOG, 0.5f, 1);
    }

    public void hoisinh()
    {
        SoundFunc.playSound(HOISINH, 0.5f, 1);
        poolCount++;
    }

    public void taitao()
    {
        SoundFunc.playMus(TAITAONANGLUONG, 0.5f, loop: true, 1);
    }

    public void taitaoPause()
    {
    }

    public bool isPlayRain()
    {
        try
        {
            return SoundFunc.isPlayingSound();
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool isPlayAirShip()
    {
        return false;
    }

    public void airShip()
    {
        cout++;
        if (cout % 2 == 0)
        {
            SoundFunc.playMus(AIR_SHIP, 0.3f, loop: false, 1);
        }
    }

    public void pauseAirShip()
    {
    }

    public void resumeAirShip()
    {
    }

    public void stopAll()
    {
        //Sound2.stopAllz();
    }

    public void backToRegister()
    {
        Session_ME2_.gI().close();
        GameCanvas2.panel.hide();
        GameCanvas2.loginScr.actRegister();
        GameCanvas2.loginScr.switchToMe();
    }

    public void newKame()
    {
        poolCount++;
        if (poolCount % 15 == 0)
        {
            SoundFunc.playSound(TRAIDAT_KAME, 0.5f, 1);
        }
    }

    public void radarClick()
    {
        SoundFunc.playSound(RADAR_CLICK, 0.5f, 1);
    }

    public void radarItem()
    {
        SoundFunc.playSound(RADAR_ITEM, 0.5f, 1);
    }

    public static void playSound(int x, int y, int id, float volume)
    {
        SoundFunc.playSound(id, volume, 0);
    }
}
