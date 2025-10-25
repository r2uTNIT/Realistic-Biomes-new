using HarmonyLib;
using Verse;
using UnityEngine;
using RimworldPlusPlus.RealisticBiomes;

namespace RimworldPlusPlus{
    class RimworldPlusPlus : Mod{
        public readonly RimworldPlusPlusSettings settings;

        public RimworldPlusPlus(ModContentPack content) : base(content){
            settings = GetSettings<RimworldPlusPlusSettings>();

            Harmony harmony = new("Rimworld++");
            harmony.PatchCategory("Realistic Biomes");
        }
        public override string SettingsCategory(){
            return "Realistic Biomes";
        }
        public override void DoSettingsWindowContents(Rect inRect){
            Listing_Standard listingStandard = new();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled(
                "Extra Realistic Biome Generation", 
                ref settings.extraRealisticBiomePlacement, 
                @"Makes biome placement be based on average monthly (twelfthy) temperature, rather than average yearly temperature. 
                    This is more realistic, but also significantly increases world generation time.", 
                0
            );
            listingStandard.Gap(8f);
            listingStandard.Label("Sea Level");

            if(listingStandard.RadioButton("Very dry", settings.seaLevel == SeaLevel.VeryDry, 16f)){
                settings.seaLevel = SeaLevel.VeryDry;
            }
            else if(listingStandard.RadioButton("Dry", settings.seaLevel == SeaLevel.Dry, 16f)){
                settings.seaLevel = SeaLevel.Dry;
            }
            else if(listingStandard.RadioButton("Vanilla", settings.seaLevel == SeaLevel.Vanilla, 16f)){
                settings.seaLevel = SeaLevel.Vanilla;
            }
            else if(listingStandard.RadioButton("Earthlike", settings.seaLevel == SeaLevel.Earthlike, 16f)){
                settings.seaLevel = SeaLevel.Earthlike;
            }
            else if(listingStandard.RadioButton("Islands", settings.seaLevel == SeaLevel.Islands, 16f)){
                settings.seaLevel = SeaLevel.Islands;
            }
            else if(listingStandard.RadioButton("Waterworld", settings.seaLevel == SeaLevel.Waterworld, 16f)){
                settings.seaLevel = SeaLevel.Waterworld;
            }
            listingStandard.End();
        }
    }
}