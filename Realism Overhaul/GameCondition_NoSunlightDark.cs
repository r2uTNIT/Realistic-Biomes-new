using RimWorld;
using UnityEngine;
using Verse;

namespace RimworldPlusPlus.RealismOverhaul{
    class GameCondition_NoSunlightDark : GameCondition{
		SkyColorSet EclipseSkyColors = new SkyColorSet(new Color(0.1f, 0.1f, 0.1f), Color.white, new Color(0.1f, 0.1f, 0.1f), 1f); // Only change this line, nothing else

		public override int TransitionTicks => 200;

		public override float SkyTargetLerpFactor(Map map){
			return GameConditionUtility.LerpInOutValue(this, TransitionTicks);
		}
        public override SkyTarget? SkyTarget(Map map){
			return new SkyTarget(0f, EclipseSkyColors, 1f, 0f);
		}
	}
}