using System;
using HarmonyLib;

namespace SpeedRunTweaks;

public class Terminal_Patch
{
    [HarmonyPatch(typeof(Terminal), nameof(Terminal.InitTerminal))]
    public static class Terminal_InitTerminal_Patch
    {
        public static void Postfix(Terminal __instance)
        {
            Terminal.commands["printseeds"] = new Terminal.ConsoleCommand(
                "printseeds",
                "print seeds of loaded dungeons without seed values",
                (Terminal.ConsoleEventFailable)(args =>
                {
                    if ((UnityEngine.Object)Player.m_localPlayer == (UnityEngine.Object)null)
                        return (object)false;
                    
                    double num = (double) Math.Min(20f, args.TryParameterFloat(1, 5f));
                    UnityEngine.Object[] objectsOfType = UnityEngine.Object.FindObjectsOfType(typeof (DungeonGenerator));
                
                    foreach (DungeonGenerator dungeonGenerator in objectsOfType)
                        args.Context.AddString(string.Format("  {0}: Seed: {1}/{2}, Distance: {3}", (object) dungeonGenerator.name, (object) dungeonGenerator.m_generatedSeed, (object) dungeonGenerator.GetSeed(), (object) Utils.DistanceXZ(Player.m_localPlayer.transform.position, dungeonGenerator.transform.position).ToString("0.0")));
                    
                    return (object) true;
            }));
        }
    }

}