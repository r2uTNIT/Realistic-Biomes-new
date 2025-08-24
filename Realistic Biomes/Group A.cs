using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class TropicalWet : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
	internal class TropicalWetRainforest : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
		}
    }
	internal class TropicalWetSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
		}
	}
}