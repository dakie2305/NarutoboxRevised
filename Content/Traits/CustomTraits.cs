using NeoModLoader.api.attributes;
using System.Collections.Generic;
using UnityEngine;
using NeoModLoader.General;
using System;
using Narutobox.Content;


namespace NarutoboxRevised.Content.Traits;

internal static class CustomTraits
{
    private static string TraitGroupId = "darkie_narutobox_revised";
    private static string PathToTraitIcon = "ui/Icons/actor_traits/narutobox_revised_traits";
    private static string Identifier = "darkie";


    private static int NoChance = 0;
    private static int Rare = 3;
    private static int LowChance = 15;
    private static int MediumChance = 30;
    private static int ExtraChance = 45;
    private static int HighChance = 75;

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

    }

    private static void addToLocale(string id, string name, string description)
    {
        LM.AddToCurrentLocale($"trait_{id}", name);
        LM.AddToCurrentLocale($"trait_{id}_info", description);
    }
}