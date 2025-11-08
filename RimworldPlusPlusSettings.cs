using Verse;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    class RimworldPlusPlusSettings : ModSettings{
        public SeaLevel seaLevel;

        public bool extraRealisticBiomePlacement;

        public override void ExposeData(){
            Scribe_Values.Look(ref seaLevel, "seaLevel", defaultValue:SeaLevel.Earthlike);
            Scribe_Values.Look(ref extraRealisticBiomePlacement, "extraRealisticBiomePlacement", defaultValue:true);

            base.ExposeData();
        }
    }
}