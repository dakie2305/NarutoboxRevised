using NeoModLoader.api.attributes;
using System.Collections.Generic;
using UnityEngine;
using NeoModLoader.General;
using System;
using Narutobox.Content;
using Narutobox;


namespace NarutoboxRevised.Content.Traits;

internal static class CustomTraits
{
    private static string TraitGroupId = "darkie_narutobox_revised";
    private static string PathToTraitIcon = "ui/Icons/actor_traits/narutobox_revised_traits";
    private static string Identifier = NarutoBoxMain.Identifier;


    private static int NoChance = 0;
    private static int Rare = 3;
    private static int LowChance = 15;
    private static int MediumChance = 30;
    private static int ExtraChance = 45;
    private static int HighChance = 75;
    private static int AlwaysChance = 100;

    [Hotfixable]
    public static void Init()
    {
        loadCustomTraitGroup();
        loadCustomTrait();
    }

    private static void loadCustomTraitGroup()
    {
        ActorTraitGroupAsset group = new ActorTraitGroupAsset()
        {
            id = TraitGroupId,
            name = $"trait_group_{TraitGroupId}",
            color = "#00f7ff", //TEAL
        };
        // Add trait group to trait group library
        AssetManager.trait_groups.add(group);
        LM.AddToCurrentLocale($"{group.name}", $"Narutobox Traits");
    }

    private static void loadCustomTrait()
    {
        //senju clan
        #region senju
        ActorTrait senju = new ActorTrait()
        {
            id = $"{Identifier}_senju",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/senju",
            rate_birth = NoChance,
            rate_inherit = AlwaysChance,
            rarity = Rarity.R0_Normal,
        };

        senju.base_stats = new BaseStats();
        senju.base_stats.set(CustomBaseStatsConstant.Damage, 85f);
        senju.base_stats.set(CustomBaseStatsConstant.Armor, 10f);
        senju.base_stats.set(CustomBaseStatsConstant.Health, 200f);
        senju.base_stats.set(CustomBaseStatsConstant.Intelligence, 50f);
        senju.base_stats.set(CustomBaseStatsConstant.Speed, 15f);
        senju.base_stats.set(CustomBaseStatsConstant.MultiplierStamina, 0.1f);
        senju.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.1f);

        senju.addOpposites(new List<string> { $"{Identifier}_uchiha", $"{Identifier}_sharingan_1", $"{Identifier}_sharingan_2", $"{Identifier}_sharingan_3" });

        senju.type = TraitType.Positive;
        senju.unlock(true);
        senju.action_special_effect = (WorldAction)Delegate.Combine(senju.action_special_effect, new WorldAction(CustomTraitActions.senjuClanAwakeningSpecialEffect));
        AssetManager.traits.add(senju);
        addToLocale(senju.id, "Senju", "Senju Clan! Clan members can have the chance to awake Woodstyle trait in the fiercest battle!");
        #endregion


        #region woodstyle
        ActorTrait woodstyle = new ActorTrait()
        {
            id = $"{Identifier}_woodstyle",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/woodstyle",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R2_Epic,
        };

        woodstyle.base_stats = new BaseStats();
        woodstyle.base_stats.set(CustomBaseStatsConstant.Damage, 100f);
        woodstyle.base_stats.set(CustomBaseStatsConstant.Armor, 15f);
        woodstyle.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 0.3f);
        woodstyle.base_stats.set(CustomBaseStatsConstant.MultiplierHealth, 0.5f);
        woodstyle.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.3f);
        woodstyle.base_stats.set(CustomBaseStatsConstant.Speed, 30f);

        woodstyle.addOpposites(new List<string> { $"{Identifier}_uchiha", $"{Identifier}_sharingan_1", $"{Identifier}_sharingan_2", $"{Identifier}_sharingan_3" });

        woodstyle.type = TraitType.Positive;
        woodstyle.unlock(true);
        woodstyle.action_special_effect = (WorldAction)Delegate.Combine(woodstyle.action_special_effect, new WorldAction(CustomTraitActions.woodstyleSpecialEffect));
        woodstyle.action_attack_target = new AttackAction(CustomTraitActions.woodstyleAttackEffect);
        AssetManager.traits.add(woodstyle);
        addToLocale(woodstyle.id, "Woodstyle", "Woodstyle No Jutsu! The true leaders of Senju clan, with special abilities of wood and the ultimate bloodline of Senju!");
        #endregion

        #region woodstyle
        ActorTrait hashirama = new ActorTrait()
        {
            id = $"{Identifier}_hashirama",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/Hashirama",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R3_Legendary,
        };

        hashirama.base_stats = new BaseStats();
        hashirama.base_stats.set(CustomBaseStatsConstant.Damage, 800f);
        hashirama.base_stats.set(CustomBaseStatsConstant.Armor, 50f);
        hashirama.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 1.3f);
        hashirama.base_stats.set(CustomBaseStatsConstant.MultiplierHealth, 1.0f);
        hashirama.base_stats.set(CustomBaseStatsConstant.Health, 2000f);
        hashirama.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.9f);
        hashirama.base_stats.set(CustomBaseStatsConstant.Speed, 30f);
        hashirama.base_stats.set(CustomBaseStatsConstant.Mass, 100f);

        hashirama.addOpposites(new List<string> { $"{Identifier}_uchiha", $"{Identifier}_sharingan_1", $"{Identifier}_sharingan_2", $"{Identifier}_sharingan_3" });

        hashirama.type = TraitType.Positive;
        hashirama.unlock(true);
        hashirama.action_special_effect = (WorldAction)Delegate.Combine(hashirama.action_special_effect, new WorldAction(CustomTraitActions.hashiramaSpecialEffect));
        hashirama.action_attack_target = new AttackAction(CustomTraitActions.woodstyleAttackEffect);
        AssetManager.traits.add(hashirama);
        addToLocale(hashirama.id, "Hashirama", "Senju Hashirama! The Ninja God has appeared!", "Rename someone with Woodstyle trait to Senju Hashirama to get this!");
        #endregion

    }

    private static void addToLocale(string id, string name, string description, string description_2 = "")
    {
        LM.AddToCurrentLocale($"trait_{id}", name);
        LM.AddToCurrentLocale($"trait_{id}_info", description);
        LM.AddToCurrentLocale($"trait_{id}_info_2", description_2);
    }
}