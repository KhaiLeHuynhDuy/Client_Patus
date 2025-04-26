using System;

namespace Mod2.XMAP
{
    public class AutoXmap2
    {
        public static bool Chat(string text)
        {
            bool flag = text == "xmp";
            if (flag)
            {
                bool isXmapRunning = IsXmapRunning;
                if (isXmapRunning)
                {
                    XmapController2.FinishXmap();
                    GameScr2.info1.addInfo("Đã hủy Xmap", 0);
                }
                else
                {
                    XmapController2.ShowXmapMenu();
                }
            }
            else
            {
                bool flag2 = IsGetInfoChat<int>(text, "xmp");
                if (flag2)
                {
                    bool isXmapRunning2 = IsXmapRunning;
                    if (isXmapRunning2)
                    {
                        XmapController2.FinishXmap();
                        GameScr2.info1.addInfo("Đã hủy Xmap", 0);
                    }
                    else
                    {
                        XmapController2.StartRunToMapId(GetInfoChat<int>(text, "xmp"));
                    }
                }
                else
                {
                    bool flag3 = text == "csb";
                    if (flag3)
                    {
                        IsUseCapsuleNormal = !IsUseCapsuleNormal;
                        GameScr2.info1.addInfo("Sử dụng capsule thường Xmap: " + (IsUseCapsuleNormal ? "Bật" : "Tắt"), 0);
                    }
                    else
                    {
                        bool flag4 = !(text == "csdb");
                        if (flag4)
                        {
                            return false;
                        }
                        IsUseCapsuleVip = !IsUseCapsuleVip;
                        GameScr2.info1.addInfo("Sử dụng capsule đặc biệt Xmap: " + (IsUseCapsuleVip ? "Bật" : "Tắt"), 0);
                    }
                }
            }
            return true;
        }

        public static bool HotKeys()
        {
            int keyAsciiPress = GameCanvas2.keyAsciiPress;
            if (keyAsciiPress != 99)
            {
                if (keyAsciiPress != 120)
                {
                    return false;
                }
                Chat("xmp");
            }
            else
            {
                Chat("csb");
            }
            return true;
        }

        public static void Update()
        {
            bool isLoading = XmapData2.GI().IsLoading;
            if (isLoading)
            {
                XmapData2.GI().Update();
            }
            if (IsXmapRunning)
            {
                XmapController2.Update();
            }
        }

        public static void Info(string text)
        {
            bool flag = text.Equals("Bạn chưa thể đến khu vực này");
            if (flag)
            {
                XmapController2.FinishXmap();
            }
            bool flag2 = (text.ToLower().Contains("chức năng bảo vệ") || text.ToLower().Contains("đã hủy xmap")) && IsXmapRunning;
            if (flag2)
            {
                XmapController2.FinishXmap();
            }
        }

        public static bool XoaTauBay(object obj)
        {
            Teleport2 teleport = (Teleport2)obj;
            bool isMe = teleport.isMe;
            bool result;
            if (isMe)
            {
                Char2.myCharz().isTeleport = false;
                bool flag = teleport.type == 0;
                if (flag)
                {
                    Controller2_.isStopReadMessage = false;
                    Char2.ischangingMap = true;
                }
                Teleport2.vTeleport.removeElement(teleport);
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static void SelectMapTrans(int selected)
        {
            if (IsMapTransAsXmap)
            {
                XmapController2.HideInfoDlg();
                XmapController2.StartRunToMapId(XmapData2.GetIdMapFromPanelXmap(GameCanvas2.panel.mapNames[selected]));
            }
            else
            {
                XmapController2.SaveIdMapCapsuleReturn();
                Service2.gI().requestMapSelect(selected);
            }
        }

        public static void ShowPanelMapTrans()
        {
            IsMapTransAsXmap = false;
            if (IsShowPanelMapTrans)
            {
                GameCanvas2.panel.setTypeMapTrans();
                GameCanvas2.panel.show();
            }
            else
            {
                IsShowPanelMapTrans = true;
            }
        }

        public static void FixBlackScreen()
        {
            Controller2_.gI().loadCurrMap(0);
            Service2.gI().finishLoadMap();
            Char2.isLoadingMap = false;
        }

        private static bool IsGetInfoChat<T>(string text, string s)
        {
            bool flag = text.StartsWith(s);
            bool result;
            if (flag)
            {
                try
                {
                    Convert.ChangeType(text[s.Length..], typeof(T));
                }
                catch
                {
                    return false;
                }
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }

        private static T GetInfoChat<T>(string text, string s)
        {
            return (T)Convert.ChangeType(text[s.Length..], typeof(T));
        }

        public static bool IsXmapRunning = false;

        public static bool IsMapTransAsXmap = false;

        public static bool IsShowPanelMapTrans = true;

        public static bool IsUseCapsuleNormal = true;

        public static bool IsUseCapsuleVip = true;

        public static int IdMapCapsuleReturn = -1;
    }
}
