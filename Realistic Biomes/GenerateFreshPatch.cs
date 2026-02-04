using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using System.Collections.Generic;
using System.Linq;
using Verse;
using UnityEngine;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(WorldGenStep_Tiles), "GenerateFresh")]
    [HarmonyPatchCategory("Realistic Biomes")]
    static class GenerateFreshPatch{
        static void Postfix(PlanetLayer layer){
            BiomeDef ocean = DefDatabase<BiomeDef>.GetNamed("Ocean");

            if(Globals.settings.extraRealisticBiomePlacement){
                Log.Message("Hope you like loading screens!");

                var monthlyTemps = new Dictionary<int, IEnumerable<float>>(layer.Tiles.Count);

                layer.Tiles.ForEach(x => {
                    IEnumerable<float> temps = BiomeWorkerUtility.GetMonthlyTemps(x.tile);
                    monthlyTemps.Add(x.tile.tileId, temps);
                });

                monthlyTemps.Keys.ToList().ForEach(x => {
                    Tile tile = layer[x];

                    int validMonths = monthlyTemps[x].Count(y => y > 0);

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
                            Vector3 coordinates = Find.WorldGrid.GetTileCenter(tile.tile);

                            int validTropicalMonths = monthlyTemps[x].Count(y => y > 18);
                            int validTemperateMonths = monthlyTemps[x].Count(y => y > 10);

                            if(BiomeWorkerUtility.SwampNoiseCheck(Globals.SwampPerlin, coordinates)){
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
                            else if(validTemperateMonths >= 4){
                                tile.PrimaryBiome = BiomeDefs.Continental;

                                break;
                            }
                            else if(validTemperateMonths >= 1){
                                tile.PrimaryBiome = BiomeDefs.Subarctic;

                                break;
                            }
                            else if(validMonths >= 1){
                                tile.PrimaryBiome = BiomeDefs.RBTundra;

                                break;
                            }
                            tile.PrimaryBiome = BiomeDefs.IceCapLand;

                            break;       
                    }
                });
            }
            else{
                layer.Tiles.ForEach(x => {
                    if(x.PrimaryBiome.defName == "SeaIce"){
                        x.PrimaryBiome = ocean;
                    }
                });
            }
        }
    }
}