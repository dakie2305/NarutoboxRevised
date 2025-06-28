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
        private const string Identifier = "darkie"; //Ensure mod compatibility

        [Hotfixable]
        public static void Init()
        {
            loadCustomStatusEffects();
        }

        private static void loadCustomStatusEffects()
        {
            //Needed this material for status effects
            Material material = LibraryMaterials.instance.dict["mat_world_object_lit"];

            #region sharingan_eye_1_effect
            var sharinganEyeEffect = new StatusAsset()
            {
                id = $"{Identifier}_sharingan_eye_1_effect",
                render_priority = 5,
                duration = 7f,
                animated = true,
                is_animated_in_pause = true,
                can_be_flipped = true,
                use_parent_rotation = false,
                removed_on_damage = false,
                cancel_actor_job = true,
                need_visual_render = true,
                scale = 1.0f,
                tier = StatusTier.Advanced,
                material_id = "mat_world_object_lit",
                material = material,
                texture = "fx_sharingan_eye1", // Make sure this folder exists in effects/
                path_icon = "ui/Icons/iconSharingan1",
            };

            sharinganEyeEffect.locale_id = $"status_title_{sharinganEyeEffect.id}";
            sharinganEyeEffect.locale_description = $"status_description_{sharinganEyeEffect.id}";

            sharinganEyeEffect.base_stats = new();
            sharinganEyeEffect.base_stats.set(CustomBaseStatsConstant.AttackSpeed, -1000f);
            sharinganEyeEffect.base_stats.set(CustomBaseStatsConstant.Speed, -1000f);

            sharinganEyeEffect.action_on_receive = (WorldAction)Delegate.Combine(sharinganEyeEffect.action_on_receive, new WorldAction(CustomStatusEffectAction.stopMovingAndMakeWait));


            sharinganEyeEffect.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{sharinganEyeEffect.texture}", false);

            AssetManager.status.add(sharinganEyeEffect);
            addToLocale(sharinganEyeEffect.id, "Sharingan Effect", "This person is under genjustu of Sharingan!");
            #endregion

            #region amaterasu_effect
            var amaterasuEffect = new StatusAsset()
            {
                id = $"{Identifier}_amaterasu_effect",
                render_priority = 5,
                duration = 999f,
                animated = true,
                is_animated_in_pause = true,
                can_be_flipped = true,
                use_parent_rotation = false,
                removed_on_damage = false,
                cancel_actor_job = true,
                need_visual_render = true,
                scale = 1.0f,
                tier = StatusTier.Advanced,
                material_id = "mat_world_object_lit",
                material = material,
                texture = "fx_amaterasu_effect", // Make sure this folder exists in effects/
                path_icon = "ui/Icons/iconAmaterasu",
            };

            amaterasuEffect.locale_id = $"status_title_{amaterasuEffect.id}";
            amaterasuEffect.locale_description = $"status_description_{amaterasuEffect.id}";

            amaterasuEffect.base_stats = new();
            amaterasuEffect.base_stats.set(CustomBaseStatsConstant.AttackSpeed, -1000f);
            amaterasuEffect.base_stats.set(CustomBaseStatsConstant.Speed, -1000f);

            amaterasuEffect.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{amaterasuEffect.texture}", false);

            amaterasuEffect.action_on_receive = (WorldAction)Delegate.Combine(amaterasuEffect.action_on_receive, new WorldAction(CustomStatusEffectAction.amaterasuSpecialEffect));

            AssetManager.status.add(amaterasuEffect);
            addToLocale(amaterasuEffect.id, "Amaterasu", "Amaterasu's flames, the most dangerous attack that will not stop until enemies no longer exists!");
            #endregion

            #region gen_effect
            var genEffect = new StatusAsset()
            {
                id = $"{Identifier}_gen_effect",
                render_priority = 5,
                duration = 999f,
                animated = true,
                is_animated_in_pause = true,
                can_be_flipped = true,
                use_parent_rotation = false,
                removed_on_damage = false,
                cancel_actor_job = false,
                need_visual_render = true,
                scale = 1.0f,
                tier = StatusTier.Advanced,
                material_id = "mat_world_object_lit",
                material = material,
                texture = "fx_gen_effect", // Make sure this folder exists in effects/
                path_icon = "ui/Icons/iconGen",
            };

            genEffect.locale_id = $"status_title_{genEffect.id}";
            genEffect.locale_description = $"status_description_{genEffect.id}";

            genEffect.base_stats = new();
            genEffect.base_stats.set(CustomBaseStatsConstant.Armor, 100f);

            genEffect.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{genEffect.texture}", false);


            AssetManager.status.add(genEffect);
            addToLocale(genEffect.id, "Genjutsu", "Genjutsu effect!");
            #endregion

        }

        private static void addToLocale(string id, string name, string description)
        {
            LM.AddToCurrentLocale($"status_title_{id}", name);
            LM.AddToCurrentLocale($"status_description_{id}", description);
        }
    }
}
