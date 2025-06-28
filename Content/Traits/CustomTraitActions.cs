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

        if (NarutoBoxConfig.EnableClanFamilyName && !pTarget.a.getName().Contains("senju", StringComparison.OrdinalIgnoreCase))
        {
            //Add prefix clan name: Senju
            renameToClanName("Senju", pTarget);
        }


        return false;
    }

    internal static bool woodstyleSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        var actor = pTarget.a;
        // Heal if health is very low
        if (Randy.randomChance(0.1f) && actor.data.health < actor.getMaxHealth() / 5)
        {
            actor.restoreHealth(10);
            actor.spawnParticle(Toolbox.color_heal);
            actor.spawnParticle(Toolbox.color_heal);
            actor.spawnParticle(Toolbox.color_heal);
        }

        // Hashirama transformation logic
        string hashiramaTrait = $"{NarutoBoxMain.Identifier}_hashirama";
        if (actor.hasTrait(hashiramaTrait))
            return false;

        if (actor.data.level >= 5)
        {
            actor.data.favorite = true;

            string actorName = actor.getName();
            if (actorName == "Hashirama Senju" || actorName == "Senju Hashirama")
            {
                actor.addTrait(hashiramaTrait);
                actor.data.health += 2500;
            }
            else if (Randy.randomChance(0.001f))
            {
                actor.data.setName("Senju Hashirama");
                actor.addTrait(hashiramaTrait);
                actor.data.health += 2500;
            }
        }

        // Leadership influence based on woodstyle
        if (actor.city?.leader == null || actor.kingdom?.king == null)
            return false;

        string woodstyleTrait = $"{NarutoBoxMain.Identifier}_woodstyle";
        string uchihaTrait = $"{NarutoBoxMain.Identifier}_uchiha";

        var cityLeader = actor.city.leader;

        if (cityLeader.hasTrait(woodstyleTrait) && !cityLeader.hasTrait(uchihaTrait))
        {
            if (actor != actor.city.kingdom.king && actor != cityLeader)
            {
                actor.city.leader = actor;
                actor.setProfession(UnitProfession.Leader);
                actor.city.data.leaderID = actor.data.id;
            }
        }

        return true;
    }


    internal static bool hashiramaSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        // Heal if health is very low
        if (pTarget.a.data.health < pTarget.a.getMaxHealth() / 2)
        {
            pTarget.a.restoreHealth(50);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
        }
        pTarget.a.removeTrait($"{NarutoBoxMain.Identifier}_woodstyle");
        if (pTarget.a.data.health <= pTarget.a.getMaxHealth() / 2)
        {
            pTarget.a.addStatusEffect("GodBody");
        }
        pTarget.a.data.favorite = true; //Always favorite
        return true;
    }

    #endregion

    #region Attack Effect
    internal static bool woodstyleAttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.09f))
        {
            //Get all units  in the area
            var allClosestUnits = Finder.getUnitsFromChunk(pTarget.current_tile, 1);
            if (allClosestUnits.Any())
            {
                foreach (var unit in allClosestUnits)
                {
                    if (pSelf.a == unit.a || unit.a.kingdom == pSelf.a.kingdom) continue;
                    unit.addStatusEffect($"{NarutoBoxMain.Identifier}_woodstyle_effect", 4f);
                }
            }
        }
        else if (Randy.randomChance(0.3f) && !pTarget.a.hasStatus($"{NarutoBoxMain.Identifier}_woodstyle_effect"))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_woodstyle_effect", 4f);
        }
        return true;
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