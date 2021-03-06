using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace BetterReforges
{
    class Reforge : GlobalItem
    {
        static int[] accessoryModifiers = { PrefixID.Warding, PrefixID.Menacing, PrefixID.Quick, PrefixID.Lucky, PrefixID.Arcane };
        static int[] mageModifiers = { PrefixID.Mythical };
        static int[] meleeModifiers = { PrefixID.Legendary };
        static int[] rangeModifiers = { PrefixID.Unreal };
        static int[] summonerModifiers = { PrefixID.Ruthless };
        static int[] toolModifiers = { PrefixID.Light };
        static int[] thrownModifiers = { PrefixID.Legendary };
        static int[] noKnockbackModifiers = { PrefixID.Demonic };

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            /*switch (item.netID)
            {
                case 385:
                case 386:
                case 388:
                case 1189:
                case 1196:
                case 1203:
                case 1231:
                case 2774:
                case 2779:
                case 2784:
                case 2798:
                case 3464:
                    return PrefixID.Demonic;
                default:
                    break;
            }*/

            if (item.accessory)
            {
                if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.All)
                {
                    int index = rand.Next(0, accessoryModifiers.Length);
                    return accessoryModifiers[index];
                }
                else if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.Warding)
                    return PrefixID.Warding;
                else if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.Quick)
                    return PrefixID.Quick;
                else if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.Menacing)
                    return PrefixID.Menacing;
                else if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.Lucky)
                    return PrefixID.Lucky;
                else if (BetterReforgesConfig.Instance.chosenType == BetterReforgesConfig.accessoryType.Arcane)
                    return PrefixID.Arcane;
            }

            if (item.maxStack == 0 || item.damage > 0 || item.useStyle != 0)
            {

                if (item.hammer > 0 || item.pick > 0 || item.axe > 0)
                {
                    if (item.channel == true) // Checks for Drills
                    {
                        int index2 = rand.Next(0, noKnockbackModifiers.Length);
                        return noKnockbackModifiers[index2];
                    }
                    int index1 = rand.Next(0, toolModifiers.Length);
                    return toolModifiers[index1];
                }

                if (item.melee)
                {
                    if (item.knockBack > 0)
                    {
                        int index = rand.Next(0, meleeModifiers.Length);
                        return meleeModifiers[index];
                    }
                    else
                    {
                        int index = rand.Next(0, noKnockbackModifiers.Length);
                        return noKnockbackModifiers[index];
                    }
                }

                if (item.ranged && item.ammo <= 0) // Makes sure the item isn't any form of ammo
                {
                    if (item.knockBack > 0)
                    {
                        int index = rand.Next(0, rangeModifiers.Length);
                        return rangeModifiers[index];
                    }
                    else
                    {
                        int index = rand.Next(0, noKnockbackModifiers.Length);
                        return noKnockbackModifiers[index];
                    }
                }

                if (item.magic)
                {
                    if (item.knockBack > 0)
                    {
                        int index = rand.Next(0, mageModifiers.Length);
                        return mageModifiers[index];
                    }
                    else
                    {
                        int index = rand.Next(0, noKnockbackModifiers.Length);
                        return noKnockbackModifiers[index];
                    }
                }

                if (item.summon)
                {
                    int index = rand.Next(0, summonerModifiers.Length);
                    return summonerModifiers[index];
                }

                if (item.thrown)
                {
                    int index = rand.Next(0, thrownModifiers.Length);
                    return thrownModifiers[index];
                }

            }

            return -1;
        }

        /*
         * public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        */
    }
}
