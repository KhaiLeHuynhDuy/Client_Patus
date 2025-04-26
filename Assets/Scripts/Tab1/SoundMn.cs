using System;

public class SoundMn
{
    // public class MediaPlayer
    // {
    // }

    // public class SoundPool
    // {
    // }

    public class AssetManager
    {
    }

    public static bool IsDelAcc;

    public static SoundMn gIz;

    // public static bool isSound = true;

    public static float volume = 0.5f;

    // public static MediaPlayer[] music;

    // public static SoundPool[] sound;

    // public static int[] soundID;

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

    // public bool freePool;

    public int poolCount;

    public static int cout = 1;

    // public static void init(AssetManager ac)
    // {
    //     Sound.setActivity(ac);
    // }

    public static SoundMn gI()
    {
        if (gIz == null)
        {
            gIz = new SoundMn();
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
        if (GameCanvas.loginScr.isLogin2 && Char.myCharz().taskMaint != null && Char.myCharz().taskMaint.taskId >= 2)
        {
            if (Char.myCharz().havePet && Char.myCharz().havePet2)
            {
                Panel.strTool = new string[13]
                {
                    mResources.gameInfo,
                    mResources.quayso,
                    MainMod.strPlayerInfo,
                    mResources.radaCard,
                    mResources.pet,
                    MainMod.strPet2,
                    mResources.change_flag,
                    mResources.change_zone,
                    mResources.chat_world,
                    mResources.account,
                    mResources.option,
                    mResources.change_account,
                    mResources.REGISTOPROTECT
                };
            }
            else if (Char.myCharz().havePet || Char.myCharz().havePet2)
            {
                Panel.strTool = new string[12]
                {
                    mResources.gameInfo,
                    mResources.quayso,
                    MainMod.strPlayerInfo,
                    mResources.radaCard,
                    Char.myCharz().havePet ? mResources.pet : MainMod.strPet2,
                    mResources.change_flag,
                    mResources.change_zone,
                    mResources.chat_world,
                    mResources.account,
                    mResources.option,
                    mResources.change_account,
                    mResources.REGISTOPROTECT
                };
            }
            else
            {
                Panel.strTool = new string[11]
            {
                mResources.gameInfo,
                mResources.quayso,
                MainMod.strPlayerInfo,
                mResources.radaCard,
                mResources.change_flag,
                mResources.change_zone,
                mResources.chat_world,
                mResources.account,
                mResources.option,
                mResources.change_account,
                mResources.REGISTOPROTECT
            };
            }
        }
        else
        {
            if (Char.myCharz().havePet && Char.myCharz().havePet2)
            {
                Panel.strTool = new string[12]
                {
                    mResources.gameInfo,
                    mResources.quayso,
                    MainMod.strPlayerInfo,
                    mResources.radaCard,
                    mResources.pet,
                    MainMod.strPet2,
                    mResources.change_flag,
                    mResources.change_zone,
                    mResources.chat_world,
                    mResources.account,
                    mResources.option,
                    mResources.change_account
                };
            }
            else if (Char.myCharz().havePet || Char.myCharz().havePet2)
            {
                Panel.strTool = new string[11]
                {
                    mResources.gameInfo,
                    mResources.quayso,
                    MainMod.strPlayerInfo,
                    mResources.radaCard,
                    Char.myCharz().havePet ? mResources.pet : MainMod.strPet2,
                    mResources.change_flag,
                    mResources.change_zone,
                    mResources.chat_world,
                    mResources.account,
                    mResources.option,
                    mResources.change_account
                };
            }
            else
            {
                Panel.strTool = new string[10]
            {
                mResources.gameInfo,
                mResources.quayso,
                MainMod.strPlayerInfo,
                mResources.radaCard,
                mResources.change_flag,
                mResources.change_zone,
                mResources.chat_world,
                mResources.account,
                mResources.option,
                mResources.change_account
            };
            }
        }
        if (IsDelAcc)
        {
            string[] array = new string[Panel.strTool.Length + 1];
            for (int i = 0; i < Panel.strTool.Length; i++)
            {
                array[i] = Panel.strTool[i];
            }
            array[Panel.strTool.Length] = mResources.delacc;
            Panel.strTool = array;
        }
    }

    public void getStrOption()
    {
        if (!GameCanvas.isLoadRes) return;
        string text = "[x]   ";
        string text2 = "[  ]   ";
        if (!Main.isIPhone)
        {
            Panel.strCauhinh = new string[5]
            {
                Char.isPaintAura ? (text + mResources.aura_off.Trim()) : (text2 + mResources.aura_off.Trim()),
                Char.isPaintAura2 ? (text + mResources.aura_off_2.Trim()) : (text2 + mResources.aura_off_2.Trim()),
                GameCanvas.isPlaySound ? (text + mResources.turnOffSound.Trim()) : (text2 + mResources.turnOffSound.Trim()),
                (mGraphics.zoomLevel <= 1) ? (text + mResources.x2Screen) : (text + mResources.x1Screen),
                GameCanvas.lowGraphic ? (text + mResources.cauhinhthap.Trim()) : (text2 + mResources.cauhinhthap.Trim())
            };
            return;
        }
        string text3 = (GameScr.isAnalog != 0) ? (text + mResources.turnOffAnalog) : (text2 + mResources.turnOnAnalog);
        if (!GameCanvas.isTouch)
        {
            text3 = GameScr.isPaintChatVip ? (text + mResources.serverchat_off) : (text2 + mResources.serverchat_off);
        }
        Panel.strCauhinh = new string[5]
        {
            Char.isPaintAura ? (text + mResources.aura_off.Trim()) : (text2 + mResources.aura_off.Trim()),
            Char.isPaintAura2 ? (text + mResources.aura_off_2.Trim()) : (text2 + mResources.aura_off_2.Trim()),
            GameCanvas.isPlaySound ? (text + mResources.turnOffSound.Trim()) : (text2 + mResources.turnOffSound.Trim()),
            GameCanvas.lowGraphic ? (text + mResources.cauhinhthap.Trim()) : (text2 + mResources.cauhinhthap.Trim()),
            text3
        };
    }

    public void GetStrModFunc()
    {
        if (!GameCanvas.isLoadRes) return;
        string text = "[x]   ";
        string text2 = "[  ]   ";
        Panel.strModFunc = new string[10]
        {
            (MainMod.isHighFps ? text : text2) + MainMod.strHighFps,
            (MainMod.GI().isUpdateZones ? text : text2) + MainMod.strUpdateZones,
            (MainMod.showCharsInMap ? text : text2) + MainMod.strCharsInMap,
            (MainMod.showInfoPet ? text : text2) + MainMod.strInfoPet,
            (MainMod.isAutoPhaLe ? text : text2) + MainMod.strAutoPhaLe,
            (MainMod.isAutoVQMM ? text : text2) + MainMod.strAutoVQMM,
            (MainMod.GI().autoWakeUp ? text : text2) + MainMod.strAutoWakeUp,
            (MainMod.isAutoLogin ? text : text2) + MainMod.strAutoLogin,
            (MainMod.isShowQuickButton ? text : text2) + MainMod.strQuickButton,
            (MainMod.isShowXMAPButton ? text : text2) + MainMod.strXMAPButton
        };
    }

    public void HP_MPup()
    {
        SoundFunc.playSound(HP_UP, 0.5f, 0);
    }

    public void charPunch(bool isKick, float volumn)
    {
        if (!Char.myCharz().me)
        {
            volume /= 2f;
        }
        if (volumn <= 0f)
        {
            volumn = 0.01f;
        }
        int num = Res.random(0, 3);
        if (isKick)
        {
            SoundFunc.playSound((num != 0) ? MEDIUM_KICK : LOW_KICK, 0.1f, 0);
        }
        else
        {
            SoundFunc.playSound((num != 0) ? MEDIUM_PUNCH : LOW_PUNCH, 0.1f, 0);
        }
        poolCount++;
    }

    public void thaiduonghasan()
    {
        SoundFunc.playSound(THAIDUONGHASAN, 0.5f, 0);
        poolCount++;
    }

    public void rain()
    {
        SoundFunc.playMus(RAIN, 0.3f, loop: true, 0);
    }

    public void gongName()
    {
        SoundFunc.playSound(NAMEK_CHARGE, 0.3f, 0);
        poolCount++;
    }

    public void gong()
    {
        SoundFunc.playSound(GONG, 0.2f, 0);
        poolCount++;
    }

    public void getItem()
    {
        SoundFunc.playSound(GET_ITEM, 0.3f, 0);
        poolCount++;
    }

    public void soundToolOption()
    {
        GameCanvas.isPlaySound = !GameCanvas.isPlaySound;
        if (GameCanvas.isPlaySound)
        {
            gI().loadSound(TileMap.mapID);
            Rms.saveRMSInt("isPlaySound", 1);
        }
        else
        {
            gI().closeSound();
            Rms.saveRMSInt("isPlaySound", 0);
        }
        getStrOption();
    }

    public void chatVipToolOption()
    {
        GameScr.isPaintChatVip = !GameScr.isPaintChatVip;
        if (GameScr.isPaintChatVip)
        {
            Rms.saveRMSInt("serverchat", 0);
        }
        else
        {
            Rms.saveRMSInt("serverchat", 1);
        }
        getStrOption();
    }

    public void analogToolOption()
    {
        if (GameScr.isAnalog == 0)
        {
            GameScr.isAnalog = 1;
            Rms.saveRMSInt("analog", GameScr.isAnalog);
            GameScr.setSkillBarPosition();
        }
        else
        {
            GameScr.isAnalog = 0;
            Rms.saveRMSInt("analog", GameScr.isAnalog);
            GameScr.setSkillBarPosition();
        }
        getStrOption();
    }

    public void CaseAnalog()
    {
        if (Main.isIPhone)
        {
            if (!GameCanvas.isTouch)
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
        if (GameCanvas.lowGraphic)
        {
            Rms.saveRMSInt("lowGraphic", 0);
            GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
        }
        else
        {
            Rms.saveRMSInt("lowGraphic", 1);
            GameCanvas.startOK(mResources.plsRestartGame, 8885, null);
        }
        getStrOption();
    }

    public void AuraToolOption()
    {
        if (Char.isPaintAura)
        {
            Rms.saveRMSInt("isPaintAura", 0);
            Char.isPaintAura = false;
        }
        else
        {
            Rms.saveRMSInt("isPaintAura", 1);
            Char.isPaintAura = true;
        }
        getStrOption();
    }

    public void AuraToolOption2()
    {
        if (Char.isPaintAura2)
        {
            Rms.saveRMSInt("isPaintAura2", 0);
            Char.isPaintAura2 = false;
        }
        else
        {
            Rms.saveRMSInt("isPaintAura2", 1);
            Char.isPaintAura2 = true;
        }
        getStrOption();
    }

    // public void HatToolOption()
    // {
    //     Service.gI().sendOptHat(0);
    // }

    public void update()
    {
    }

    public void closeSound()
    {
        SoundFunc.stopAll = true;
        stopAll();
    }

    // public void openSound()
    // {
    //     if (Sound.music == null)
    //     {
    //         loadSound(0);
    //     }
    //     Sound.stopAll = false;
    // }

    public void bigeExlode()
    {
        SoundFunc.playSound(BIG_EXPLODE, 0.5f, 0);
        poolCount++;
    }

    public void explode_1()
    {
        SoundFunc.playSound(EXPLODE_1, 0.5f, 0);
        poolCount++;
    }

    public void explode_2()
    {
        SoundFunc.playSound(EXPLODE_1, 0.5f, 0);
        poolCount++;
    }

    public void traidatKame()
    {
        SoundFunc.playSound(TRAIDAT_KAME, 1f, 0);
        poolCount++;
    }

    public void namekKame()
    {
        SoundFunc.playSound(NAMEK_KAME, 0.3f, 0);
        poolCount++;
    }

    public void nameLazer()
    {
        SoundFunc.playSound(NAMEK_LAZER, 0.3f, 0);
        poolCount++;
    }

    public void xaydaKame()
    {
        SoundFunc.playSound(XAYDA_KAME, 0.3f, 0);
        poolCount++;
    }

    public void mobKame(int type)
    {
        int id = XAYDA_KAME;
        if (type == 13)
        {
            id = NORMAL_KAME;
        }
        SoundFunc.playSound(id, 0.1f, 0);
        poolCount++;
    }

    public void charRun(float volumn)
    {
        if (!Char.myCharz().me)
        {
            volume /= 2f;
            if (volumn <= 0f)
            {
                volumn = 0.01f;
            }
        }
        if (GameCanvas.gameTick % 8 == 0)
        {
            SoundFunc.playSound(MOVE, volumn, 0);
            poolCount++;
        }
    }

    public void monkeyRun(float volumn)
    {
        if (GameCanvas.gameTick % 8 == 0)
        {
            SoundFunc.playSound(KHICHAY, 0.2f, 0);
            poolCount++;
        }
    }

    public void charFall()
    {
        SoundFunc.playSound(MOVE, 0.1f, 0);
        poolCount++;
    }

    public void charJump()
    {
        SoundFunc.playSound(MOVE, 0.2f, 0);
        poolCount++;
    }

    public void panelOpen()
    {
        SoundFunc.playSound(PANEL_OPEN, 0.5f, 0);
        poolCount++;
    }

    public void buttonClose()
    {
        //Sound.playSound(BUTTON_CLOSE, 0.5f, 0);
        //poolCount++;
    }

    public void buttonClick()
    {
        SoundFunc.playSound(BUTTON_CLICK, 0.5f, 0);
        poolCount++;
    }

    // public void stopMove()
    // {
    // }

    public void charFly()
    {
        SoundFunc.playSound(FLY, 0.2f, 0);
        poolCount++;
    }

    // public void stopFly()
    // {
    // }

    public void openMenu()
    {
        SoundFunc.playSound(BUTTON_CLOSE, 0.5f, 0);
        poolCount++;
    }

    public void panelClick()
    {
        SoundFunc.playSound(PANEL_CLICK, 0.5f, 0);
        poolCount++;
    }

    public void eatPeans()
    {
        SoundFunc.playSound(EAT_PEAN, 0.5f, 0);
        poolCount++;
    }

    public void openDialog()
    {
        SoundFunc.playSound(OPEN_DIALOG, 0.5f, 0);
    }

    public void hoisinh()
    {
        SoundFunc.playSound(HOISINH, 0.5f, 0);
        poolCount++;
    }

    // public void taitao()
    // {
    //     Sound.playMus(TAITAONANGLUONG, 0.5f, loop: true);
    // }

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
            SoundFunc.playMus(AIR_SHIP, 0.3f, loop: false, 0);
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
        SoundFunc.stopAllz();
    }

    public void backToRegister()
    {
        Session_ME.gI().close();
        GameCanvas.panel.hide();
        GameCanvas.loginScr.actRegister();
        GameCanvas.loginScr.switchToMe();
    }

    public void newKame()
    {
        poolCount++;
        if (poolCount % 15 == 0)
        {
            SoundFunc.playSound(TRAIDAT_KAME, 0.5f, 0);
        }
    }

    public void radarClick()
    {
        SoundFunc.playSound(RADAR_CLICK, 0.5f, 0);
    }

    public void radarItem()
    {
        SoundFunc.playSound(RADAR_ITEM, 0.5f, 0);
    }

    public static void playSound(int x, int y, int id, float volume)
    {
        SoundFunc.playSound(id, volume, 0);
    }
}
