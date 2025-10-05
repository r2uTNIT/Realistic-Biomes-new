using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        // C# has no tail-call optimization, recursion very slow, dont use this
        public static float[] DoMonthlyTemps(Tile tile, float[] temps = null, byte idx = 0){
            float[] checkedTemps = temps == null ? new float[12] : temps;

            if(idx < checkedTemps.Length){
                checkedTemps[idx] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)idx);

                return DoMonthlyTemps(tile, checkedTemps, ++idx);
            }
            return temps;
        }
        public static IEnumerable<float> GetMonthlyTemps(Tile tile){
            float[] monthlyTemps = new float[12];

            for(int i = 0; i < 12; ++i){
                monthlyTemps[i] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)i);
            }
            return monthlyTemps;
        }
    }
}