using RimWorld.Planet;
using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class HotDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
    internal class ColdDesert : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
    internal class HotSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
    internal class ColdSteppe : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
}