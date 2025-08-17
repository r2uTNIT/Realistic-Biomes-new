using RimWorld;
using RimWorld.Planet;
using System.Linq;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class Tundra : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 0;});

            int validTemperateMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 10;});

            if(validMonths >= 1 || validTemperateMonths >= 1 && tile.rainfall < 100){
                return 100f;
            }
            return 0f;
        }
    }
    internal class IceCapLand : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 0;});

            if(validMonths != 0){
                return 0f;
            }
            return 100f;
        }
    }
    internal class IceCapSea : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(!tile.WaterCovered){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 0;});
            
            if(validMonths != 0){
                return 0f;
            }
            return 100f;
        }
    }
}