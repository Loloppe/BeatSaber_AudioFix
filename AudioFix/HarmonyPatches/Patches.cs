/*using HarmonyLib;
using UnityEngine;
using static AudioTimeSyncController;

namespace AudioFix.HarmonyPatches
{
    [HarmonyPatch(typeof(AudioTimeSyncController), nameof(AudioTimeSyncController.Update))]
    static class Audio
    {
        static void Prefix(AudioTimeSyncController __instance)
        {
            int timeSamples = __instance._audioSource.timeSamples;
            float time = __instance._audioSource.time;
            float num2 = __instance.timeSinceStart - __instance._audioStartTimeOffsetSinceStart;
            float num3 = Mathf.Abs(num2 - time);
            if ((num3 > __instance._forcedSyncDeltaTime || __instance._state == State.Paused))
            {
                Plugin.Log.Warn("Sync issue: " + num3.ToString() + " > " + __instance._forcedSyncDeltaTime.ToString());
            }
        }
    }
}
*/