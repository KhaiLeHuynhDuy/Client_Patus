using System;
using UnityEngine;

public class CreateCharScr2 : mScreen2, IActionListener2
{
    public static CreateCharScr2 instance;

    public static bool isCreateChar = false;

    public static TField2 tAddName;

    public static int indexGender;

    public static int indexHair;

    public static int selected;

    public static int[][] hairID = new int[3][]
    {
        new int[3] { 64, 30, 31 },
        new int[3] { 9, 29, 32 },
        new int[3] { 6, 27, 28 }
    };

    public static int[] defaultLeg = new int[3] { 2, 13, 8 };

    public static int[] defaultBody = new int[3] { 1, 12, 7 };

    private int yButton;

    private int disY;

    public int yBegin;

    private readonly int cx;

    private readonly int cy;

    private readonly int dy = 45;

    private int cp1;

    private int cf;

    private readonly int xPopup;

    private readonly int yPopup;

    mFont2 mFontGender;

    public CreateCharScr2()
    {
        try
        {
            if (!GameCanvas2.lowGraphic)
            {
                loadMapFromResource(new sbyte[3] { 39, 40, 41 });
            }
            loadMapTableFromResource(new sbyte[3] { 39, 40, 41 });
        }
        catch (Exception)
        {
        }

        xPopup = (GameCanvas2.w - 160) / 2;
        yPopup = (GameCanvas2.h - 160) / 2;

        cx = GameCanvas2.w / 2;
        cy = yPopup + 70;

        if (GameCanvas2.w <= 200)
        {
            GameScr2.setPopupSize(128, 100);
            GameScr2.popupX = (GameCanvas2.w - 128) / 2;
            GameScr2.popupY = 10;
            cy += 15;
            dy -= 15;
        }

        tAddName = new TField2
        {
            width = GameCanvas2.w < 200 ? 60 : 160,
            height = ITEM_HEIGHT + 2,
            strInfo = mResources2.char_name,
            showSubTextField = true,
            name = mResources2.char_name,
            x = xPopup,
            y = yPopup - 30,
            isFocus = !GameCanvas2.isTouch
        };
        tAddName.setIputType(TField2.INPUT_TYPE_ANY);
        if (tAddName.getText().Equals("@"))
        {
            tAddName.setText(GameCanvas2.loginScr.tfUser.getText().Substring(0, GameCanvas2.loginScr.tfUser.getText().IndexOf("@")));
        }

        indexGender = 1;
        indexHair = 0;

        center = new Command2(mResources2.NEWCHAR, this, 8000, null);
        left = new Command2(mResources2.BACK, this, 8001, null);
        if (!GameCanvas2.isTouch)
        {
            right = tAddName.cmdClear;
        }
        yBegin = tAddName.y;
        mFontGender = mFont2.tahoma_7b_dark;
    }

    public static CreateCharScr2 gI()
    {
        if (instance == null)
        {
            instance = new CreateCharScr2();
        }
        return instance;
    }

    public static void loadMapFromResource(sbyte[] mapID)
    {
        for (int i = 0; i < mapID.Length; i++)
        {
            DataInputStream2 dataInputStream = MyStream2.readFile("/mymap/" + mapID[i]);
            MapTemplate2.tmw[i] = (ushort)dataInputStream.read();
            MapTemplate2.tmh[i] = (ushort)dataInputStream.read();
            MapTemplate2.maps[i] = new int[dataInputStream.available()];
            for (int j = 0; j < MapTemplate2.tmw[i] * MapTemplate2.tmh[i]; j++)
            {
                MapTemplate2.maps[i][j] = dataInputStream.read();
            }
            MapTemplate2.types[i] = new int[MapTemplate2.maps[i].Length];
        }
    }

    public void loadMapTableFromResource(sbyte[] mapID)
    {
        if (GameCanvas2.lowGraphic)
        {
            return;
        }
        try
        {
            for (int i = 0; i < mapID.Length; i++)
            {
                DataInputStream2 dataInputStream = MyStream2.readFile("/mymap/mapTable" + mapID[i]);
                short num = dataInputStream.readShort();
                MapTemplate2.vCurrItem[i] = new MyVector2();
                for (int j = 0; j < num; j++)
                {
                    short id = dataInputStream.readShort();
                    short num2 = dataInputStream.readShort();
                    short num3 = dataInputStream.readShort();
                    if (TileMap2.getBIById(id) != null)
                    {
                        BgItem2 bIById = TileMap2.getBIById(id);
                        BgItem2 bgItem = new BgItem2();
                        bgItem.id = id;
                        bgItem.idImage = bIById.idImage;
                        bgItem.dx = bIById.dx;
                        bgItem.dy = bIById.dy;
                        bgItem.x = num2 * TileMap2.size;
                        bgItem.y = num3 * TileMap2.size;
                        bgItem.layer = bIById.layer;
                        MapTemplate2.vCurrItem[i].addElement(bgItem);
                        if (!BgItem2.imgNew.containsKey(bgItem.idImage + string.Empty))
                        {
                            try
                            {
                                Image2 image = GameCanvas2.loadImage("/mapBackGround/" + bgItem.idImage + ".png");
                                if (image == null)
                                {
                                    BgItem2.imgNew.put(bgItem.idImage + string.Empty, Image2.createRGBImage(new int[1], 1, 1, bl: true));
                                    Service2.gI().getBgTemplate(bgItem.idImage);
                                }
                                else
                                {
                                    BgItem2.imgNew.put(bgItem.idImage + string.Empty, image);
                                }
                            }
                            catch (Exception)
                            {
                                Image2 image2 = GameCanvas2.loadImage("/mapBackGround/" + bgItem.idImage + ".png");
                                if (image2 == null)
                                {
                                    image2 = Image2.createRGBImage(new int[1], 1, 1, bl: true);
                                    Service2.gI().getBgTemplate(bgItem.idImage);
                                }
                                BgItem2.imgNew.put(bgItem.idImage + string.Empty, image2);
                            }
                            BgItem2.vKeysLast.addElement(bgItem.idImage + string.Empty);
                        }
                        if (!BgItem2.isExistKeyNews(bgItem.idImage + string.Empty))
                        {
                            BgItem2.vKeysNew.addElement(bgItem.idImage + string.Empty);
                        }
                        bgItem.changeColor();
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public override void switchToMe()
    {
        LoginScr2.isContinueToLogin = false;
        GameCanvas2.menu.showMenu = false;
        GameCanvas2.endDlg();
        GameCanvas2.loadBG(2);
        base.switchToMe();
        indexGender = Res2.random(0, 3);
        indexHair = Res2.random(0, 3);
        Char2.isLoadingMap = false;
        ServerListScreen2.countDieConnect = 0;
    }

    public override void keyPress(int keyCode)
    {
        tAddName.keyPressed(keyCode);
    }

    public override void update()
    {
        cp1++;
        if (cp1 > 30)
        {
            cp1 = 0;
        }
        if (cp1 % 15 < 5)
        {
            cf = 0;
        }
        else
        {
            cf = 1;
        }

        tAddName.update();
        tAddName.isFocus = selected == 0;
    }

    public override void updateKey()
    {
        if (GameCanvas2.keyPressed[(!Main2.isPC) ? 2 : 21])
        {
            selected--;
            if (selected < 0)
            {
                selected = 2;
            }
        }
        else if (GameCanvas2.keyPressed[(!Main2.isPC) ? 8 : 22] || GameCanvas2.keyPressed[16])
        {
            selected++;
            if (selected > 2)
            {
                selected = 0;
            }
        }
        if (selected == 0)
        {
            if (!GameCanvas2.isTouch)
            {
                right = tAddName.cmdClear;
            }
            tAddName.update();
            mFontGender = mFont2.tahoma_7b_dark;
        }
        else if (selected == 1)
        {
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
            {
                indexGender--;
                if (indexGender < 0)
                {
                    indexGender = mResources2.MENUGENDER.Length - 1;
                }
            }
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
            {
                indexGender++;
                if (indexGender > mResources2.MENUGENDER.Length - 1)
                {
                    indexGender = 0;
                }
            }
            right = null;
            mFontGender = mFont2.tahoma_7b_blue;
        }
        else if (selected == 2)
        {
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 4 : 23])
            {
                indexHair--;
                if (indexHair < 0)
                {
                    indexHair = mResources2.hairStyleName[0].Length - 1;
                }
            }
            if (GameCanvas2.keyPressed[(!Main2.isPC) ? 6 : 24])
            {
                indexHair++;
                if (indexHair > mResources2.hairStyleName[0].Length - 1)
                {
                    indexHair = 0;
                }
            }
            right = null;
            mFontGender = mFont2.tahoma_7b_dark;

        }
        if (GameCanvas2.isPointerJustRelease)
        {
            int textWidth = mFont2.tahoma_7b_dark.getWidth(mResources2.MENUGENDER[indexGender]);
            int textHeight = mFont2.tahoma_7b_dark.getHeight();

            if (GameCanvas2.isPointerHoldIn(tAddName.x, tAddName.y, tAddName.width, tAddName.height))
            {
                selected = 0;
                mFontGender = mFont2.tahoma_7b_dark;
            }
            else if (GameCanvas2.isPointerHoldIn((GameCanvas2.w - textWidth) / 2 - 10, yPopup + 20, textWidth + 10, textHeight + 10))
            {
                mFontGender = mFont2.tahoma_7b_blue;
                selected = 1;
            }
            else if (GameCanvas2.isPointerHoldIn(xPopup + 40, yPopup + 80, 80, 80))
            {
                selected = 2;
                mFontGender = mFont2.tahoma_7b_dark;
            }
            else if (GameCanvas2.isPointerHoldIn(xPopup + 10, yPopup + 25, 23, 26))
            {
                selected = 1;
                indexGender--;
                if (indexGender < 0)
                {
                    indexGender = 2;
                }
            }
            else if (GameCanvas2.isPointerHoldIn(xPopup + 130, yPopup + 25, 23, 26))
            {
                selected = 1;
                indexGender++;
                if (indexGender > 2)
                {
                    indexGender = 0;
                }
            }
            else if (GameCanvas2.isPointerHoldIn(xPopup + 10, cy + 20, 23, 26))
            {
                selected = 2;
                indexHair--;
                if (indexHair < 0)
                {
                    indexHair = 2;
                }
            }
            else if (GameCanvas2.isPointerHoldIn(xPopup + 130, cy + 20, 23, 26))
            {
                selected = 2;
                indexHair++;
                if (indexHair > 2)
                {
                    indexHair = 0;
                }
            }
        }
        if (!TouchScreenKeyboard.visible)
        {
            base.updateKey();
        }
        GameCanvas2.clearKeyHold();
        GameCanvas2.clearKeyPressed();
    }

    public override void paint(mGraphics2 g)
    {
        if (Char2.isLoadingMap)
        {
            return;
        }
        GameCanvas2.paintBGGameScr(g);
        int num = 30;
        if (GameCanvas2.w == 128)
        {
            num = 20;
        }
        g.translate(-g.getTranslateX(), -g.getTranslateY());

        if (GameCanvas2.currentDialog == null)
        {
            PopUp2.paintPopUp(g, xPopup - 20, yPopup - 60, 160 + 40, 160 + 60, -1, isButton: true);

            mFontGender.drawString(g, mResources2.MENUGENDER[indexGender], GameCanvas2.w / 2, yPopup + 30, mFont2.CENTER);

            g.drawRegion(GameScr2.arrow, 0, 0, 13, 16, 3, xPopup + 20, yPopup + 35, StaticObj2.VCENTER_HCENTER);
            g.drawRegion(GameScr2.arrow, 0, 0, 13, 16, 0, xPopup + 140, yPopup + 35, StaticObj2.VCENTER_HCENTER);

            // Draw char
            int num2 = hairID[indexGender][indexHair];
            int num3 = defaultLeg[indexGender];
            int num4 = defaultBody[indexGender];
            g.drawImage(TileMap2.bong, cx, cy + dy, 3);

            Part2 part3 = null;
            try
            {
                Part2 part = GameScr2.parts[num2];
                Part2 part2 = GameScr2.parts[num3];
                part3 = GameScr2.parts[num4];
                SmallImage2.drawSmallImage(g, part.pi[Char2.CharInfo[cf][0][0]].id, cx + Char2.CharInfo[cf][0][1] + part.pi[Char2.CharInfo[cf][0][0]].dx, cy - Char2.CharInfo[cf][0][2] + part.pi[Char2.CharInfo[cf][0][0]].dy + dy, 0, 0);
                SmallImage2.drawSmallImage(g, part2.pi[Char2.CharInfo[cf][1][0]].id, cx + Char2.CharInfo[cf][1][1] + part2.pi[Char2.CharInfo[cf][1][0]].dx, cy - Char2.CharInfo[cf][1][2] + part2.pi[Char2.CharInfo[cf][1][0]].dy + dy, 0, 0);
                SmallImage2.drawSmallImage(g, part3.pi[Char2.CharInfo[cf][2][0]].id, cx + Char2.CharInfo[cf][2][1] + part3.pi[Char2.CharInfo[cf][2][0]].dx, cy - Char2.CharInfo[cf][2][2] + part3.pi[Char2.CharInfo[cf][2][0]].dy + dy, 0, 0);
            }
            catch (Exception ex)
            {
                MainMod2.WriteLog("Error at paint CreateChar: " + ex.Message + " --- " + ex.StackTrace);
            }

            g.drawRegion(GameScr2.arrow, 0, 0, 13, 16, 3, xPopup + 20, cy + 30, StaticObj2.VCENTER_HCENTER);
            g.drawRegion(GameScr2.arrow, 0, 0, 13, 16, 0, xPopup + 140, cy + 30, StaticObj2.VCENTER_HCENTER);

            if (!GameCanvas2.lowGraphic)
            {
                for (int j = 0; j < MapTemplate2.vCurrItem[indexGender].size(); j++)
                {
                    BgItem2 bgItem2 = (BgItem2)MapTemplate2.vCurrItem[indexGender].elementAt(j);
                    if (bgItem2.idImage != -1 && bgItem2.layer == 3)
                    {
                        bgItem2.paint(g);
                    }
                }
            }

            if (!Main2.isPC)
            {
                if (mGraphics2.addYWhenOpenKeyBoard != 0)
                {
                    yButton = 110;
                    disY = 60;
                    if (GameCanvas2.w > GameCanvas2.h)
                    {
                        yButton = GameScr2.popupY + 30 + 3 * num + part3.pi[Char2.CharInfo[0][2][0]].dy + dy - 15;
                        disY = 35;
                    }
                }
                else
                {
                    yButton = 110;
                    disY = 60;
                    if (GameCanvas2.w > GameCanvas2.h)
                    {
                        yButton = 100;
                        disY = 45;
                    }
                }
                tAddName.y = yButton - tAddName.height - disY + 5;
            }
            else
            {
                yButton = 110;
                disY = 60;
                if (GameCanvas2.w > GameCanvas2.h)
                {
                    yButton = 100;
                    disY = 45;
                }
                tAddName.y = yBegin;
            }

            tAddName.paint(g);

            g.setClip(0, 0, GameCanvas2.w, GameCanvas2.h);
        }

        if (!TouchScreenKeyboard.visible)
        {
            base.paint(g);
        }
    }

    public void perform(int idAction, object p)
    {
        switch (idAction)
        {
            case 8000:
                if (tAddName.getText().Equals(string.Empty))
                {
                    GameCanvas2.startOKDlg(mResources2.char_name_blank);
                    break;
                }
                if (tAddName.getText().Length < 5)
                {
                    GameCanvas2.startOKDlg(mResources2.char_name_short);
                    break;
                }
                if (tAddName.getText().Length > 15)
                {
                    GameCanvas2.startOKDlg(mResources2.char_name_long);
                    break;
                }
                InfoDlg2.showWait();
                Service2.gI().createChar(tAddName.getText(), indexGender, hairID[indexGender][indexHair]);
                break;
            case 8001:
                if (GameCanvas2.loginScr.isLogin2)
                {
                    GameCanvas2.startYesNoDlg(mResources2.note, new Command2(mResources2.YES, this, 10019, null), new Command2(mResources2.NO, this, 10020, null));
                    break;
                }
                if (Main2.isWindowsPhone)
                {
                    GameMidlet2.isBackWindowsPhone = true;
                }
                Session_ME2_.gI().close();
                GameCanvas2.serverScreen.switchToMe();
                break;
            case 10020:
                GameCanvas2.endDlg();
                break;
            case 10019:
                Session_ME2_.gI().close();
                GameCanvas2.endDlg();
                GameCanvas2.serverScreen.switchToMe();
                break;
        }
    }
}
