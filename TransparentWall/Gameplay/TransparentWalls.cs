using System.Diagnostics.CodeAnalysis;
using System.Linq;
using TransparentWall.Gameplay.Modifications;
using TransparentWall.Settings;
using UnityEngine;

namespace TransparentWall.Gameplay
{
    public class TransparentWalls : MonoBehaviour
    {
        private LivWalls _livWalls;

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity calls this")]
        private void Start()
        {
            if (Resources.FindObjectsOfTypeAll<MoveBackWall>().Any())
            {
                Configuration.MoveBackLayer = Resources.FindObjectsOfTypeAll<MoveBackWall>().First().gameObject.layer;
            }

            _livWalls = gameObject.AddComponent<LivWalls>();
            StartCoroutine(_livWalls.ApplyGameCoreModifications());
        }

        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Unity calls this")]
        private void OnDestroy()
        {
            _livWalls = null;
        }
    }
}
