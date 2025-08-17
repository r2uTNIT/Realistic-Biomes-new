using System;
using System.Collections.Generic;
using RimWorld;
using RimWorld.Planet;
using UnityEngine;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    internal static class BiomeWorkerUtility{
        /* C# has no tail-call optimization, which means that recursive functions like these are very slow, especially when called thousands of times, which makes world generation hella slow.
        So Im gonna have to replace this with regular for loops */
        public static IEnumerable<float> DoMonthlyTemps(Tile tile, IList<float> temps = null, int idx = 0){
            if(temps == null){
                temps = new float[12];
            }
            if(idx < 12){
                temps[idx] = AverageTemperatureAtTileForTwelfth(tile, tile.tile, (Twelfth) idx);

                return DoMonthlyTemps(tile, temps, ++idx);
            }
            return temps;
        }
        private static float AverageTemperatureAtTileForTwelfth(Tile tile, PlanetTile planetTile, Twelfth twelfth){
            int num = 30000;
            int num2 = 300000 * (int) twelfth;

            Func<float, int, float> doNum3 = null;
            doNum3 = (a, b) => {
                if(b < 120){
                    int absTick = num2 + num + Mathf.RoundToInt(b / 120f * 300000f);

                    return doNum3(
                        a + GetTemperatureFromSeasonAtTile(absTick, tile, planetTile),
                        ++b
                    );
                }
                return a;
            };
            float num3 = doNum3(0f, 0);

            return num3 / 120f;
        }
        /* The "Tile tile2 = Find.WorldGrid[tile]" in GenTemperature.GetTemperatureFromSeasonAtTile() throws an exception since WorldGrid hasn't been created yet, so instead I made
        a custom GetTemperatureFromSeasonAtTile() method that takes a Tile as a parameter, so we don't have to use WorldGrid... This took me two days to figure out BTW!! */
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