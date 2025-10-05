using Verse;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    class RimworldPlusPlusSettings : ModSettings{
        public SeaLevel seaLevel;

        public override void ExposeData(){
            Scribe_Values.Look(ref seaLevel, "seaLevel", SeaLevel.Earthlike);

            base.ExposeData();
        }
    }
}