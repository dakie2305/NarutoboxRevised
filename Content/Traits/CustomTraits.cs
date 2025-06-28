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
            color = "#ff9500",
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

        #region hashirama
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

        #region cell
        ActorTrait cell = new ActorTrait()
        {
            id = $"{Identifier}_cell",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/Cell",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R0_Normal,
        };
        cell.base_stats = new BaseStats();
        cell.base_stats.set(CustomBaseStatsConstant.Health, 100f);
        cell.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.9f);
        cell.type = TraitType.Other;
        cell.unlock(true);
        cell.action_special_effect = (WorldAction)Delegate.Combine(cell.action_special_effect, new WorldAction(CustomTraitActions.cellSpecialEffect));
        AssetManager.traits.add(cell);
        addToLocale(cell.id, "Hashirama's Cell", "The blood cell of The Ninja God! Give this trait to Madara to unlock ultimate form!");
        #endregion


        #region Uchiha
        ActorTrait uchiha = new ActorTrait()
        {
            id = $"{Identifier}_uchiha",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/uchiha",
            rate_birth = NoChance,
            rate_inherit = AlwaysChance,
            rarity = Rarity.R0_Normal,
        };
        uchiha.base_stats = new BaseStats();
        uchiha.base_stats.set(CustomBaseStatsConstant.Damage, 85f);
        uchiha.base_stats.set(CustomBaseStatsConstant.Armor, 10f);
        uchiha.base_stats.set(CustomBaseStatsConstant.Health, 200f);
        uchiha.base_stats.set(CustomBaseStatsConstant.Intelligence, 50f);
        uchiha.base_stats.set(CustomBaseStatsConstant.Speed, 15f);
        uchiha.base_stats.set(CustomBaseStatsConstant.MultiplierStamina, 0.1f);
        uchiha.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.1f);
        uchiha.type = TraitType.Positive;
        uchiha.unlock(true);

        uchiha.addOpposites(new List<string> { $"{Identifier}_senju", $"{Identifier}_hashirama", $"{Identifier}_woodstyle" });

        uchiha.action_special_effect = (WorldAction)Delegate.Combine(uchiha.action_special_effect, new WorldAction(CustomTraitActions.uchihaClanAwakeningSpecialEffect));

        AssetManager.traits.add(uchiha);
        addToLocale(uchiha.id, "Uchiha", "Uchiha Clan! Clan members can have the chance to awake Sharingan trait in the fiercest battle!");
        #endregion

        #region sharingan_1
        ActorTrait sharingan_1 = new ActorTrait()
        {
            id = $"{Identifier}_sharingan_1",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/sharingan_1",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R1_Rare,
        };

        sharingan_1.base_stats = new BaseStats();
        sharingan_1.base_stats.set(CustomBaseStatsConstant.Damage, 25f);
        sharingan_1.base_stats.set(CustomBaseStatsConstant.Armor, 5f);
        sharingan_1.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 0.05f);
        sharingan_1.base_stats.set(CustomBaseStatsConstant.Health, 100f);
        sharingan_1.base_stats.set(CustomBaseStatsConstant.Intelligence, 20f);
        sharingan_1.base_stats.set(CustomBaseStatsConstant.Speed, 10f);

        sharingan_1.type = TraitType.Positive;
        sharingan_1.unlock(true);

        sharingan_1.addOpposites(new List<string> { $"{Identifier}_senju", $"{Identifier}_sharingan_2", $"{Identifier}_sharingan_3" });
        sharingan_1.action_attack_target = new AttackAction(CustomTraitActions.sharingan1AttackEffect);
        sharingan_1.action_special_effect = (WorldAction)Delegate.Combine(sharingan_1.action_special_effect, new WorldAction(CustomTraitActions.sharingan1SpecialEffect));

        AssetManager.traits.add(sharingan_1);
        addToLocale(sharingan_1.id, "Sharingan 1", "The Eyes Of The Uchiha! Can slow enemy and make them stop whatever they are doing!", "Have small chance to evolve into Sharingan level 2 in fiercest battles or through sheer luck!");
        #endregion

        #region sharingan_2
        ActorTrait sharingan_2 = new ActorTrait()
        {
            id = $"{Identifier}_sharingan_2",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/sharingan_2",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R2_Epic,
        };

        sharingan_2.base_stats = new BaseStats();
        sharingan_2.base_stats.set(CustomBaseStatsConstant.Damage, 95f);
        sharingan_2.base_stats.set(CustomBaseStatsConstant.Armor, 10f);
        sharingan_2.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 0.05f);
        sharingan_2.base_stats.set(CustomBaseStatsConstant.Health, 150f);
        sharingan_2.base_stats.set(CustomBaseStatsConstant.Intelligence, 40f);
        sharingan_2.base_stats.set(CustomBaseStatsConstant.Speed, 15f);

        sharingan_2.type = TraitType.Positive;
        sharingan_2.unlock(true);

        sharingan_2.addOpposites(new List<string> { $"{Identifier}_senju", $"{Identifier}_sharingan_1", $"{Identifier}_sharingan_3" });
        sharingan_2.action_attack_target = new AttackAction(CustomTraitActions.sharingan2AttackEffect);
        sharingan_2.action_special_effect = (WorldAction)Delegate.Combine(sharingan_2.action_special_effect, new WorldAction(CustomTraitActions.sharingan2SpecialEffect));

        AssetManager.traits.add(sharingan_2);
        addToLocale(sharingan_2.id, "Sharingan 2", "The Stage 2 Sharingan! Can slow enemy and make them stop whatever they are doing!", "Have small chance to evolve into Sharingan level 3 in fiercest battles or killed many people, or through sheer luck!");
        #endregion

        #region sharingan_3
        ActorTrait sharingan_3 = new ActorTrait()
        {
            id = $"{Identifier}_sharingan_3",
            group_id = TraitGroupId,
            path_icon = $"{PathToTraitIcon}/sharingan_3",
            rate_birth = NoChance,
            rate_inherit = NoChance,
            rarity = Rarity.R3_Legendary,
        };

        sharingan_3.base_stats = new BaseStats();
        sharingan_3.base_stats.set(CustomBaseStatsConstant.Damage, 110f);
        sharingan_3.base_stats.set(CustomBaseStatsConstant.Armor, 15f);
        sharingan_3.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 0.1f);
        sharingan_3.base_stats.set(CustomBaseStatsConstant.Health, 200f);
        sharingan_3.base_stats.set(CustomBaseStatsConstant.Intelligence, 100f);
        sharingan_3.base_stats.set(CustomBaseStatsConstant.Speed, 20f);

        sharingan_3.type = TraitType.Positive;
        sharingan_3.unlock(true);

        sharingan_3.addOpposites(new List<string> { $"{Identifier}_senju", $"{Identifier}_sharingan_1", $"{Identifier}_sharingan_2" });
        sharingan_3.action_attack_target = new AttackAction(CustomTraitActions.sharingan3AttackEffect);
        sharingan_3.action_special_effect = (WorldAction)Delegate.Combine(sharingan_3.action_special_effect, new WorldAction(CustomTraitActions.MangenkyouSpecialEffect));

        AssetManager.traits.add(sharingan_3);
        addToLocale(sharingan_3.id, "Sharingan 3", "The last and strongest stage of Sharingan! This is the foundation to become a legend!", "Rename unit to Uchiha Obito or Uchiha Itachi, or add Cell trait to evolve further!");
        #endregion

    }

    private static void addToLocale(string id, string name, string description, string description_2 = "")
    {
        LM.AddToCurrentLocale($"trait_{id}", name);
        LM.AddToCurrentLocale($"trait_{id}_info", description);
        LM.AddToCurrentLocale($"trait_{id}_info_2", description_2);
    }
}