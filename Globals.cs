using Verse.Noise;
using Verse;

namespace RimworldPlusPlus{
    static class Globals{
        public const double PerlinFrequency = 0.1;
        public const double PerlinLacunarity = 10;
        public const double PerlinPersistence = 0.6;
        
        public const int PerlinOctaves = 12;

        public static Perlin SwampPerlin = new Perlin(PerlinFrequency, PerlinLacunarity, PerlinPersistence, PerlinOctaves, Find.World.info.Seed, QualityMode.Low);

        public static RimworldPlusPlusSettings settings = LoadedModManager.GetMod<RimworldPlusPlus>().settings;
    }
}