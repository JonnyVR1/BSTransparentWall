using Hive.Versioning;
using IPA;
using IPA.Config;
using IPA.Loader;
using TransparentWall.Gameplay;
using TransparentWall.HarmonyPatches;
using TransparentWall.Settings;
using TransparentWall.Settings.UI;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace TransparentWall
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public static string PluginName => "TransparentWall";
        public static Version PluginVersion { get; private set; } = new Version("0.0.0");

        [Init]
        public void Init(IPALogger logger, Config config, PluginMetadata metadata)
        {
            Logger.Log = logger;
            Configuration.Init(config);

            if (metadata?.HVersion != null)
            {
                PluginVersion = metadata.HVersion;
            }
        }

        [OnEnable]
        public void OnEnable() => Load();

        [OnDisable]
        public void OnDisable() => Unload();

        public void OnGameSceneLoaded()
        {
            new GameObject(PluginName).AddComponent<TransparentWalls>();
        }

        private void Load()
        {
            Configuration.Load();
            TransparentWallPatches.ApplyHarmonyPatches();
            SettingsUI.CreateMenu();
            AddEvents();

            Logger.Log.Info($"{PluginName} v.{PluginVersion} has started.");
        }

        private void Unload()
        {
            RemoveEvents();
            TransparentWallPatches.RemoveHarmonyPatches();
            Configuration.Save();
            SettingsUI.RemoveMenu();
        }

        private void AddEvents()
        {
            RemoveEvents();
            BS_Utils.Utilities.BSEvents.gameSceneLoaded += OnGameSceneLoaded;
        }

        private void RemoveEvents()
        {
            BS_Utils.Utilities.BSEvents.gameSceneLoaded -= OnGameSceneLoaded;
        }
    }
}
