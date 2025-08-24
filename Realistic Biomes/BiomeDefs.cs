using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    [DefOf]
    internal static class BiomeDefs{
        public static BiomeDef TropicalWetRainforest;
        public static BiomeDef TropicalWet;
        public static BiomeDef TropicalSwamp;

        public static BiomeDef HotDesert;
        public static BiomeDef ColdDesert;
        public static BiomeDef HotSteppe;
        public static BiomeDef ColdSteppe;

        public static BiomeDef HumidSubtropical;
        public static BiomeDef HumidSubtropicalSwamp;

        public static BiomeDef Continental;
        public static BiomeDef ContinentalSwamp;

        public static BiomeDef Subarctic;
        public static BiomeDef SubarcticSwamp;

        public static BiomeDef RBTundra;
        public static BiomeDef IceCapLand;
        public static BiomeDef IceCapSea;

        static BiomeDefs(){
            DefOfHelper.EnsureInitializedInCtor(
                typeof(BiomeDefs)
            );
        }
    }
}