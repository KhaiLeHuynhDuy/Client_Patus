using System.Collections.Generic;
using UnityEngine;

namespace Mod2.XMAP
{
    public class XmapController2 : IActionListener2
    {
        private static readonly string listMap = "Làng Aru,Đồi hoa cúc,Thung lũng tre,Rừng nấm,Rừng xương,Đảo Kamê,Đông Karin,Làng Mori,Đồi nấm tím,Thị trấn Moori,Thung lũng Namếc,Thung lũng Maima,Vực maima,Đảo Guru,Làng Kakarot,Đồi hoang,Làng Plant,Rừng nguyên sinh,Rừng thông Xayda,Thành phố Vegeta,Vách núi đen,Nhà Gôhan,Nhà Moori,Nhà Broly,Trạm tàu vũ trụ,Trạm tàu vũ trụ,Trạm tàu vũ trụ,Rừng Bamboo,Rừng dương xỉ,Nam Kamê,Đảo Bulông,Núi hoa vàng,Núi hoa tím,Nam Guru,Đông Nam Guru,Rừng cọ,Rừng đá,Thung lũng đen,Bờ vực đen,Vách núi Aru,Vách núi Moori,Vực Plant,Vách núi Aru,Vách núi Moori,Vách núi Kakarot,Thần điện,Tháp Karin,Rừng Karin,Hành tinh Kaio,Phòng tập thời gian,Thánh địa Kaio,Đấu trường,Đại hội võ thuật,Tường thành 1,Tầng 3,Tầng 1,Tầng 2,Tầng 4,Tường thành 2,Tường thành 3,Trại độc nhãn 1,Trại độc nhãn 2,Trại độc nhãn 3,Trại lính Fide,Núi dây leo,Núi cây quỷ,Trại qủy già,Vực chết,Thung lũng Nappa,Vực cấm,Núi Appule,Căn cứ Raspberry,Thung lũng Raspberry,Thung lũng chết,Đồi cây Fide,Khe núi tử thần,Núi đá,Rừng đá,Lãnh  địa Fize,Núi khỉ đỏ,Núi khỉ vàng,Hang quỷ chim,Núi khỉ đen,Hang khỉ đen,Siêu Thị,Hành tinh M-2,Hành tinh Polaris,Hành tinh Cretaceous,Hành tinh Monmaasu,Hành tinh Rudeeze,Hành tinh Gelbo,Hành tinh Tigere,Thành phố phía đông,Thành phố phía nam,Đảo Balê,95,Cao nguyên,Thành phố phía bắc,Ngọn núi phía bắc,Thung lũng phía bắc,Thị trấn Ginder,101,Nhà Bunma,Võ đài Xên bọ hung,Sân sau siêu thị,Cánh đồng tuyết,Rừng tuyết,Núi tuyết,Dòng sông băng,Rừng băng,Hang băng,Đông Nam Karin,Võ đài Hạt Mít,Đại hội võ thuật,Cổng phi thuyền,Phòng chờ,Thánh địa Kaio,Cửa Ải 1,Cửa Ải 2,Cửa Ải 3,Phòng chỉ huy,Đấu trường,Ngũ Hành Sơn,Ngũ Hành Sơn,Ngũ Hành Sơn,Võ đài Bang,Thành phố Santa,Cổng phi thuyền,Bụng Mabư,Đại hội võ thuật,Đại hội võ thuật Vũ Trụ,Hành Tinh Yardart,Hành Tinh Yardart 2,Hành Tinh Yardart 3,Đại hội võ thuật Vũ Trụ 6-7,Động hải tặc,Hang Bạch Tuộc,Động kho báu,Cảng hải tặc,Hành tinh Potaufeu,Hang động Potaufeu,Con đường rắn độc,Con đường rắn độc,Con đường rắn độc,Hoang mạc,Võ Đài Siêu Cấp,Tây Karin,Sa mạc,Lâu đài Lychee,Thành phố Santa,Lôi Đài,Hành tinh bóng tối,Vùng đất băng giá,Lãnh địa bang hội,Hành tinh Bill,Hành tinh ngục tù,Tây thánh địa,Đông thánh Địa,Bắc thánh địa,Nam thánh Địa,Khu hang động,Bìa rừng nguyên thủy,Rừng nguyên thủy,Làng Plant nguyên thủy,Tranh ngọc Namếc";

        public static readonly string[] mapNames = listMap.Split(new char[] { ',' });

        public static void Update()
        {
            bool flag = IsWaiting() || XmapData2.GI().IsLoading;
            if (!flag)
            {
                if (IsWaitNextMap)
                {
                    Wait(100);
                    IsWaitNextMap = false;
                }
                else
                {
                    if (IsNextMapFailed)
                    {
                        XmapData2.GI().MyLinkMaps = null;
                        WayXmap = null;
                        IsNextMapFailed = false;
                    }
                    else
                    {
                        if (WayXmap == null)
                        {
                            if (XmapData2.GI().MyLinkMaps == null)
                            {
                                XmapData2.GI().LoadLinkMaps();
                                return;
                            }
                            WayXmap = XmapAlgorithm2.FindWay(TileMap2.mapID, IdMapEnd);
                            IndexWay = 0;
                            if (WayXmap == null)
                            {
                                GameScr2.info1.addInfo("Không thể tìm thấy đường đi", 0);
                                FinishXmap();
                                return;
                            }
                        }
                        if (TileMap2.mapID == WayXmap[^1] && !XmapData2.IsMyCharDie())
                        {
                            GameScr2.info1.addInfo("|4|Modded by patus", 0);
                            FinishXmap();
                        }
                        else
                        {
                            if (TileMap2.mapID == WayXmap[IndexWay])
                            {
                                if (XmapData2.IsMyCharDie())
                                {
                                    Service2.gI().returnTownFromDead();
                                    IsWaitNextMap = IsNextMapFailed = true;
                                }
                                else
                                {
                                    if (XmapData2.CanNextMap())
                                    {
                                        NextMap(WayXmap[IndexWay + 1]);
                                        IsWaitNextMap = true;
                                    }
                                }
                                Wait(500);
                            }
                            else
                            {
                                if (TileMap2.mapID == WayXmap[IndexWay + 1])
                                {
                                    IndexWay++;
                                }
                                else
                                {
                                    IsNextMapFailed = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void perform(int idAction, object p)
        {
            if (idAction == 1)
            {
                ShowPanelXmap((List<int>)p);
            }
        }

        private static void Wait(int time)
        {
            IsWait = true;
            TimeStartWait = mSystem2.currentTimeMillis();
            TimeWait = time;
        }

        private static bool IsWaiting()
        {
            if (IsWait && mSystem2.currentTimeMillis() - TimeStartWait >= TimeWait)
            {
                IsWait = false;
            }
            return IsWait;
        }

        public static void ShowXmapMenu()
        {
            XmapData2.GI().LoadGroupMapsFromFile();
            MyVector2 myVector = new();
            foreach (GroupMap2 groupMap in XmapData2.GI().GroupMaps)
            {
                myVector.addElement(new Command2(groupMap.NameGroup, _Instance, 1, groupMap.IdMaps));
            }
            GameCanvas2.menu.startAt(myVector, 3);
        }

        public static string GetMapName(int id)
        {
            string result = TileMap2.mapName;
            if (id >= 0 && id < mapNames.Length && mapNames[id] != null && mapNames[id] != string.Empty)
            {
                result = mapNames[id];
            }
            return result;
        }

        public static void ShowPanelXmap(List<int> idMaps)
        {
            AutoXmap2.IsMapTransAsXmap = true;
            int count = idMaps.Count;
            GameCanvas2.panel.mapNames = new string[count];
            GameCanvas2.panel.planetNames = new string[count];
            for (int i = 0; i < count; i++)
            {
                string str = GetMapName(idMaps[i]);
                GameCanvas2.panel.mapNames[i] = str + " [" + idMaps[i].ToString() + "]";
                GameCanvas2.panel.planetNames[i] = "";
            }
            GameCanvas2.panel.setTypeMapTrans();
            GameCanvas2.panel.show();
        }

        public static void StartRunToMapId(int idMap)
        {
            IdMapEnd = idMap;
            AutoXmap2.IsXmapRunning = true;
        }

        public static void FinishXmap()
        {
            AutoXmap2.IsXmapRunning = false;
            IsNextMapFailed = false;
            XmapData2.GI().MyLinkMaps = null;
            WayXmap = null;
            GameCanvas2.panel.hide();
        }

        public static void SaveIdMapCapsuleReturn()
        {
            AutoXmap2.IdMapCapsuleReturn = TileMap2.mapID;
        }

        private static void NextMap(int idMapNext)
        {
            VuDangMapNext = idMapNext;
            List<MapNext2> mapNexts = XmapData2.GI().GetMapNexts(TileMap2.mapID);
            if (mapNexts != null)
            {
                foreach (MapNext2 mapNext in mapNexts)
                {
                    if (mapNext.MapID == idMapNext)
                    {
                        NextMap(mapNext);
                        return;
                    }
                }
            }
            GameScr2.info1.addInfo("Lỗi tại dữ liệu", 0);
        }

        private static void NextMap(MapNext2 mapNext)
        {
            switch (mapNext.Type)
            {
                case TypeMapNext2.AutoWaypoint:
                    NextMapAutoWaypoint(mapNext);
                    break;
                case TypeMapNext2.NpcMenu:
                    NextMapNpcMenu(mapNext);
                    break;
                case TypeMapNext2.NpcPanel:
                    NextMapNpcPanel(mapNext);
                    break;
                case TypeMapNext2.Position:
                    NextMapPosition(mapNext);
                    break;
                case TypeMapNext2.Capsule:
                    NextMapCapsule(mapNext);
                    break;
            }
        }

        private static void NextMapAutoWaypoint(MapNext2 mapNext)
        {
            Waypoint2 waypoint = XmapData2.FindWaypoint(mapNext.MapID);
            if (waypoint != null)
            {
                int posWaypointX = XmapData2.GetPosWaypointX(waypoint);
                int posWaypointY = XmapData2.GetPosWaypointY(waypoint);
                MainMod2.MoveTo(posWaypointX, posWaypointY);
                if (Char2.myCharz().isInEnterOnlinePoint() != null)
                {
                    waypoint.popup.command.performAction();
                }
            }
        }

        private static void NextMapNpcMenu(MapNext2 mapNext)
        {
            int num = mapNext.Info[0];
            if (GameScr2.findNPCInMap((short)num) == null)
            {
                Fixtl();
            }
            else
            {
                MainMod2.GotoNpc(num);
                Service2.gI().openMenu(num);
                for (int i = 0; i < GameCanvas2.menu.menuItems.size(); i++)
                {
                    if (((Command2)GameCanvas2.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("võ thuật") && VuDangMapNext == 129)
                    {
                        Service2.gI().confirmMenu((short)num, (sbyte)i);
                        return;
                    }
                    if (((Command2)GameCanvas2.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("tương lai") && VuDangMapNext >= 92 && VuDangMapNext <= 103)
                    {
                        Service2.gI().confirmMenu((short)num, (sbyte)i);
                        return;
                    }
                    if (((Command2)GameCanvas2.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("yardart") && VuDangMapNext >= 131 && VuDangMapNext <= 133)
                    {
                        Service2.gI().confirmMenu((short)num, (sbyte)i);
                        return;
                    }
                    if (VuDangMapNext >= 161 && VuDangMapNext <= 164)
                    {
                        if (((Command2)GameCanvas2.menu.menuItems.elementAt(i)).caption.Trim().ToLower().Contains("thực vật"))
                        {
                            Service2.gI().confirmMenu((short)num, (sbyte)i);
                        }
                        else
                        {
                            Service2.gI().useItem(0, 1, (sbyte)MainMod2.FindItemIndex(992), -1);
                        }
                        return;
                    }
                }
                for (int j = 1; j < mapNext.Info.Length; j++)
                {
                    int num2 = mapNext.Info[j];
                    Service2.gI().confirmMenu((short)num, (sbyte)num2);
                }
            }
        }

        private static void Fixtl()
        {
            if (TileMap2.mapID == 27)
            {
                NextMap(28);
                IsWaitNextMap = true;
                step = 0;
            }
            else
            {
                if (TileMap2.mapID == 29)
                {
                    NextMap(28);
                    IsWaitNextMap = true;
                    step = 1;
                }
                else
                {
                    if (step == 0)
                    {
                        NextMap(29);
                        IsWaitNextMap = true;
                    }
                    else
                    {
                        if (step == 1)
                        {
                            NextMap(27);
                            IsWaitNextMap = true;
                        }
                    }
                }
            }
        }

        private static void NextMapNpcPanel(MapNext2 mapNext)
        {
            int num = mapNext.Info[0];
            int num2 = mapNext.Info[1];
            int selected = mapNext.Info[2];
            MainMod2.GotoNpc(num);
            Service2.gI().openMenu(num);
            Service2.gI().confirmMenu((short)num, (sbyte)num2);
            Service2.gI().requestMapSelect(selected);
        }

        private static void NextMapPosition(MapNext2 mapNext)
        {
            GameCanvas2.startOKDlg("Đây là lỗi, vui lòng báo cáo lại với ADMIN");
            InfoDlg2.hide();
        }

        private static void NextMapCapsule(MapNext2 mapNext)
        {
            SaveIdMapCapsuleReturn();
            int selected = mapNext.Info[0];
            Service2.gI().requestMapSelect(selected);
        }

        public static void UseCapsuleNormal()
        {
            AutoXmap2.IsShowPanelMapTrans = false;
            Service2.gI().useItem(0, 1, (sbyte)MainMod2.FindItemIndex(193), -1);
        }

        public static void UseCapsuleVip()
        {
            AutoXmap2.IsShowPanelMapTrans = false;
            Service2.gI().useItem(0, 1, (sbyte)MainMod2.FindItemIndex(194), -1);
        }

        public static void HideInfoDlg()
        {
            InfoDlg2.hide();
        }


        public static int VuDangMapNext;

        private static int step;

        private const int TIME_DELAY_NEXTMAP = 200;

        private const int TIME_DELAY_RENEXTMAP = 500;

        private const int ID_ITEM_CAPSULE_VIP = 194;

        private const int ID_ITEM_CAPSULE = 193;

        private const int ID_ICON_ITEM_TDLT = 4387;

        private static readonly XmapController2 _Instance = new XmapController2();

        public static int IdMapEnd;

        private static List<int> WayXmap;

        private static int IndexWay;

        private static bool IsNextMapFailed;

        private static bool IsWait;

        private static long TimeStartWait;

        private static long TimeWait;

        private static bool IsWaitNextMap;
    }
}
