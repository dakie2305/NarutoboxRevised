using Narutobox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarutoboxRevised.Content.Config
{
    public class NarutoBoxConfig
    {
        private int NoChance = 0;
        private int Rare = 0;
        private int LowChance = 15;
        private int MediumChance = 30;
        private int ExtraChance = 45;
        private int HighChance = 75;

        public static bool EnableClanFamilyName { get; set; } = false;
        public static bool EnableAutoFavorite { get; set; } = false;
        public static bool EnableForceRename { get; set; } = false;
        public static bool UnlockLegendTraits { get; set; } = false;


        //// This method will be called when config value set. ATTENTION: It might be called when game start.
        public static void ClanNameEnableSwitchConfigCallBack(bool pCurrentValue)
        {
            EnableClanFamilyName = pCurrentValue;
            NarutoBoxMain.LogInfo($"Set enable clan family name to '{EnableClanFamilyName}'");
        }

        public static void UnlockLegendTraitsSwitchConfigCallBack(bool pCurrentValue)
        {
            UnlockLegendTraits = pCurrentValue;
            NarutoBoxMain.LogInfo($"Set unlock legend traits to '{UnlockLegendTraits}'");
        }
        public static void AutoFavoriteEnableSwitchConfigCallBack(bool pCurrentValue)
        {
            EnableAutoFavorite = pCurrentValue;
            NarutoBoxMain.LogInfo($"Set Enable Auto Favorite unit to '{EnableAutoFavorite}'");
        }
        public static void ForceRenameSwitchConfigCallBack(bool pCurrentValue)
        {
            EnableForceRename = pCurrentValue;
            NarutoBoxMain.LogInfo($"Set force rename to '{EnableForceRename}'");
        }

    }
}
