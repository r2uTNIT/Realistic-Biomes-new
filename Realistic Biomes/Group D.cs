using RimWorld;
using RimWorld.Planet;
using System.Linq;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class Continental : BiomeWorker{
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
            int validMonths = BiomeWorkerUtility.DoMonthlyTemps(tile)
                .Count((x) => {return x > 10;});

            if(validMonths >= 4 && tile.rainfall >= 100){
                return 100f;
            }
            return 0f;
        }
    }
	internal class ContinentalSwamp : BiomeWorker{
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
                .Count((x) => {return x > 10;});

            if(validMonths >= 4){
                return 100f;
            }
            return 0f;
		}
	}
}