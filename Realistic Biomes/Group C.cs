using RimWorld;
using RimWorld.Planet;
using System.Linq;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class HumidSubtropical : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            return 0;
        }
    }
	internal class HumidSubtropicalSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
			return 0;
		}
	}
}