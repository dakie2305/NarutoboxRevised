using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoboxRevised.Content.Effects
{
    public class CustomEffects
    {
        public static void Init()
        {
            loadCustomEffects();
        }

        private static void loadCustomEffects()
        {
            EffectAsset customTeleportEffect = new EffectAsset();
            customTeleportEffect.id = "fx_MinatoCustomTeleport_effect";
            customTeleportEffect.use_basic_prefab = true;
            customTeleportEffect.sorting_layer_id = "EffectsTop";
            customTeleportEffect.sprite_path = "effects/fx_tele_minato";
            AssetManager.effects_library.add(customTeleportEffect);

            EffectAsset customAntiMatterEffect = new EffectAsset();
            customAntiMatterEffect.id = "fx_CustomAntimatter_effect";
            customAntiMatterEffect.use_basic_prefab = true;
            customAntiMatterEffect.sorting_layer_id = "EffectsTop";
            customAntiMatterEffect.prefab_id = "effects/prefabs/PrefabAntimatterEffect";
            customAntiMatterEffect.sprite_path = "effects/antimatterEffect";
            customAntiMatterEffect.draw_light_area = false;
            customAntiMatterEffect.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionAntimatterBomb";
            AssetManager.effects_library.add(customAntiMatterEffect);
        }
    }
}
