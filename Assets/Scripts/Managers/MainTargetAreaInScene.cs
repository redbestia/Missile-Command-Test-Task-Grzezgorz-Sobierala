using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class MainTargetAreaInScene : MonoBehaviour
    {
        [SerializeField] private Transform mainTargetArea;
        public static Transform MainTargetAreaStatic { get => secureMainTargetAreaStatic(); }
        private static Transform mainTargetAreaStatic;
        private void Awake()
        {
            if (mainTargetArea == null)
            {
                Debug.LogError("Set main target area in this scene");
                return;
            }

            mainTargetAreaStatic = mainTargetArea;
        }

        static Transform secureMainTargetAreaStatic()
        {
            if(mainTargetAreaStatic == null)
            {
                Debug.LogError("Set main target area in this scene. To do this use this script.");
                return null;
            }
            return mainTargetAreaStatic;
        }
    }
}