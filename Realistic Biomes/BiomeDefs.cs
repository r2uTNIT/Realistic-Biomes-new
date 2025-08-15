using RimWorld;


// TODO: Change to use DefDataBase
namespace RimworldPlusPlus.RealisticBiomes{
    [DefOf]
    static class BiomeDefs{
        public static BiomeDef TropicalWet;
        public static BiomeDef TropicalWetRainforest;
        public static BiomeDef TropicalWetSwamp;

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
            DefOfHelper.EnsureInitializedInCtor(typeof(BiomeDefs));
        }
    }
}