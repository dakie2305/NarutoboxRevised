using HarmonyLib;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using NarutoboxRevised.Content.Traits;
using NarutoboxRevised.Content.Effects;
using NarutoboxRevised.Content.StatusEffects;
using NarutoboxRevised.Content.Items;

namespace Narutobox;

public class DarkieTraitsMain : BasicMod<DarkieTraitsMain>, IReloadable
{
    internal static bool _reload_switch;

    /// <summary>
    ///     <para>
    ///         To test reloading function, you can modify traits in <see cref="CustomTraits" /> or trait action in
    ///         <see cref="CustomTraitActions" /> then click Reload button in mod list
    ///     </para>
    ///     <para>You can modify them both in once reloading.</para>
    /// </summary>
    // Let the method can be hotfixed when it is modified and after the mod is reloaded. You can add this attribute at runtime.
    [Hotfixable]
    public void Reload()
    {
        _reload_switch = !_reload_switch;
        CustomTraits.Init();
        CustomStatusEffects.Init();
        CustomEffects.Init();
    }

    protected override void OnModLoad()
    {
        LogInfo("Narutobox Revised hast started up and is running!");
        Config.isEditor = true;
        CustomTraits.Init();
        CustomItems.Init();
        CustomEffects.Init();
        CustomStatusEffects.Init();
    }
}