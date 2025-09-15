using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        /* C# has no tail-call optimization, recursion very slow, dont use this
        public static IEnumerable<float> DoMonthlyTemps(Tile tile, IList<float> temps = null, int idx = 0){
            if(temps == null){
                temps = new float[12];
            }
            if(idx < 12){
                temps[idx] = AverageTemperatureAtTileForTwelfth(tile, tile.tile, (Twelfth) idx);

                return DoMonthlyTemps(tile, temps, ++idx);
            }
            return temps;
        }*/
        public static IEnumerable<float> GetMonthlyTemps(Tile tile){
            float[] monthlyTemps = new float[12];

            for(Mut<int> i = new Mut<int>(0); i.Variable < 12; ++i.Variable){
                monthlyTemps[i.Variable] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)i.Variable);
            }
            return monthlyTemps;
        }
    }
}