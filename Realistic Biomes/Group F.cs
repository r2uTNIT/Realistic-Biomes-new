using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    class Tundra : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(tile.temperature > -15.1 || tile.temperature < -26.6){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
    class IceCapLand : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(tile.temperature > -26.6){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
    class IceCapSea : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(!tile.WaterCovered){
                return 0f;
            }
            else if(tile.temperature > -26.6){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
}