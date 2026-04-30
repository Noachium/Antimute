using BepInEx;
using HarmonyLib;

namespace antimute
{
    [BepInPlugin("com.cosmic.antimute", "antimute", "1.0.0")]
    public class main : BaseUnityPlugin
    {
        private void Awake()
        {
            new Harmony("cosmic.antimute").PatchAll();
        }

        [HarmonyPatch(typeof(GorillaTelemetry))]
        public static class ggwptelemetrypatch
        {
            //ty to foaa mod (fuck off another axiom mod) for this method which blocks telemetry data from this single method, it was involved with ggwp in gtag assembly so here we are
            [HarmonyPatch(nameof(GorillaTelemetry.PostNotificationEvent)), HarmonyPrefix]
            public static bool ggwptelemetry() => false;
        }

        [HarmonyPatch(typeof(GorillaMetaReport))]
        public static class ggwpmoderationpatch
        {
            [HarmonyPatch("OnMuteSanction"), HarmonyPrefix]
            public static bool automute() => false;

            [HarmonyPatch("OnWarning"), HarmonyPrefix]
            public static bool autowarning() => false;
        }
    }
}