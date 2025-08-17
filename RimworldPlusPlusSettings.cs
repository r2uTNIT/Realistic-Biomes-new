using Verse;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    internal class RimworldPlusPlusSettings : ModSettings{
        public bool realisticBiomes;
        public bool realismOverhaul;
        public bool darkerNights;

        public SeaLevel seaLevel;

        public override void ExposeData(){
            Scribe_Values.Look(ref realisticBiomes, "realisticBiomes", true);
            Scribe_Values.Look(ref seaLevel, "seaLevel", SeaLevel.Earthlike);
            Scribe_Values.Look(ref realismOverhaul, "realismOverhaul", true);
            Scribe_Values.Look(ref darkerNights, "darkerNights", true);

            base.ExposeData();
        }
    }
}