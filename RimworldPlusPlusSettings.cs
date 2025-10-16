using Verse;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    class RimworldPlusPlusSettings : ModSettings{
        public SeaLevel seaLevel;

        public bool extraRealisticBiomePlacement;

        public override void ExposeData(){
            Scribe_Values.Look(ref seaLevel, "seaLevel", SeaLevel.Earthlike);
            Scribe_Values.Look(ref extraRealisticBiomePlacement, "extraRealisticBiomePlacement", false);

            base.ExposeData();
        }
    }
}