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

    internal static bool uchihaClanAwakeningSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        pTarget.a.removeTrait("peaceful");
        if (
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_woodstyle") || 
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_hashirama") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_sharingan_1") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_sharingan_2") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_sharingan_3") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_itachi") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_obito") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_madara") ||
            pTarget.a.hasTrait($"{NarutoBoxMain.Identifier}_full_form")
            )
            return false;
        //Awaken age range
        if (pTarget.a.data.getAge() > 10 && pTarget.a.data.getAge() <= 40)
        {
            if (pTarget.a.data.kills > 25)
            {
                pTarget.a.addTrait($"{NarutoBoxMain.Identifier}_sharingan_1");
                pTarget.a.data.health += 500;
                return true;
            }
            else if(Randy.randomChance(0.05f) || pTarget.a.data.health < pTarget.a.getMaxHealth() / 10)
            {
                pTarget.a.addTrait($"{NarutoBoxMain.Identifier}_sharingan_1");
                pTarget.a.data.health += 500;
                return true;
            }
        }

        if (NarutoBoxConfig.EnableClanFamilyName && !pTarget.a.getName().Contains("uchiha", StringComparison.OrdinalIgnoreCase))
        {
            //Add prefix clan name: Uchiha
            renameToClanName("Uchiha", pTarget);
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
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_god_body_effect");
        }
        pTarget.a.data.favorite = true; //Always favorite
        return true;
    }

    internal static bool cellSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        // Heal if health is very low
        if (pTarget.a.data.health < pTarget.a.getMaxHealth() / 8)
        {
            pTarget.a.restoreHealth(20);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
            pTarget.a.spawnParticle(Toolbox.color_heal);
        }
        return true;
    }

    internal static bool sharingan1SpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;

        var actor = pTarget.a;
        string sharingan1 = $"{NarutoBoxMain.Identifier}_sharingan_1";
        string sharingan2 = $"{NarutoBoxMain.Identifier}_sharingan_2";

        // Already has next stage? Skip
        if (actor.hasTrait(sharingan2))
            return true;

        bool shouldEvolve = false;

        // Evolution condition 1: Young and rare chance
        if (actor.getAge() < 35)
        {
            shouldEvolve = Randy.randomChance(0.001f);
        }
        // Evolution condition 2: Low HP and higher chance
        else if (actor.data.health < actor.getMaxHealth() / 8f)
        {
            shouldEvolve = Randy.randomBool();
        }
        if (shouldEvolve)
        {
            actor.removeTrait(sharingan1);
            actor.addTrait(sharingan2);
            actor.data.health += 500;
        }
        return true;
    }


    internal static bool sharingan2SpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;

        var actor = pTarget.a;
        string sharingan2 = $"{NarutoBoxMain.Identifier}_sharingan_2";
        string sharingan3 = $"{NarutoBoxMain.Identifier}_sharingan_3";

        // Already has next stage? Skip
        if (actor.hasTrait(sharingan3))
            return true;

        bool shouldEvolve = false;

        // Evolution condition 1
        if (actor.getAge() < 55 || actor.data.kills > 55)
        {
            shouldEvolve = Randy.randomChance(0.0001f);
        }
        // Evolution condition 2: Low HP and higher chance
        else if (actor.data.health < actor.getMaxHealth() / 8f)
        {
            shouldEvolve = Randy.randomBool();
        }
        if (shouldEvolve)
        {
            actor.removeTrait(sharingan2);
            actor.addTrait(sharingan3);
            actor.data.health += 700;
        }
        return true;
    }

    internal static bool MangenkyouSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget?.a == null || !pTarget.a.isAlive())
            return false;

        Actor actor = pTarget.a;

        string trait_sharingan1 = $"{NarutoBoxMain.Identifier}_sharingan_1";
        string trait_sharingan2 = $"{NarutoBoxMain.Identifier}_sharingan_2";
        string trait_sharingan3 = $"{NarutoBoxMain.Identifier}_sharingan_3";
        string trait_itachi = $"{NarutoBoxMain.Identifier}_itachi";
        string trait_obito = $"{NarutoBoxMain.Identifier}_obito";
        string trait_senju = $"{NarutoBoxMain.Identifier}_senju";
        string trait_uchiha = $"{NarutoBoxMain.Identifier}_uchiha";

        // Clean up previous sharingan stages
        if (actor.hasTrait(trait_sharingan1) || actor.hasTrait(trait_sharingan2))
        {
            actor.removeTrait(trait_sharingan1);
            actor.removeTrait(trait_sharingan2);
        }

        string name = actor.getName();
        if (name == "Uchiha Itachi" || name == "Itachi Uchiha")
        {
            actor.data.favorite = true;
            actor.removeTrait(trait_sharingan3);
            actor.addTrait(trait_itachi);
            actor.data.health += 1000;
        }
        else if (name == "Uchiha Obito" || name == "Obito Uchiha")
        {
            actor.data.favorite = true;
            actor.removeTrait(trait_sharingan3);
            actor.addTrait(trait_obito);
            actor.data.health += 1200;
        }
        else
        {
            // Random rare evolution into Itachi or Obito
            if (!actor.hasTrait(trait_itachi) && !actor.hasTrait(trait_obito))
            {
                if (Randy.randomChance(0.0001f))
                {
                    actor.removeTrait(trait_sharingan3);
                    actor.addTrait(trait_itachi);
                    actor.data.health += 1000;
                    actor.data.setName("Uchiha Itachi");
                }
                else if (Randy.randomChance(0.0001f))
                {
                    actor.removeTrait(trait_sharingan3);
                    actor.addTrait(trait_obito);
                    actor.data.health += 1000;
                    actor.data.setName("Uchiha Obito");
                }
            }
        }

        if (actor.city == null || actor.city.leader == null || actor.kingdom == null || actor.kingdom.king == null)
            return false;

        // Leadership override if leader isn't Senju or Uchiha
        if (!actor.city.leader.hasTrait(trait_senju) && !actor.city.leader.hasTrait(trait_uchiha))
        {
            if (actor.city.kingdom.king != actor)
            {
                actor.city.leader = actor;
                actor.city.leader.setProfession(UnitProfession.Leader);
                actor.city.data.leaderID = actor.data.id;
            }
        }
        return true;
    }

    internal static bool kamuiSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (pTarget.a.data.health <= pTarget.a.getMaxHealth() / 5 && Randy.randomChance(0.3f))
        {
            ActionLibrary.teleportRandom(pTarget, pTarget, pTile);
            ActionLibrary.castBloodRain(pTarget, pTarget, pTile);
            return true;
        }
        return false;
    }

    internal static bool madaraSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;

        Actor a = pTarget.a;
        a.removeTrait($"{NarutoBoxMain.Identifier}_obito");
        a.data.setName("Uchiha Madara");

        a.data.favorite = true;
        if (a.hasTrait($"{NarutoBoxMain.Identifier}_cell"))
        {
            a.addTrait($"{NarutoBoxMain.Identifier}_final_form");
            a.removeTrait($"{NarutoBoxMain.Identifier}_madara");
            a.data.health += 8000;
        }

        if (Randy.randomChance(0.2f))
        {
            pTarget.a.restoreHealth(25);
            pTarget.a.spawnParticle(Toolbox.color_heal);
        }

        if (a.attackedBy != null)
        {
            a.addStatusEffect($"{NarutoBoxMain.Identifier}_half_susano_effect");
        }
        return true;
    }

    internal static bool rankEvolutionSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        Actor actor = pTarget.a;
        //Kill two enemies
        if (actor.data.kills >= 2 && !actor.hasTrait($"{NarutoBoxMain.Identifier}_rank_genin"))
        {
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_academy_student");
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_chunin"); // Safety: if somehow higher already
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_jonin");


            actor.addTrait($"{NarutoBoxMain.Identifier}_rank_genin");
            actor.data.health += 100;
        }
        return true;
    }

    internal static bool rank2EvolutionSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        Actor actor = pTarget.a;
        //Kill more than 8 enemies
        if (actor.data.kills >= 8 && !actor.hasTrait($"{NarutoBoxMain.Identifier}_rank_chunin"))
        {
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_genin");
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_genin");
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_jonin");

            actor.addTrait($"{NarutoBoxMain.Identifier}_rank_chunin");
            actor.data.health += 100;
        }
        return true;
    }

    internal static bool rank3EvolutionSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        Actor actor = pTarget.a;
        //Kill more than 20 enemies
        // Promote to Jonin
        if (actor.data.kills >= 20 && !actor.hasTrait($"{NarutoBoxMain.Identifier}_rank_jonin"))
        {
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_academy_student");
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_genin");
            actor.removeTrait($"{NarutoBoxMain.Identifier}_rank_chunin");

            actor.addTrait($"{NarutoBoxMain.Identifier}_rank_jonin");
            actor.data.health += 100;
        }
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

    internal static bool sharingan1AttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.05f) && !pTarget.a.hasStatus($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect"))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
            return true;
        }
        return false;
    }

    internal static bool sharingan2AttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.15f) && !pTarget.a.hasStatus($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect"))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
            return true;
        }
        return false;
    }

    internal static bool sharingan3AttackEffect(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.45f) && !pTarget.a.hasStatus($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect"))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
            return true;
        }
        return false;
    }

    internal static bool itachiSpecialAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.1f))
        {
            pTarget.addStatusEffect($"{NarutoBoxMain.Identifier}_amaterasu_effect"); //spam Amaterasu
        }
        else if (Randy.randomChance(0.3f))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
        }
        else if (Randy.randomChance(0.2f))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_gen_effect");
        }

        return true;
    }

    internal static bool obitoSpecialAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        //He can use sharingan
        if (Randy.randomChance(0.3f))
        {
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
        }
        else if (Randy.randomChance(0.3f))
            pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_kamui_effect");
        //he can banish other to somewhere else
        else if (Randy.randomChance(0.02f))
            ActionLibrary.teleportRandom(pSelf, pTarget, null);
        return true;
    }


    internal static bool madaraSpecialAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        Actor a = pSelf.a;
        if (a.data.health <= (a.getMaxHealth() / 2))
        {
            if (Randy.randomChance(0.2f))
                a.addStatusEffect($"{NarutoBoxMain.Identifier}_full_susano_effect");
        }
        if (Randy.randomChance(0.1f))
        {
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "fire");
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "fire");
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "acid");
        }
        if (Randy.randomChance(0.2f))
        {
            EffectsLibrary.spawnExplosionWave(pTile.posV3, 1f, 1f);
            World.world.applyForceOnTile(pTile: pTarget.current_tile, pByWho: pSelf);
            return true;
        }

        return true;
    }

    internal static bool tengaiShinseiAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        if (Randy.randomChance(0.05f))       //default 0.009f
        {
            ActionLibrary.unluckyMeteorite(pTarget);    //spawn 1 meteorite
            pSelf.a.addStatusEffect("invincible", 5f);
            pSelf.a.makeWait(10);
        }

        //shinra tensei
        if (Randy.randomChance(0.1f))
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTarget.current_tile);    //flash
            EffectsLibrary.spawnExplosionWave(pTile.posV3, 1f, 1f);
            World.world.applyForceOnTile(pTile: pTarget.current_tile, pByWho: pSelf);
        }

        //Black shield
        if (Randy.randomChance(0.1f))
        {
            pSelf.a.addStatusEffect($"{NarutoBoxMain.Identifier}_black_shield_effect");
        }

        //switch place with target
        if (pSelf.a.isAttackReady())
        {

            if (Randy.randomChance(0.4f))
            {
                WorldTile targetTile = pTarget.current_tile;
                WorldTile selfTile = pSelf.current_tile;
                teleportToSpecificLocation(pSelf, pSelf, targetTile);
                teleportToSpecificLocation(pSelf, pTarget, selfTile);
                pTarget.a.addStatusEffect($"{NarutoBoxMain.Identifier}_sharingan_eye_1_effect");
            }
        }
        return true;
    }

    internal static bool joninAttack(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile)
    {
        if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
        //Random attack
        if (Randy.randomChance(0.05f))
        {
            teleportToSpecificLocation(pSelf, pTarget, pTarget.current_tile);
        }
        else if (Randy.randomChance(0.05f))
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTarget.current_tile);    //flash
            EffectsLibrary.spawnExplosionWave(pTile.posV3, 1f, 1f);
        }
        else if (Randy.randomChance(0.05f))
        {
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "fire");
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "fire");
            MapBox.instance.drop_manager.spawn(pTarget.current_tile, "acid");
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
            pTarget.a.data.setName($"{actorName} {clanName}");
        }
    }

    internal static bool obitoDeathEffect(BaseSimObject pTarget, WorldTile pTile)
    {
        Actor a = pTarget.a;
        var act = World.world.units.createNewUnit(a.asset.id, pTile);
        if (pTarget.kingdom != null)
            act.kingdom = pTarget.kingdom;
        ActorTool.copyUnitToOtherUnit(a, act);
        act.removeTrait($"{NarutoBoxMain.Identifier}_obito");
        act.addTrait($"{NarutoBoxMain.Identifier}_madara", true);
        act.data.health += 1300;
        ActionLibrary.castLightning(pTarget, act, null);
        EffectsLibrary.spawn("fx_spawn", act.current_tile);
        return true;
    }

    public static bool teleportToSpecificLocation(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile, string text = "fx_teleport_blue")
    {
        EffectsLibrary.spawnAt(text, pTile.pos, 0.1f);
        pTarget.a.cancelAllBeh();
        pTarget.a.spawnOn(pTile, 0f);
        return true;
    }

    #endregion
}