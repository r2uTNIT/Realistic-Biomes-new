using RimWorld;
using RimWorld.Planet;
using System.Linq;

namespace RimworldPlusPlus.RealisticBiomes{
    internal class HumidSubtropical : BiomeWorker{
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

            if(validMonths >= 8){
                return 100f;
            }
            return 0f;
        }
    }
	internal class HumidSubtropicalSwamp : BiomeWorker{
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

            if(validMonths >= 8){
                return 100f;
            }
            return 0f;
		}
	}
}