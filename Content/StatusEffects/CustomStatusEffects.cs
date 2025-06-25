using Narutobox;
using Narutobox.Content;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NarutoboxRevised.Content.StatusEffects
{
    public class CustomStatusEffects
    {
        [Hotfixable]
        public static void Init()
        {
            loadCustomStatusEffects();
        }

        private static void loadCustomStatusEffects()
        {
            //Needed this material for status effects
            Material material = LibraryMaterials.instance.dict["mat_world_object_lit"];

            //Let it gooo
            #region ice_storm_effect
            var iceStormEffect = new StatusAsset()
            {
                id = "ice_storm_effect",
                render_priority = 5,
                duration = 10f,
                animated = true,
                is_animated_in_pause = true,
                can_be_flipped = true,
                use_parent_rotation = false,
                removed_on_damage = false,
                cancel_actor_job = false,
                need_visual_render = true,
                scale = 1.0f,
            };

            iceStormEffect.locale_id = $"status_title_{iceStormEffect.id}";
            iceStormEffect.locale_description = $"status_description_{iceStormEffect.id}";
            iceStormEffect.tier = StatusTier.Advanced;

            iceStormEffect.texture = "fx_ice_storm_attack"; // Make sure this folder exists in effects/
            iceStormEffect.path_icon = "ui/Icons/iconIceStorm";

            iceStormEffect.material_id = "mat_world_object_lit";
            iceStormEffect.material = material;

            iceStormEffect.base_stats = new();
            iceStormEffect.base_stats.set(CustomBaseStatsConstant.Damage, 20f);
            iceStormEffect.base_stats.set(CustomBaseStatsConstant.Speed, 20f);

            var iceStormSprite = SpriteTextureLoader.getSpriteList($"effects/{iceStormEffect.texture}", false);
            iceStormEffect.sprite_list = iceStormSprite;

            AssetManager.status.add(iceStormEffect);
            addToLocale(iceStormEffect.id, "Ice Storm", "Let it gooo. Freeze them all");
            #endregion

        }

        private static void addToLocale(string id, string name, string description)
        {
            LM.AddToCurrentLocale($"status_title_{id}", name);
            LM.AddToCurrentLocale($"status_description_{id}", description);
        }
    }
}
