﻿using System.Collections.Generic;
using System.Threading;

namespace Mod.XMAP
{
    public class PickMob
    {
        public static void Update()
        {
            PickMobController.Update();
        }

        public static void MobStartDie(Mob m)
        {
            Mob mob = m;
            bool flag = mob.status != 1 && mob.status != 0;
            if (flag)
            {
                mob.lastDie = mSystem.currentTimeMillis();
                mob.countDie++;
                if (mob.countDie > 10)
                {
                    mob.countDie = 0;
                }
            }
        }

        public static void UpdateCountDie(Mob mob)
        {
            bool flag = mob.levelBoss != 0;
            if (flag)
            {
                mob.countDie = 0;
            }
        }

        public static void GoBack()
        {
            Thread.Sleep(5000);
            if (!GameScr.gI().magicTree.isUpdate && GameScr.gI().magicTree.currPeas > 0 && TileMap.mapID == Char.myCharz().cgender + 21)
            {
                Service.gI().magicTree(1);
                Thread.Sleep(500);
                GameCanvas.gI().keyPressedz(-5);
                Thread.Sleep(1000);
            }
            for (int i = 0; i < GameScr.vItemMap.size(); i++)
            {
                ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(i);
                Char.myCharz().cx = itemMap.x;
                Service.gI().charMove();
                Thread.Sleep(1000);
                Service.gI().pickItem(itemMap.itemMapID);
                Thread.Sleep(1000);
            }
            XmapController.StartRunToMapId(mapGoback);
            while (mapGoback != -1 && TileMap.mapID != mapGoback)
            {
                Thread.Sleep(200);
            }
            while (zoneGoback != -1 && TileMap.zoneID != zoneGoback)
            {
                Thread.Sleep(1000);
                Service.gI().requestChangeZone(zoneGoback, -1);
            }
            mapGoback = -1;
            zoneGoback = -1;
            Thread.Sleep(2000);
            MainMod.MoveTo(xGoback, yGoback);
            GameScr.isAutoPlay = true;
        }

        private static readonly sbyte[] IdSkillsBase = new sbyte[]
        {
            0,
            2,
            17,
            4,
            13
        };

        public static readonly short[] IdItemBlockBase = new short[]
        {
            225,
            353,
            354,
            355,
            356,
            357,
            358,
            359,
            360,
            362
        };

        public static bool tanSat = false;

        public static bool tsPlayer = false;

        public static bool neSieuQuai = false;

        public static bool vuotDiaHinh = true;

        public static bool telePem = true;

        public static bool isGoBack;

        public static int mapGoback = -1;

        public static int zoneGoback = -1;

        public static int xGoback;

        public static int yGoback;

        public static List<int> IdMobsTanSat = new();

        public static List<int> TypeMobsTanSat = new();

        public static List<sbyte> IdSkillsTanSat = new(IdSkillsBase);

        public static bool IsAutoPickItems = true;

        public static bool IsPickItemsAll = true;

        public static bool IsPickItemsDis = false;

        public static bool IsLimitTimesPickItem = true;

        public static int TimesAutoPickItemMax = 20;

        public static List<short> IdItemPicks = new();

        public static List<short> IdItemBlocks = new(IdItemBlockBase);

        public static List<sbyte> TypeItemPicks = new();

        public static List<sbyte> TypeItemBlock = new();

        public static int HpBuff = 0;

        public static int MpBuff = 0;
    }
}
