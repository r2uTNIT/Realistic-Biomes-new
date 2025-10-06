using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        public static float[] DoMonthlyTemps(Tile tile, float[] temps = null, byte idx = 0){
            float[] checkedTemps = temps == null ? new float[12] : temps;

            if(idx < checkedTemps.Length){
                checkedTemps[idx] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)idx);

                return DoMonthlyTemps(tile, checkedTemps, ++idx);
            }
            return temps;
        }
    }
}