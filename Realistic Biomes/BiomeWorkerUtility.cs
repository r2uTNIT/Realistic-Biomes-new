using RimWorld;
using RimWorld.Planet;
using Verse;
using Verse.Noise;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace RimworldPlusPlus.RealisticBiomes{
    static class BiomeWorkerUtility{
        public const float PerlinCulling = 0.95f;

        public const int num = 30000;

        public static IEnumerable<float> GetMonthlyTemps(PlanetTile tile){
            // This looks like a really useful function | Enumerable.Range(0, 12)

            return new float[12].Select((x, y) => GenTemperature.AverageTemperatureAtTileForTwelfth(tile, (Twelfth)y));
        }
        public static bool SwampNoiseCheck(Perlin perlin, Vector3 coordinates){
            return perlin.GetValue(coordinates) >= PerlinCulling;
        }
    }
}