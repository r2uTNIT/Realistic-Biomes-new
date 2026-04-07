using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    class HumidSubtropical : BiomeWorker{
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
            else if(tile.swampiness >= 0.5){
                return 0f;
            }
            else if(tile.temperature > 22 || tile.temperature < 15.3){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
	class HumidSubtropicalSwamp : BiomeWorker{
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
            else if(tile.swampiness < 0.5){
                return 0f;
            }
            else if(tile.temperature > 22 || tile.temperature < 15.3){
                return 0f;
            }
            else{
                return 100f;
            }
		}
	}
}