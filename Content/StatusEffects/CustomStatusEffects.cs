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
        public const string Identifier = NarutoBoxMain.Identifier; //Ensure mod compatibility

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


            #region kamui_effect
            var kamuiEffect = new StatusAsset()
            {
                id = $"{Identifier}_kamui_effect",
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
                texture = "fx_kamui_effect", // Make sure this folder exists in effects/
                path_icon = "ui/Icons/iconKamui",
            };

            kamuiEffect.locale_id = $"status_title_{kamuiEffect.id}";
            kamuiEffect.locale_description = $"status_description_{kamuiEffect.id}";

            kamuiEffect.base_stats = new();
            kamuiEffect.base_stats.set(CustomBaseStatsConstant.Armor, 100f);

            kamuiEffect.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{kamuiEffect.texture}", false);


            AssetManager.status.add(kamuiEffect);
            addToLocale(kamuiEffect.id, "Kamui", "Kamui Nojustu!");
            #endregion

            #region half_susano_effect
            var halfSusa = new StatusAsset()
            {
                id = $"{Identifier}_half_susano_effect",
                render_priority = 5,
                duration = 1f,
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
                texture = "fx_half_susa_effect",
                path_icon = "ui/Icons/iconHalfSusa",
            };

            halfSusa.locale_id = $"status_title_{halfSusa.id}";
            halfSusa.locale_description = $"status_description_{halfSusa.id}";

            halfSusa.base_stats = new();
            halfSusa.base_stats.set(CustomBaseStatsConstant.Armor, 20f);
            halfSusa.base_stats.set(CustomBaseStatsConstant.Mass, 100f);
            halfSusa.base_stats.set(CustomBaseStatsConstant.Damage, 25f);
            halfSusa.opposite_status = new[] { amaterasuEffect.id };


            halfSusa.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{halfSusa.texture}", false);

            AssetManager.status.add(halfSusa);
            addToLocale(halfSusa.id, "Half Sussano Effect", "Half Sussano Nojustu");
            #endregion

            #region full_susano_effect
            var fullSusa = new StatusAsset()
            {
                id = $"{Identifier}_full_susano_effect",
                render_priority = 5,
                duration = 1f,
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
                texture = "fx_full_susa_effect",
                path_icon = "ui/Icons/iconFullSusa",
            };

            fullSusa.locale_id = $"status_title_{fullSusa.id}";
            fullSusa.locale_description = $"status_description_{fullSusa.id}";

            fullSusa.base_stats = new();
            fullSusa.base_stats.set(CustomBaseStatsConstant.Scale, 0.01f);
            fullSusa.base_stats.set(CustomBaseStatsConstant.Knockback, 10f);
            fullSusa.opposite_status = new[] { amaterasuEffect.id };

            fullSusa.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{fullSusa.texture}", false);

            AssetManager.status.add(fullSusa);
            addToLocale(fullSusa.id, "Full Sussano Effect", "Full Sussano Nojustu");
            #endregion

            #region black_shield_effect
            var blackShield = new StatusAsset()
            {
                id = $"{Identifier}_black_shield_effect",
                render_priority = 5,
                duration = 1f,
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
                texture = "fx_black_shield_effect",
                path_icon = "ui/Icons/iconBlackShield",
            };

            blackShield.locale_id = $"status_title_{blackShield.id}";
            blackShield.locale_description = $"status_description_{blackShield.id}";

            blackShield.base_stats = new();
            blackShield.base_stats.set(CustomBaseStatsConstant.Armor, 25f);
            blackShield.base_stats.set(CustomBaseStatsConstant.Scale, 0.01f);
            blackShield.opposite_status = new[] { amaterasuEffect.id };

            blackShield.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{blackShield.texture}", false);

            AssetManager.status.add(blackShield);
            addToLocale(blackShield.id, "BlackShield Effect", "Black Shield Nojustu");
            #endregion

            #region god_body_effect
            var godBody = new StatusAsset()
            {
                id = $"{Identifier}_god_body_effect",
                render_priority = 5,
                duration = 1f,
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
                texture = "fx_god_body_effect",
                path_icon = "ui/Icons/iconGodBody",
            };

            godBody.locale_id = $"status_title_{godBody.id}";
            godBody.locale_description = $"status_description_{godBody.id}";

            godBody.base_stats = new();
            godBody.base_stats.set(CustomBaseStatsConstant.Armor, 25f);
            godBody.base_stats.set(CustomBaseStatsConstant.Mass, 100f);
            godBody.opposite_status = new[] { amaterasuEffect.id };

            godBody.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{godBody.texture}", false);

            AssetManager.status.add(godBody);
            addToLocale(godBody.id, "GodBody Effect", "God Body Protection");
            #endregion

            #region skill1_effect
            var woodStyleEffect = new StatusAsset()
            {
                id = $"{Identifier}_woodstyle_effect",
                render_priority = 5,
                duration = 15f,
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
                texture = "fx_skill_1_effect",
                path_icon = "ui/Icons/iconSkill1",
            };

            woodStyleEffect.locale_id = $"status_title_{woodStyleEffect.id}";
            woodStyleEffect.locale_description = $"status_description_{woodStyleEffect.id}";

            woodStyleEffect.base_stats = new();
            woodStyleEffect.base_stats.set(CustomBaseStatsConstant.Health, -100f);
            woodStyleEffect.base_stats.set(CustomBaseStatsConstant.Speed, -999f);
            woodStyleEffect.base_stats.set(CustomBaseStatsConstant.AttackSpeed, -999f);
            woodStyleEffect.base_stats.set(CustomBaseStatsConstant.Damage, -300f);

            woodStyleEffect.action_on_receive = (WorldAction)Delegate.Combine(woodStyleEffect.action_on_receive, new WorldAction(StatusLibrary.poisonedEffect));

            woodStyleEffect.sprite_list = SpriteTextureLoader.getSpriteList($"effects/{woodStyleEffect.texture}", false);

            AssetManager.status.add(woodStyleEffect);
            addToLocale(woodStyleEffect.id, "Woodstyle", "Woodstyle No Jutsu");
            #endregion

        }

        private static void addToLocale(string id, string name, string description)
        {
            //Already have locale files, so this is not needed

            //LM.AddToCurrentLocale($"status_title_{id}", name);
            //LM.AddToCurrentLocale($"status_description_{id}", description);
        }
    }
}
