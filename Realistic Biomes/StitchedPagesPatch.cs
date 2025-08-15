using HarmonyLib;
using RimWorld;

namespace RimworldPlusPlus.RealisticBiomes{
    [HarmonyPatch(typeof(PageUtility), "StitchedPages")]
    [HarmonyPatchCategory("Realistic Biomes")]
    static class StitchedPagesPatch{
        static void Postfix(ref Page __result){
            if(__result == null){
				return;
			}
			if(TutorSystem.TutorialMode){
				return;
			}
			Page _Result = __result;
			
            while(true){
				Page page = _Result.next;
				
                if(page == null){
					break;
				}
				if(!(page is RimWorld.Page_CreateWorldParams)){
					_Result = page;
				}
				else{
					Page page1 = page.next;
					Page page2 = page.prev;
					
                    Page_CreateWorldParams createWorldParam = new Page_CreateWorldParams();
					page2.next = createWorldParam;
					page1.prev = createWorldParam;
					createWorldParam.prev = page2;
					createWorldParam.next = page1;
					
                    break;
				}
			}
        }
    }
}