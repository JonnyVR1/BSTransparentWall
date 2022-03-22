using System;
using System.Collections.Generic;
using System.Linq;
using TransparentWall.Settings;
using UnityEngine;

namespace TransparentWall.Gameplay.Modifications
{
    public class LivWalls : MonoBehaviour
    {
        private static readonly IEnumerable<string> LivNames = new List<string> { "MenuMainCamera", "MainCamera", "LIV Camera", "LIV" };
        private static readonly List<int> LayersToMask = new List<int> { Configuration.WallLayerMask, Configuration.MoveBackLayer };

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public IEnumerator<WaitForEndOfFrame> ApplyGameCoreModifications()
        {
            yield return new WaitForEndOfFrame();

            try
            {
                FindObjectsOfType<LIV.SDK.Unity.LIV>().Where(x => LivNames.Contains(x.name)).ToList().ForEach(l =>
                {
                    LayersToMask.ForEach(i =>
                    {
                        l.spectatorLayerMask|= 1 << i;
                    });
                });
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }
    }
}
