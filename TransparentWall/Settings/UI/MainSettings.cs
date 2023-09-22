using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Util;

namespace TransparentWall.Settings.UI
{
    internal class MainSettings : PersistentSingleton<MainSettings>
    {
        [UIValue("enable-in-hmd")]
        public bool EnableForHeadset
        {
            get => Configuration.EnableForHeadset;
            set => Configuration.EnableForHeadset = value;
        }

        [UIValue("disable-in-liv")]
        public bool DisableForLivCamera
        {
            get => Configuration.DisableForLivCamera;
            set => Configuration.DisableForLivCamera = value;
        }
    }
}
