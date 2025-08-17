namespace RimworldPlusPlus.RealisticBiomes{
    internal static class DrynessUtility{
        public static Dryness IsDry(float temp, float rainfall){
            if(rainfall < 20 * temp){
                return Dryness.Arid;
            }
            else if(rainfall < 20 * temp * 2){
                return Dryness.Semiarid;
            }
            return Dryness.Wet;
        }
    }
}