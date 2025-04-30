using System;
using HarmonyLib;

namespace SpeedRunTweaks;

public class GUI_Patch
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.OnWorldNew))]
    public static class FejdStartup_OnWorldNew_Patch
    {
        public static void Postfix(FejdStartup __instance)
        {
            __instance.m_newWorldSeed.text = "XXXXXX";
        }
    }
}