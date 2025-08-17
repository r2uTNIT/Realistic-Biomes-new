using RimWorld;
using UnityEngine;
using Verse;

// *
namespace RimworldPlusPlus.RealismOverhaul{
    public class GameCondition_NoSunlightDark : GameCondition{
		SkyColorSet eclipseSkyColors;

		public override int TransitionTicks => 200;

        GameCondition_NoSunlightDark(){
            eclipseSkyColors = new SkyColorSet(
                new Color(0.1f, 0.1f, 0.1f), 
                Color.white, 
                new Color(0.1f, 0.1f, 0.1f), 
                1f
            );
        }
		public override float SkyTargetLerpFactor(Map map){
			return GameConditionUtility.LerpInOutValue(this, TransitionTicks);
		}
        public override SkyTarget? SkyTarget(Map map){
			return new SkyTarget?(new SkyTarget(0f, eclipseSkyColors, 1f, 0f));
		}
	}
}