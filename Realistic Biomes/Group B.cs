using RimWorld.Planet;
using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class HotDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Arid){
                return 0f;
            }
            else if(tile.temperature < 18){
                return 0f;
            }
            return 100f;
        }
    }
    internal class ColdDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Arid){
                return 0f;
            }
            else if(tile.temperature >= 18){
                return 0f;
            }
            return 100f;
        }
    }
    internal class HotSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Semiarid){
                return 0f;
            }
            else if(tile.temperature < 18){
                return 0f;
            }
            return 100f;
        }
    }
    internal class ColdSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Semiarid){
                return 0f;
            }
            else if(tile.temperature >= 18){
                return 0f;
            }
            return 100f;
        }
    }
}