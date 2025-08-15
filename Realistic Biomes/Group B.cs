using RimWorld.Planet;
using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    class HotDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0f;
        }
    }
    class ColdDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0f;
        }
    }
    class HotSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0f;
        }
    }
    class ColdSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0f;
        }
    }
}