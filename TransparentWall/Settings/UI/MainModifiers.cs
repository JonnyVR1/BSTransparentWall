using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Util;

namespace TransparentWall.Settings.UI
{
    class MainModifiers : NotifiableSingleton<MainModifiers>
    {
        [UIValue("enable-headset")]
        public bool IsEnableForHeadset
        {
            get => Configuration.EnableForHeadset;
            set => Configuration.EnableForHeadset = value;
        }

        [UIValue("disable-liv")]
        public bool IsDisableForLiv
        {
            get => Configuration.DisableForLivCamera;
            set => Configuration.DisableForLivCamera = value;
        }

        [UIAction("trigger-headset-toggle")]
        public void TriggerHeadsetEnable(bool val) => IsEnableForHeadset = val;

        [UIAction("trigger-liv-toggle")]
        public void TriggerLivDisable(bool val) => IsDisableForLiv = val;
    }
}
