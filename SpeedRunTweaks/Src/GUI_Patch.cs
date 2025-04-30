using System;
using System.Collections.Generic;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace SpeedRunTweaks;

public class GUI_Patch
{
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.OnWorldNew))]
    public static class FejdStartup_OnWorldNew_Patch
    {
        public static void Postfix(FejdStartup __instance)
        {
            GameObject panel = __instance.m_createWorldPanel.transform.GetChild(0).gameObject;
            GameObject seedField = panel.transform.GetChild(3).gameObject;
            GameObject textArea = seedField.transform.GetChild(0).gameObject;
            GameObject text = textArea.transform.GetChild(2).gameObject;
            TextMeshProUGUI textMeshProUGUI = text.GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.fontSize = 0;
        }
    }
    
    [HarmonyPatch(typeof(FejdStartup), nameof(FejdStartup.UpdateWorldList))]
    public static class FejdStartup_UpdateWorldList_Patch
    {
        public static void Postfix(FejdStartup __instance)
        {
            RectTransform worldListRoot = __instance.m_worldListRoot;
            
            for (int i = 0; i < worldListRoot.childCount; i++)
            {
                GameObject worldElement = worldListRoot.GetChild(i).gameObject;
                GameObject seed = worldElement.transform.GetChild(4).gameObject;
                seed.SetActive(false);
            }
        }
    }
}