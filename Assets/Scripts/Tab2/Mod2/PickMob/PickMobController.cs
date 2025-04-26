using System;
using System.Collections.Generic;
using System.Linq;

namespace Mod2.XMAP
{
    public class PickMobController2
    {
        public static void Update()
        {
            if (!IsWaiting())
            {
                Char2 @char = Char2.myCharz();

                // Status me
                // 1: stand
                // 2: run
                // 3: fly
                // 10: fly with mount
                // 14: dead

                if (@char.statusMe != 14 && @char.cHP > 0 || !@char.isWaitMonkey)
                {
                    // Pick item
                    if (PickMob2.IsAutoPickItems)
                    {
                        if (IsPickingItems)
                        {
                            if (IndexItemPick >= ItemPicks.Count)
                            {
                                IsPickingItems = false;
                                Wait(100);
                                return;
                            }
                            ItemMap2 itemMap = ItemPicks[IndexItemPick];
                            if (GameScr2.vItemMap.contains(itemMap))
                            {
                                Service2.gI().pickItem(itemMap.itemMapID);
                                itemMap.countAutoPick++;
                            }
                            Wait(500);
                            IndexItemPick++;
                        }
                        ItemPicks.Clear();
                        IndexItemPick = 0;
                        for (int i = 0; i < GameScr2.vItemMap.size(); i++)
                        {
                            ItemMap2 itemMap2 = (ItemMap2)GameScr2.vItemMap.elementAt(i);
                            if (GetTypePickItem(itemMap2) != TpyePickItem.CanNotPickItem)
                            {
                                ItemPicks.Add(itemMap2);
                            }
                        }
                        if (ItemPicks.Count > 0)
                        {
                            IsPickingItems = true;
                            return;
                        }
                    }

                    // Tan sat mob
                    bool isTDLT = ItemTime2.isExistItem(4387);
                    if (PickMob2.tanSat)
                    {
                        if (@char.isCharge)
                        {
                            Wait(100);
                        }
                        else
                        {
                            if (@char.mobFocus != null && !IsMobTanSat(@char.mobFocus))
                            {
                                @char.mobFocus = null;
                            }
                            if (@char.mobFocus == null)
                            {
                                @char.mobFocus = GetMobTanSat();
                                if (isTDLT && @char.mobFocus != null)
                                {
                                    if (PickMob2.telePem)
                                    {
                                        if (Math2.abs(@char.mobFocus.xFirst - @char.cx) >= 20 || Math2.abs(@char.mobFocus.yFirst - @char.cy) >= 20)
                                        {
                                            MainMod2.MoveTo(@char.mobFocus.xFirst, @char.mobFocus.yFirst);
                                        }
                                        return;
                                    }
                                    @char.cx = @char.mobFocus.xFirst;
                                    @char.cy = @char.mobFocus.yFirst;
                                    Service2.gI().charMove();
                                }
                            }
                            if (@char.mobFocus != null)
                            {
                                if (@char.skillInfoPaint() == null)
                                {
                                    Skill2 skillAttack = GetSkillAttack2();
                                    if (skillAttack != null && CanUseSkill(skillAttack))
                                    {
                                        Mob2 mobFocus = @char.mobFocus;
                                        mobFocus.x = mobFocus.xFirst;
                                        mobFocus.y = mobFocus.yFirst;
                                        if (Char2.myCharz().myskill != skillAttack)
                                        {
                                            GameScr2.gI().doSelectSkill(skillAttack, true);
                                        }
                                        if (Res2.distance(mobFocus.xFirst, mobFocus.yFirst, @char.cx, @char.cy) <= 48)
                                        {
                                            if (GameCanvas2.gameTick % 50 == 0 && Mob2.arrMobTemplate[Char2.myCharz().mobFocus.templateId].type == 4)
                                            {
                                                MainMod2.MoveTo(mobFocus.xFirst, mobFocus.yFirst + 1);
                                            }
                                            if (skillAttack.template.isAttackSkill())
                                            {
                                                MainMod2.GI().AttackMob(mobFocus);
                                                MainMod2.GI().SetUsedSkill(@char.myskill);
                                            }
                                            else if (skillAttack.template.isUseAlone())
                                            {
                                                MainMod2.GI().DoDoubleClickToObj(mobFocus);
                                            }
                                        }
                                        else
                                        {
                                            if (PickMob2.telePem)
                                            {
                                                if (Math2.abs(mobFocus.xFirst - @char.cx) >= 20 || Math2.abs(mobFocus.yFirst - @char.cy) >= 20)
                                                {
                                                    MainMod2.MoveTo(mobFocus.xFirst, mobFocus.yFirst);
                                                }
                                                return;
                                            }
                                            Move(mobFocus.xFirst, mobFocus.yFirst);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (!isTDLT)
                                {
                                    Mob2 mobNext = GetMobNext();
                                    if (mobNext != null)
                                    {
                                        Char2.myCharz().FocusManualTo(mobNext);
                                        if (PickMob2.telePem)
                                        {
                                            if (Math2.abs(mobNext.xFirst - @char.cx) >= 20 || Math2.abs(mobNext.yFirst - @char.cy) >= 20)
                                            {
                                                MainMod2.MoveTo(mobNext.xFirst, mobNext.yFirst);
                                            }
                                            return;
                                        }
                                        Move(mobNext.xFirst, mobNext.yFirst);
                                    }
                                }
                            }
                            Wait(100);
                        }
                    }

                    // Tan sat player
                    else if (PickMob2.tsPlayer)
                    {
                        if (@char.isCharge)
                        {
                            Wait(100);
                        }
                        else
                        {
                            if (@char.charFocus != null && !IsCharTanSat(@char.charFocus))
                            {
                                @char.charFocus = null;
                            }
                            if (@char.charFocus == null)
                            {
                                @char.charFocus = GetCharTanSat();
                                if (@char.charFocus != null)
                                {
                                    if (PickMob2.telePem)
                                    {
                                        if (Math2.abs(@char.charFocus.cx - @char.cx) >= 20 || Math2.abs(@char.charFocus.cy - @char.cy) >= 20)
                                        {
                                            MainMod2.MoveTo(@char.charFocus.cx, @char.charFocus.cy);
                                        }
                                        return;
                                    }
                                    @char.cx = @char.charFocus.cx;
                                    @char.cy = @char.charFocus.cy;
                                    Service2.gI().charMove();
                                }
                            }
                            if (@char.charFocus != null)
                            {
                                if (@char.skillInfoPaint() == null)
                                {
                                    Skill2 skillAttack = GetSkillAttack2();
                                    if (skillAttack != null && CanUseSkill(skillAttack))
                                    {
                                        Char2 charFocus = @char.charFocus;
                                        if (@char.myskill != skillAttack)
                                        {
                                            GameScr2.gI().doSelectSkill(skillAttack, true);
                                        }
                                        if (Res2.distance(charFocus.cx, charFocus.cy, @char.cx, @char.cy) <= 48)
                                        {
                                            MainMod2.GI().DoDoubleClickToObj(charFocus);
                                        }
                                        else
                                        {
                                            if (PickMob2.telePem)
                                            {
                                                if (Math2.abs(charFocus.cx - @char.cx) >= 20 || Math2.abs(charFocus.cy - @char.cy) >= 20)
                                                {
                                                    MainMod2.MoveTo(charFocus.cx, charFocus.cy);
                                                }
                                                return;
                                            }
                                            Move(charFocus.cx, charFocus.cy);
                                        }
                                    }
                                }
                            }
                            Wait(100);
                        }
                    }
                }
            }
        }

        public static void Move(int x, int y)
        {
            Char2 @char = Char2.myCharz();
            bool flag = !PickMob2.vuotDiaHinh;
            if (flag)
            {
                @char.currentMovePoint = new MovePoint2(x, y);
            }
            else
            {
                int[] pointYsdMax = GetPointYsdMax(@char.cx, x);
                bool flag2 = pointYsdMax[1] >= y || (pointYsdMax[1] >= @char.cy && (@char.statusMe == 2 || @char.statusMe == 1));
                if (flag2)
                {
                    pointYsdMax[0] = x;
                    pointYsdMax[1] = y;
                }
                @char.currentMovePoint = new MovePoint2(pointYsdMax[0], pointYsdMax[1]);
            }
        }

        private static TpyePickItem GetTypePickItem(ItemMap2 itemMap)
        {
            TpyePickItem result;
            Char2 @char = Char2.myCharz();
            bool canPick = itemMap.playerId == @char.charID || itemMap.playerId == -1 || PickMob2.IsPickItemsAll;
            if (!canPick)
            {
                result = TpyePickItem.CanNotPickItem;
            }
            else
            {
                if (PickMob2.IsLimitTimesPickItem && itemMap.countAutoPick > PickMob2.TimesAutoPickItemMax)
                {
                    result = TpyePickItem.CanNotPickItem;
                }
                else
                {
                    if (!FilterItemPick(itemMap))
                    {
                        result = TpyePickItem.CanNotPickItem;
                    }
                    else
                    {
                        if (PickMob2.IsPickItemsDis || Res2.abs(@char.cx - itemMap.xEnd) < 100 && Res2.abs(@char.cy - itemMap.yEnd) < 100)
                        {
                            result = TpyePickItem.PickItemNormal;
                        }
                        else
                        {
                            if (ItemTime2.isExistItem(4387))
                            {
                                result = TpyePickItem.PickItemTDLT;
                            }
                            else
                            {
                                if (PickMob2.tanSat)
                                {
                                    result = TpyePickItem.PickItemTanSat;
                                }
                                else
                                {
                                    result = TpyePickItem.CanNotPickItem;
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static bool FilterItemPick(ItemMap2 itemMap)
        {
            return (PickMob2.IdItemPicks.Count == 0 || PickMob2.IdItemPicks.Contains(itemMap.template.id))
                && (PickMob2.IdItemBlocks.Count == 0 || !PickMob2.IdItemBlocks.Contains(itemMap.template.id))
                && (PickMob2.TypeItemPicks.Count == 0 || PickMob2.TypeItemPicks.Contains(itemMap.template.type))
                && (PickMob2.TypeItemBlock.Count == 0 || !PickMob2.TypeItemBlock.Contains(itemMap.template.type));
        }

        private static Mob2 GetMobTanSat()
        {
            Mob2 result = null;
            int num = int.MaxValue;
            Char2 @char = Char2.myCharz();
            for (int i = 0; i < GameScr2.vMob.size(); i++)
            {
                Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
                int num2 = (mob.xFirst - @char.cx) * (mob.xFirst - @char.cx) + (mob.yFirst - @char.cy) * (mob.yFirst - @char.cy);
                bool flag = IsMobTanSat(mob) && num2 < num;
                if (flag)
                {
                    result = mob;
                    num = num2;
                }
            }
            return result;
        }

        private static Char2 GetCharTanSat()
        {
            Char2 result = null;
            for (int i = 0; i < GameScr2.vCharInMap.size(); i++)
            {
                Char2 c = (Char2)GameScr2.vCharInMap.elementAt(i);
                if (IsCharTanSat(c))
                {
                    result = c;
                }
            }
            return result;
        }

        private static Mob2 GetMobNext()
        {
            Mob2 result = null;
            long num = mSystem2.currentTimeMillis();
            for (int i = 0; i < GameScr2.vMob.size(); i++)
            {
                Mob2 mob = (Mob2)GameScr2.vMob.elementAt(i);
                bool flag = IsMobNext(mob) && mob.lastDie < num;
                if (flag)
                {
                    result = mob;
                    num = mob.lastDie;
                }
            }
            return result;
        }

        private static bool IsMobTanSat(Mob2 mob)
        {
            bool result;
            if (mob.status == 0 || mob.status == 1 || mob.hp <= 0 || mob.isMobMe)
            {
                result = false;
            }
            else
            {
                bool flag = PickMob2.neSieuQuai && !ItemTime2.isExistItem(4387);
                result = ((mob.levelBoss == 0 || !flag) && FilterMobTanSat(mob));
            }
            return result;
        }

        private static bool IsCharTanSat(Char2 c)
        {
            return Char2.myCharz().isMeCanAttackOtherPlayer(c);
        }

        private static bool IsMobNext(Mob2 mob)
        {
            bool isMobMe = mob.isMobMe;
            bool result;
            if (isMobMe)
            {
                result = false;
            }
            else
            {
                bool flag = !FilterMobTanSat(mob);
                if (flag)
                {
                    result = false;
                }
                else
                {
                    bool flag2 = PickMob2.neSieuQuai && !ItemTime2.isExistItem(4387) && mob.getTemplate().hp >= 3000;
                    if (flag2)
                    {
                        bool flag3 = mob.levelBoss != 0;
                        if (flag3)
                        {
                            Mob2 mob2 = null;
                            bool flag4 = false;
                            for (int i = 0; i < GameScr2.vMob.size(); i++)
                            {
                                mob2 = (Mob2)GameScr2.vMob.elementAt(i);
                                bool flag5 = mob2.countDie == 10 && (mob2.status == 0 || mob2.status == 1);
                                if (flag5)
                                {
                                    flag4 = true;
                                    break;
                                }
                            }
                            bool flag6 = !flag4;
                            if (flag6)
                            {
                                return false;
                            }
                            mob.lastDie = mob2.lastDie;
                        }
                        else
                        {
                            bool flag7 = mob.countDie == 10 && (mob.status == 0 || mob.status == 1);
                            if (flag7)
                            {
                                return false;
                            }
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        private static bool FilterMobTanSat(Mob2 mob)
        {
            return (PickMob2.IdMobsTanSat.Count == 0 || PickMob2.IdMobsTanSat.Contains(mob.mobId)) && (PickMob2.TypeMobsTanSat.Count == 0 || PickMob2.TypeMobsTanSat.Contains(mob.templateId)) && !mob.isMobMe;
        }

        private static Skill2 GetSkillAttack()
        {
            Skill2 skill = null;
            SkillTemplate2 skillTemplate = new();
            foreach (sbyte id in PickMob2.IdSkillsTanSat)
            {
                skillTemplate.id = id;
                Skill2 skill2 = Char2.myCharz().getSkill(skillTemplate);
                if (IsSkillBetter(skill2, skill))
                {
                    skill = skill2;
                }
            }
            return skill;
        }

        private static Skill2 GetSkillAttack2()
        {
            Skill2 skill = null;

            // Skill on screen
            // Except skill type 2, 4; skill id 10, 11, 14, 23
            Skill2[] skills = GameCanvas2.isTouch ? GameScr2.onScreenSkill : GameScr2.keySkill;
            for (int i = 0; i < skills.Length; i++)
            {
                Skill2 s = skills[i];
                if (s == null
                    || s.template.id == 10
                    || s.template.id == 11
                    || s.template.id == 14
                    || s.template.id == 23
                    || s.template.isBuffToPlayer()
                    || s.template.isSkillSpec())
                {
                    continue;
                }
                if (IsSkillBetter(s, skill))
                {
                    skill = s;
                }
            }
            return skill;
        }

        private static bool IsSkillBetter(Skill2 SkillBetter, Skill2 skill)
        {
            bool result;
            if (SkillBetter == null)
            {
                result = false;
            }
            else if (skill == null)
            {
                result = true;
            }
            else
            {
                if (!CanUseSkill(SkillBetter))
                {
                    result = false;
                }
                else if (!CanUseSkill(skill))
                {
                    result = true;
                }
                else
                {
                    bool flag3 = (SkillBetter.template.id == 17 && skill.template.id == 2) || (SkillBetter.template.id == 9 && skill.template.id == 0);
                    result = skill.coolDown < SkillBetter.coolDown || flag3;
                }
            }
            return result;
        }

        public static bool CanUseSkill(Skill2 skill)
        {
            // Check cooldown & mana
            if (mSystem2.currentTimeMillis() - skill.lastTimeUseThisSkill > skill.coolDown + 25L)
            {
                skill.paintCanNotUseSkill = false;
            }
            return !skill.paintCanNotUseSkill && Char2.myCharz().cMP >= GetManaUseSkill(skill);
        }

        private static long GetManaUseSkill(Skill2 skill)
        {
            bool flag = skill.template.manaUseType == 2;
            long result;
            if (flag)
            {
                result = 1;
            }
            else
            {
                bool flag2 = skill.template.manaUseType == 1;
                if (flag2)
                {
                    result = skill.manaUse * Char2.myCharz().cMPFull / 100;
                }
                else
                {
                    result = skill.manaUse;
                }
            }
            return result;
        }

        public static int GetYsd(int xsd)
        {
            Char2 @char = Char2.myCharz();
            int num = TileMap2.pxh;
            int result = -1;
            for (int i = 24; i < TileMap2.pxh; i += 24)
            {
                bool flag = TileMap2.tileTypeAt(xsd, i, 2);
                if (flag)
                {
                    int num2 = Res2.abs(i - @char.cy);
                    bool flag2 = num2 < num;
                    if (flag2)
                    {
                        num = num2;
                        result = i;
                    }
                }
            }
            return result;
        }

        private static int[] GetPointYsdMax(int xStart, int xEnd)
        {
            int num = TileMap2.pxh;
            int num2 = -1;
            bool flag = xStart > xEnd;
            if (flag)
            {
                for (int i = xEnd; i < xStart; i += 24)
                {
                    int ysd = GetYsd(i);
                    bool flag2 = ysd < num;
                    if (flag2)
                    {
                        num = ysd;
                        num2 = i;
                    }
                }
            }
            else
            {
                for (int j = xEnd; j > xStart; j -= 24)
                {
                    int ysd2 = GetYsd(j);
                    bool flag3 = ysd2 < num;
                    if (flag3)
                    {
                        num = ysd2;
                        num2 = j;
                    }
                }
            }
            return new int[]
            {
                num2,
                num
            };
        }

        public static void Wait(int time)
        {
            IsWait = true;
            TimeStartWait = mSystem2.currentTimeMillis();
            TimeWait = time;
        }

        public static bool IsWaiting()
        {
            if (IsWait && mSystem2.currentTimeMillis() - TimeStartWait >= TimeWait)
            {
                IsWait = false;
            }
            return IsWait;
        }

        private static readonly sbyte[] IdSkillsMelee = new sbyte[]
        {
            0,
            9,
            2,
            17,
            4
        };

        private static readonly sbyte[] IdSkillsCanNotAttack = new sbyte[]
        {
            10,
            11,
            14,
            23,
            7
        };

        private static readonly PickMobController2 _Instance = new();

        public static bool IsPickingItems;

        private static bool IsWait;

        private static long TimeStartWait;

        private static long TimeWait;

        public static List<ItemMap2> ItemPicks = new List<ItemMap2>();

        private static int IndexItemPick = 0;

        private enum TpyePickItem
        {
            CanNotPickItem,
            PickItemNormal,
            PickItemTDLT,
            PickItemTanSat
        }
    }
}
