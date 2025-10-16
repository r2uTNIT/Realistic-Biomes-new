using RimWorld;
using RimWorld.Planet;
using Verse;
using System.Collections.Immutable;
using Verse.Noise;
using UnityEngine;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        public const float PerlinCulling = 0.95f;

        public static ImmutableArray<float> DoMonthlyTemps(Tile tile, IOption<float[]> temps, byte idx = 0){
            float[] checkedTemps = temps.IsDefined() ? temps.Get() : new float[12];

            if(idx < checkedTemps.Length){
                checkedTemps[idx] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth)idx);

                return DoMonthlyTemps(tile, new Some<float[]>(checkedTemps), ++idx);
            }
            return ImmutableArray.Create(checkedTemps);
        }
        // Thank you BiomesKit!
        public static bool SwampNoiseCheck(Perlin perlin, Vector3 coordinates){
            return perlin.GetValue(coordinates) >= PerlinCulling;
        }
    }
}