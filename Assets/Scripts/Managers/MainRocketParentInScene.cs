using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public class MainRocketParentInScene : MonoBehaviour
    {
        [SerializeField] private Transform mainRocketParent;
        public static Transform MainRocketParentStatic { get => secureMainTargetAreaStatic(); }
        private static Transform mainRocketParentStatic;
        private void Awake()
        {
            if (mainRocketParent == null)
            {
                Debug.LogError("Set main rocket parent in this scene");
                return;
            }

            mainRocketParentStatic = mainRocketParent;
        }

        static Transform secureMainTargetAreaStatic()
        {
            if (mainRocketParentStatic == null)
            {
                Debug.LogError("Set main rocket parent in this scene. To do this use this script.");
                return null;
            }
            return mainRocketParentStatic;
        }
    }
}