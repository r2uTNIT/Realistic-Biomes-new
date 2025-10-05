namespace RimworldPlusPlus.RealisticBiomes{
    static class DrynessUtility{
        public static Dryness IsDry(float temp, float rainfall){
            float threshold = 13.75f * temp + 50;

            if(rainfall < threshold){
                return Dryness.Arid;
            }
            else if(rainfall < threshold * 2){
                return Dryness.Semiarid;
            }
            return Dryness.Wet;
        }
    }
}