using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MissileCommand
{
    public abstract class LaunchableGameObjectStrategy : ScriptableObject
    {
        [SerializeField,Tooltip("This Game Object need LanchableGameObject Component")] 
        protected GameObject gameObjectToLunch;

        public abstract void Launch(Vector3 startPosition, Quaternion startRotation,
                Vector3 endPosition, float speed, Transform newParent);

    }
}