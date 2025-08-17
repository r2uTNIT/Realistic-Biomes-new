using System.Linq;
using RimWorld;
using RimWorld.Planet;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class TropicalWet : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(tile.swampiness >= 0.75f){
                return 0f;
            }
            else if(tile.rainfall >= 2000){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 18;});

            if(validMonths != 12){
                return 0f;
            }
            return 100f;
        }
    }
	internal class TropicalWetRainforest : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(tile.swampiness >= 0.75f){
                return 0f;
            }
            else if(tile.rainfall < 2000){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 18;});

            if(validMonths != 12){
                return 0f;
            }
            return 100f;
		}
    }
	internal class TropicalWetSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            if(!RimworldPlusPlus.settings.realisticBiomes){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(tile.swampiness < 0.75f){
                return 0f;
            }
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 18;});

            if(validMonths != 12){
                return 0f;
            }
            return 100f;
		}
	}
}