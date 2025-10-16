using RimWorld;
using RimWorld.Planet;
using UnityEngine;

namespace RimworldPlusPlus.RealisticBiomes{
    class Continental : BiomeWorker{
        public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
            Vector3 coordinates = tile.Layer.GetTileCenter(planetTile);

            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(BiomeWorkerUtility.SwampNoiseCheck(Globals.SwampPerlin, coordinates)){
                return 0f;
            }
            else if(tile.temperature > 15.3 || tile.temperature < -6.3){
                return 0f;
            }
            else{
                return 100f;
            }
        }
    }
	class ContinentalSwamp : BiomeWorker{
		public override float GetScore(BiomeDef biome, Tile tile, PlanetTile planetTile){
			Vector3 coordinates = tile.Layer.GetTileCenter(planetTile);

            if(Globals.settings.extraRealisticBiomePlacement){
                return 0f;
            }
            else if(tile.WaterCovered){
                return 0f;
            }
            else if(DrynessUtility.IsDry(tile.temperature, tile.rainfall) != Dryness.Wet){
                return 0f;
            }
            else if(!BiomeWorkerUtility.SwampNoiseCheck(Globals.SwampPerlin, coordinates)){
                return 0f;
            }
            else if(tile.temperature > 15.3 || tile.temperature < -6.3){
                return 0f;
            }
            else{
                return 100f;
            }
		}
	}
}