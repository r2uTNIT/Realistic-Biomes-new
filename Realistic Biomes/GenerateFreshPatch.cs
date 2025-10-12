using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;
using System;
using System.Collections.Immutable;
using UnityEngine;
using Verse.Noise;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenStep_Tiles), "GenerateFresh")]
    [HarmonyPatchCategory("Realistic Biomes")]
    static class GenerateFreshPatch{
        /* GenTemperature.AverageTemperatureAtTileForTwelfth() doesn't work in a BiomeWorker since the tiles are still being generated, so instead I just change the BiomeDefs of the already
        generated tiles in a postfix patch. Yes I know it's slow as fuck, but this was the only method that works. And yes, I HAVE tried every other possible way, including making my own
        AverageTemperatureAtTileForTwelfth() function that DOES work before all the tiles have been generated, but it ended up being 2x slower than the current method anyway... :( */

        const float PerlinCulling = 0.95f;
        
        const double Frequency = 0.1;
        const double Lacunarity = 10;
        const double Persistence = 0.6;
        
        const int Octaves = 12;

        static void Postfix(PlanetLayer layer){
            Dictionary<int, ImmutableArray<float>> monthlyTemps = new Dictionary<int, ImmutableArray<float>>();

            layer.Tiles.ForEach((x) => {
                monthlyTemps.Add(
                    x.tile.tileId,
                    BiomeWorkerUtility.DoMonthlyTemps(x, new None<float[]>())
                );
            });
            BiomeDef ocean = DefDatabase<BiomeDef>.GetNamed("Ocean");

            Array.ForEach(monthlyTemps.Keys.ToArray(), (x) => {
                Tile tile = layer[x];
                Vector3 coordinates = Find.WorldGrid.GetTileCenter(tile.tile);

                int validTropicalMonths = monthlyTemps[x].Count((y) => {return y > 18;});
                int validTemperateMonths = monthlyTemps[x].Count((y) => {return y > 10;});
                int validMonths = monthlyTemps[x].Count((y) => {return y > 0;});

                if(tile.WaterCovered){
                    if(validMonths == 0){
                        tile.PrimaryBiome = BiomeDefs.IceCapSea;

                        return;
                    }
                    // Removes vanilla sea ice biome
                    else if(tile.PrimaryBiome.defName == "SeaIce"){
                        tile.PrimaryBiome = ocean;
                    }
                    return;
                }
                switch(DrynessUtility.IsDry(tile.temperature, tile.rainfall)){
                    case Dryness.Arid:
                        tile.PrimaryBiome = tile.temperature >= 18 ? BiomeDefs.HotDesert : BiomeDefs.ColdDesert;

                        break;

                    case Dryness.Semiarid:
                        tile.PrimaryBiome = tile.temperature >= 18 ? BiomeDefs.HotSteppe : BiomeDefs.ColdSteppe;

                        break;

                    case Dryness.Wet:
                        if(PerlinNoiseCheck(coordinates)){
                            if(validTropicalMonths == 12){
                                tile.PrimaryBiome = BiomeDefs.TropicalWetSwamp;

                                break;
                            }
                            else if(validTemperateMonths >= 8){
                                tile.PrimaryBiome = BiomeDefs.HumidSubtropicalSwamp;

                                break;
                            }
                            else if(validTemperateMonths >= 4){
                                tile.PrimaryBiome = BiomeDefs.ContinentalSwamp;

                                break;
                            }
                            else if(validTemperateMonths >= 1){
                                tile.PrimaryBiome = BiomeDefs.SubarcticSwamp;

                                break;
                            }
                        }
                        if(validTropicalMonths == 12){
                            tile.PrimaryBiome = tile.rainfall >= 2000 ? BiomeDefs.TropicalWetRainforest : BiomeDefs.TropicalWet;

                            break;
                        }
                        else if(validTemperateMonths >= 8){
                            tile.PrimaryBiome = BiomeDefs.HumidSubtropical;

                            break;
                        }
                        else if(validTemperateMonths >= 4 /*&& tile.rainfall >= 100*/){
                            tile.PrimaryBiome = BiomeDefs.Continental;

                            break;
                        }
                        else if(validTemperateMonths >= 1 /*&& tile.rainfall >= 100*/){
                            tile.PrimaryBiome = BiomeDefs.Subarctic;

                            break;
                        }
                        else if(validMonths >= 1 /*|| validTemperateMonths >= 1 && tile.rainfall < 100*/){
                            tile.PrimaryBiome = BiomeDefs.RBTundra;

                            break;
                        }
                        tile.PrimaryBiome = BiomeDefs.IceCapLand;

                        break;       
                }
            });
        }
        // Thank you BiomesKit!
        static bool PerlinNoiseCheck(Vector3 coordinates){
            Perlin perlin = new Perlin(Frequency, Lacunarity, Persistence, Octaves, Find.World.info.Seed, QualityMode.Low);
            return perlin.GetValue(coordinates) >= PerlinCulling;
        }
    }
}