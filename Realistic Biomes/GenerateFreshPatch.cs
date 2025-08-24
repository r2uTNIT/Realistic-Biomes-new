using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenStep_Tiles), "GenerateFresh")]
    [HarmonyPatchCategory("Realistic Biomes")]
    internal static class GenerateFreshPatch{
        // Calculating monthly temps once after tile generation is faster than calculating multiple times for every biome with BiomeWorker
        private static void Postfix(PlanetLayer layer){
            Dictionary<int, float[]> monthlyTemps = new Dictionary<int, float[]>();

            layer.Tiles.ForEach((x) => {
                monthlyTemps.Add(
                    x.tile.tileId,
                    (float[]) BiomeWorkerUtility.GetMonthlyTemps(x)
                );
            });
            BiomeDef ocean = DefDatabase<BiomeDef>.GetNamed("Ocean");

            monthlyTemps.Keys.ToList().ForEach((x) => {
                Tile tile = layer[x];

                // Enumerable.Count(IEnumerable<TSource>, Func<TSource, Boolean>) doesn't work, so I count the valid months manually

                int validTropicalMonths = 0;
                int validTemperateMonths = 0;
                int validMonths = 0;

                foreach(float i in monthlyTemps[x]){
                    if(i > 18){
                        ++validTropicalMonths;
                    }
                    if(i > 10){
                        ++validTemperateMonths;
                    }
                    if(i > 0){
                        ++validMonths;
                    }
                }
                if(tile.WaterCovered){
                    if(validMonths == 0){
                        tile.PrimaryBiome = BiomeDefs.IceCapSea;

                        return;
                    }
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
                        if(tile.swampiness >= 0.75f){
                            if(validTropicalMonths == 12){
                                tile.PrimaryBiome = BiomeDefs.TropicalSwamp;

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
                        else if(validTemperateMonths >= 4 && tile.rainfall >= 100){
                            tile.PrimaryBiome = BiomeDefs.Continental;

                            break;
                        }
                        else if(validTemperateMonths >= 1 && tile.rainfall >= 100){
                            tile.PrimaryBiome = BiomeDefs.Subarctic;

                            break;
                        }
                        else if(validMonths >= 1 || validTemperateMonths >= 1 && tile.rainfall < 100){
                            tile.PrimaryBiome = BiomeDefs.RBTundra;

                            break;
                        }
                        tile.PrimaryBiome = BiomeDefs.IceCapLand;

                        break;       
                }
            });
        }
    }
}