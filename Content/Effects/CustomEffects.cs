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
        }
    }
}
