using RimWorld.Planet;
using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    class HotDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
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
            else{
                return 100f;
            }
        }
    }
    class ColdDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){

            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Arid){
                return 0f;
            }
            else if(tile.temperature > 18){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
    class HotSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
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
            else{
                return 100f;
            }
        }
    }
    class ColdSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Semiarid){
                return 0f;
            }
            else if(tile.temperature > 18){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
}