using System.Collections.Generic;
using RimWorld.Planet;
using HarmonyLib;
using Verse;
using RimWorld;

//namespace RimworldPlusPlus.RealisticBiomes{
    /*Average twelfthy (monthly) temperature of a tile can't be accessed until after the world is finished generating for some reason... so instead I let the world generate normally
    without any custom biomeworkers & just change the biomedefs of the already-generated tiles in a postfix patch. It's really fucking slow, but it works*/
    /*[HarmonyPatch(typeof(WorldGenStep_Terrain), "GenerateGridIntoWorld")]
    [HarmonyPatchCategory("Realistic Biomes")]
    static class GenerateGridIntoWorldPatch{
        public static Dictionary<int, float[]> tiles = new Dictionary<int, float[]>();

        public static WorldGrid worldGrid;

        public static void Postfix(){
            worldGrid = Find.WorldGrid;

            for(int i = 0; i < worldGrid.TilesCount; ++i){
                float[] monthlyTemps = new float[12];

                for(short j = 0; j < 12; ++j){
                    monthlyTemps[j] = GenTemperature.AverageTemperatureAtTileForTwelfth(i, (Twelfth)j);
                }
                tiles.Add(i, monthlyTemps);
            }
            foreach(int tileId in tiles.Keys){
                Tile tile = worldGrid[tileId];

                if(!tile.WaterCovered){
                    switch(DrynessUtility.IsDry(tile.temperature, tile.rainfall)){
                        case Dryness.Wet: 
                            if(tile.swampiness >= 0.75){
                                SwampCheck(tiles[tileId], tile);
                                
                                continue;    
                            }
                            else{
                                WetCheck(tiles[tileId], tile);

                                continue;
                            }
                        case Dryness.Semiarid: 
                            if(tile.temperature > 18){
                                tile.biome = BiomeDefs.HotSteppe;

                                continue;
                            }
                            else{
                                tile.biome = BiomeDefs.ColdSteppe;

                                continue;
                            }
                        case Dryness.Arid:
                            if(tile.temperature > 18){
                                tile.biome = BiomeDefs.HotDesert;

                                continue;
                            }
                            else{
                                tile.biome = BiomeDefs.ColdDesert;

                                continue;
                            }
                    }
                }
                else{SeaCheck(tiles[tileId], tile);}
            }
            tiles.Clear();
        }
        public static void SeaCheck(IEnumerable<float> temps, Tile tile){
            foreach(float temp in temps){
                if(temp > 0){return;}
            }
            tile.biome = BiomeDefs.IceCapSea;
        }
        public static void WetCheck(IEnumerable<float> temps, Tile tile){
            short validMonths = 0;
            short validTropicalMonths = 0;
            short validTemperateMonths = 0;

            foreach(float temp in temps){
                if(temp > 18){++validTropicalMonths;}
                if(temp > 10){++validTemperateMonths;}
                if(temp > 0){++validMonths;}
            }
            if(validTropicalMonths == 12 && tile.rainfall >= 2000){
                tile.biome = BiomeDefs.TropicalWetRainforest;

                return;
            }
            else if(validTropicalMonths == 12){
                tile.biome = BiomeDefs.TropicalWet;

                return;
            }
            else if(validTemperateMonths >= 8){
                tile.biome = BiomeDefs.HumidSubtropical;

                return;
            }
            else if(validTemperateMonths >= 4 && tile.rainfall >= 100){
                tile.biome = BiomeDefs.Continental;

                return;
            }
            else if(validTemperateMonths >= 1 && tile.rainfall >= 100){
                tile.biome = BiomeDefs.Subarctic;

                return;
            }
            else if(validMonths >= 1 || validTemperateMonths >= 1 && tile.rainfall < 100){
                tile.biome = BiomeDefs.RBTundra;

                return;
            }
            else{
                tile.biome = BiomeDefs.IceCapLand;

                return;
            }
        }
        public static void SwampCheck(IEnumerable<float> temps, Tile tile){
            short validMonths = 0;
            short validTropicalMonths = 0;

            foreach(float temp in temps){
                if(temp > 18){++validTropicalMonths;}
                if(temp > 10){++validMonths;}
            }
            if(validTropicalMonths == 12){
                tile.biome = BiomeDefs.TropicalWetSwamp;
                
                return;
            }
            else if(validMonths >= 8){
                tile.biome = BiomeDefs.HumidSubtropicalSwamp;
            
                return;
            }
            else if(validMonths >= 4){
                tile.biome = BiomeDefs.ContinentalSwamp;
                
                return;    
            }
            else if(validMonths >= 1){
                tile.biome = BiomeDefs.SubarcticSwamp;
                
                return;    
            }
        }
    }
}*/