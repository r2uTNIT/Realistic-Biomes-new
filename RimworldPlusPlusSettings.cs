using Verse;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    class RimworldPlusPlusSettings : ModSettings{
        public bool realisticBiomes = true;
        public bool realismOverhaul = true;
        public bool darkerNights = true;

        public SeaLevel seaLevel = SeaLevel.Vanilla;

        public override void ExposeData(){
            Scribe_Values.Look(ref realisticBiomes, "realisticBiomes");
            Scribe_Values.Look(ref seaLevel, "seaLevel");
            Scribe_Values.Look(ref realismOverhaul, "realismOverhaul");
            Scribe_Values.Look(ref darkerNights, "darkerNights");
            
            base.ExposeData();
        }
    }
}