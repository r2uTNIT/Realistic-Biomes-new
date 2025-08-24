using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    internal static class BiomeWorkerUtility{
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

            for(int i = 0; i < 12; ++i){
                monthlyTemps[i] = GenTemperature.AverageTemperatureAtTileForTwelfth(tile.tile, (Twelfth) i);
            }
            return monthlyTemps;
        }
        private static float AverageTemperatureAtTileForTwelfth(Tile tile, PlanetTile planetTile, Twelfth twelfth){
            int num = 30000;
            int num2 = 300000 * (int) twelfth;

            float num3 = 0;

            for(int i = 0; i < 120; ++i){
                int absTick = num2 + num + Mathf.RoundToInt(i / 120f * 300000f);

                num3 += GetTemperatureFromSeasonAtTile(absTick, tile, planetTile);
            }
            return num3 / 120f;
        }
        /* The "Tile tile2 = Find.WorldGrid[tile]" in GenTemperature.GetTemperatureFromSeasonAtTile() throws an exception since WorldGrid hasn't been created yet, so instead I made
        a custom GetTemperatureFromSeasonAtTile() method that takes a Tile as a parameter, so we don't have to use WorldGrid... if only I had known the solution was so simple */
        private static float GetTemperatureFromSeasonAtTile(int absTick, Tile tile, PlanetTile planetTile){
            if(absTick == 0){
                absTick = 1;
            }
            if(tile == null){
                return 21f;
            }
            return tile.temperature + GenTemperature.OffsetFromSeasonCycle(absTick, planetTile);
        }
    }
}