using System.Collections.Generic;
using System.Threading;

namespace Mod2.XMAP
{
    public class ManualXmap2
    {
        public static ManualXmap2 GI()
        {
            _Instance ??= new ManualXmap2();
            return _Instance;
        }

        public void LoadMapLeft()
        {
            LoadMap(0);
        }

        public void LoadMapCenter()
        {
            LoadMap(2);
        }

        public void LoadMapRight()
        {
            LoadMap(1);
        }

        private static void LoadWaypointsInMap()
        {
            ResetSavedWaypoints();
            int num = TileMap2.vGo.size();
            if (num != 2)
            {
                for (int i = 0; i < num; i++)
                {
                    Waypoint2 waypoint = (Waypoint2)TileMap2.vGo.elementAt(i);
                    if (waypoint.maxX < 60)
                    {
                        wayPointMapLeft[0] = (int)(waypoint.minX + 15);
                        wayPointMapLeft[1] = (int)waypoint.maxY;
                    }
                    else if ((int)waypoint.maxX > TileMap2.pxw - 60)
                    {
                        wayPointMapRight[0] = (int)(waypoint.maxX - 15);
                        wayPointMapRight[1] = (int)waypoint.maxY;
                    }
                    else
                    {
                        wayPointMapCenter[0] = (int)(waypoint.minX + 15);
                        wayPointMapCenter[1] = (int)waypoint.maxY;
                    }
                }
                return;
            }
            Waypoint2 waypoint2 = (Waypoint2)TileMap2.vGo.elementAt(0);
            Waypoint2 waypoint3 = (Waypoint2)TileMap2.vGo.elementAt(1);
            if ((waypoint2.maxX < 60 && waypoint3.maxX < 60) || ((int)waypoint2.minX > TileMap2.pxw - 60 && (int)waypoint3.minX > TileMap2.pxw - 60))
            {
                wayPointMapLeft[0] = (int)(waypoint2.minX + 15);
                wayPointMapLeft[1] = (int)waypoint2.maxY;
                wayPointMapRight[0] = (int)(waypoint3.maxX - 15);
                wayPointMapRight[1] = (int)waypoint3.maxY;
                return;
            }
            if (waypoint2.maxX < waypoint3.maxX)
            {
                wayPointMapLeft[0] = (int)(waypoint2.minX + 15);
                wayPointMapLeft[1] = (int)waypoint2.maxY;
                wayPointMapRight[0] = (int)(waypoint3.maxX - 15);
                wayPointMapRight[1] = (int)waypoint3.maxY;
                return;
            }
            wayPointMapLeft[0] = (int)(waypoint3.minX + 15);
            wayPointMapLeft[1] = (int)waypoint3.maxY;
            wayPointMapRight[0] = (int)(waypoint2.maxX - 15);
            wayPointMapRight[1] = (int)waypoint2.maxY;
        }

        private static int GetYGround(int x)
        {
            int num = 50;
            int i = 0;
            while (i < 30)
            {
                i++;
                num += 24;
                if (TileMap2.tileTypeAt(x, num, 2))
                {
                    if (num % 24 != 0)
                    {
                        num -= num % 24;
                        break;
                    }
                    break;
                }
            }
            return num;
        }

        private static void ResetSavedWaypoints()
        {
            wayPointMapLeft = new int[2];
            wayPointMapCenter = new int[2];
            wayPointMapRight = new int[2];
        }

        private static bool IsNRDMap(int mapID)
        {
            return mapID >= 85 && mapID <= 91;
        }

        private static bool IsKarinMap(int mapID)
        {
            return mapID >= 45 && mapID <= 47;
        }

        public static void LoadMap(int position)
        {
            if (IsKarinMap(TileMap2.mapID))
            {
                return;
            }
            if (IsNRDMap(TileMap2.mapID))
            {
                TeleportInNRDMap(position);
                return;
            }
            LoadWaypointsInMap();
            switch (position)
            {
                case 0:
                    if (wayPointMapLeft[0] != 0 && wayPointMapLeft[1] != 0)
                    {
                        MainMod2.MoveTo(wayPointMapLeft[0], wayPointMapLeft[1]);
                    }
                    else
                    {
                        MainMod2.MoveTo(60, GetYGround(60));
                    }
                    break;
                case 1:
                    if (wayPointMapRight[0] != 0 && wayPointMapRight[1] != 0)
                    {
                        MainMod2.MoveTo(wayPointMapRight[0], wayPointMapRight[1]);
                    }
                    else
                    {
                        MainMod2.MoveTo(TileMap2.pxw - 60, GetYGround(TileMap2.pxw - 60));
                    }
                    break;
                case 2:
                    if (wayPointMapCenter[0] != 0 && wayPointMapCenter[1] != 0)
                    {
                        MainMod2.MoveTo(wayPointMapCenter[0], wayPointMapCenter[1]);
                        if (Char2.myCharz().isInEnterOfflinePoint() != null)
                        {
                            Service2.gI().getMapOffline();
                        }
                        else if (Char2.myCharz().isInEnterOnlinePoint() != null)
                        {
                            Service2.gI().requestChangeMap();
                        }
                    }
                    else
                    {
                        MainMod2.MoveTo(TileMap2.pxw / 2, GetYGround(TileMap2.pxw / 2));
                    }
                    break;
            }
        }

        private static void TeleportInNRDMap(int position)
        {
            if (position == 0)
            {
                MainMod2.MoveTo(60, GetYGround(60));
                return;
            }
            if (position != 2)
            {
                MainMod2.MoveTo(TileMap2.pxw - 60, GetYGround(TileMap2.pxw - 60));
                return;
            }
            for (int i = 0; i < GameScr2.vNpc.size(); i++)
            {
                Npc2 npc = (Npc2)GameScr2.vNpc.elementAt(i);
                if (npc.template.npcTemplateId >= 30 && npc.template.npcTemplateId <= 36)
                {
                    Char2.myCharz().npcFocus = npc;
                    MainMod2.MoveTo(npc.cx, npc.cy - 3);
                    return;
                }
            }
        }

        public static ManualXmap2 _Instance;

        public static bool isXmaping;

        public static int IdMapEnd;

        private static int[] wayPointMapLeft;

        private static int[] wayPointMapCenter;

        private static int[] wayPointMapRight;
    }
}
