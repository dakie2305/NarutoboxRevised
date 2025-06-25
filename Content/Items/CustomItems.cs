using HarmonyLib;
using Narutobox;
using Narutobox.Content;
using NCMS.Utils;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NarutoboxRevised.Content.Items
{
    public class CustomItems
    {
        private const string PathIcon = "ui/Icons/items";
        private const string PathSlash = "ui/effects/slashes";

        [Hotfixable]
        public static void Init()
        {
            loadCustomItems();
        }

        private static void loadCustomItems()
        {

            #region teleport dagger
            ItemAsset uchihaFan = AssetManager.items.clone("uchiha_fan", "$weapon");
            uchihaFan.id = "uchiha_fan";
            uchihaFan.material = "adamantine"; //Since they are special weapon, I think this is suitable, and I don't have time to use other materials
            uchihaFan.translation_key = "Uchiha Fan";
            uchihaFan.equipment_subtype = "uchiha_fan";
            uchihaFan.group_id = "sword";
            uchihaFan.animated = false;
            uchihaFan.is_pool_weapon = false;
            uchihaFan.unlock(true);

            uchihaFan.base_stats = new();
            uchihaFan.base_stats.set(CustomBaseStatsConstant.Damage, 50f);
            uchihaFan.base_stats.set(CustomBaseStatsConstant.MultiplierSpeed, 1.0f);
            uchihaFan.base_stats.set(CustomBaseStatsConstant.MultiplierAttackSpeed, 1.0f); //Percentage
            uchihaFan.base_stats.set(CustomBaseStatsConstant.MultiplierHealth, 0.2f);
            uchihaFan.base_stats.set(CustomBaseStatsConstant.ConstructionSpeed, 50f);
            uchihaFan.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.5f);

            uchihaFan.equipment_value = 5000;
            uchihaFan.special_effect_interval = 0.4f;
            uchihaFan.quality = Rarity.R2_Epic;
            uchihaFan.equipment_type = EquipmentType.Weapon;
            uchihaFan.name_class = "item_class_weapon";

            uchihaFan.item_modifier_ids = AssetLibrary<EquipmentAsset>.a(new string[]
             {
                            "stunned"
             });

            uchihaFan.path_slash_animation = "effects/slashes/slash_sword";
            uchihaFan.path_icon = $"{PathIcon}/icon_uchiha_fan"; 
            uchihaFan.path_gameplay_sprite = $"weapons/{uchihaFan.id}"; //Make sure image share same name as id
            uchihaFan.gameplay_sprites = getWeaponSprites(uchihaFan.id); //Make sure this path is also valid

            uchihaFan.action_attack_target = new AttackAction(CustomItemActions.uchihaFanAttackEffect);        //special attack action
            AssetManager.items.list.AddItem(uchihaFan);
            addToLocale(uchihaFan.id, uchihaFan.translation_key, "One of the signature weapon for the most dangerous Uchiha members!");
            #endregion



            #region Executioner blade
            ItemAsset executionerBlade = AssetManager.items.clone("executioners_blade", "$weapon");
           executionerBlade.id = "executioners_blade";
           executionerBlade.material = "adamantine"; 
           executionerBlade.translation_key = "Executioners Blade";
           executionerBlade.equipment_subtype = "executioners_blade";
           executionerBlade.group_id = "sword";
           executionerBlade.animated = false;
           executionerBlade.is_pool_weapon = false;
           executionerBlade.unlock(true);

           executionerBlade.base_stats = new();
           executionerBlade.base_stats.set(CustomBaseStatsConstant.Damage, 70f);
           executionerBlade.base_stats.set(CustomBaseStatsConstant.AttackSpeed, 15f); //Percentage
           executionerBlade.base_stats.set(CustomBaseStatsConstant.Speed, 10f); //Percentage
           executionerBlade.base_stats.set(CustomBaseStatsConstant.MultiplierMana, 0.5f);
           executionerBlade.base_stats.set(CustomBaseStatsConstant.Knockback, 0.5f);
           executionerBlade.equipment_value = 4000;
           executionerBlade.special_effect_interval = 0.4f;
           executionerBlade.quality = Rarity.R2_Epic;
           executionerBlade.equipment_type = EquipmentType.Weapon;
           executionerBlade.name_class = "item_class_weapon";

            executionerBlade.path_slash_animation = "effects/slashes/slash_sword";
            executionerBlade.path_icon = $"{PathIcon}/icon_executioners_blade";
            executionerBlade.path_gameplay_sprite = $"weapons/{executionerBlade.id}"; //Make sure image share same name as id
            executionerBlade.gameplay_sprites = getWeaponSprites(executionerBlade.id); //Make sure this path is also valid

            executionerBlade.action_attack_target = new AttackAction(CustomItemActions.executionerBladeAttackEffect);        //special attack action
            AssetManager.items.list.AddItem(executionerBlade);
            addToLocale(executionerBlade.id, executionerBlade.translation_key, "The one and only Decapitating Carving Knife. A giant sword with a butcher-knife-like appearance!");
            #endregion

        }

        private static void addToLocale(string id, string translation_key, string description)
        {
            LM.AddToCurrentLocale(translation_key, translation_key);
            LM.AddToCurrentLocale($"{id}_description", description);
        }

        public static Sprite[] getWeaponSprites(string id)
        {
            var sprite = Resources.Load<Sprite>("weapons/" + id);
            if (sprite != null)
                return new Sprite[] { sprite };
            else
            {
                DarkieTraitsMain.LogError("Can not find weapon sprite for weapon with this id: " + id);
                return Array.Empty<Sprite>();
            }
        }
    }
}
