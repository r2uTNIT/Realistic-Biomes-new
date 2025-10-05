using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;
using System;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenStep_Tiles), "GenerateFresh")]
    [HarmonyPatchCategory("Realistic Biomes")]
    static class GenerateFreshPatch{
        static void Postfix(PlanetLayer layer){
            Dictionary<int, float[]> monthlyTemps = new Dictionary<int, float[]>();

            layer.Tiles.ForEach((x) => {
                monthlyTemps.Add(
                    x.tile.tileId,
                    BiomeWorkerUtility.DoMonthlyTemps(x)
                );
            });
            BiomeDef ocean = DefDatabase<BiomeDef>.GetNamed("Ocean");

            Array.ForEach(monthlyTemps.Keys.ToArray(), (x) => {
                Tile tile = layer[x];

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
                        if(tile.swampiness >= 0.75f){
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
    }
}