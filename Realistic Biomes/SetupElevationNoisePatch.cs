using HarmonyLib;
using RimWorld.Planet;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenStep_Terrain), "SetupElevationNoise")]
    [HarmonyPatchCategory("Realistic Biomes")]
    internal static class SetupElevationNoisePatch{
        private static void Prefix(ref FloatRange ___ElevationRange){
            switch(RimworldPlusPlus.settings.seaLevel){
                case SeaLevel.VeryDry: 
                    ___ElevationRange = new FloatRange(-50f, 5000f);

                    break;

                case SeaLevel.Dry:
                    ___ElevationRange = new FloatRange(-250f, 5000f);

                    break;

                case SeaLevel.Vanilla:
                    ___ElevationRange = new FloatRange(-500f, 5000f);

                    break;
                
                case SeaLevel.Earthlike:
                    ___ElevationRange = new FloatRange(-1000f, 5000f);

                    break;

                case SeaLevel.Islands:
                    ___ElevationRange = new FloatRange(-1500f, 5000f);

                    break;
                
                case SeaLevel.Waterworld:
                    ___ElevationRange = new FloatRange(-2000f, 5000f);

                    break;
            }
        }
    }
}