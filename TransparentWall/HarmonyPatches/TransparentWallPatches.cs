using HarmonyLib;
using System.Reflection;

namespace TransparentWall.HarmonyPatches
{
    /// <summary>
    /// Apply and remove all of our Harmony patches through this class
    /// </summary>
    public static class TransparentWallPatches
    {
        private static Harmony _instance;
        private static bool IsPatched { get; set; }
        private const string InstanceId = "com.pespiri.beatsaber.transparentwalls";

        internal static void ApplyHarmonyPatches()
        {
            if (IsPatched) return;
            if (_instance == null)
            {
                _instance = new Harmony(InstanceId);
            }

            _instance.PatchAll(Assembly.GetExecutingAssembly());
            IsPatched = true;
        }

        internal static void RemoveHarmonyPatches()
        {
            if (_instance == null || !IsPatched) return;

            _instance.UnpatchSelf();
            IsPatched = false;
        }
    }
}
