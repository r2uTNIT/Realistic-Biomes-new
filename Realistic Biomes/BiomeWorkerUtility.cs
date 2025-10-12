using RimWorld;
using RimWorld.Planet;
using Verse;
using System.Collections.Immutable;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        public static ImmutableArray<float> DoMonthlyTemps(Tile tile, IOption<float[]> temps, byte idx = 0){
            float[] checkedTemps = temps.IsDefined() ? temps.Get() : new float[12];

            if(idx < checkedTemps.Length){
                checkedTemps[idx] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)idx);

                return DoMonthlyTemps(
                    tile, 
                    new Some<float[]>(checkedTemps), 
                    ++idx
                );
            }
            return ImmutableArray.Create(checkedTemps);
        }
    }
}