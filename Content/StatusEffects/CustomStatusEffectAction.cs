using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.UI.CanvasScaler;

namespace NarutoboxRevised.Content.StatusEffects
{
    public class CustomStatusEffectAction
    {

        #region special effects
        internal static bool stopMovingAndMakeWait(BaseSimObject pTarget, WorldTile pTile)
        {
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
            pTarget.a.cancelAllBeh();
            pTarget.a.stopMovement();
            pTarget.a.makeWait(1f);
            return true;
        }

        internal static bool amaterasuSpecialEffect(BaseSimObject pTarget, WorldTile pTile)
        {
            //Gradually damage
            if (pTarget == null || pTarget.a == null || !pTarget.a.isAlive()) return false;
            pTarget.getHit(10, true, AttackType.Fire, null, true, false);
            if (Randy.randomChance(0.1f))
            {
                MapBox.instance.particles_fire.spawn(pTarget.current_position.x, pTarget.current_position.y, true);
            }
            return true;
        }
        #endregion
    }
}
