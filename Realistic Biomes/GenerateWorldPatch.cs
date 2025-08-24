using HarmonyLib;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenerator), "GenerateWorld")]
    [HarmonyPatchCategory("Realistic Biomes")]
    internal static class GenerateWorldPatch{
        private static void Prefix(ref OverallRainfall overallRainfall){
            switch(RimworldPlusPlus.settings.seaLevel){
                case SeaLevel.VeryDry:
                    overallRainfall = OverallRainfall.AlmostNone; 

                    break;

                case SeaLevel.Dry:
                    overallRainfall = OverallRainfall.Little;

                    break;

                case SeaLevel.Vanilla:
                    overallRainfall = OverallRainfall.LittleBitLess;

                    break;

                case SeaLevel.Earthlike:
                    overallRainfall = OverallRainfall.Normal;

                    break;

                case SeaLevel.Islands:
                    overallRainfall = OverallRainfall.LittleBitMore;

                    break;

                case SeaLevel.Waterworld:
                    overallRainfall = OverallRainfall.High;

                    break;
            }
        }
    }
}