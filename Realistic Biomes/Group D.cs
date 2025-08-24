using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class Continental : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
	internal class ContinentalSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
			return 0;
		}
	}
}