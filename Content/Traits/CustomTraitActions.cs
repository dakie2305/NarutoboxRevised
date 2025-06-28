using ai;
using HarmonyLib.Tools;
using Narutobox;
using Narutobox.Content;
using NarutoboxRevised.Content.Config;
using NeoModLoader.api.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.CanvasScaler;

namespace NarutoboxRevised.Content.Traits;

internal static class CustomTraitActions
{
    #region special effects
    public static bool senjuClanAwakeningSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_woodstyle") || pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_hashirama"))
            return false;
        //Awaken age range
        if (pTarget.a.data.getAge() > 15 && pTarget.a.data.getAge() <= 40)
        {
            if (Randy.randomChance(0.005f) || pTarget.a.data.health < pTarget.a.getMaxHealth() / 10 || pTarget.a.data.kills > 15)
            {
                pTarget.a.addTrait($"{NarutoBoxMain.Identifier}_woodstyle");
                pTarget.a.data.health += 1200;
                return true;
            }
        }

        //Healing
        if (Randy.randomChance(0.1f) && pTarget.a.data.health < pTarget.a.getMaxHealth() / 5)
        {
            pTarget.a.restoreHealth(10);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
        }

        if (NarutoBoxConfig.EnableClanFamilyName)
        {
            //Add prefix clan name: Senju
            renameToClanName("Senju", pTarget);
        }


        return false;
    }
    #endregion



    #region Custom Function
    private static void renameToClanName(string clanName, BaseSimObject pTarget)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return;
        string actorName = pTarget.a.getName();
        if (!actorName.Contains(clanName, StringComparison.OrdinalIgnoreCase))
        {
            pTarget.a.data.setName($"{clanName} {actorName}");
        }
    }

    #endregion
}