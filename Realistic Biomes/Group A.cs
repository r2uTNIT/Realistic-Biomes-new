using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    class TropicalWet : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(tile.WaterCovered){
                return 0f;
            }
            else if(tile.temperature < 25){
                return 0f;
            }
            else if(tile.rainfall >= 2000){
                return 0f;
            }
            else if(
                DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet
            ){
                return 0f;
            }
            else if(tile.swampiness >= 0.75f){
                return 0f;
            }
            return 100f;
        }
    }
	class TropicalWetRainforest : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
			if(tile.WaterCovered){
                return 0f;
            }
            else if(tile.temperature < 25){
                return 0f;
            }
            else if(tile.rainfall < 2000){
                return 0f;
            }
            else if(
                DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet
            ){
                return 0f;
            }
            else if(tile.swampiness >= 0.75f){
                return 0f;
            }
            return 100f;
		}
    }
	class TropicalWetSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(tile.WaterCovered){
                return 0f;
            }
            else if(tile.temperature < 25){
                return 0f;
            }
            else if(
                DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet
            ){
                return 0f;
            }
            else if(tile.swampiness < 0.75f){
                return 0f;
            }
            return 100f;
		}
	}
}