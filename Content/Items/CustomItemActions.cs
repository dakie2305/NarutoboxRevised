using HarmonyLib;
using NCMS.Utils;
using NeoModLoader.api.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NarutoboxRevised.Content.Items
{
    public class CustomItemActions
    {
        public static bool uchihaFanAttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive())
                return false;
            if (Randy.randomChance(0.1f))
            {
                //Maybe can improve further
                ActionLibrary.castFire(pSelf, pTarget, pTile);
                return true;
            }
            return false;
        }

        public static bool executionerBladeAttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive())
                return false;
            if (Randy.randomChance(0.1f))
            {
                //Maybe can improve further
                ActionLibrary.addSlowEffectOnTarget(pSelf, pTarget, pTile);
                return true;
            }
            return false;
        }

        internal static bool samehadaAttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive())
                return false;
            if (Randy.randomChance(0.1f))
            {
                //Maybe can improve further
                ActionLibrary.addSlowEffectOnTarget(pSelf, pTarget, pTile);
                ActionLibrary.addStunnedEffectOnTarget(pSelf, pTarget, pTile);
                return true;
            }
            return false;
        }

        internal static bool kusanagiAttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive())
                return false;
            if (Randy.randomChance(0.1f))
            {
                ActionLibrary.breakBones(pSelf, pTarget, pTile);
                return true;
            }
            return false;
        }
    }
}
